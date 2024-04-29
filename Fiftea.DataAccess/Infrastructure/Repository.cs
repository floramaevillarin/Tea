using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.DataAccess.Infrastructure
{
	/// <summary>
	/// Generic Repo with CRUD operations
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public  class Repository<T> : IRepository<T> where T : class
	{
		private FifteaDBConnectionStringEntities _context;
		private readonly IDbSet<T> dbSet;
	

		public Repository(FifteaDBConnectionStringEntities context)
		{
			dbSet = context.Set<T>();
			_context = context;
		}

		#region Implementation
		public virtual void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Update(T entity)
		{
			dbSet.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public virtual void Delete(Expression<Func<T, bool>> where)
		{
			IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
			foreach (T obj in objects)
				dbSet.Remove(obj);
		}

		public virtual T GetById(int id)
		{
			return dbSet.Find(id);
		}

		public virtual IEnumerable<T> GetAll()
		{
			return dbSet.ToList();
		}

		public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
		{
			return dbSet.Where(where).ToList();
		}

		public T Get(Expression<Func<T, bool>> where)
		{
			return dbSet.Where(where).FirstOrDefault<T>();
		}

		public virtual void Insert(T entity)
		{
			dbSet.Add(entity);
		}
		#endregion
	}
}
