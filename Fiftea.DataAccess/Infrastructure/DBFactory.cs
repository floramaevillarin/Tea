using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.DataAccess.Infrastructure
{
	public class DBFactory : Disposable, IDBFactory
	{
		FifteaDBConnectionStringEntities dbContext;

		public FifteaDBConnectionStringEntities Init()
		{
			return dbContext ?? (dbContext = new FifteaDBConnectionStringEntities());
		}

		protected override void DisposeCore()
		{
			if (dbContext != null)
			{
				dbContext.Dispose();
			}
		}
	}
}
