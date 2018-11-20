# csharpwebapi-examples


Execute on your project:

- dotnet add package Microsoft.Extensions.Configuration.UserSecrets
- dotnet add package Mysql.Data.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore.Design

Migrations:

- dotnet ef migrations add InitialCreate
- dotnet ef database update

Secrets to ConnectionStrings:

- dotnet user-secrets set ConnectionStrings.DbName "server=servername;port=3306;user=username;password=passwdOfUser;database=DbName" (Use the connection string of your connection provider, in this case: Mysql)

Using secrets on scaffold:

- dotnet ef dbcontext scaffold Name=ConnectionStrings.DbName Mysql.Data.EntityFrameworkCore -o Models -c ContextName.cs


