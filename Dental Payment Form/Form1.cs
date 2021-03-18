using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Payment_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calc()
        {
            const int caoVoiPrice = 100_000;
            const int tayTrangPrice = 1200_000;
            const int chupHinhRangPrice = 200_000;
            const int tramRangPrice = 80_000;

            int sum = 0;
            if (cbCaoVoi.Checked)
            {
                sum += caoVoiPrice;
            }

            if (cbTayTrang.Checked)
            {
                sum += tayTrangPrice;
            }

            if (cbChupHinhRang.Checked)
            {
                sum += chupHinhRangPrice;
            }

            sum += Convert.ToInt32(numTramRang.Value) * tramRangPrice;

            txtTotalPrice.Text = "$" + sum / 1000 + ".000";
        }

        private void cbCaoVoi_CheckedChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void cbTayTrang_CheckedChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calc();
        }

        private void numTramRang_ValueChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi " + txtCustomerName.Text + ", your total price: " + txtTotalPrice.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbChupHinhRang_CheckedChanged(object sender, EventArgs e)
        {
            calc();
        }
    }
}
