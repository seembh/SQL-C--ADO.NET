using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void teamBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.teamBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hw_dbDataSet);

        }

        private void Navigation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hw_dbDataSet.Team' table. You can move, or remove it, as needed.
            this.teamTableAdapter.Fill(this.hw_dbDataSet.Team);

        }

        private void teamDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            Console.WriteLine(e.RowIndex);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form newTeam = new NewTeam();
            newTeam.ShowDialog();
            this.teamTableAdapter.Fill(this.hw_dbDataSet.Team);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string teamIdSelected = teamDataGridView.Rows[teamDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
            //Console.WriteLine(teamIdSelected);
            string connectionString = @"Data Source=DESKTOP-VTGGSL9;Initial Catalog=hw_db;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();// open the database connection  

            SqlCommand deleteCommand = new SqlCommand("DELETE FROM Team WHERE TeamId = " + teamIdSelected, conn);
            deleteCommand.ExecuteNonQuery();
            conn.Close();
            //this.Close();
            this.teamTableAdapter.Fill(this.hw_dbDataSet.Team);

        }

        private void teamDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string teamIdSelected = teamDataGridView.Rows[teamDataGridView.CurrentCell.RowIndex].Cells[0].Value.ToString();
            Form memberForm = new Member(teamIdSelected);
            memberForm.ShowDialog();
        }
    }
}
