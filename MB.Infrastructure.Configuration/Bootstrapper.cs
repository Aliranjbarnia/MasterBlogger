using MB.Application;
using MB.ApplicationContract.Article;
using MB.ApplicationContract.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EfCore.Repositories;
using MB.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.EfCore.Configuration
{
    public class Bootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            //ArticleCategory
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

            //Article
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleQuery, ArticleQuery>();


            services.AddDbContext<ArticleContext>(x => x.UseSqlServer(connectionString));
        }

    }
}
