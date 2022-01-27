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
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-VTGGSL9;Initial Catalog=hw_db;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();// open the database connection
            SqlCommand getMaxIdCommand = new SqlCommand("SELECT MAX(MemberId) FROM Team;", conn);
            SqlDataReader reader = getMaxIdCommand.ExecuteReader();
            int maxTeamId = 0;
            while (reader.Read())
            {
                // Check if first element
                if (reader.IsDBNull(0))
                    maxTeamId = 0;
                else
                {
                    maxTeamId = reader.GetInt32(0);
                }

            }
            reader.Close();

            Console.WriteLine(maxTeamId);
            Console.WriteLine(textBox1.Text);
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Team (TeamId,TeamName,LeaderName) Values(@0, @1, @2);", conn);
            insertCommand.Parameters.Add(new SqlParameter("0", maxTeamId + 1));
            insertCommand.Parameters.Add(new SqlParameter("1", textBox1.Text));
            insertCommand.Parameters.Add(new SqlParameter("2", textBox1.Text));
            insertCommand.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }
    }
}
