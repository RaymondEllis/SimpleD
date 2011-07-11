using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleD;

namespace cSharp
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			SimpleD.Group MainGroup = new SimpleD.Group();
			//Open from the string.
			MainGroup.FromString(txtData.Text);

			Group g;

			try
			{
				//Get The Group
				g = MainGroup.GetGroup("the group"); //Names are not case sensitive.

				//Get the value from the group.
				TextBox1.Text = g.GetValue(TextBox1.Name);

				//Get sub group.
				g = g.GetGroup("SubGroup");
				CheckBox1.Checked =bool.Parse(g.GetValue("The check box"));

				//Get the other group.
				g = MainGroup.GetGroup("OtherGroup");
				NumericUpDown1.Value = Decimal.Parse(g.GetValue(NumericUpDown1.Name));

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SimpleD.Group MainGroup = new SimpleD.Group();

			Group g;
			//The Group
			g = MainGroup.CreateGroup("The Group"); //Create group inside MainGroup.
			g.SetValue(TextBox1.Name, TextBox1.Text); 

			//Sub group
			g = g.CreateGroup("SubGroup"); //Create the sub group from 'The Group'
			g.SetValue("The check box", CheckBox1.Checked.ToString()); //Yes there can be spaces in group and property names.

			//Other group    There is nothing new here.
			g = MainGroup.CreateGroup("OtherGroup");
			g.SetValue(NumericUpDown1.Name, NumericUpDown1.Value.ToString());

			//Save to the data text box.
			txtData.Text = MainGroup.ToString();

		}
	}
}
