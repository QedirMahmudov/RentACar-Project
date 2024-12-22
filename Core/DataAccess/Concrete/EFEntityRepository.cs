using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete
{
	public class EFEntityRepository<TEntity, TContext>(TContext context) : IEntityRepository<TEntity>
		where TEntity : class, IEntity, new()
		where TContext : DbContext, new()
	{
		private readonly TContext _context = context;
		public void Add(TEntity entity)
		{
			var addEntity = _context.Entry(entity);
			addEntity.State = EntityState.Added;
			_context.SaveChanges();
		}

		public void Delete(TEntity entity)
		{
			var deleteEntity = _context.Entry(entity);
			deleteEntity.State = EntityState.Modified;
			_context.SaveChanges();
		}

		public TEntity Get(Expression<Func<TEntity, bool>> filter)
		{
			return _context.Set<TEntity>().SingleOrDefault(filter);
		}

		public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
		{
			return filter == null
				? _context.Set<TEntity>().ToList()
				: _context.Set<TEntity>().Where(filter).ToList();
		}

		public void Update(TEntity entity)
		{
			var updateEntity = _context.Entry(entity);
			updateEntity.State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}
