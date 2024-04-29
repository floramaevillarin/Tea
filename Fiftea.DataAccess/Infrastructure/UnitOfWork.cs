using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.DataAccess.Infrastructure
{
	/// <summary>
	/// To call  from service to execute Commit command to db through injection interface
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private FifteaDBConnectionStringEntities context;
		private Repository<Category> _repoCategory;
		private Repository<Product> _repoProduct;
		private Repository<Order> _repoOrder;
		private Repository<OrderDetail> _repoOrderDetail;

		public UnitOfWork(IDBFactory dbFactory)
		{
			DBFactory = dbFactory;
		}

		public IDBFactory DBFactory
		{
			get;
			private set;
		}

		protected FifteaDBConnectionStringEntities DbContext
		{
			get { return context ?? (context = DBFactory.Init()); }
		}

		public void Save()
		{
			DbContext.SaveChanges();
		}

		public Repository<Category> CatergoryRepository
		{
			get
			{

				if (_repoCategory == null)
				{
					_repoCategory = new Repository<Category>(DbContext);
				}
				return _repoCategory;
			}
		}

		public Repository<Product> ProductRepository
		{
			get
			{

				if (_repoProduct == null)
				{
					_repoProduct = new Repository<Product>(DbContext);
				}
				return _repoProduct;
			}
		}

		public Repository<Order> OrderRepository
		{
			get
			{

				if (_repoOrder == null)
				{
					_repoOrder = new Repository<Order>(DbContext);
				}
				return _repoOrder;
			}
		}

		public Repository<OrderDetail> OrderDetailRepository
		{
			get
			{

				if (_repoOrderDetail == null)
				{
					_repoOrderDetail = new Repository<OrderDetail>(DbContext);
				}
				return _repoOrderDetail;
			}
		}


		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					DbContext.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
