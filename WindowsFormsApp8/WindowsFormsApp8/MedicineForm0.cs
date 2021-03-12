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
    public partial class MedicineForm0 : Form
    {
        public MedicineForm0()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arifu\OneDrive\Documents\HospitalManagementsystem.mdf;Integrated Security=True;Connect Timeout=30");
        private void MedicineForm0_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MedicineId.Text == "" || MedicineName.Text == "" || MedicineUnit.Text == "" || Price.Text == "" )
                MessageBox.Show("No Empty Fill Accepted");
            else
            {
                con.Open();
                string query = "insert into MedicineTb0 values(" + MedicineId.Text + ",'" + MedicineName.Text + "','" + MedicineUnit.Text + "','" + Price.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Successfully Added");
                con.Close();
               populate();
            }
        }

        private void DoctorGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MedicineId.Text = DoctorGridView.SelectedRows[0].Cells[0].Value.ToString();
            MedicineName.Text = DoctorGridView.SelectedRows[0].Cells[1].Value.ToString();
            MedicineUnit.Text = DoctorGridView.SelectedRows[0].Cells[2].Value.ToString();
            Price.Text = DoctorGridView.SelectedRows[0].Cells[3].Value.ToString();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from MedicineTb0";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DoctorGridView.DataSource = ds.Tables[0];
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update MedicineTb0 set MediName = '" + MedicineName.Text + "',MediUnit ='" + MedicineUnit.Text + "',Price='" + Price.Text + "' where MediId=" + MedicineId.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Medicine Successfully updated");
            con.Close();
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MedicineId.Text == "")
                MessageBox.Show("Enter The Doctor Id");
            else
            {
                con.Open();
                string query = "delete from MedicineTb0 where MediId=" + MedicineId.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Successfully Deleted");
                con.Close();
                populate();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home hom = new Home();
            hom.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }
    }
}
