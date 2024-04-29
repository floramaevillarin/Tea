using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.Model
{
	public class Items
	{
		public int Id { get; set; }
		public Item<Product> Tea { get; set; }
		public List<Item<Product>> Toppings { get; set; }
		public double Total { get; set; }
		public double Cash { get; set; }
		public double Change { get; set; }
	}
}

