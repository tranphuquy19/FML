using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security_Panel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button numBtn = (Button)sender;

            txtPasscode.Text += numBtn.Text;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtPasscode.Text = "";
        }

        private void btnSharp_Click(object sender, EventArgs e)
        {
            string accessLog = DateTime.Now.ToString("MM/dd/yyyy h:mm tt") + "\t";

            switch (txtPasscode.Text)
            {
                case "1645":
                case "1689":
                    accessLog += "Technicians";
                    break;
                case "8345":
                    accessLog += "Custodians";
                    break;
                case "9998":
                case "1006":
                case "1007":
                case "1008":
                    accessLog += "Scientist";
                    break;
                default:
                    accessLog += "Restricted Access!";
                    break;
            }

            txtPasscode.Text = "";
            lsLog.Items.Add(accessLog);
        }
    }
}
