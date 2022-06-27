using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionStringBuilder=new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.ConnectionString=builder.Configuration.GetConnectionString("SQLDbConnection");
sqlConnectionStringBuilder.UserID=builder.Configuration["UserId"];
sqlConnectionStringBuilder.Password=builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnectionStringBuilder.ConnectionString));

builder.Services.AddScoped<ICommandRepo, CommandRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/commands", async (ICommandRepo repo, IMapper mapper)=>{
    var commands=await repo.GetAllCommands();
    return Results.Ok(mapper.Map<IEnumerable<Command>>(commands));
});

app.Run();