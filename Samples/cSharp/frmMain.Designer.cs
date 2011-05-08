namespace cSharp
{
	partial class frmMain
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
			this.grpSubGroup = new System.Windows.Forms.GroupBox();
			this.CheckBox1 = new System.Windows.Forms.CheckBox();
			this.grpOtherGroup = new System.Windows.Forms.GroupBox();
			this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.grpGroup1 = new System.Windows.Forms.GroupBox();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.txtData = new System.Windows.Forms.TextBox();
			this.grpSubGroup.SuspendLayout();
			this.grpOtherGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
			this.grpGroup1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpSubGroup
			// 
			this.grpSubGroup.Controls.Add(this.CheckBox1);
			this.grpSubGroup.Location = new System.Drawing.Point(11, 45);
			this.grpSubGroup.Name = "grpSubGroup";
			this.grpSubGroup.Size = new System.Drawing.Size(95, 53);
			this.grpSubGroup.TabIndex = 3;
			this.grpSubGroup.TabStop = false;
			this.grpSubGroup.Text = "SubGroup";
			// 
			// CheckBox1
			// 
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Location = new System.Drawing.Point(7, 20);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new System.Drawing.Size(81, 17);
			this.CheckBox1.TabIndex = 0;
			this.CheckBox1.Text = "CheckBox1";
			this.CheckBox1.UseVisualStyleBackColor = true;
			// 
			// grpOtherGroup
			// 
			this.grpOtherGroup.Controls.Add(this.NumericUpDown1);
			this.grpOtherGroup.Location = new System.Drawing.Point(12, 123);
			this.grpOtherGroup.Name = "grpOtherGroup";
			this.grpOtherGroup.Size = new System.Drawing.Size(119, 56);
			this.grpOtherGroup.TabIndex = 7;
			this.grpOtherGroup.TabStop = false;
			this.grpOtherGroup.Text = "Other Group";
			// 
			// NumericUpDown1
			// 
			this.NumericUpDown1.Location = new System.Drawing.Point(11, 20);
			this.NumericUpDown1.Name = "NumericUpDown1";
			this.NumericUpDown1.Size = new System.Drawing.Size(95, 20);
			this.NumericUpDown1.TabIndex = 0;
			// 
			// grpGroup1
			// 
			this.grpGroup1.Controls.Add(this.grpSubGroup);
			this.grpGroup1.Controls.Add(this.TextBox1);
			this.grpGroup1.Location = new System.Drawing.Point(12, 12);
			this.grpGroup1.Name = "grpGroup1";
			this.grpGroup1.Size = new System.Drawing.Size(119, 105);
			this.grpGroup1.TabIndex = 8;
			this.grpGroup1.TabStop = false;
			this.grpGroup1.Text = "The Group";
			// 
			// TextBox1
			// 
			this.TextBox1.Location = new System.Drawing.Point(6, 19);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(100, 20);
			this.TextBox1.TabIndex = 2;
			this.TextBox1.Text = "Some text";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(137, 41);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "> Save >";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(137, 12);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 23);
			this.btnOpen.TabIndex = 5;
			this.btnOpen.Text = "< Open <";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// txtData
			// 
			this.txtData.Location = new System.Drawing.Point(218, 12);
			this.txtData.Multiline = true;
			this.txtData.Name = "txtData";
			this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtData.Size = new System.Drawing.Size(309, 167);
			this.txtData.TabIndex = 4;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(539, 189);
			this.Controls.Add(this.grpOtherGroup);
			this.Controls.Add(this.grpGroup1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.txtData);
			this.Name = "frmMain";
			this.Text = "C# SimpleD Sample";
			this.grpSubGroup.ResumeLayout(false);
			this.grpSubGroup.PerformLayout();
			this.grpOtherGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
			this.grpGroup1.ResumeLayout(false);
			this.grpGroup1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.GroupBox grpSubGroup;
		internal System.Windows.Forms.CheckBox CheckBox1;
		internal System.Windows.Forms.GroupBox grpOtherGroup;
		internal System.Windows.Forms.NumericUpDown NumericUpDown1;
		internal System.Windows.Forms.GroupBox grpGroup1;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.Button btnOpen;
		internal System.Windows.Forms.TextBox txtData;
	}
}

