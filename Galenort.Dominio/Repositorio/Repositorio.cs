using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galenort.Dominio.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : EntityBase
    {
        public async Task Create(T entity)
        {
            using (var context = new GestionSanatorialContext())
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }
        public async Task Update(T entity)
        {
            using (var context = new GestionSanatorialContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(T entity)
        {
            using (var context = new GestionSanatorialContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool enableTracking = true)
        {
            using (var context = new GestionSanatorialContext())
            {
                IQueryable<T> query = context.Set<T>();

                if (enableTracking)
                {
                    query = query.AsNoTracking();
                }
                if (include != null)
                {
                    query = include(query);
                }
                return orderBy != null
                    ? await orderBy(query).ToListAsync()
                    : await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = true)
        {
            using (var context = new GestionSanatorialContext())
            {
                IQueryable<T> query = context.Set<T>();

                if (enableTracking)
                {
                    query = query.AsNoTracking();
                }

                if (include != null)
                {
                    query = include(query);
                }

                if (predicate != null)
                {
                    query = query.Where(predicate);
                }
                return orderBy != null
                    ? await orderBy(query).ToListAsync()
                    : await query.ToListAsync();
            }
        }

        public async Task<T> GetById(long id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = default,
            bool enableTracking = true)
        {
            using (var context = new GestionSanatorialContext())
            {
                IQueryable<T> query = context.Set<T>();

                if (enableTracking)
                {
                    query = query.AsNoTracking();
                }

                if (include != null)
                {
                    query = include(query);
                }
                return await query.FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}
