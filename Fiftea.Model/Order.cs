using System.Collections.Generic;

namespace Fiftea.Model
{
	public class Order
	{
		public int OrderId { get; set; }
		public double Amount { get; set; }
		public double Cash { get; set; }
		public int StaffId { get; set; }
		public ICollection<OrderDetail> OrderDetails { get; set; }

	}
}
