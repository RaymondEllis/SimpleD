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

		private void btnFromString_Click(object sender, EventArgs e)
		{
			SimpleD.Group MainGroup = new SimpleD.Group();
			//Open from the string.
			txtErrors.Text = MainGroup.FromString(txtData.Text);

			try
			{
				//Get The Group
				Group TheGroup = MainGroup.GetGroup("the group"); //Names are not case sensitive.

				//Get the value from the group.
				TextBox1.Text = TheGroup.GetValue(TextBox1.Name);

				//Get sub group.
				Group SubGroup = TheGroup.GetGroup("SubGroup");
				CheckBox1.Checked =bool.Parse(SubGroup.GetValue("The check box"));

				//Get the other group.
				Group OtherGroup = MainGroup.GetGroup("OtherGroup");
				NumericUpDown1.Value = Decimal.Parse(OtherGroup.GetValue(NumericUpDown1.Name));

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message,"Error");
			}

		}

		private void btnToString_Click(object sender, EventArgs e)
		{
			SimpleD.Group MainGroup = new SimpleD.Group();

			//The Group
			Group TheGroup = MainGroup.CreateGroup("The Group"); //Create group inside MainGroup.
			TheGroup.SetValue(TextBox1.Name, TextBox1.Text); 

			//Sub group
			Group SubGroup = TheGroup.CreateGroup("SubGroup"); //Create the sub group from 'The Group'
			SubGroup.SetValue("The check box", CheckBox1.Checked.ToString()); //Yes there can be spaces in group and property names.

			//Other group    There is nothing new here.
			Group OtherGroup = MainGroup.CreateGroup("OtherGroup");
			OtherGroup.BraceStyle = Group.Style.NoStyle; //Set the style.
			OtherGroup.SetValue(NumericUpDown1.Name, NumericUpDown1.Value.ToString());

			//Save to the data text box.
			txtData.Text = MainGroup.ToString();
		}
	}
}
