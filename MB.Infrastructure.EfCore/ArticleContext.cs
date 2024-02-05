using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> option) : base(option){}

        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
