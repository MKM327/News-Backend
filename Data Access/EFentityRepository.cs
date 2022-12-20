using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using News_Backend.Models;

namespace News_Backend.Data_Access;

public class EFentityRepository<TEntity,TContext>:IEFentityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{    

    public TEntity? Get(Expression<Func<TEntity, bool>> filter)
    {
        using var context = new TContext();
        return context.Set<TEntity>().SingleOrDefault(filter);
        
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
    {
        using var context = new TContext();
        var list = context.Set<TEntity>();

        if (filter != null)
        {
            return list.Where(filter).ToList();
        }

        return list.ToList();
    }

    public TEntity Add(TEntity entity)
    {
        using var context = new TContext();
        context.Set<TEntity>().Add(entity);
        context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        using var context = new TContext();
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        using var context = new TContext();
        context.Entry(entity).State = EntityState.Deleted;
        context.SaveChanges();
        return entity;
    }
}