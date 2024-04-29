namespace POS_Fiftea
{
	partial class FormSize
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
			this.btnRegular = new System.Windows.Forms.Button();
			this.btnLarge = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnRegular
			// 
			this.btnRegular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.btnRegular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRegular.ForeColor = System.Drawing.Color.Transparent;
			this.btnRegular.Location = new System.Drawing.Point(95, 43);
			this.btnRegular.Margin = new System.Windows.Forms.Padding(4);
			this.btnRegular.Name = "btnRegular";
			this.btnRegular.Size = new System.Drawing.Size(171, 105);
			this.btnRegular.TabIndex = 31;
			this.btnRegular.Text = "Regular";
			this.btnRegular.UseVisualStyleBackColor = false;
			this.btnRegular.Click += new System.EventHandler(this.btnRegular_Click);
			// 
			// btnLarge
			// 
			this.btnLarge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.btnLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLarge.ForeColor = System.Drawing.Color.Transparent;
			this.btnLarge.Location = new System.Drawing.Point(309, 43);
			this.btnLarge.Margin = new System.Windows.Forms.Padding(4);
			this.btnLarge.Name = "btnLarge";
			this.btnLarge.Size = new System.Drawing.Size(171, 105);
			this.btnLarge.TabIndex = 32;
			this.btnLarge.Text = "Large";
			this.btnLarge.UseVisualStyleBackColor = false;
			this.btnLarge.Click += new System.EventHandler(this.btnLarge_Click);
			// 
			// FormSize
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 185);
			this.Controls.Add(this.btnLarge);
			this.Controls.Add(this.btnRegular);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSize";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Please select option:";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnRegular;
		private System.Windows.Forms.Button btnLarge;
	}
}