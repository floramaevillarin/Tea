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
	public partial class FormMessageBox : Form
	{
		public FormMessageBox()
		{
			InitializeComponent();
		}
		

		private static DialogResult result = DialogResult.No;
		public static DialogResult Show(string text, string caption, string btnOkText)
		{
			var msgBox = new FormMessageBox();
			msgBox.lblMessagetText.Text = text; 
			msgBox.Text = caption;
			msgBox.btnYes.Text = btnOkText;
										   
										   
			msgBox.ShowDialog();
			return result;
		}


		private void btnYes_Click(object sender, EventArgs e)
		{
			result = DialogResult.Yes;
			Close();
		}

		private void btnNo_Click(object sender, EventArgs e)
		{
			result = DialogResult.No;
			Close();
		}
	}
}
