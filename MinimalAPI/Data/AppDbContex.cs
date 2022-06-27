using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MinimalAPI.Data;

public class AppDbContex: DbContext
{
    public AppDbContex(DbContextOptions<AppDbContex> options) : base(options){

    }

    public DbSet<Command> Commands => Set<Command>();
}