using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void setFullScreen()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Location = new Point(0, 0);
            Size = new Size(x, y);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string username = "admin";
            string password = "1234";
            if (textBox1.Text == username && textBox2.Text == password)
            {
                
                Home H = new Home();
                H.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Enter Correct Username or Password");
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panel3.Location = new Point(
                 this.ClientSize.Width / 2 - panel3.Size.Width / 2,
                this.ClientSize.Height / 2 - panel3.Size.Height / 2
                );
           panel3.Anchor = AnchorStyles.Top;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }

        }
    }
}
