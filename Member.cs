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
namespace OrganizationManagement
{
    public partial class Member : Form
    {
        public Member(string teamIdSelected)
        {
            
            InitializeComponent();
            
            string connectionString = @"Data Source=DESKTOP-VTGGSL9;Initial Catalog=hw_db;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            String query = "SELECT * FROM Member WHERE TeamId = " + teamIdSelected;
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            this.hw_dbDataSet.Clear();

            this.memberBindingSource.Filter = string.Format("TeamId = "+ teamIdSelected);
            //adapter.Fill(this.hw_dbDataSet);
            this.memberTableAdapter.Fill(this.hw_dbDataSet.Member);
            
            Console.WriteLine(query);
            
            conn.Close();
        }

        private void memberBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.memberBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hw_dbDataSet);

        }

        private void Member_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hw_dbDataSet.Member' table. You can move, or remove it, as needed.
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void memberDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
