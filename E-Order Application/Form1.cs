using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Order_Application
{
    public partial class Form1 : Form
    {
        private const int tablesNum = 4;
        private Hashtable tables;

        public Form1()
        {
            InitializeComponent();
            InitCbTables();
        }

        private void InitCbTables()
        {
            tables = new Hashtable();
            for (int i = 1; i <= tablesNum; i++)
            {
                string tableName = "Table-" + i;
                cbTables.Items.Add(tableName);
                cbTables.SelectedIndex = 0;

                tables.Add(tableName, new Hashtable());
            }
        }

        private void RenderFoods()
        {
            dataGridView1.DataSource = getCurrentFoods().Cast<DictionaryEntry>()
                .Select(x => new { Food_Name = x.Key.ToString(), Quantity = x.Value.ToString() }).ToList();
        }

        private Hashtable getCurrentFoods()
        {
            int i = cbTables.SelectedIndex;
            return (Hashtable)tables[cbTables.Items[i].ToString()];
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            string foodName = btnClicked.Text;

            Hashtable _foods = getCurrentFoods();

            if (_foods.ContainsKey(foodName))
            {
                _foods[foodName] = Convert.ToInt32(_foods[foodName]) + 1;
            }
            else
            {
                _foods[foodName] = 1;
            }

            int i = cbTables.SelectedIndex;
            tables[cbTables.Items[i].ToString()] = _foods;
            RenderFoods();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Hashtable _foods = getCurrentFoods();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                _foods.Remove(row.Cells[0].Value.ToString());
            }
            int i = cbTables.SelectedIndex;
            tables[cbTables.Items[i].ToString()] = _foods;
            RenderFoods();
        }

        private void cbTables_Click(object sender, EventArgs e)
        {
            RenderFoods();
        }

        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RenderFoods();
            }
            catch (Exception)
            {

            }
        }
    }
}
