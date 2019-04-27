using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
	public partial class FunnyPicform : Form
	{
		public FunnyPicform()
		{
			InitializeComponent();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			pictureBox1.Visible = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
