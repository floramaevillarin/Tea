using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.Model
{
	public class Item<T> : Base
	{
		public int Id { get; set; }
		public T OrderItem { get; set; }
		public string Size { get; set; }
		public int Qty { get; set; }
		public double Price { get; set; }
	}
}
