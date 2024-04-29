using Fiftea.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Fiftea.DataAccess
{
	public class FifteaContexts : DbContext
	{	
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			Database.SetInitializer<FifteaContexts>(new CreateDatabaseIfNotExists<FifteaContexts>());
			//convention and configurations
		    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
