# DockerCLI Commands

## Network Creation

```css
docker network create my-network
```

## Build Commands

```bash
docker build -t products .
```

```bash
docker build -t carts .
```

```bash
docker build -t orders .
```

```bash
docker build -t gateway .
```

## Run Commands

```bash
docker run -d --name products --network my-network -p 5001:8080 -e ASPNETCORE_URLS=http://+:8080 products
```

```bash
docker run -d --name carts --network my-network -p 5002:8080 -e ASPNETCORE_URLS=http://+:8080 carts
```

```bash
docker run -d --name orders --network my-network -p 5003:8080 -e ASPNETCORE_URLS=http://+:8080 orders
```

```bash
docker run -d --name gateway --network my-network -p 5000:8080 -e ASPNETCORE_URLS=http://+:8080 gateway
```