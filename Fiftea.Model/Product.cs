

namespace Fiftea.Model
{
	public class Product : Base 
	{
		public int ProductId { get; set; }
		public string Description { get; set; }		  
		public double RegularPrice { get; set; }
		public double LargePrice { get; set; }
		public int CategoryId { get; set; }
		public bool IsActive { get; set; }

	}
}
