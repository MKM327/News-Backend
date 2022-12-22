using News_Backend.Models;

namespace News_Backend.Data_Access._News;

public interface INewsDal:IEFentityRepository<News>
{
    public new News? Add(News news);
    public News? DeleteWithId(int id);
}