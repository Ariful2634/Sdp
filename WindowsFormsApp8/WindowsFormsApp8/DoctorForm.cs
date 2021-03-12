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
    public partial class DoctorForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arifu\OneDrive\Documents\HospitalManagementsystem.mdf;Integrated Security=True;Connect Timeout=30");
        public DoctorForm()
        {
            InitializeComponent();
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            populate();
        }
       
            private void populate()
        {
            con.Open();
            string query = "select * from DoctorTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DoctorGridView.DataSource = ds.Tables[0];
            con.Close();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DocId.Text == "" || DocName.Text == "" || DocPass.Text == "" || DocExp.Text == "")
                MessageBox.Show("No Empty Fill Accepted");
            else
            {
                con.Open();
                string query = "insert into DoctorTbl values(" + DocId.Text + ",'" + DocName.Text + "'," + DocExp.Text + ",'" + DocPass.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Successfully Added");
                con.Close();
                populate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DocId.Text == "")
                MessageBox.Show("Enter The Doctor Id");
            else
            {
                con.Open();
                string query = "delete from DoctorTbl where DocId=" + DocId.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Successfully Deleted");
                con.Close();
                populate();
            }
        }

        private void DoctorGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DocId.Text = DoctorGridView.SelectedRows[0].Cells[0].Value.ToString();
            DocName.Text = DoctorGridView.SelectedRows[0].Cells[1].Value.ToString();
            DocExp.Text = DoctorGridView.SelectedRows[0].Cells[2].Value.ToString();
            DocPass.Text = DoctorGridView.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update DoctorTbl set DocName = '" + DocName.Text + "',DocExp ='" + DocExp.Text + "',DocPass='" + DocPass.Text + "' where DocId=" + DocId.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor Successfully updated");
            con.Close();
            populate();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DocPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void DocExp_TextChanged(object sender, EventArgs e)
        {

        }

        private void DocName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DocId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
