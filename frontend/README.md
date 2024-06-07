# template project: Books CRUD with Rest API

Book Application in that:
- Each Book has id, author, title, description.
- We can create, retrieve, update, delete Books.

Live demo: [https://template.azurewebsites.net](https://template.azurewebsites.net)

## Using nodejs version 18.12.0

Run `npm install` to install the dependencies first.

Run `ng serve --port 8081` for a dev server. Navigate to `http://localhost:8081/`. The app will automatically reload if you change any of the source files.
(In case you want to run on linux, use `ng serve --open --port 8081` instead)

Or you can run by docker
```yml
docker build -t frontend --target development .
docker run -it -p 8081:8081 frontend
```

## This is just for production deploy
```yml
docker build -t frontend --target production .
docker login templateregistry.azurecr.io --username templateregistry
docker tag frontend templateregistry.azurecr.io/frontend:latest
docker push templateregistry.azurecr.io/frontend:latest
```