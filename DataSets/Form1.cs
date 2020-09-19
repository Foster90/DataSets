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
using Newtonsoft.Json;
using System.IO;

namespace DataSets
{
    public partial class Form1 : Form




    {
        string sConnectionString = "Data Source=LT15784\\SQLEXPRESS;Initial Catalog=test_DB;Integrated Security=True";
        DataTable dtbl;
       


        static DataTable dbmethod(string sConnectionString, DataTable datatable, DataGridView datagrid)

        {
            using (SqlConnection sqlCon = new SqlConnection(sConnectionString))

            {


                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM TestTable", sqlCon);
                datatable = new DataTable();
                sqlDa.Fill(datatable);


                datagrid.DataSource = datatable;

                return datatable;

            }

           
        }


        static void dbmethod2(string sConnectionString, DataTable datatable)

        {
            using (SqlConnection sqlCon = new SqlConnection(sConnectionString))

            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM TestTable", sqlCon);
                sqlDa.Fill(datatable);
                 
            }
            
        }



        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dbmethod(sConnectionString, dtbl, dataGridView1);


            DataTable dtbl2 = new DataTable();
            dbmethod2(sConnectionString, dtbl2);
            var datarow = dtbl2.AsEnumerable().Where(x => x.Field<int>("Field1") > 50);
            DataView view = datarow.AsDataView();

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = view;

            comboBox1.DataSource = bindingSource1.DataSource;
            comboBox1.DisplayMember = "Field3";

        }

           
        private void button1_Click(object sender, EventArgs e)
        {
            dbmethod(sConnectionString, dtbl, dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            dtbl = dbmethod(sConnectionString, dtbl, dataGridView1);
            DataView DV = new DataView(dtbl);
            DV.RowFilter = string.Format("TestTableID = '{0}'", textBox1.Text);
            dataGridView1.DataSource = DV;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataTable dtbl2  = new DataTable();
            dbmethod2(sConnectionString, dtbl2);

            var datarow = dtbl2.AsEnumerable().Where(x => x.Field<int>("Field1") > 50);
            DataView view = datarow.AsDataView();


            dataGridView2.DataSource = view;




        }

        private void button3_Click(object sender, EventArgs e)
        {

            var ds = dbmethod(sConnectionString, dtbl, dataGridView1);

            string JSONresult = JsonConvert.SerializeObject(ds);

            string path = @"C:\json\export.json";
          

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                
            }

            MessageBox.Show("Exported to " +  path);

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            string path = @"C:\json\export.json";

            using (StreamReader sr = File.OpenText(path))
            {
                var obj = JsonConvert.DeserializeObject<DataTable>(sr.ReadToEnd());
                                
                dataGridView3.DataSource = obj;
            }


        }
        

    }
}
