namespace POS_Fiftea
{
	partial class FormSummary
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblDetails = new System.Windows.Forms.Label();
			this.txtDetails = new System.Windows.Forms.RichTextBox();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTotal
			// 
			this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotal.Location = new System.Drawing.Point(56, 25);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(490, 37);
			this.lblTotal.TabIndex = 0;
			this.lblTotal.Text = "Total including GST : ";
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDetails
			// 
			this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDetails.Location = new System.Drawing.Point(56, 73);
			this.lblDetails.Name = "lblDetails";
			this.lblDetails.Size = new System.Drawing.Size(490, 30);
			this.lblDetails.TabIndex = 1;
			this.lblDetails.Text = "Payment Details :";
			this.lblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDetails
			// 
			this.txtDetails.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDetails.Location = new System.Drawing.Point(59, 119);
			this.txtDetails.Name = "txtDetails";
			this.txtDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtDetails.Size = new System.Drawing.Size(487, 357);
			this.txtDetails.TabIndex = 2;
			this.txtDetails.Text = "";
			// 
			// btnPrint
			// 
			this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPrint.ForeColor = System.Drawing.Color.Transparent;
			this.btnPrint.Location = new System.Drawing.Point(126, 495);
			this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(171, 105);
			this.btnPrint.TabIndex = 33;
			this.btnPrint.Text = "PRINT";
			this.btnPrint.UseVisualStyleBackColor = false;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.ForeColor = System.Drawing.Color.Transparent;
			this.btnClose.Location = new System.Drawing.Point(305, 495);
			this.btnClose.Margin = new System.Windows.Forms.Padding(4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(171, 105);
			this.btnClose.TabIndex = 34;
			this.btnClose.Text = "CLOSE";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// FormSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(598, 613);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.txtDetails);
			this.Controls.Add(this.lblDetails);
			this.Controls.Add(this.lblTotal);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSummary";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Summary";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblDetails;
		private System.Windows.Forms.RichTextBox txtDetails;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnClose;
	}
}