using Fiftea.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Fiftea.Service.Constants;

namespace POS_Fiftea
{
	public partial class FormPOS
	{
		/// <summary>
		/// Initial Location in Panel
		/// </summary>
		private void InitLocation()
		{
			PanelSubItem.Controls.Clear();
			locationX = 2;
			locationY = 265;
		}

		/// <summary>
		/// Initial Location
		/// </summary>
		private void InitItemBoxLocation()
		{
			subItemScreen = 1;
			currentScreen = 0;
			capacity = 12;

			InitLocation();
		}

		/// <summary>
		/// Display the item/menu as button in screen
		/// </summary>
		/// <typeparam name="T">Tea or Topping</typeparam>
		/// <param name="lstItems"></param>
		private void DisplayItem<T>(List<T> lstItems) where T : Base
		{
			List<T> items = new List<T>();
			List<T> currentSubItems = new List<T>();

			if (lstItems.Count() <= 12)
				capacity = lstItems.Count();
			else
				capacity = 12;

			for (int i = 0; i < lstItems.Count(); i++)
			{
				Point newLoc = new Point(locationX, locationY);
				Button b = new Button();
				b.Size = new Size(196, 122);
				b.Location = newLoc;
				b.Text = lstItems[i].Name;
				b.BackColor = Color.Green;
				b.Name = lstItems[i].Name;
				b.Click += new EventHandler(this.Item_Click);

				PanelSubItem.Controls.Add(b);
				locationX = locationX + 193;
				if (i == 3)
				{
					locationY = locationY - 128;
					locationX = 2;
				}
				if (i == 7)
				{
					locationY = locationY - 128;
					locationX = 2;
				}
			}
		}

		/// <summary>
		/// List the items per screen/panel with max 12 items per screen
		/// </summary>
		/// <typeparam name="T">Tea or Topping</typeparam>
		/// <param name="lstItems">All items from repo</param>
		/// <returns></returns>
		private Dictionary<int, List<T>> SetItemPerScreen<T>(List<T> lstItems)
		{
			Dictionary<int, List<T>> itemPerScreen = new Dictionary<int, List<T>>();
			subItemScreen = (lstItems.Count() / capacity);

			if ((subItemScreen % capacity) >= 1)
				subItemScreen = subItemScreen + 1;

			if (subItemScreen > 1)
			{
				for (int i = 1; i <= subItemScreen; i++)
				{
					int count = (lstItems.Count() > (i * capacity)) ? capacity : (lstItems.Count() - ((i - 1) * capacity));
					if (i > 1)
						itemPerScreen.Add(i, lstItems.GetRange((((i - 1) * capacity) - 1), count));
					else
						itemPerScreen.Add(i, lstItems.GetRange(0, count));
				}

			}
			else
			{
				itemPerScreen.Add(1, lstItems);
			}

			currentScreen = 1;
			return itemPerScreen;
		}

		/// <summary>
		/// Show the menu
		/// </summary>
		/// <param name="items"></param>
		private void ShowItem(List<Product> items)
		{
			screenItem = new Dictionary<int, List<Product>>();
			Previous.Enabled = false;
			selectedItem = OrderType.Item.ToString();

			PanelSubItem.Controls.Clear();
			InitItemBoxLocation();

			try
			{
				allSelectedItem = items;
				screenItem = SetItemPerScreen<Product>(allSelectedItem);
				DisplayItem(screenItem[1]);

				if (screenItem.Count() > 1)
					Next.Enabled = true;
				else
					Next.Enabled = false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Update the price and quantity in any order change
		/// </summary>
		private void UpdatePriceAndQty()
		{
			txtQuantity.Text = orderItemAndTopping.Count().ToString();

			double price = 0;
			double total = 0;

			orderItemAndTopping.ForEach(delegate (Items o)
			{
				price = price + o.Tea.Price;
				total = total + o.Tea.Price;

				o.Toppings.ForEach(delegate (Item<Product> t)
				{
					total = total + t.Price;
				});

			});
			
			txtUnitPrice.Text = price.ToString("N");
			txtTotal.Text = total.ToString("N");  
		}

	}
}
