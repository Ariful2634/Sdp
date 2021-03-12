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
    public partial class EmergencyForm2 : Form
    {
        public EmergencyForm2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arifu\OneDrive\Documents\HospitalManagementsystem.mdf;Integrated Security=True;Connect Timeout=30");
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into EmergencyTb values('" + EmNameTb.Text + "','" + EmPhoneTb.Text + "','" + CatCombo.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully");
                con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void EmergencyForm2_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update EmergencyTb set EmName='" + EmNameTb.Text + "', EmCategory = '" + CatCombo.Text + "'where EmPhone = '" + EmPhoneTb.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Emergency Update Successfully");
                con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmPhoneTb.Text == "")
            {
                MessageBox.Show("Enter The Number to Delete");
            }
            else
            {
                con.Open();
                string query = "delete from EmergencyTb where EmPhone=" + EmPhoneTb.Text + ";";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Number Deleted Successfully");
                con.Close();
                populate();
            }
        }

        private void DoctorGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmNameTb.Text = EmDgv.SelectedRows[0].Cells[0].Value.ToString();
            EmPhoneTb.Text = EmDgv.SelectedRows[0].Cells[1].Value.ToString();
            CatCombo.Text = EmDgv.SelectedRows[0].Cells[2].Value.ToString();
        }
        void filterbycategory()
        {
            try
            {
                con.Open();
                string query = "select* from EmergencyTb where EmCategory='" + SearchCombo.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);

                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                EmDgv.DataSource = ds.Tables[0];
                con.Close();

            }
            catch
            {

            }
        }
        void populate()
        {
            try
            {
                con.Open();
                string query = "select* from EmergencyTb";
                SqlDataAdapter da = new SqlDataAdapter(query, con);

                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                EmDgv.DataSource = ds.Tables[0];
                con.Close();

            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filterbycategory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Hide();
        }
    }
}
