using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.Model
{
	public class ItemDataGrid
	{
		
		public int No { get; set; }
		public string Type { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public string Size { get; set; }
		public int Qty { get; set; }
		public double Price { get; set; }
		public string Action { get; set; }

		public ItemDataGrid(int no, string type, string desc, string size, double amount)
		{
			No = no;
			Type = type;
			Description = desc;
			Size = size;
			Qty = 1;
			Price = amount;
		}

		public ItemDataGrid(int no, string type, string desc, string size, double amount, int qty)
		{
			No = no;
			Type = type;
			Description = desc;
			Size = size;
			Qty = qty;
			Price = amount;
		}


		public string[] OrderRow(ItemDataGrid order)
		{
			string[] row = new string[] {order.No.ToString(), order.Type, order.Description, order.Size, order.Qty.ToString(), order.Price.ToString() };
			return row;
		}

	}

}
