using Microsoft.EntityFrameworkCore;
using WebApi8.Models;

namespace WebApi8.Data
{
    public class AppDbContext : DbContext //herdando o dbcontext do entity
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }
}
