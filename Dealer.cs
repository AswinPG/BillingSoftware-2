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

namespace WindowsFormsApplication1
{
    public partial class Dealer : Form
    {


        public Dealer()
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

        private void button7_Click(object sender, EventArgs e)
        {
            double Dealer_No = 0;
           double  max;
            String Max;
            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = "SELECT MAX(Dealer_No) FROM dealer_details";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

            MyConn2.Open();
            Max = MyCommand2.ExecuteScalar().ToString();
            max = Convert.ToDouble(Max);

            MyConn2.Close();

            Dealer_No = max + 1;
            textBox1.Text = Dealer_No.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                try
                {
                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Dealer_No as 'Dealer No',Dealer_Name as  'Dealer Name',Address as 'Address',Dealer_Type as 'Dealer_Type',Contact_Person as 'Contact_Person',Contact_No as 'Contact No',Balance as 'Balance' from dealer_details WHERE Dealer_Name LIKE '%" + textBox6.Text + "%';");
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand2;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    dataGridView1.DataSource = dTable;


                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                        col.DefaultCellStyle.Font = new Font("Arial", 13F, GraphicsUnit.Pixel);
                    }

                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();


                }

                catch
                {
                    MessageBox.Show("Invalid Name");
                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                try
                {

                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Dealer_No as 'Dealer No',Dealer_Name as  'Dealer Name',Address as 'Address',Dealer_Type as 'Dealer_Type',Contact_Person as 'Contact_Person',Contact_No as 'Contact No',Balance as 'Balance' from dealer_details WHERE Dealer_No LIKE '%" + textBox6.Text + "%' || Dealer_Name LIKE '%" + textBox6.Text + "%';");
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand2;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    dataGridView1.DataSource = dTable;


                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                        col.DefaultCellStyle.Font = new Font("Arial", 13F, GraphicsUnit.Pixel);
                    }

                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();

                }

                catch
                {
                    MessageBox.Show("Invalid No");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();

            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = row.Cells[3].Value.ToString();
                textBox7.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
                textBox5.Text = row.Cells[6].Value.ToString();

            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox6.Clear();
            dataGridView1.DataSource = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox6.Clear();
            dataGridView1.DataSource = null;
            comboBox1.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = "insert into dealer_details(Dealer_No,Dealer_Name,Address,Dealer_Type,Contact_Person,Contact_No,Balance) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.comboBox1.Text + "','" + this.textBox7.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "');";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Save Data");

                while (MyReader2.Read())
                {

                }

                MyConn2.Close();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = "delete from dealer_details where Dealer_No='" + this.textBox1.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MySqlDataReader MyReader2;

                MyConn2.Open();

                MyReader2 = MyCommand2.ExecuteReader();

                MessageBox.Show("Successfully Deleted");

                while (MyReader2.Read())
                {

                }

                MyConn2.Close();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = "update dealer_details set Dealer_Type='" + this.comboBox1.Text + "',Contact_Person='" + this.textBox7.Text + "',Contact_No='" + this.textBox4.Text + "',Balance='" + this.textBox5.Text + "'where Dealer_No='" + this.textBox1.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Successfully Updated");

                while (MyReader2.Read())
                {

                }

                MyConn2.Close();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            dataGridView1.DataSource = null;
            FormCollection fc = Application.OpenForms;

            foreach (Form1 fm in fc)
            {
                MessageBox.Show("Hello");
            }
            this.Hide();
            Home hm = new Home();
            hm.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                //  button15.PerformClick();
                //button2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
                //  button15.PerformClick();

            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
                //  button15.PerformClick();

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
                //  button15.PerformClick();

            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
                
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }

        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5.PerformClick();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
             try
                {

                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Dealer_No as 'Dealer No',Dealer_Name as  'Dealer Name',Address as 'Address',Dealer_Type as 'Dealer_Type',Contact_Person as 'Contact_Person',Contact_No as 'Contact No',Balance as 'Balance' from dealer_details");
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand2;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    dataGridView1.DataSource = dTable;


                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                        col.DefaultCellStyle.Font = new Font("Arial", 13F, GraphicsUnit.Pixel);
                    }

                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();

                }

                catch
                {
                   // MessageBox.Show("Invalid No");
                }
            }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Dealer_Load(object sender, EventArgs e)
        {
            setFullScreen();

            panel1.Location = new Point(
                 this.ClientSize.Width / 2 - panel1.Size.Width / 2,
                this.ClientSize.Height / 2 - panel1.Size.Height / 2
                );
            panel1.Anchor = AnchorStyles.Top;

           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
            this.Hide();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Backup bk = new Backup();
            bk.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Reports re = new Reports();
            re.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
            fm.button58.PerformClick();
            fm.textBox4.Focus();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        }
    }
