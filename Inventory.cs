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
    public partial class Inventory : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";

        public Inventory()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox13.Text == "" || comboBox1.Text == "")
            {
                textBox6.Text = comboBox13.Text + comboBox1.Text + "00";

            }
            else
            {
                textBox6.Text = comboBox13.Text + comboBox1.Text + "000";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database= gallolowa_grocery;Charset=utf8";
                string Query = "insert into stock_details(Stock_Code,Item_No,Item_Name,Dealer,Purchase_Stock,Purchase_Price,Unit_Price,Tax,Discount,Ex_Date,Current_Stock,Best_Price,S_Name,Category,Sub_Category) values('" + this.textBox20.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "','" + this.comboBox14.Text + "','" + this.textBox53.Text + "','" + this.textBox55.Text + "','" + this.textBox1.Text + "','" + this.textBox52.Text + "','" + this.textBox56.Text + "','" + this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "','" + this.textBox53.Text + "','" + this.textBox4.Text + "','"+this.textBox13.Text+"','"+this.comboBox13.Text+"','"+this.comboBox1.Text+"');";
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = "delete from stock_details where Item_No='" + this.textBox6.Text + "';";
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.Clear();
            textBox3.Clear();
            textBox13.Clear();
            textBox4.ResetText();
            textBox6.Clear();
            textBox7.Clear();
          //  textBox8.Clear();
            textBox20.Clear();
            textBox52.Clear();
            textBox53.Clear();
            textBox54.Clear();
            textBox55.ResetText();
            textBox56.Clear();
            comboBox1.ResetText();
            comboBox13.ResetText();
            comboBox14.ResetText();
          //  comboBox15.ResetText();
            dateTimePicker1.ResetText();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery;Charset=utf8";
                string Query = "update stock_details set Item_No='" + textBox14.Text + "',Item_Name='" + textBox7.Text + "',S_Name = '" + textBox13.Text + "',Dealer = '" + comboBox14.Text + "',Category='" + comboBox13.Text + "',Sub_Category='" + comboBox1.Text + "',Stock_Code = '"+textBox20.Text+"',Purchase_Stock='"+textBox53.Text+"',Purchase_Price='"+textBox55.Text+"',Unit_Price='"+textBox1.Text+"',Tax='"+textBox52.Text+"',Discount='"+textBox56.Text+"',Best_Price='"+textBox4.Text+"'  where Item_No='" + this.textBox6.Text + "';";
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
        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox5.Text != "")
            {

                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = ("select Item_No as 'Item No',Item_Name as 'Item Name',Dealer as 'Dealer',Stock_Code as 'Stock Code',Purchase_Stock as 'Purchase_Stock',Purchase_Price as 'Purchase_Price',Unit_Price as 'Unit_Price',Best_Price as 'Best_Price',Ex_Date as 'Ex_Date',Current_Stock as 'Current_Stock',(Purchase_Stock-Current_Stock) as 'Sell_Stock',Tax as 'Tax',Discount as 'Discount' from stock_details WHERE Item_Name LIKE '%" + textBox5.Text + "%';");
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

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";

            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dealer deal = new Dealer();
            deal.Show();
            deal.button19.Visible = true;
            deal.button8.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox6.Text = row.Cells[0].Value.ToString();
                textBox7.Text = row.Cells[1].Value.ToString();
                comboBox14.Text = row.Cells[2].Value.ToString();
                textBox20.Text = row.Cells[3].Value.ToString();
                textBox53.Text = row.Cells[4].Value.ToString();
                textBox55.Text = row.Cells[5].Value.ToString();
                textBox1.Text = row.Cells[6].Value.ToString();
                textBox4.Text = row.Cells[7].Value.ToString();
                textBox54.Text = row.Cells[8].Value.ToString();
                textBox3.Text = row.Cells[9].Value.ToString();
                textBox2.Text = row.Cells[10].Value.ToString();
                textBox52.Text = row.Cells[11].Value.ToString();
                textBox56.Text = row.Cells[12].Value.ToString();
                textBox13.Text = row.Cells[13].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
            textBox6.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox20.Clear();
            textBox53.Clear();
            textBox55.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox56.Clear();
            textBox52.Clear();
            comboBox1.ResetText();
            comboBox13.ResetText();
            comboBox14.ResetText();
            dateTimePicker1.ResetText();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (textBox5.Text != "")
            {
                try
                {

                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Item_No as 'Item No',Item_Name as 'Item Name',Dealer as 'Dealer',Stock_Code as 'Stock Code',Purchase_Stock as 'Purchase_Stock',Purchase_Price as 'Purchase_Price',Unit_Price as 'Unit_Price',Best_Price as 'Best_Price',Ex_Date as 'Ex_Date',Current_Stock as 'Current_Stock',(Purchase_Stock-Current_Stock) as 'Sell_Stock',Tax as 'Tax',Discount as 'Discount',S_Name as 'S_Name' from stock_details WHERE Item_No LIKE '%" + textBox5.Text + "%' || Item_Name Like '%" + textBox5.Text + "%';");
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
                    MessageBox.Show("Invalid No or Name");
                }
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = "insert into combo1(Category,Sub_category) values('" + this.textBox9.Text + "','" + this.textBox10.Text + "');";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MySqlParameter Parameters = new MySqlParameter();
                MyConn2.Open();
                //  MyCommand2.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Add successfully!");
                while (MyReader2.Read())
                {

                }
                MyConn2.Close();

                textBox9.Text = "";
                textBox10.Text = "";
            }
            catch
            {
            }

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            setFullScreen();

            panel1.Location = new Point(
                 this.ClientSize.Width / 2 - panel1.Size.Width / 2,
                this.ClientSize.Height / 2 - panel1.Size.Height / 2
                );
            panel1.Anchor = AnchorStyles.Top;
        }

        private void comboBox13_DropDown(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select Category,Sub_Category from combo1";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    comboBox13.DisplayMember = "Category";
                    comboBox13.ValueMember = "Category";
                    comboBox13.DataSource = ds.Tables["com"];
                    //comboBox1.DisplayMember = "Sub_Category";
                    //comboBox1.ValueMember = "Sub_Category";
                    //comboBox1.DataSource = ds.Tables["com"];

                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
            //  textBox6.Text = "";
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select Sub_Category from combo1";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    //comboBox13.DisplayMember = "Category";
                    //comboBox13.ValueMember = "Category";
                    //comboBox13.DataSource = ds.Tables["com"];
                    comboBox1.DisplayMember = "Sub_Category";
                    comboBox1.ValueMember = "Sub_Category";
                    comboBox1.DataSource = ds.Tables["com"];

                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
            // textBox6.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = "insert into combo1(Sub_Category) values('" + this.textBox10.Text + "');";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MySqlParameter Parameters = new MySqlParameter();
            MyConn2.Open();
            //  MyCommand2.Parameters.Add(new MySqlParameter("@IMG", imageBt));
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Add successfully!");
            while (MyReader2.Read())
            {

            }
            MyConn2.Close();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox14_DropDown(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select Dealer_Name from dealer_details";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    //comboBox13.DisplayMember = "Category";
                    //comboBox13.ValueMember = "Category";
                    //comboBox13.DataSource = ds.Tables["com"];
                    comboBox14.DisplayMember = "Dealer_Name";
                    comboBox14.ValueMember = "Dealer_Name";
                    comboBox14.DataSource = ds.Tables["com"];

                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }


        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox13.Focus();

            }

        }

        private void comboBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }

        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox20.Focus();
            }

        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox14.Focus();

            }

        }

        private void comboBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox53.Focus();

            }

        }

        private void textBox53_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox55.Focus();
            }

        }

        private void textBox55_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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
                textBox52.Focus();
            }

        }

        private void textBox52_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox56.Focus();
            }

        }

        private void textBox56_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                button4.Focus();
            }
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.Focus();
            }
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6.Focus();
            }
        }

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button9.PerformClick();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
                 try
                {

                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Item_No as 'Item No',Item_Name as 'Item Name',Dealer as 'Dealer',Stock_Code as 'Stock Code',Purchase_Stock as 'Purchase_Stock',Purchase_Price as 'Purchase_Price',Unit_Price as 'Unit_Price',Best_Price as 'Best_Price',Ex_Date as 'Ex_Date',Current_Stock as 'Current_Stock',(Purchase_Stock-Current_Stock) as 'Sell_Stock',Tax as 'Tax',Discount as 'Discount',S_Name as 'S_Name' from stock_details");
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

        private void button18_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Backup bk = new Backup();
            bk.Show();
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Dealer de = new Dealer();
            de.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Reports re = new Reports();
            re.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
            fm.button58.PerformClick();
            fm.textBox4.Focus();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database= gallolowa_grocery";
                string Query = "insert into stock_details(BarCode) values('" + this.textBox11.Text + "') where Item_No LIKE '"+textBox12.Text+"';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Save Barcode");

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

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 fm2 = new Form2();
                fm2.Show();
            }
            catch
            {
                MessageBox.Show("Invalid Code");
            }
         
            SetValueForText1 = textBox6.Text;
           // SetValueForText2 = textBox23.Text;

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string x = textBox6.Text;
            textBox14.Text = x.ToString();
        }
        }
    }


