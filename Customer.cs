using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //MySqlConection

namespace WindowsFormsApplication1
{
    public partial class Customer : Form
    {

        public Customer()
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
            double  Customer_No;
            double max;
            String Max;
            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = "SELECT MAX(Customer_No) FROM customer_details";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

            MyConn2.Open();
            Max = MyCommand2.ExecuteScalar().ToString();
            max = Convert.ToDouble(Max);

            MyConn2.Close();

            Customer_No = max + 1;
            textBox1.Text = Customer_No.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox9.Clear();
            dataGridView1.DataSource = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = "insert into customer_details(Customer_No,Customer_Name,Customer_Cat,Address,Contact_No,Sub_Balance,Balance_Limit) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox8.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','"+this.textBox9.Text+"');";
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = "delete from customer_details where Customer_No='" + this.textBox1.Text + "';";
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = "update customer_details set Customer_Cat='" + this.textBox8.Text + "',Contact_No='" + this.textBox4.Text + "',Balance_Limit='" + this.textBox9.Text + "'where Customer_No='" + this.textBox1.Text + "';";
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

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox6.Text != " ")

            {
                try
                {
                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Customer_No as 'Customer No',Customer_Name as  'Customer Name',Customer_Cat as 'Customer Cat',Address as 'Address',Contact_No as 'Contact No',Sub_Balance as 'Balance',Balance_Limit as 'Balance_Limit' from customer_details WHERE Customer_No LIKE '%" + textBox6.Text + "%' || Customer_Name LIKE '%" + textBox6.Text + "%';");
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

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            dataGridView1.DataSource = null;
        }

     

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox9.Clear();
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox8.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (textBox6.Text != "")
            {
                try
                {

                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Customer_No as 'Customer No',Customer_Name as  'Customer Name',Customer_Cat as 'Customer Cat',Address as 'Address',Contact_No as 'Contact No',Sub_Balance as 'Balance' from customer_details WHERE Customer_Name LIKE '%" + textBox6.Text + "%';");
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
                catch {
                    MessageBox.Show("Invalid Name");
                }
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
             
                button2.Focus();
            }
           
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
                textBox8.Focus();

           
            }
           
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
           
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
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
                textBox5.Focus();
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
                    string Query = ("select Customer_No as 'Customer No',Customer_Name as  'Customer Name',Customer_Cat as 'Customer Cat',Address as 'Address',Contact_No as 'Contact No',Sub_Balance as 'Balance',Balance_Limit as 'Balance_Limit' from customer_details");
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
                    
                }
            }

        private void Customer_Load(object sender, EventArgs e)
        {

            setFullScreen();

            panel2.Location = new Point(
                 this.ClientSize.Width / 2 - panel2.Size.Width / 2,
                this.ClientSize.Height / 2 - panel2.Size.Height / 2
                );
            panel2.Anchor = AnchorStyles.Top;
            
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

        private void button18_Click(object sender, EventArgs e)
        {

            Dealer de = new Dealer();
            de.Show();
            this.Hide();

        }

        private void button14_Click(object sender, EventArgs e)
        {

            Customer cu = new Customer();
            cu.Show();
            this.Hide();

        }

        private void button15_Click(object sender, EventArgs e)
        {

            Dealer de = new Dealer();
            de.Show();
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

