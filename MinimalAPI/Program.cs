using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionStringBuilder=new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.ConnectionString=builder.Configuration.GetConnectionString("SQLDbConnection");
sqlConnectionStringBuilder.UserID=builder.Configuration["UserId"];
sqlConnectionStringBuilder.Password=builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnectionStringBuilder.ConnectionString));

builder.Services.AddScoped<ICommandRepo, CommandRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();