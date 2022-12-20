using Microsoft.EntityFrameworkCore;
using News_Backend.Models;

namespace News_Backend.Context
{
    public class NewsContext:DbContext
    {
        public NewsContext(DbContextOptions options) :base(options){}
        public NewsContext(){}
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=News;Integrated Security=True;");
        }
    }
}
