using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Collections;


namespace WindowsFormsApplication1
{
    public partial class Backup : Form
    {

        public Backup()
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            setFullScreen();

            panel1.Location = new Point(
                 this.ClientSize.Width / 2 - panel1.Size.Width / 2,
                this.ClientSize.Height / 2 - panel1.Size.Height / 2
                );
            panel1.Anchor = AnchorStyles.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string constring = "server=localhost;user=root;database=gallolowa_grocery;Charset=utf8";
                string file = "F:\\Shop\\Gal";
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
                MessageBox.Show("Backup Completed...!");
            }
            catch
            {
                MessageBox.Show("Error..!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string constring = "server=localhost;user=root;database=gallolowa_grocery;Charset=utf8";
                string file = "F:\\Shop\\Gal";
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file);
                            conn.Close();
                        }
                    }
                }
                MessageBox.Show("Successfully Restored...!");
            }
            catch
            {
                MessageBox.Show("Error..!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Customer cu = new Customer();
           cu.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Dealer de = new Dealer();
            de.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Reports re = new Reports();
            re.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
            fm.button58.PerformClick();
            fm.textBox4.Focus();
        }
    }
}
