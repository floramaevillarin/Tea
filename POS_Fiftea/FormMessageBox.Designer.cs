namespace POS_Fiftea
{
	partial class FormMessageBox
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
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.lblMessagetText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnYes
			// 
			this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnYes.ForeColor = System.Drawing.Color.Transparent;
			this.btnYes.Location = new System.Drawing.Point(79, 52);
			this.btnYes.Margin = new System.Windows.Forms.Padding(4);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(171, 105);
			this.btnYes.TabIndex = 32;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = false;
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnNo
			// 
			this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNo.ForeColor = System.Drawing.Color.Transparent;
			this.btnNo.Location = new System.Drawing.Point(315, 52);
			this.btnNo.Margin = new System.Windows.Forms.Padding(4);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(171, 105);
			this.btnNo.TabIndex = 33;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = false;
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// lblMessagetText
			// 
			this.lblMessagetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessagetText.Location = new System.Drawing.Point(82, 12);
			this.lblMessagetText.Name = "lblMessagetText";
			this.lblMessagetText.Size = new System.Drawing.Size(403, 36);
			this.lblMessagetText.TabIndex = 34;
			this.lblMessagetText.Text = "MessagetText";
			// 
			// FormMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(575, 170);
			this.Controls.Add(this.lblMessagetText);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnYes);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMessageBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Commit Transaction?";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Label lblMessagetText;
	}
}