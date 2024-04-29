

namespace Fiftea.DataAccess.Infrastructure
{
	public interface IUnitOfWork
	{
		Repository<Category> CatergoryRepository { get; }
		Repository<Product> ProductRepository { get; }
		Repository<Order> OrderRepository { get; }

		void Dispose();
		void Save();
	}
}