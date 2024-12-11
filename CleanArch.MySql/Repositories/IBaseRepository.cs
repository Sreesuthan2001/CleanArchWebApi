using CleanArch.Core.Common;
using System.Linq.Expressions;

namespace CleanArch.MySql.Repositories
{
	public interface IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

		Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

		Task<TEntity> AddAsync(TEntity entity);

		Task<List<TEntity>> AddRangeAsync(List<TEntity> entityList);

		Task<TEntity> UpdateAsync(TEntity entity);

		Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entityList);

		Task<TEntity> DeleteAsync(TEntity entity);

		Task<List<TEntity>> DeleteRangeAsync(List<TEntity> entityList);

	}
}
