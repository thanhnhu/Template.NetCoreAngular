using Microsoft.AspNetCore.Http;

namespace Template.NetCore.Tests.UnitTests.Helpers
{
    public static class HttpContextHelper
    {
        public static HttpContext GetHttpContext()
        {
            var context = new DefaultHttpContext();
            context.Request.Scheme = "http";
            context.Request.Host = new HostString("my.HoΨst:80");
            context.Request.PathBase = new PathString("/un?escaped/base");
            context.Request.Path = new PathString("/un?escaped");
            context.Request.QueryString = new QueryString("?name=val%23ue");

            return context;
        }
    }
}
