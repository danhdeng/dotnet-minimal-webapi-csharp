# create the Mininmal API 
dotnet new webapi -minimal -n MininmalAPI

# solve the https certificate issue
dotnet dev-certs https trust

# install required packages
dotnet add package Microsoft.EntityFrameworkCore 
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

# generate the user secret for data access
dotnet user-secrets init

# output should be as following
Set UserSecretsId to 'bf8ab4bd-05ca-4035-be24-b7dc8e860b54' for MSBuild project 'E:\Code\dotnet\dotnet-mininal-webapi\MinimalAPI\MinimalAPI.csproj'.


# set the UserId generated from above command to be the SA

dotnet user-secrets set "UserId" "sa"

# output
λ dotnet user-secrets set "UserId" "sa"
Successfully saved UserId = sa to the secret store.

# set password matching with the one in docker-compose yaml file

dotnet user-secrets set "Password" "P@55w0rd!"

# output
λ dotnet user-secrets set "Password" "P@55w0rd!"
Successfully saved Password = P@$$w0rd to the secret store.

# prepare for the data migration
dotnet ef migrations add initialmigration

# apply the migrations to the database
dotnet ef database update
