using Fiftea.DataAccess.Infrastructure;
using Fiftea.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.DataAccess.Repositories
{
	public class ItemRepository : Repository<ItemEntity>, IItemRepository
	{
		public ItemRepository(IDBFactory dbFactory) 
			: base(dbFactory)
		{
		}
	}

	public interface IItemRepository : IRepository<ItemEntity>
	{
	}
}
