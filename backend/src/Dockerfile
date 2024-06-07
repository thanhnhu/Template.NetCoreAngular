#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Template.NetCore.API/Template.NetCore.API.csproj", "Template.NetCore.API/"]
RUN dotnet restore "Template.NetCore.API/Template.NetCore.API.csproj"
COPY . .
WORKDIR "/src/Template.NetCore.API"
RUN dotnet build "Template.NetCore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Template.NetCore.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.NetCore.API.dll"]