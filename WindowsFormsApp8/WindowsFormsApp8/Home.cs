using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login h = new Login();
            h.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DoctorForm doct = new DoctorForm();
            doct.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PatientForm pat = new PatientForm();
            pat.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DiForm di = new DiForm();
            di.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MedicineForm0 medi = new MedicineForm0();
            medi.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PaymentForm2 pay = new PaymentForm2();
            pay.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            EmergencyForm2 eme = new EmergencyForm2();
            eme.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ComplainForm2 com = new ComplainForm2();
            com.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            AboutUsForm ab = new AboutUsForm();
            ab.Show();
            this.Hide();
        }
    }
}
