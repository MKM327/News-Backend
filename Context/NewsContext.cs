using Microsoft.EntityFrameworkCore;
using News_Backend.Models;

namespace News_Backend.Context
{
    public class NewsContext:DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
