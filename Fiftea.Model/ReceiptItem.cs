using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.Model
{
	public class ReceiptItem
	{
		public List<Items> Orders { get; set; }
		public double Total { get; set; }
		public double Cash { get; set; }
		public double Change { get; set; }
	}
}
