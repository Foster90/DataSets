using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataSets
{
    public partial class Form1 : Form

        
    {
        string sConnectionString = "Data Source=LT15784\\SQLEXPRESS;Initial Catalog=test_DB;Integrated Security=True";
        DataTable dtbl;

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(sConnectionString))

            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM TestTable",sqlCon);
                dtbl = new DataTable();
                sqlDa.Fill(dtbl);


                dataGridView1.DataSource = dtbl;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dtbl);
            DV.RowFilter = string.Format("TestTableID = '{0}'", textBox1.Text);
            dataGridView1.DataSource = DV;

        }
    }
}
