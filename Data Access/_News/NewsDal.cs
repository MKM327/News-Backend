using News_Backend.Context;
using News_Backend.Models;

namespace News_Backend.Data_Access._News;

public class NewsDal:EFentityRepository<News,NewsContext>,INewsDal
{
    public new News Add(News news)
    {
        using var context = new NewsContext();
       var category = context.Categories.SingleOrDefault(category => category.Id == news.CategoryId);
       if (category == null)
           return null;
       context.News.Add(news);
       context.SaveChanges();
       return news;
    }
}