

namespace Fiftea.Model
{
	public class OrderDetail
	{
		public int OrderDetailId { get; set; }
		public int OrderId { get; set; }
		public int CategoryId { get; set; }
		public int  ProductId { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }   
		

	}
}
