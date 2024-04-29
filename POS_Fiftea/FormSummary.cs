using Fiftea.Model;
using Fiftea.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Fiftea
{
	public partial class FormSummary : Form
	{
		IMenuItem app = FormPOS.app;
		List<Items> items = FormPOS.receiptitem.Orders;
		double total = FormPOS.receiptitem.Total;
		double cash = FormPOS.receiptitem.Cash;
		double change = FormPOS.receiptitem.Change;

		/// <summary>
		/// View list of orders and payment details
		/// </summary>
		public FormSummary()
		{
			InitializeComponent();

			lblTotal.Text += total;

			
			var sb = new StringBuilder();		
			
			string hearder = "Qty Description";

			sb.Append(hearder.PadRight(50));
			sb.Append("Price Amount");
			sb.AppendLine();
			sb.AppendLine("--------------------------------------------------------------------");

			foreach (Items i in items)
			{
				sb.Append(i.Tea.Qty.ToString().PadRight(2));
				sb.Append(i.Tea.OrderItem.Name.ToUpper().PadRight(50));
				sb.Append(i.Tea.Price.ToString().PadRight(5));
				sb.Append(i.Tea.Price * i.Tea.Qty);
				sb.AppendLine();

				foreach (Item<Product> t in i.Toppings)
				{
					sb.Append("-".PadRight(2));
					sb.Append(t.Name.ToUpper().PadRight(50));
					sb.Append(t.Price.ToString().PadRight(5));
					sb.Append(t.Price * t.Qty);
					sb.AppendLine();				
				}
			}
			sb.AppendLine("--------------------------------------------------------------------");
			sb.AppendLine("SUB-TOTAL".PadRight(57) + total);
			sb.AppendLine("CASH".PadRight(57) + cash);
			sb.AppendLine("--------------------------------------------------------------------");
			sb.AppendLine("CHANGE".PadRight(57) + change);
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine("TOTAL NO OF ITEMS: " + FormPOS.receiptitem.Orders.Count());

			txtDetails.Text = sb.ToString();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Save the orders to db
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrint_Click(object sender, EventArgs e)
		{
			List<OrderDetail> orderDetails = new List<OrderDetail>();
			
			foreach (Items i in items)
			{
				orderDetails.Add(new OrderDetail
				{
					CategoryId = i.Tea.OrderItem.CategoryId,
					ProductId = i.Tea.OrderItem.ProductId,
					Quantity = i.Tea.Qty,
					Price = i.Tea.Price * i.Tea.Qty
				});

				foreach (Item<Product> t in i.Toppings)
				{
					orderDetails.Add(new OrderDetail
					{
						CategoryId = t.OrderItem.CategoryId,
						ProductId = t.Id,
						Quantity = t.Qty,
						Price = t.Price * t.Qty
					});
				}
			}

			Order order = new Order()
			{
				Amount = total,
				Cash = cash,
				StaffId = 1, //TODO
				OrderDetails = orderDetails
			};

			app.SaveOrders(order);
			this.Close();
		}
	}
}
