using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;          //Library
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Data_Collector
{
    public partial class Form1 : Form
    {
        Customer customer = new Customer();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer.CusId = textBox1.Text;
            customer.ComName = textBox2.Text;
            customer.ConName= textBox3.Text;
            customer.Phone = textBox4.Text;
            var success = customer.InsertCustomer(customer);
            if (success)
            {

                MessageBox.Show("Customer Data Saved");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = customer.ShowCustomer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            customer.CusId= textBox1.Text;
            customer.ComName = textBox2.Text;
            customer.ConName = textBox3.Text;
            customer.Phone = textBox4.Text;
            var success = customer.UpdateCustomer(customer);
            if (success)
            {
                MessageBox.Show("Customer Data Updated");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            customer.CusId= textBox8.Text;
            var success = customer.DeleteCustomer(customer);
            if (success)
            {
                MessageBox.Show("Customer Data Deleted");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
