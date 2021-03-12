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

namespace WindowsFormsApp8
{
    public partial class ComplainForm2 : Form
    {
        public ComplainForm2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arifu\OneDrive\Documents\HospitalManagementsystem.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {

            if (complainD.Text == "" )
                MessageBox.Show("No Empty Fill Accepted");
            else
            {
                con.Open();
                string query = "insert into ComplainTb values('" + ComplainCombo.Text + "','" + complainD.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thank You Sir For Your Compalain . We Will try to improve our service");
                con.Close();
               populate();
            }
        }

        private void ComplainForm2_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from ComplainTb";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DoctorGridView.DataSource = ds.Tables[0];
            con.Close();

        }

        private void DoctorGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           ComplainCombo.Text = DoctorGridView.SelectedRows[0].Cells[0].Value.ToString();
           complainD.Text = DoctorGridView.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
