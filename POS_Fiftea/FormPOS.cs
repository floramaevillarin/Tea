using Autofac;
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
using static Fiftea.Service.Constants;

namespace POS_Fiftea
{
    public partial class FormPOS : Form
    {
		public static IMenuItem app;

		List<Product> allSubItem = new List<Product>();
		List<Product> allSelectedItem= new List<Product>();
		List<Product> allTopping = new List<Product>();
		List<Items> orderItemAndTopping = new List<Items>();
		List<ItemDataGrid> ordersInDataGrid = new List<ItemDataGrid>();		

		private Dictionary<int, List<Product>> screenItem = new Dictionary<int, List<Product>>();
		private Dictionary<int, List<Product>> screenTopping = new Dictionary<int, List<Product>>();
		
		int capacity = 0;
		int locationX = 0;
		int locationY = 0;
		int subItemScreen = 0;
		int currentScreen = 0;

		string selectedSize = string.Empty;
		string selectedItem = string.Empty;

		public static ReceiptItem receiptitem = new ReceiptItem();

		public FormPOS()
        {
			InitializeComponent();
			InitItemBoxLocation();		

		}

		private void frmPOS_Load(object sender, EventArgs e)
		{
			var container = ContainerConfig.Configure();
			using (var scope = container.BeginLifetimeScope())
			{
				if (allSubItem.Count == 0)
				{
					app = scope.Resolve<IMenuItem>();
					allSubItem = app.GetTeaItems().ToList();
					allTopping = app.GetToppings().ToList();
				}

			}
		}		

		/// <summary>
		/// Find Cravings Menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FindCravings_Click(object sender, EventArgs e)
		{
			allSelectedItem = allSubItem.Where(o => o.CategoryId == Convert.ToInt32(TeaType.FindCravings)).ToList();

			if(allSelectedItem != null)
				ShowItem(allSelectedItem);			
		}		

		/// <summary>
		/// Find Tea Menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FindTea_Click(object sender, EventArgs e)
		{
			allSelectedItem = allSubItem.Where(o => o.CategoryId == Convert.ToInt32(TeaType.FindTea)).ToList();

			if (allSelectedItem != null)
				ShowItem(allSelectedItem);
		}

		/// <summary>
		/// Find Fresh Milk Menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FindFreshMilk_Click(object sender, EventArgs e)
		{
			allSelectedItem = allSubItem.Where(o => o.CategoryId == Convert.ToInt32(TeaType.FindFreshMilk)).ToList();

			if (allSelectedItem != null)
				ShowItem(allSelectedItem);
		}

		/// <summary>
		/// Find Fruit Menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FindFruit_Click(object sender, EventArgs e)
		{
			allSelectedItem = allSubItem.Where(o => o.CategoryId == Convert.ToInt32(TeaType.FindFruit)).ToList();

			if (allSelectedItem != null)
				ShowItem(allSelectedItem);
		}

		/// <summary>
		/// Find Ice Cream Menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FindIceCream_Click(object sender, EventArgs e)
		{
			allSelectedItem = allSubItem.Where(o => o.CategoryId == Convert.ToInt32(TeaType.FindIceCream)).ToList();

			if (allSelectedItem != null)
				ShowItem(allSelectedItem);
		}

		/// <summary>
		/// Add Extra/Topping
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Topping_Click(object sender, EventArgs e)
		{

			screenTopping = new Dictionary<int, List<Product>>();

			InitItemBoxLocation();
			PanelSubItem.Controls.Clear();
			Previous.Enabled = false;
			Next.Enabled = false;
			selectedItem = OrderType.Topping.ToString();

			try
			{
				if (allTopping.Count == 0)
				{
					allTopping = app.GetToppings().ToList();
				}

				screenTopping = SetItemPerScreen<Product>(allTopping);
				DisplayItem(screenTopping[1]);

				if (screenTopping.Count() > 1)
					Next.Enabled = true;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}		

		/// <summary>
		/// Trigger when item added to order
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Item_Click(object sender, EventArgs e)
		{
			ItemDataGrid orderGridDetail = null; 
			Item<Product> orderItem = new Item<Product>();
			Item<Product> orderTopping = new Item<Product>();
			string type = string.Empty;
			
			double amount = 0;
			int no = 0;

			/*
			 * Setup the button menu
			 * */
			Button btn = (Button)sender;
			int index = dataGridViewItem.Rows.Count - 1;

			if (selectedItem == OrderType.Topping.ToString() && index < 0)
			{
				return;
			}
			else if (selectedItem == OrderType.Topping.ToString())
			{
				/*
				 * Show Extras Menu
				 * */

				selectedSize = string.Empty;
				type = OrderType.Topping.ToString();

				Product top = allTopping.Where(o => o.Description == btn.Name).FirstOrDefault();
				amount = top.RegularPrice;
				no = Convert.ToInt32(dataGridViewItem[dataGridViewItem.Columns["No"].Index, index].Value);

				orderTopping = new Item<Product>
				{
					Id = no,
					OrderItem = top,
					Size = selectedSize,
					Price = amount,
					Qty = 1,
					Name = top.Name
				};


				// If last row selected, add extra in last row
				if (dataGridViewItem.Rows[dataGridViewItem.Rows.Count - 1].Selected)
				{
					orderItemAndTopping.Where(o => o.Tea.Id == no && o.Id == no).FirstOrDefault().Toppings.Add(orderTopping);

					orderGridDetail = new ItemDataGrid(no, type, btn.Text, selectedSize, amount);					
					dataGridViewItem.Rows.Add(orderGridDetail.OrderRow(orderGridDetail));
				}
				else
				{
					foreach (DataGridViewRow r in dataGridViewItem.Rows)
					{
						if (r.Selected && r.Cells[dataGridViewItem.Columns["Type"].Index].Value.ToString() == OrderType.Item.ToString())
						{
							orderItemAndTopping.Where(o => o.Id.ToString() == r.Cells[dataGridViewItem.Columns["No"].Index].Value.ToString())
								.FirstOrDefault().Toppings.Add(orderTopping);


							orderGridDetail = new ItemDataGrid(no, type, btn.Text, selectedSize, amount);
							dataGridViewItem.Rows.Insert(r.Index + 1, orderGridDetail.OrderRow(orderGridDetail));
							break;
						}
					}
				}

				

				

			}
			else
			{
				/**
				 *  Show Tea Menu and ask for size (Regular, Large)
				 * */
				type = OrderType.Item.ToString();
				Product item = allSelectedItem.Where(o => o.Name == btn.Name).FirstOrDefault();
				no = orderItemAndTopping.Count() + 1;
				FormSize formSize = new FormSize();
				formSize.ShowDialog();

				if (!string.IsNullOrEmpty(formSize.Size))
					selectedSize = formSize.Size;

				if (selectedSize == OrderSize.Large.ToString())
					amount = item.LargePrice;
				else
					amount = item.RegularPrice;

				/**
				 * add to order 
				 **/

				orderItem = new Item<Product>
				{
					Id = no,
					OrderItem = item,
					Size = selectedSize,
					Price = amount,
					Qty = 1,
					Name =item.Name
				};

				orderItemAndTopping.Add(new Items
				{
					Id = no,
					Tea = orderItem,
					Toppings = new List<Item<Product>>()
				});

				orderGridDetail = new ItemDataGrid(no, type, btn.Text, selectedSize, amount);
				dataGridViewItem.Rows.Add(orderGridDetail.OrderRow(orderGridDetail));
			}		

			
			ordersInDataGrid.Add(orderGridDetail);			
			UpdatePriceAndQty();
		}

		private void dataGridViewItem_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			/*
			 * Hide the No. value for topping in data grid
			 * */

			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridViewItem.Rows[e.RowIndex];

				if (row.Cells[dataGridViewItem.Columns["Type"].Index].Value != null && row.Cells[dataGridViewItem.Columns["Type"].Index].Value.ToString() == OrderType.Topping.ToString())
				{
					if (e.ColumnIndex == 0)
					{
						e.CellStyle.ForeColor = e.CellStyle.BackColor;
						e.CellStyle.SelectionForeColor = e.CellStyle.SelectionBackColor;
					}
				}
			}

		}

		/// <summary>
		/// Trigger to check remove item click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridViewItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			/**
			 * index 7 = Delete
			 **/

			if (e.ColumnIndex == 6)
			{
				DataGridViewRow row = dataGridViewItem.Rows[e.RowIndex];
				int del_no = Convert.ToInt32(row.Cells[dataGridViewItem.Columns["No"].Index].Value);
				string del_type = row.Cells[dataGridViewItem.Columns["Type"].Index].Value.ToString();

				List<DataGridViewRow> del_row = new List<DataGridViewRow>();

				if (FormMessageBox.Show(string.Format("Do you want to delete item: {0} ?", row.Cells["Description"].Value), "Confirmation", "Yes") == DialogResult.Yes)
				{

					if (row.Cells[dataGridViewItem.Columns["Type"].Index].Value.ToString() == OrderType.Item.ToString())
					{
						orderItemAndTopping.Remove(orderItemAndTopping.Where(o => o.Id == Convert.ToInt32(row.Cells[dataGridViewItem.Columns["No"].Index].Value)).FirstOrDefault());
						ordersInDataGrid.RemoveAll(r => r.No.ToString() == row.Cells[dataGridViewItem.Columns["No"].Index].Value.ToString());

						/*
						 * Get the list of Tea to be remove
						 * */
						foreach (DataGridViewRow r in dataGridViewItem.Rows)
						{
							if (Convert.ToInt32(r.Cells[dataGridViewItem.Columns["No"].Index].Value) == Convert.ToInt32(del_no))
							{
								del_row.Add(r);
							}
						}
					}

					if (row.Cells[dataGridViewItem.Columns["Type"].Index].Value.ToString() == OrderType.Topping.ToString())
					{
						Item<Product> removeTopping = orderItemAndTopping[Convert.ToInt32(row.Cells[dataGridViewItem.Columns["No"].Index].Value) - 1].Toppings.Where(t => t.Name.ToString() == row.Cells[dataGridViewItem.Columns["Description"].Index].Value.ToString()).FirstOrDefault();
						orderItemAndTopping[Convert.ToInt32(row.Cells[dataGridViewItem.Columns["No"].Index].Value) - 1].Toppings.Remove(removeTopping);
						ordersInDataGrid.Remove(ordersInDataGrid.Where(o => o.No.ToString() == row.Cells[dataGridViewItem.Columns["No"].Index].Value.ToString() && o.Description == row.Cells[dataGridViewItem.Columns["Description"].Index].Value.ToString()).FirstOrDefault());

						/*
						 * Remove Topping from the data grid view 
						 * */
						this.dataGridViewItem.Rows.RemoveAt(e.RowIndex);
					}

					/*
					 * Remove the list of Tea from the data grid view 
					 * */
					del_row.ForEach(delegate (DataGridViewRow r)
					{
						this.dataGridViewItem.Rows.Remove(r);
					});

					/*
					 * Reset the order of No. from the data grid view 
					  * */
					int cnt = 0;

					if (ordersInDataGrid.Count() > 0)
					{		
						ordersInDataGrid.ForEach(delegate (ItemDataGrid i)
						{							
							if(del_no < i.No)
							{
								i.No = i.No - 1;
							}
							cnt++;
						});
					}

					if (orderItemAndTopping.Count() > 0 && del_type == OrderType.Item.ToString())
					{
						cnt = 0;
						orderItemAndTopping.ForEach(delegate (Items i)
						{
							if (del_no < i.Id)
							{
								i.Id = i.Id - 1;
								i.Tea.Id = i.Tea.Id - 1;

								i.Toppings.ToList().ForEach(delegate (Item<Product> t)
								{
									t.Id = t.Id - 1;
								});
							}
						});
					}

					if (del_row.Count() > 0)
					{
						int no = Convert.ToInt32(del_row[del_row.Count() - 1].Cells[dataGridViewItem.Columns["No"].Index].Value);
						foreach (DataGridViewRow r in dataGridViewItem.Rows)
						{
							if (no < Convert.ToInt32(r.Cells[dataGridViewItem.Columns["No"].Index].Value))
							{
								r.Cells[dataGridViewItem.Columns["No"].Index].Value = (Convert.ToInt32(r.Cells[dataGridViewItem.Columns["No"].Index].Value)- 1).ToString();
							}
						}
					}

					this.dataGridViewItem.Refresh();
					UpdatePriceAndQty();

				}
			}
		}

		private void dataGridViewItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			UpdatePriceAndQty();
		}

		private void dataGridViewItem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.dataGridViewItem.ClearSelection();
			this.dataGridViewItem.Rows[e.RowIndex].Selected = true;
		}

		/// <summary>
		/// Less Qty
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DecrementQty_Click(object sender, EventArgs e)
		{
			DataGridViewRow selected_row = new DataGridViewRow();
			foreach (DataGridViewRow row in dataGridViewItem.SelectedRows)
			{
				if (Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Qty"].Index].Value) > 1)
				{				

					row.Cells[dataGridViewItem.Columns["Price"].Index].Value = (Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Price"].Index].Value) - (Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Price"].Index].Value) / Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Qty"].Index].Value))).ToString();
					row.Cells[dataGridViewItem.Columns["Qty"].Index].Value = (Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Qty"].Index].Value) - 1).ToString();

					selected_row = row;
				}
			}

			DataGridView_UpdateQtyAndPrice(selected_row);

		}

		/// <summary>
		/// Add Qty
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IncrementQty_Click(object sender, EventArgs e)
		{
			DataGridViewRow selected_row = new DataGridViewRow();

			foreach (DataGridViewRow row in dataGridViewItem.SelectedRows)
			{
				//Qty
				row.Cells[dataGridViewItem.Columns["Qty"].Index].Value = (Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Qty"].Index].Value) + 1).ToString();
				
				//Price
				if (Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Qty"].Index].Value) > 1)
					row.Cells[dataGridViewItem.Columns["Price"].Index].Value = (Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Qty"].Index].Value) * 
						(Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Price"].Index].Value) / (Convert.ToInt32(row.Cells[dataGridViewItem.Columns["Qty"].Index].Value) - 1))).ToString();

				selected_row = row;
			}

			DataGridView_UpdateQtyAndPrice(selected_row);

		}

		/// <summary>
		/// Update the price and qty from the list and data view
		/// </summary>
		/// <param name="selected_row"></param>
		private void DataGridView_UpdateQtyAndPrice(DataGridViewRow selected_row)
		{
			/*
			* 
			* */

			if (orderItemAndTopping.Count() > 0 && selected_row.Index >= 0)
			{
				if (selected_row.Cells[dataGridViewItem.Columns["Type"].Index].Value.ToString() == OrderType.Item.ToString())
				{
					orderItemAndTopping.ForEach(delegate (Items i)
					{
						if (i.Tea.Id.ToString() == selected_row.Cells[dataGridViewItem.Columns["No"].Index].Value.ToString())
						{
							i.Tea.Price = Convert.ToDouble(selected_row.Cells[dataGridViewItem.Columns["Price"].Index].Value);
							i.Tea.Qty = Convert.ToInt32(selected_row.Cells[dataGridViewItem.Columns["Qty"].Index].Value);
						}
					});
				}

				if (selected_row.Cells[dataGridViewItem.Columns["Type"].Index].Value.ToString() == OrderType.Topping.ToString())
				{
					orderItemAndTopping.Where(o => o.Id.ToString() == selected_row.Cells[dataGridViewItem.Columns["No"].Index].Value.ToString()).FirstOrDefault()
						.Toppings.ToList().ForEach(delegate (Item<Product> t)
						{
							if (t.Id.ToString() == selected_row.Cells[dataGridViewItem.Columns["No"].Index].Value.ToString() &&
								t.Name == selected_row.Cells[dataGridViewItem.Columns["Description"].Index].Value.ToString())
							{
								t.Price = Convert.ToDouble(selected_row.Cells[dataGridViewItem.Columns["Price"].Index].Value);
								t.Qty = Convert.ToInt32(selected_row.Cells[dataGridViewItem.Columns["Qty"].Index].Value);
							}
						});
				}

				UpdatePriceAndQty();
			}
		}

	

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Navigate Previous item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Previous_Click(object sender, EventArgs e)
		{
			InitLocation();
			currentScreen--;

			if (selectedItem == OrderType.Topping.ToString())
			{
				DisplayItem(screenTopping[currentScreen]);
				if (screenTopping.Count() > 1)
					Next.Enabled = true;
			}
			else
			{
				DisplayItem(screenItem[currentScreen]);
				if (screenItem.Count() > 1)
					Next.Enabled = true;
			}

			if (currentScreen == 1)
				Previous.Enabled = false;

		}

		/// <summary>
		/// Navigate Next item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Next_Click(object sender, EventArgs e)
		{
			InitLocation();
			currentScreen++;

			if (selectedItem == OrderType.Topping.ToString())
			{
				DisplayItem(screenTopping[currentScreen]);
				if (currentScreen == screenTopping.Count())
					Next.Enabled = false;
			}
			else
			{
				DisplayItem(screenItem[currentScreen]);
				if (currentScreen == screenItem.Count())
					Next.Enabled = false;
			}

			Previous.Enabled = true;
		}

		private void Clear_All_Click(object sender, EventArgs e)
		{
			this.dataGridViewItem.Rows.Clear();
			orderItemAndTopping = new List<Items>();
			ordersInDataGrid = new List<ItemDataGrid>();
		}

		private void Bill_Click(object sender, EventArgs e)
		{
			if (orderItemAndTopping.Count() > 0)
			{
				PanelPayment.Visible = !PanelPayment.Visible;
				lblCash.Text = string.Empty;
			}
		}


		#region Bill the order
		private void btnExit_Click(object sender, EventArgs e)
		{
			PanelPayment.Visible = false;
		}

		private void btnCls_Click(object sender, EventArgs e)
		{
			double cash = 0;
			lblCash.Text = cash.ToString("N");
		}

		private void btn0_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn0.Text);
		}

		private void btn1_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn1.Text);
		}

		private void btn2_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn2.Text);
		}
		

		private void btn3_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn3.Text);
		}

		private void btn4_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn4.Text);
		}

		private void btn5_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn5.Text);
		}

		private void btn6_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn6.Text);
		}

		private void btn7_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn7.Text);
		}

		private void btn8_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn8.Text);
		}

		private void btn9_Click(object sender, EventArgs e)
		{
			lblCash.Text += double.Parse(btn9.Text);
		}

		private void btnDot_Click(object sender, EventArgs e)
		{
			lblCash.Text +=btnDot.Text;
		}

		private void btn50_Click(object sender, EventArgs e)
		{
			lblCash.Text = btn50.Text;
		}

		private void btn100_Click(object sender, EventArgs e)
		{
			lblCash.Text = btn100.Text;
		}

		private void btn200_Click(object sender, EventArgs e)
		{
			lblCash.Text = btn200.Text;
		}

		private void btn500_Click(object sender, EventArgs e)
		{
			lblCash.Text = btn500.Text;
		}

		private void btnEnter_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(lblCash.Text))
			{
				PanelPayment.Visible = false;
				receiptitem = new ReceiptItem
				{
					Orders = orderItemAndTopping,
					Cash = double.Parse(lblCash.Text),
					Total = double.Parse(txtTotal.Text),
					Change = double.Parse(lblCash.Text) - double.Parse(txtTotal.Text)

				};

				if (FormMessageBox.Show(string.Format("Cash Change: {0}", double.Parse(lblCash.Text) - double.Parse(txtTotal.Text)), "Commit Transaction?", "Yes") == DialogResult.Yes)
				{
					FormSummary summary = new FormSummary();
					summary.ShowDialog();
				}
			}
		}
		#endregion
		
	}
}
