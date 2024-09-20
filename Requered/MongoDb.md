# MongoDb

## Docker Install And Run

### Localhost

```bash 
docker run -d --name mongodb -p 27017:27017 -v mongodbdata:/data/db mongo
```

### For Container

```bash 
docker run -d --name mongodb --network my-network -p 27017:27017 -v mongodbdata:/data/db mongo
```