# Taller 2 - Despliegue (Docker, Kubernetes)

## Integrantes

- Juan David Gaviria Correa
- Ana Maria Valencia Quintero
- Juan David Osorio Zapata
- Fabian Jussep Rios Ferrer
- Johan Sneider Garzon Salazar

## Link De Video Youtube

[Ver en YouTube](https://youtu.be/mTeYAJ7OQU8)


## Comandos Docker

```
docker build -t commitm2:latest .

docker run -it --rm -p 8080:8080 commitm2:latest
```

Go to [localhost 8080](http://localhost:8080/swagger/index.html).

## Comandos Kubernetes

```
kubectl apply -f deployment.yaml

kubectl apply -f service.yaml

kubectl port-forward svc/commitm2-service 30080:8080
```

Go to [localhost 30080](http://localhost:30080/swagger/index.html).

## Comandos Utiles

```
kubectl get deployments
kubectl delete deployment commitm2-deployment

kubectl get pods

kubectl get svc
kubectl delete svc commitm2-service
```

## Evidencias

### Contenedor Docker Corriendo

![Contenedor](./evidencias/1-contenedor.jpeg)

### Imagen Creada

![Contenedor](./evidencias/2-imagen.jpeg)

### Swagger UI

![Contenedor](./evidencias/3-swagger.jpeg)

### Kubectl get pods y kubectl get svc  

![Contenedor](./evidencias/4-pods.jpeg)

### Navegador accediendo al servicio (Swagger)  

![Contenedor](./evidencias/5-swagger-kubernet.jpeg)

### YAML Deployment

![Contenedor](./evidencias/6-YAMLdeployment.jpeg)

### YAML Service

![Contenedor](./evidencias/7-YAMLservice.jpeg)

### Arbol Git Commits

![Contenedor](./evidencias/8-git.png)



