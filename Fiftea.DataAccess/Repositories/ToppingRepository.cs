using Fiftea.DataAccess.Entities;
using Fiftea.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.DataAccess.Repositories
{
	public class ToppingRepository : Repository<ToppingEntity>, IToppingRepository
	{
		public ToppingRepository(IDBFactory dbFactory) : base(dbFactory)
		{
		}
	}

	public interface IToppingRepository : IRepository<ToppingEntity>
	{
	}
}
