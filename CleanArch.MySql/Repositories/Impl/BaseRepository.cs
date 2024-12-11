using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CleanArch.MySql.Persistence;
using CleanArch.Core.Common;
using CleanArch.Core.Exceptions;

namespace CleanArch.MySql.Repositories.Impl
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly DatabaseContext Context;
		protected readonly DbSet<TEntity> DbSet;

		protected BaseRepository(DatabaseContext context)
		{
			Context = context;
			DbSet = context.Set<TEntity>();
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			var addedEntity = (await DbSet.AddAsync(entity)).Entity;
			await Context.SaveChangesAsync();

			return addedEntity;
		}

		public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entityList)
		{
			await DbSet.AddRangeAsync(entityList);
			await Context.SaveChangesAsync();

			return entityList;
		}

		public async Task<TEntity> DeleteAsync(TEntity entity)
		{
			var removedEntity = DbSet.Remove(entity).Entity;
			await Context.SaveChangesAsync();

			return removedEntity;
		}

		public async Task<List<TEntity>> DeleteRangeAsync(List<TEntity> entityList)
		{
			DbSet.RemoveRange(entityList);
			await Context.SaveChangesAsync();

			return entityList;
		}

		public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await DbSet.Where(predicate).ToListAsync();
		}

		public async Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
		{
			try
			{
				var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();
				return entity;
			}
			catch (Exception)
			{
				throw new ResourceNotFoundException(typeof(TEntity));
			}
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			DbSet.Update(entity);
			await Context.SaveChangesAsync();

			return entity;
		}

		public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entityList)
		{
			DbSet.UpdateRange(entityList);
			await Context.SaveChangesAsync();

			return entityList;
		}
	}
}
