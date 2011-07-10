using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
			SimpleD.Group sd = new SimpleD.Group();
			//Open from the string.
			sd.FromString(txtData.Text);

			Group g = default(Group);

			try
			{
				//Get The Group
				g = sd.GetGroup("the group"); //Names are not case sensitive.

				//Get the value from the group.
				g.GetValue(TextBox1);

				//Get sub group.
				g = g.GetGroup("SubGroup");
				CheckBox1.Checked =bool.Parse(g.GetValue("The check box"));

				//Get the other group.
				g = sd.GetGroup("OtherGroup");
				NumericUpDown1.Value = Decimal.Parse(g.GetValue(NumericUpDown1.Name));

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SimpleD.Group sd = new SimpleD.Group();

			Group g = default(Group);
			//The Group
			g = sd.CreateGroup("The Group"); //Create group from sd.
			g.SetValue(TextBox1); //Add textbox1   Can use most controls.

			//Sub group
			g = g.CreateGroup("SubGroup"); //Create the sub group from 'The Group'
			g.SetValue("The check box", CheckBox1.Checked.ToString()); //Yes there can be spaces in group and property names.

			//Other group    There is nothing new here.
			g = sd.CreateGroup("OtherGroup");
			g.SetValue(NumericUpDown1);

			//Save to the data text box.
			txtData.Text = sd.ToString();

		}
	}
}
