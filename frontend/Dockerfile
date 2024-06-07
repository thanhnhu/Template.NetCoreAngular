FROM node:18.12.0-alpine as builder

RUN mkdir /app
COPY . /app
WORKDIR /app

RUN npm cache clean --force && npm install
COPY . .
RUN $(npm bin)/ng build

FROM builder as development
CMD $(npm bin)/ng serve --host 0.0.0.0 --port 8081

FROM nginx:1.16.1-alpine as production
COPY --from=builder /app/dist /usr/share/nginx/html
RUN rm /etc/nginx/conf.d/default.conf
COPY --from=builder /app/nginx.conf /etc/nginx/conf.d/

#EXPOSE 8081
CMD [ "nginx", "-g", "daemon off;"]