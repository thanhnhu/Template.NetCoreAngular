# template-netcore-angular

<p align="center">
  <img src="images/logo.jpg" alt="template-netcore-angular logo" width="400"/>
</p>

A .NET/.NET Core template to use Onion Architecture and DDD (Domain Driven Design) with CQRS and ES with a simple example on how to use all this architecture together from the Controller until the Repository class using Domain objects and different patterns.

An Angular 16 template with simple CRUD.

### Prerequisites

#### .NET 6

- Ensure you have the correct dotnet-core SDK installed for your system:

https://dotnet.microsoft.com/download/dotnet/6.0

This is just the version used by the template, if you need to use a newer or older one, you can do it manually after.

- Ensure you have the GIT BASH installed for your system.

### Usage

1. Clone this repository
2. To allow the api to be created you will need to install the template using GIT BASH from where you cloned the repository:

```
bash template.sh -i {{Path_where_you_cloned_the_repository}}
```

- Example: run GIT BASH from /D/Working/Projects/Template.NetCoreAngular

```
bash template.sh -i ./
```

3. To check that the template has been installed successfully:

```
dotnet new -l
```

- There should now be a new template **Template.NetCore**

```
Templates                                          Short Name                 Language          Tags
----------------------------------------------------------------------------------------------------------
.NET Core 6.0 Template with CQRS, ES and DDD       Template.NetCore      [C#]              Web/API/Microservices
```

4. Create the .Net Core Solution

```
bash template.sh -g -n {{Namespace_of_your_project}} -o <outputFolder>
```

- Example:

```
bash template.sh -g -n sample -o /D/Working/Projects/Template.NetCoreAngular/sample
```

- This will create the folder containing a solution and project folder.
  ![](images/installation.jpg)

And you are ready to go, you can use Visual Studio, Visual Studio Code or any other IDE to proceed with your coding.

- In case you want to run the migration
```yml
dotnet ef migrations add InitialCreate --startup-project .\src\Template.NetCore.API\ --project .\src\Template.NetCore.Infrastructure\
dotnet ef database update --startup-project .\src\Template.NetCore.API\ --project .\src\Template.NetCore.Infrastructure\
```

Then you can run IIS Express with Visual Studio and navigate to `https://localhost:44366/swagger` to launch the API.

Or with dotnet CLI `dotnet run --project .\src\Template.NetCore.API\`, then navigate to `https://localhost:5001/swagger` to launch the API.
(In case you want to run on linux, use `dotnet run --project ./src/Template.NetCore.API/` instead)

## This is just for production deploy
```yml
cd src
docker build -t backend --target final .
#docker run -it -p 8080:80 backend
docker login templateregistry.azurecr.io --username templateregistry
docker tag backend templateregistry.azurecr.io/backend:latest
docker push templateregistry.azurecr.io/backend:latest
```
