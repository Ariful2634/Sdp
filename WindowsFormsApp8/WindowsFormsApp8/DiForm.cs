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
    public partial class DiForm : Form
    {
        public DiForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arifu\OneDrive\Documents\HospitalManagementsystem.mdf;Integrated Security=True;Connect Timeout=30");
        void populatecombo()
        {
            string sql = "select * from PatientTbl";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr;
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("PatId", typeof(int));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                PatIdCb.ValueMember = "PatId";
                PatIdCb.DataSource = dt;
                con.Close();

            }
            catch
            {
            }
        }
        string patname;
        void fecthpatientname()
        {
            try
            {
                con.Open();
                string mysql = "select * from PatientTbl ";
                SqlCommand cmd = new SqlCommand(mysql, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    patname = dr["PatName"].ToString();
                    PName.Text = patname;
                }
                con.Close();
            }
            catch
            {

            }
            
        }
        private void populate()
        {
            con.Open();
            string query = "select * from DiTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DiagnosisGV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void DiForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fecthpatientname();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (DiagId.Text == "" || SymptomsTb.Text == "" || DiaTb.Text == "" || PName.Text == "" || medtb.Text == "")
                MessageBox.Show("No Empty Fill Accepted");
            else
            {
                con.Open();
                string query = "insert into DiTbl values('" + DiagId.Text + "','" + PatIdCb.SelectedValue.ToString() + "','" + PName.Text + "','" + SymptomsTb.Text + "','" + DiaTb.Text + "','" + medtb.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis Successfully Added");
                con.Close();
                populate();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            fecthpatientname();
            populatecombo();
            populate();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DiagnosisGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
           
            string query = "update DiTbl set PatId = '" + PatIdCb.SelectedValue.ToString() + "',PatNmae ='" + PName.Text + "',Symptoms='" + SymptomsTb.Text + "',Diagnosis='" + DiaTb.Text + "',Medicines='" + medtb.Text + "'where DiagId= '" + DiagId.Text + "';";
          
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Diagnosis Successfully updated");
            con.Close();
            populate();
        
    }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DiagId.Text == "")
                MessageBox.Show("Enter The Diagnosis Id");
            else
            {
                con.Open();
                string query = "delete from DiTbl where DiagId=" + DiagId.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis Successfully Deleted");
                con.Close();
                populate();
            }
        }
    }
}
