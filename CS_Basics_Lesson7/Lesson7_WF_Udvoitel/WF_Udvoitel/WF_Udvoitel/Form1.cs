using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Udvoitel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            btnCommand1.Text = "+1";
            btnCommand2.Text = "*2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "0";
            this.Text = "Удвоитель";
            lblCounter.Text = "0";
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            lblCounter.Text = (int.Parse(lblCounter.Text) + 1).ToString();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            lblCounter.Text = (int.Parse(lblCounter.Text) + 1).ToString();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "1";
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int gameNumber = rnd.Next(50, 1000);
            MessageBox.Show("Ваша задача получить число " + gameNumber + " с минимальным количеством операций.", "Внимание!", MessageBoxButtons.OK);
            lblGameNumber.Text = gameNumber.ToString();
        }

        private void lblCounter_Click(object sender, EventArgs e)
        {

        }

        private void lblNumber_Click(object sender, EventArgs e)
        {

        }
    }
}
