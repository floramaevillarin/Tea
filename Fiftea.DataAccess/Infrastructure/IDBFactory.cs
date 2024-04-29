namespace Fiftea.DataAccess.Infrastructure
{
	public interface IDBFactory
	{
		FifteaDBConnectionStringEntities Init();
	}
}