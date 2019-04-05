using Microsoft.EntityFrameworkCore;
using Novia.EngineManagement.Domain.Abstractions;
using Novia.EngineManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Novia.EngineManagement.Infrastructure.Data.Ef
{
    /// <summary>
    /// This EFrepository uses the EF DBContext to do the real work and implements the IRepository interface
    /// </summary>
    public class EfRepository<TDbContext, TEntity, TIEntity> : IRepository<TIEntity>
    where TIEntity : IEntity<int>
    where TEntity : Entity, TIEntity
    where TDbContext : EfDbContext
    {
        protected readonly TDbContext mDbContext;
        public EfRepository(TDbContext dbContext)
        {
            mDbContext = dbContext;
        }
        public virtual TIEntity GetById(int id)
        {
            return mDbContext.Set<TEntity>().Find(id);
        }
        public TIEntity GetSingleBySpec(ISpecification<TIEntity> spec)
        {
            return List(spec).FirstOrDefault();
        }
        public IEnumerable<TIEntity> ListAll()
        {
            return mDbContext.Set<TEntity>().AsEnumerable();
        }
        public IEnumerable<TIEntity> List(ISpecification<TIEntity> spec)
        {
            ISpecification<TEntity> specification = spec as ISpecification<TEntity>;
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = specification.Includes
            .Aggregate(mDbContext.Set<TEntity>().AsQueryable(),
            (current, include) => current.Include(include));
            // modify the IQueryable to include any string-based include statements
            var secondaryResult = specification.IncludeStrings
            .Aggregate(queryableResultWithIncludes,
            (current, include) => current.Include(include));
            // return the result of the query using the specification's criteria expression
            return secondaryResult
            .Where(specification.Criteria)
            .AsEnumerable();
        }
        public TIEntity Add(TIEntity entity)
        {
            mDbContext.Set<TEntity>().Add(entity as TEntity);
            mDbContext.SaveChanges();
            return entity;
        }
        public void Update(TIEntity entity)
        {
            mDbContext.Entry(entity as TEntity).State = EntityState.Modified;
            mDbContext.SaveChanges();
        }
        public void Delete(TIEntity entity)
        {
            mDbContext.Set<TEntity>().Remove(entity as TEntity);
            mDbContext.SaveChanges();
        }
    }
}