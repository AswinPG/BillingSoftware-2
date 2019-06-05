using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Inventory.SetValueForText1;
            int max, Stock_Code;
            String Max;
            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = "SELECT MAX(Stock_Code) FROM stock_details where Item_No = '" + textBox1.Text + "'";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

            MyConn2.Open();
            Max = MyCommand2.ExecuteScalar().ToString();
            max = Convert.ToInt16(Max);

            MyConn2.Close();

            Stock_Code = max + 1;
            textBox2.Text = Stock_Code.ToString();
          //  textBox2.Text = Inventory.SetValueForText2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database= gallolowa_grocery";
                string Query = "insert into stock(Stock_Code,Item_Code,P_Stock,P_Price,U_Price,Tax,Dis,B_Price,Ex_Date) values('" + this.textBox2.Text + "','" + this.textBox1.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "');";
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
