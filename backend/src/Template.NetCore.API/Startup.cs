using Template.NetCore.API.Extensions;
using Template.NetCore.API.Extensions.Middleware;
using Template.NetCore.Application.Handlers;
using Template.NetCore.Application.Mappers;
using Template.NetCore.Application.Services;
using Template.NetCore.Domain.Books;
using Template.NetCore.Domain.Books.Commands;
using Template.NetCore.Domain.Books.Events;
using Template.NetCore.Infrastructure.Context;
using Template.NetCore.Infrastructure.Repositories;
using FluentMediator;
using Jaeger;
using Jaeger.Samplers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Util;
using Serilog;
using System.Linq;
using System.Reflection;

namespace Template.NetCore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "cors",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            services.AddControllers();

            services.AddApplicationDbContext(Configuration, Environment);

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddSingleton<BookViewModelMapper>();

            services.AddScoped<BookCommandHandler>();
            services.AddScoped<BookEventHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddFluentMediator(builder =>
            {
                builder.On<CreateNewBookCommand>().PipelineAsync().Return<Book, BookCommandHandler>((handler, request) => handler.HandleNewBook(request));
                builder.On<BookCreatedEvent>().PipelineAsync().Call<BookEventHandler>((handler, request) => handler.HandleBookCreatedEvent(request));

                builder.On<UpdateBookCommand>().PipelineAsync().Return<Book, BookCommandHandler>((handler, request) => handler.HandleUpdateBook(request));
                builder.On<BookUpdatedEvent>().PipelineAsync().Call<BookEventHandler>((handler, request) => handler.HandleBookUpdatedEvent(request));

                builder.On<DeleteBookCommand>().PipelineAsync().Call<BookCommandHandler>((handler, request) => handler.HandleDeleteBook(request));
                builder.On<BookDeletedEvent>().PipelineAsync().Call<BookEventHandler>((handler, request) => handler.HandleBookDeletedEvent(request));
            });

            services.AddSingleton(serviceProvider =>
            {
                var serviceName = Assembly.GetEntryAssembly().GetName().Name;

                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                ISampler sampler = new ConstSampler(true);

                ITracer tracer = new Tracer.Builder(serviceName)
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler)
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });

            Log.Logger = new LoggerConfiguration().CreateLogger();

            services.AddOpenTracing();

            services.AddOptions();

            services.AddMvc();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // this migration just for production testing
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<BookDbContext>();
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("cors");

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Books API V1");
            });
        }
    }
}
