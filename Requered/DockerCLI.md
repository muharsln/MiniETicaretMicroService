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