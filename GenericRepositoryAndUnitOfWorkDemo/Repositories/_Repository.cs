using GenericRepositoryAndUnitOfWorkDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepositoryAndUnitOfWorkDemo.Repositories
{
    public interface IRepository<Entity> where Entity : class
    {
        DbSet<Entity> DbSet { get; }
        IEntityType EntityType { get; }
        Entity Add(Entity entity);
        IEnumerable<Entity> AddRange(IEnumerable<Entity> entities);
        int Count();
        int Count(Func<Entity, bool> predicate);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<Entity, bool>> predicate);
        Entity Find(params object[] id);
        Task<Entity> FindAsync(params object[] id);
        Entity FirstOrDefault();
        Entity FirstOrDefault(Func<Entity, bool> predicate);
        Task<Entity> FirstOrDefaultAsync();
        Task<Entity> FirstOrDefaultAsync(Expression<Func<Entity, bool>> predicate);
        IEnumerable<Entity> Get();
        IQueryable<Entity> GetAsNoTracking();
        Entity Remove(Entity entity);
        IEnumerable<Entity> RemoveRange(IEnumerable<Entity> entities);
        Entity Update(Entity entity);
        IEnumerable<Entity> Where(Func<Entity, bool> predicate);
        IOrderedEnumerable<Entity> OrderBy(Func<Entity, object> keySelector);
        IOrderedEnumerable<Entity> OrderByDescending(Func<Entity, object> keySelector);
        IQueryable<Entity> AsQueryable();
        IQueryable<TResult> Select<TResult>(Expression<Func<Entity, TResult>> expression);
        IQueryable<Entity> Query(Expression<Func<Entity, bool>> predicate);
        decimal? Min(Func<Entity, decimal?> selector);
        decimal? Max(Func<Entity, decimal?> selector);
        bool Any();
        bool Any(Expression<Func<Entity, bool>> expression);
        IUnitOfWork UOW { get; }
    }

    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly DbContext db;
        public IUnitOfWork UOW { get; }

        public Repository(DbContext db, IUnitOfWork uow)
        {
            this.db = db;
            this.UOW = uow;
        }

        public DbSet<Entity> DbSet => db.Set<Entity>();

        public IQueryable<Entity> Query(Expression<Func<Entity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IEntityType EntityType => db.Model.FindEntityType(typeof(Entity));

        public virtual IQueryable<Entity> AsQueryable()
        {
            return DbSet.AsQueryable();
        }

        public virtual IEnumerable<Entity> Get()
        {
            return DbSet;
        }

        public decimal? Min(Func<Entity, decimal?> selector)
        {
            return DbSet.Min(selector);
        }

        public decimal? Max(Func<Entity, decimal?> selector)
        {
            return DbSet.Max(selector);
        }

        public virtual IQueryable<Entity> GetAsNoTracking()
        {
            return DbSet.AsNoTracking();
        }

        public IOrderedEnumerable<Entity> OrderBy(Func<Entity, object> keySelector)
        {
            return DbSet.OrderBy(keySelector);
        }

        public IOrderedEnumerable<Entity> OrderByDescending(Func<Entity, object> keySelector)
        {
            return DbSet.OrderByDescending(keySelector);
        }

        public virtual IEnumerable<Entity> Where(Func<Entity, bool> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual Entity FirstOrDefault()
        {
            return DbSet.FirstOrDefault();
        }

        public virtual Entity FirstOrDefault(Func<Entity, bool> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual async Task<Entity> FirstOrDefaultAsync()
        {
            return await DbSet.FirstOrDefaultAsync();
        }

        public virtual async Task<Entity> FirstOrDefaultAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public virtual int Count(Func<Entity, bool> predicate)
        {
            return DbSet.Count(predicate);
        }

        public virtual async Task<int> CountAsync()
        {
            return await DbSet.CountAsync();
        }

        public virtual async Task<int> CountAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await DbSet.CountAsync(predicate);
        }

        public virtual Entity Find(params object[] id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<Entity> FindAsync(params object[] id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual Entity Add(Entity entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public virtual IEnumerable<Entity> AddRange(IEnumerable<Entity> entities)
        {
            DbSet.AddRange(entities);
            return entities;
        }

        public virtual Entity Remove(Entity entity)
        {
            return DbSet.Remove(entity).Entity;
        }

        public virtual IEnumerable<Entity> RemoveRange(IEnumerable<Entity> entities)
        {
            DbSet.RemoveRange(entities);
            return entities;
        }

        public virtual Entity Update(Entity entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<Entity, TResult>> expression)
        {
            return DbSet.Select<Entity, TResult>(expression);
        }

        public bool Any()
        {
            return DbSet.Any();
        }

        public bool Any(Expression<Func<Entity, bool>> expression)
        {
            return DbSet.Any(expression);
        }
    }
}
