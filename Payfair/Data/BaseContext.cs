using Microsoft.EntityFrameworkCore;
using Payfair.Models;

namespace Payfair.Data{
    public class BaseContext : DbContext{
        
    public DbSet<Usuario> Usuarios { get; set; }
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
        
    } 
    
    }
}