# MsSql

### Docker Install And Run

```bash
docker run -d -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Udemy#123" -e "MSSQL_PID=Evaluation" -p 1433:1433 --name sqlpreview --hostname  sqlpreview mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
```

### Production Connection String
```
Server=host.docker.internal,1433;Initial Catalog=MiniETicaretProductsDb;Persist Security Info=False;User ID=sa;Password=Udemy#123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection  Timeout=30;
```