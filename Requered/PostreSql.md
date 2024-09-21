# PostgreSql

## Docker Install And Run

```bash 
docker run --name postgres -e POSTGRES_PASSWORD=1 -e POSTGRES_DB=shoppingcartsdb -d -p 5432:5432 postgres
```

## Connection String

### Shopping Cart

#### Development

```bash 
Host=localhost;Port=5432;Database=shoppingcartsdb;Username=postgres;Password=1;
```

#### Production

```bash 
Host=host.docker.internal;Port=5432;Database=shoppingcartsdb;Username=postgres;Password=1;
```

### Gateway

#### Development

```bash 
Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=1;
```

#### Production

```bash 
Host=host.docker.internal;Port=5433;Database=usersdb;Username=postgres;Password=1;
```