using POS_Fiftea;
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
	/// <summary>
	/// Request for size (Regular or Large)
	/// </summary>
	public partial class FormSize : Form
	{
		public string _size = string.Empty;
		public string Size
		{
			get { return _size; }
		}

		public FormSize()
		{
			InitializeComponent();
		}
		
		private void btnRegular_Click(object sender, EventArgs e)
		{
			_size = OrderSize.Regular.ToString();
			Close();
		}

		private void btnLarge_Click(object sender, EventArgs e)
		{
			_size = OrderSize.Large.ToString();
			Close();
		}
	}
}
