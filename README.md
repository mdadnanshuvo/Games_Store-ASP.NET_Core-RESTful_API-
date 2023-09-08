# Game Store API

## starting SQL Server
```powershell 
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433  -v sqlvolume:/var/opt/mssql --name sql --hostname sqlpreview -d --rm mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
```