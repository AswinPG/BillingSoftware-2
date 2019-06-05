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
    public partial class Payment : Form
    {
        public static string SetValueForText7 = "";
        public static string SetValueForText8 = "";
      

        public Payment()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetValueForText7 = textBox1.Text;
            SetValueForText8 = label11.Text;
            double Sub_Balance = double.Parse(textBox2.Text);

            string user = textBox6.Text;
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Text = "0";
            }
            double limit = double.Parse(textBox4.Text);

            if (user == "Credit" && Sub_Balance >= limit)
            {
                MessageBox.Show("Your Balance Limit is Over");

            }
            else
            {

                try
                {
                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery;Charset=utf8";
                    string Query = "insert into bill_details(Bill_No,Customer,Net_Total,Discount,Tax,Total,Cash,Balance,Sale_Total,Date,Items,Sub_Balance,Type) values('" + this.textBox3.Text + "','" + this.textBox7.Text + "','" + this.label8.Text + "','" + this.label9.Text + "','" + this.label15.Text + "','" + this.label10.Text + "','" + this.textBox1.Text + "','" + this.label11.Text + "','" + this.label14.Text + "','" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "','" + this.label20.Text + "','" + this.textBox2.Text + "','"+textBox10.Text+"');";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Submit");

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
                try
                {
                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = "update customer_details set Sub_Balance='" + this.textBox2.Text + "'where Customer_No='" + this.textBox8.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    //    MessageBox.Show("Successfully Updated");

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            
            textBox3.Text = Form1.SetValueForText1;
            label8.Text = Form1.SetValueForText2;
            label9.Text = Form1.SetValueForText3;
            label10.Text = Form1.SetValueForText4;
            label14.Text = Form1.SetValueForText5;
            label15.Text = Form1.SetValueForText6;
           textBox7.Text = Form1.SetValueForText9;
            label20.Text = Form1.SetValueForText10;
            label23.Text = Form1.SetValueForText11;
            textBox4.Text = Form1.SetValueForText12;
            textBox5.Text = Form1.SetValueForText13;
            textBox6.Text = Form1.SetValueForText14;
            textBox8.Text = Form1.SetValueForText15;
            textBox10.Text = Form1.SetValueForText16;
           
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //  double Old_Balance = double.Parse(label23.Text);
                double Total = double.Parse(textBox5.Text);
                double  Cash = double.Parse(textBox1.Text);
                double  Balance;
                double Sub_Balance;
              
                //   double New_Balance;

                Balance = (Cash - (Total));

                //  New_Balance = (Old_Balance +( Balance));
                label11.Text = Balance.ToString();
                label18.Text = Balance.ToString("0.00");
                if (Total > Cash)
                {
                    Sub_Balance = Total - Cash;
                   
                        textBox2.Text = Sub_Balance.ToString();
                   
                }
                else
                {
                    Sub_Balance = 0;
                    textBox2.Text = Sub_Balance.ToString();
                }

                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
           
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string user =textBox7.Text;
             label17.Text = user.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("update customer_details set Balance_Limit = '" + this.textBox4.Text + "' WHERE Customer_No = '" + this.textBox8.Text + "'");
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Update..!");
            while (MyReader2.Read())
            {

            }

            MyConn2.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
