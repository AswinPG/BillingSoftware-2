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
    public partial class Form1 : Form
    {
        DataTable tb = new DataTable();
        DataTable db = new DataTable();

        double Unit_Price;
        double Qty;
        double Total;
        double All_Total;
        double Tax_Total;
        double Discount_Total;
        double Net_Tot;
        int No_Of_Items = 0;
        double NQty;
        int i = 0;
        Timer t1 = new Timer();

        string code;
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
        public static string SetValueForText6 = "";
        public static string SetValueForText9 = "";
        public static string SetValueForText10 = "";
        public static string SetValueForText11 = "";
        public static string SetValueForText12 = "";
        public static string SetValueForText13 = "";
        public static string SetValueForText14 = "";
        public static string SetValueForText15 = "";
        public static string SetValueForText16 = "";
        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView4.Hide();
            dataGridView2.Hide();

            setFullScreen();

            panel1.Location = new Point(
                 this.ClientSize.Width / 2 - panel1.Size.Width / 2,
                this.ClientSize.Height / 2 - panel1.Size.Height / 2
                );
            panel1.Anchor = AnchorStyles.Top;
            

            tb.Columns.Add("Item_No", typeof(String));
            tb.Columns.Add("Item_Name", typeof(String));
            tb.Columns.Add("Unit_Price", typeof(double));

            tb.Columns.Add("Qty", typeof(double));
            tb.Columns.Add("Total", typeof(double));
            tb.Columns.Add("Tax", typeof(double));

            tb.Columns.Add("Discount", typeof(double));
            tb.Columns.Add("Purchase_Price", typeof(double));
            tb.Columns.Add("All_Total", typeof(double));

            tb.Columns.Add("Tax_Total", typeof(double));
            tb.Columns.Add("Discount_Total", typeof(double));
            tb.Columns.Add("No", typeof(int));

            tb.Columns.Add("Net_Tot", typeof(double));

            dataGridView1.DataSource = tb;


            DataGridViewColumn column0 = dataGridView1.Columns[0];
        //    column0.Width = 75;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
          //  column1.Width = 125;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            //column2.Width = 150;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            //column3.Width = 150;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            //column4.Width = 150;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 100;
            column5.Visible = false;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 100;
           // column6.Visible = false;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 100;
            column7.Visible = false;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 100;
            column8.Visible = false;
            DataGridViewColumn column9 = dataGridView1.Columns[9];
            column9.Width = 100;
            column9.Visible = false;
            DataGridViewColumn column10 = dataGridView1.Columns[10];
            column10.Width = 100;
          //  column10.Visible = false;
            DataGridViewColumn column11 = dataGridView1.Columns[11];
            column11.Width = 100;
            //column11.Visible = false;
            DataGridViewColumn column12 = dataGridView1.Columns[12];
            column12.Width = 100;
            column12.Visible = false;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                col.DefaultCellStyle.Font = new Font("Arial", 13F, GraphicsUnit.Pixel);
            }
            textBox16.Text = "0";
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox5.Text = "0";
            textBox2.Text = "0";
            textBox60.Text = "0";
     
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label98.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void button58_Click(object sender, EventArgs e)
        {
            try
            {
                double Bill_No;
                double max;
                String Max;
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = "SELECT MAX(Bill_No) FROM bill_details";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MyConn2.Open();
                Max = MyCommand2.ExecuteScalar().ToString();
                max = Convert.ToDouble(Max);

                MyConn2.Close();

                Bill_No = max + 1;
                textBox4.Text = Bill_No.ToString();

                textBox29.Clear();
                textBox8.Clear();
                listBox1.Items.Clear();
                textBox6.Clear();
                tb.Clear();
                dataGridView3.DataSource = null;
                textBox46.ResetText();
                label5.ResetText();
                label8.ResetText();
                label7.ResetText();
                label99.ResetText();
                label11.ResetText();
                No_Of_Items = 0;
                comboBox1.Text = "";
                textBox38.Clear();
                dataGridView4.Hide();
                textBox39.Clear();
                textBox48.Clear();
                textBox49.Clear();
                comboBox3.Text = "";
                comboBox2.Text = "";
                comboBox4.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }


        private void button59_Click(object sender, EventArgs e)
        {


            {
                double Discount = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    Discount += Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                }
                label11.Text = Discount.ToString("0.00");
                if (string.IsNullOrEmpty(label11.Text))
                    label11.Text = "0";


                double Tax = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    Tax += Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                }
                label7.Text = Tax.ToString("0.00");
                if (string.IsNullOrEmpty(label7.Text))
                    label7.Text = "0";
            }


            double sum = 0;


            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            label8.Text = sum.ToString("0.00");


            double allsum = 0;


            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                allsum += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
            }
            label9.Text = allsum.ToString("0.00");




            int No_Of_Items = 0;


            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                No_Of_Items += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            label5.Text = No_Of_Items.ToString();

            double TOTAL = 0;


            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                TOTAL += Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value);
            }
            label99.Text = TOTAL.ToString("0.00");


            int Items = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Items = i;
            }
            textBox46.Text =Items.ToString();

            double FTot;

            if (string.IsNullOrEmpty(textBox39.Text))
            {
                textBox39.Text = "0";
            }

            double obal = double.Parse(textBox39.Text);
            FTot = obal + TOTAL;
            textBox48.Text = FTot.ToString("0.00");



        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            

            SetValueForText1 = textBox4.Text;
            SetValueForText2 = label99.Text;
            SetValueForText3 = label11.Text;
            SetValueForText4 = label8.Text;
            SetValueForText5 = label9.Text;
            SetValueForText6 = label7.Text;
            //  SetValueForText9 = label98.Text;
            SetValueForText9 = textBox3.Text;
            SetValueForText10 = label5.Text;
            SetValueForText11 = textBox39.Text;
            SetValueForText12 = textBox49.Text;
            SetValueForText13 = textBox48.Text;
            SetValueForText14 = textBox38.Text;
            SetValueForText15 = textBox51.Text;
            SetValueForText16 = comboBox4.Text;



            Payment pay = new Payment();
            pay.Show();


        }

        private void button60_Click(object sender, EventArgs e)
        {
            double Qty1 = double.Parse(textBox10.Text);
            double Stock1 = double.Parse(textBox11.Text);
            double NQty1;

            No_Of_Items = No_Of_Items - 1;
            textBox6.Text = No_Of_Items.ToString();

            NQty1 = (Stock1 + Qty1);
            textBox12.Text = NQty1.ToString();

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);

            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("update stock_details set Current_Stock = '" + this.textBox12.Text + "' WHERE Item_No LIKE '%" + textBox9.Text + "%';");
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


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Show();
            cus.button19.Visible = true;
            cus.button8.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox14.Text != "")
            {

                try
                {
                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Item_No as 'Item_No',Item_Name as 'Item_Name',Tax as 'Tax',Discount as 'Discount',Current_Stock as 'Current_Stock',Unit_Price as 'Unit_Price',Purchase_Price as 'Purchase_Price',Ex_Date as 'Ex_Date',Best_Price as 'Best_Price',S_Name as 'S_Name' from stock_details WHERE Item_No LIKE '" + textBox14.Text + "';");
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {
                        textBox20.Text = MyReader2.GetString("Tax");
                        textBox21.Text = MyReader2.GetString("Discount");
                        textBox9.Text = MyReader2.GetString("Item_No");
                        textBox11.Text = MyReader2.GetString("Current_Stock");
                        textBox18.Text = MyReader2.GetString("Purchase_Price");
                        textBox16.Text = MyReader2.GetString("Tax");
                        textBox17.Text = MyReader2.GetString("Discount");

                        textBox5.Text = MyReader2.GetString("Best_Price");
                        textBox1.Text = MyReader2.GetString("Item_Name");
                        textBox50.Text = MyReader2.GetString("S_Name");
                        textBox2.Text = MyReader2.GetString("Current_Stock");
                        textBox60.Text = MyReader2.GetString("Unit_Price");



                    }
                    DateTime d = MyReader2.GetDateTime("Ex_Date");
                    label15.Text = d.ToString("yyyy-MM-dd");
                    MyConn2.Close();
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand2;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
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
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                try
                {

                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Item_No as 'Item_No',Tax as 'Tax',Discount as 'Discount',Current_Stock as 'Current_Stock',Unit_Price as 'Unit_Price',Purchase_Price as 'Purchase_Price',Ex_Date as 'Ex_Date',Best_Price as 'Best_Price' , S_Name as 'S_Name' from stock_details WHERE Item_Name LIKE '" + textBox1.Text + "';");
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {
                        textBox20.Text = MyReader2.GetString("Tax");
                        textBox21.Text = MyReader2.GetString("Discount");
                        textBox9.Text = MyReader2.GetString("Item_No");
                        textBox11.Text = MyReader2.GetString("Current_Stock");
                        textBox18.Text = MyReader2.GetString("Purchase_Price");
                        textBox16.Text = MyReader2.GetString("Tax");
                        textBox17.Text = MyReader2.GetString("Discount");
                        textBox50.Text = MyReader2.GetString("S_Name");
                        textBox5.Text = MyReader2.GetString("Best_Price");
                        textBox14.Text = MyReader2.GetString("Item_No");
                        textBox2.Text = MyReader2.GetString("Current_Stock");
                        textBox60.Text = MyReader2.GetString("Unit_Price");


                    }
                    DateTime d = MyReader2.GetDateTime("Ex_Date");
                    label15.Text = d.ToString("yyyy-MM-dd");

                    MyConn2.Close();
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand2;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);

                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();
                }
          
                 catch {
              
                   //  MessageBox.Show("Invalid Name");
                  }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double Unit_Price = double.Parse(textBox60.Text);
                double Best_Price = double.Parse(textBox5.Text);
                double Stock = double.Parse(textBox2.Text);
                double Qty =double.Parse(textBox61.Text);
                double Price = double.Parse(textBox18.Text);
                double Tax = double.Parse(textBox16.Text);
                double Discount = double.Parse(textBox17.Text);

                textBox10.Text = Qty.ToString();

                No_Of_Items = No_Of_Items + 1;
                textBox6.Text = No_Of_Items.ToString();

                NQty = Stock - Qty;
                textBox7.Text = NQty.ToString();
       
                if (textBox38.Text == "Best" && textBox61.Text != "1")
                {

                    Total = Qty * Best_Price;
                    textBox62.Text = Total.ToString();

                    All_Total = Qty * Price;
                    textBox19.Text = All_Total.ToString();

                    Tax_Total = ((Tax * Best_Price) / 100) * Qty;
                    textBox22.Text = Tax_Total.ToString();
                    Discount_Total = ((Discount * Best_Price) / 100) * Qty;
                    textBox23.Text = Discount_Total.ToString();

                    Net_Tot = (Total + (Tax_Total - Discount_Total));
                    textBox42.Text = Net_Tot.ToString();
                    tb.Rows.Add(textBox14.Text, textBox50.Text, textBox5.Text, textBox61.Text, textBox62.Text, textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text, textBox22.Text, textBox23.Text, textBox6.Text, textBox42.Text);
                    dataGridView1.DataSource = tb;

               }
                else
                {
                    Total = Qty * Unit_Price;
                    textBox62.Text = Total.ToString();

                    All_Total = Qty * Price;
                    textBox19.Text = All_Total.ToString();

                    Tax_Total = ((Tax * Unit_Price) / 100) * Qty;
                    textBox22.Text = Tax_Total.ToString();
                    Discount_Total = ((Discount * Unit_Price) / 100) * Qty;
                    textBox23.Text = Discount_Total.ToString();

                    Net_Tot = (Total + (Tax_Total - Discount_Total));
                    textBox42.Text = Net_Tot.ToString();

                    tb.Rows.Add(textBox14.Text, textBox50.Text, textBox60.Text, textBox61.Text, textBox62.Text, textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text, textBox22.Text, textBox23.Text, textBox6.Text, textBox42.Text);
                    dataGridView1.DataSource = tb;
                }
                foreach (DataGridViewRow row1 in dataGridView1.Rows)
                {
                    Total = Convert.ToDouble(row1.Cells[2].Value) * Convert.ToDouble(row1.Cells[3].Value);
                    row1.Cells[4].Value = Total;
                    All_Total = Convert.ToDouble(row1.Cells[7].Value) * Convert.ToDouble(row1.Cells[3].Value);
                    row1.Cells[8].Value = All_Total;
                    Net_Tot = (Convert.ToDouble(row1.Cells[4].Value) - Convert.ToDouble(row1.Cells[10].Value)) + Convert.ToDouble(row1.Cells[9].Value);
                    row1.Cells[12].Value = Net_Tot;
                    Tax_Total = (Convert.ToDouble(row1.Cells[5].Value) * Convert.ToDouble(row1.Cells[2].Value) / 100) * Convert.ToDouble(row1.Cells[3].Value);
                    row1.Cells[9].Value = Tax_Total;
                    Discount_Total = (Convert.ToDouble(row1.Cells[6].Value) * Convert.ToDouble(row1.Cells[2].Value) / 100) * Convert.ToDouble(row1.Cells[3].Value);
                    row1.Cells[10].Value = Discount_Total;
                }

                if (textBox5.Text != "0")
                {
                    //if (Stock - Qty <= 0)
                    //{
         
                    //    button23.PerformClick();
                    //}
                    //else
                    {
                        string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                        string Query = ("update stock_details set Unit_Price = '" + this.textBox60.Text + "', Best_Price = '" + this.textBox5.Text + "' , Current_Stock = '" + this.textBox7.Text + "' WHERE Item_No ='" + textBox14.Text + "';");
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();

                        while (MyReader2.Read())
                        {

                        }

                        MyConn2.Close();
                       
                    }
                }
                else
                {
                    //if ( Stock-Qty  <= 0)
                    //{
                      
                    //    button23.PerformClick();
                      
                    //}
                    //else
                    {
                        string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                        string Query = ("update stock_details set Unit_Price = '" + this.textBox60.Text + "', Current_Stock = '" + this.textBox7.Text + "' WHERE Item_No = '" + textBox14.Text + "';");
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();

                        while (MyReader2.Read())
                        {

                        }

                        MyConn2.Close();
                       
                    }
                }
                    textBox14.Clear();
                    textBox1.Clear();
                    textBox16.Text = "0";
                    textBox17.Text = "0";
                    textBox18.Text = "0";
                    textBox5.Text = "0";
                    textBox2.Text = "0";
                    textBox60.Text = "0";
                    textBox61.Clear();
                    label15.Text = "";
                    textBox62.Clear();
                    dataGridView4.Hide();
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    textBox50.ResetText();

                   
                
                }
            catch
            {
                MessageBox.Show("Please Enter Quantity");
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (i >= 0)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow newDataRow = this.dataGridView1.Rows[rowIndex];
                textBox25.Text = newDataRow.Cells[3].Value.ToString();
            }

            foreach (DataGridViewRow row1 in dataGridView1.Rows)
            {

                double nqty;
                double nstock;
                double up;
                double p;
                double t;
                double d;
                double net1;

                double bp = double.Parse(textBox45.Text);
                double dup = double.Parse(textBox30.Text);
                double dp = double.Parse(textBox31.Text);

                double dt = double.Parse(textBox32.Text);
                double dd = double.Parse(textBox33.Text);
                double net = double.Parse(textBox43.Text);

                double qty = double.Parse(textBox24.Text);
                double qty1 = double.Parse(textBox25.Text);
                double stock2 = double.Parse(textBox27.Text);
                if (textBox38.Text == "Best")
                {
                    nqty = (qty + (qty1));
                    up = (bp * nqty);
                    textBox34.Text = up.ToString();
                    p = (dp * nqty);
                    textBox35.Text = p.ToString();
                    t = (((bp * dt) / 100) * nqty);
                    textBox36.Text = t.ToString();
                    d = (((bp * dd) / 100) * nqty);
                    textBox37.Text = d.ToString();
                    net1 = ((up - d) + t);
                    textBox44.Text = net1.ToString();

                    textBox26.Text = nqty.ToString();

                    nstock = (stock2 - (qty1));
                    textBox28.Text = nstock.ToString();



                    if (i >= 0)
                    {
                        int rowIndex = dataGridView1.CurrentCell.RowIndex;
                        DataGridViewRow newDataRow = this.dataGridView1.Rows[rowIndex];
                        newDataRow.Cells[3].Value = textBox26.Text;
                        newDataRow.Cells[4].Value = textBox34.Text;
                        newDataRow.Cells[8].Value = textBox35.Text;
                        newDataRow.Cells[9].Value = textBox36.Text;
                        newDataRow.Cells[10].Value = textBox37.Text;
                        newDataRow.Cells[12].Value = textBox44.Text;
                    }
                }
                else
                {
                    nqty = (qty + (qty1));
                    up = (dup * nqty);
                    textBox34.Text = up.ToString();
                    p = (dp * nqty);
                    textBox35.Text = p.ToString();
                    t = (((dup * dt) / 100) * nqty);
                    textBox36.Text = t.ToString();
                    d = (((dup * dd) / 100) * nqty);
                    textBox37.Text = d.ToString();
                    net1 = ((up - d) + t);
                    textBox44.Text = net1.ToString();

                    textBox26.Text = nqty.ToString();

                    nstock = (stock2 - (qty1));
                    textBox28.Text = nstock.ToString();



                    if (i >= 0)
                    {
                        int rowIndex = dataGridView1.CurrentCell.RowIndex;
                        DataGridViewRow newDataRow = this.dataGridView1.Rows[rowIndex];
                        newDataRow.Cells[3].Value = textBox26.Text;
                        newDataRow.Cells[4].Value = textBox34.Text;
                        newDataRow.Cells[8].Value = textBox35.Text;
                        newDataRow.Cells[9].Value = textBox36.Text;
                        newDataRow.Cells[10].Value = textBox37.Text;
                        newDataRow.Cells[12].Value = textBox44.Text;
                    }
                }
            }
           
            

            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("update stock_details set Current_Stock = '" + this.textBox28.Text + "' WHERE Item_No LIKE '%" + textBox9.Text + "%';");
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

            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();

            while (MyReader2.Read())
            {

            }

            MyConn2.Close();


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                double Net_Total = double.Parse(label8.Text);
                double Tax = double.Parse(textBox39.Text);
                double Discount = double.Parse(label11.Text);
                double FTotal = double.Parse(textBox48.Text);
                double Balance = double.Parse(textBox29.Text);
                double Cash = double.Parse(textBox8.Text);
                int Items = int.Parse(label5.Text);
                int Psc = int.Parse(textBox46.Text);

                Graphics graphic = e.Graphics;

                Font font = new Font("Courier New", 7);
                Font font10 = new Font("Courier New", 10);
                Font font12 = new Font("Courier New", 12);
                Font font14 = new Font("Courier New", 14);

                float leading = 4;
                float fontHeight = font.GetHeight() + leading;
                float lineheight12 = font12.GetHeight() + leading;
                float lineheight14 = font14.GetHeight() + leading;

                float startX = 0;
                float startY = leading;
                float offset = 0;

                StringFormat formatLeft = new StringFormat(StringFormatFlags.NoClip);
                StringFormat formatCenter = new StringFormat(formatLeft);
                StringFormat formatRight = new StringFormat(formatLeft);

                formatCenter.Alignment = StringAlignment.Center;
                formatRight.Alignment = StringAlignment.Far;
                formatLeft.Alignment = StringAlignment.Near;

                SizeF layoutSize = new SizeF(250 - offset * 2, lineheight14);
                RectangleF layout = new RectangleF(new PointF(startX, startY + offset), layoutSize);

                Brush brush = Brushes.Black;


                layout = new RectangleF(new PointF(startX, 5 + offset), layoutSize);

                graphic.DrawString("ගල්ලොලුව ග්‍රොසරිය  ", font, brush, layout, formatCenter);

                layout = new RectangleF(new PointF(startX, 15 + offset), layoutSize);
                graphic.DrawString(" ගල්ලොලු හන්දිය ", font, brush, layout, formatCenter);
                layout = new RectangleF(new PointF(startX, 25 + offset), layoutSize);
                graphic.DrawString(" මිනුවන්ගොඩ", font, brush, layout, formatCenter);
                layout = new RectangleF(new PointF(startX, 35 + offset), layoutSize);
                graphic.DrawString("දූ. අංක : 0777398852 ", font, brush, layout, formatCenter);

                offset = offset + lineheight14;

                layout = new RectangleF(new PointF(startX, 25 + offset), layoutSize);
                graphic.DrawString("---------------------------------------------------------".PadRight(25, '_'), new Font("Courier New", 5), brush, layout, formatLeft);
                offset = offset + lineheight12;

                layout = new RectangleF(new PointF(startX + 10, 10 + offset), layoutSize);
                graphic.DrawString("දිනය:" + DateTime.Now.ToString("dd/MM/yy"), font, brush, layout, formatLeft);
                offset = offset + lineheight14;

                layout = new RectangleF(new PointF(startX + 10, offset), layoutSize);
                graphic.DrawString("Cashier: CASHIER", font, brush, layout, formatLeft);
                offset = offset + lineheight14;

                layout = new RectangleF(new PointF(startX, offset - 10), layoutSize);
                graphic.DrawString("---------------------------------------------------------".PadRight(25, '_'), new Font("Courier New", 5), brush, layout, formatLeft);
                offset = offset + lineheight12;

                //---------------------
                layout = new RectangleF(new PointF(startX + 5, offset - 20), layoutSize);
                graphic.DrawString("භාණ්ඩය  ප්‍රමාණය  ඒකක මිල  වට්ටම්  වටිනාකම", font, brush, layout, formatLeft);
                offset = offset + lineheight14;

                layout = new RectangleF(new PointF(startX, offset - 25), layoutSize);
                graphic.DrawString("---------------------------------------------------------", new Font("Courier New", 5), brush, layout, formatLeft);
                offset = offset + lineheight12;

                //------------------------

                foreach (string item in listBox1.Items)
                {
                    layout = new RectangleF(new PointF(startX + 5, offset - 40), layoutSize);
                    graphic.DrawString(item, font, brush, layout, formatLeft);
                    offset = offset + 15;
                }
                //-------------------------
                layout = new RectangleF(new PointF(startX, startY + offset), layoutSize);
                graphic.DrawString("---------------------------------------------------------".PadRight(25, '_'), new Font("Courier New", 5), brush, layout, formatLeft);
                offset = offset + lineheight12;

                //---------------------------
                layout = new RectangleF(new PointF(startX + 30, startY + offset - 10), layoutSize);
                graphic.DrawString("භාණ්ඩ වටිනාකම ", new Font("Courier New", 7), brush, layout, formatLeft);
                graphic.DrawString("රු.", font, brush, layout, formatCenter);
                layout = new RectangleF(new PointF(startX - 15, startY + offset - 10), layoutSize);
                graphic.DrawString("" + String.Format("{0,10:##.00}", Net_Total), new Font("Courier New", 7), brush, layout, formatRight);
                offset = offset + fontHeight;

                layout = new RectangleF(new PointF(startX + 30, startY + offset - 10), layoutSize);
                graphic.DrawString("පරණ වටිනාකම  ", new Font("Courier New", 7), brush, layout, formatLeft);
                graphic.DrawString("රු.", font, brush, layout, formatCenter);
                layout = new RectangleF(new PointF(startX - 15, startY + offset - 10), layoutSize);
                graphic.DrawString("" + String.Format("{0,10:##.00}", Tax), new Font("Courier New", 7), brush, layout, formatRight);
                offset = offset + fontHeight;
             

                layout = new RectangleF(new PointF(startX + 30, startY + offset - 10), layoutSize);
                graphic.DrawString("වට්ටම් අඩු කළා  ", new Font("Courier New", 7), brush, layout, formatLeft);
                graphic.DrawString("රු.", font, brush, layout, formatCenter);
                layout = new RectangleF(new PointF(startX - 15, startY + offset - 10), layoutSize);
                graphic.DrawString("" + String.Format("{0,10:##.00}", Discount), new Font("Courier New", 7), brush, layout, formatRight);
                offset = offset + fontHeight;
              

                layout = new RectangleF(new PointF(startX + 30, startY + offset - 10), layoutSize);
                graphic.DrawString("මුළු වටිනාකම ", new Font("Courier New", 7), brush, layout, formatLeft);
                graphic.DrawString("රු.", font, brush, layout, formatCenter);
                layout = new RectangleF(new PointF(startX - 15, startY + offset - 10), layoutSize);
                graphic.DrawString("" + String.Format("{0,10:##.00}",FTotal), new Font("Courier New", 7), brush, layout, formatRight);
                offset = offset + fontHeight;
            

                layout = new RectangleF(new PointF(startX + 30, startY + offset - 10), layoutSize);
                graphic.DrawString("දුන් මුදල", new Font("Courier New", 7), brush, layout, formatLeft);
                graphic.DrawString("රු.", font, brush, layout, formatCenter);
                layout = new RectangleF(new PointF(startX - 15, startY + offset - 10), layoutSize);
                graphic.DrawString("" + String.Format("{0,10:##.00}", Cash), new Font("Courier New", 7), brush, layout, formatRight);
                offset = offset + fontHeight;

                layout = new RectangleF(new PointF(startX + 30, startY + offset - 10), layoutSize);
                graphic.DrawString("ඉතිරි මුදල", new Font("Courier New", 7), brush, layout, formatLeft);
                graphic.DrawString("රු.", font, brush, layout, formatCenter);
                layout = new RectangleF(new PointF(startX - 15, startY + offset - 10), layoutSize);
                graphic.DrawString("" + String.Format("{0,10:##.00}", Balance), new Font("Courier New", 7), brush, layout, formatRight);
                offset = offset + fontHeight;

                layout = new RectangleF(new PointF(startX, startY + offset - 10), layoutSize);
                graphic.DrawString("---------------------------------------------------------".PadRight(25, '_'), new Font("Courier New", 5), brush, layout, formatLeft);
                offset = offset + lineheight12;

                //-------------------------------------

                //string Pcs;
                //int sum = 0;
                //for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                //{
                //    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);
                //}
                //Pcs = sum.ToString();
                //layout = new RectangleF(new PointF(startX + 5, startY + offset - 25), layoutSize);
                //layout = new RectangleF(new PointF(startX - 10, startY + offset - 25), layoutSize);
                //graphic.DrawString("බිල් අංකය :" + textBox4.Text, font, brush, layout, formatLeft);
                //graphic.DrawString("වේලාව:" + DateTime.Now.ToString("hh.mm.tt"), font, brush, layout, formatRight);
                //offset = offset + lineheight14;

                layout = new RectangleF(new PointF(startX + 5, startY + offset - 25), layoutSize);
                graphic.DrawString("බිල් අංකය : " + textBox4.Text, font, brush, layout, formatLeft);
                //offset = offset + lineheight14;
                layout = new RectangleF(new PointF(startX - 15, startY + offset - 25), layoutSize);
                graphic.DrawString("වේලාව : " + DateTime.Now.ToString("hh.mm.tt"), font, brush, layout, formatRight);
                offset = offset + lineheight14;
                //layout = new RectangleF(new PointF(startX, startY + offset), layoutSize);
                //graphic.DrawString("Items     ", font, brush, layout, formatLeft);
                //graphic.DrawString("" + Items, font, brush, layout, formatCenter);
                //offset = offset + fontHeight;

                layout = new RectangleF(new PointF(startX + 5, startY + offset - 40), layoutSize);
                graphic.DrawString("ගණුදෙනු ආකාරය : " + comboBox4.Text, font, brush, layout, formatLeft);
                offset = offset + lineheight14;
                //layout = new RectangleF(new PointF(startX, startY + offset), layoutSize);
                //graphic.DrawString("No of Item  ", font, brush, layout, formatLeft);
                //graphic.DrawString("" + Psc, font, brush, layout, formatCenter);
                //offset = offset + fontHeight;

                layout = new RectangleF(new PointF(startX, startY + offset - 40), layoutSize);
                graphic.DrawString("---------------------------------------------------------".PadRight(25, '_'), new Font("Courier New", 5), brush, layout, formatLeft);
                offset = offset + lineheight12;

                layout = new RectangleF(new PointF(startX, startY + offset - 50), layoutSize);
                graphic.DrawString(" ස්තුතියි, නැවත එන්න!!.", font, brush, layout, formatCenter);
                offset = offset + fontHeight;

                layout = new RectangleF(new PointF(startX, startY + offset - 50), layoutSize);
                graphic.DrawString("---------------------------------------------------------".PadRight(25, '_'), new Font("Courier New", 5), brush, layout, formatLeft);
                offset = offset + lineheight12;

                layout = new RectangleF(new PointF(startX, startY + offset - 60), layoutSize);
                graphic.DrawString("මෙම බිල්පත සම්බන්දයෙන් ඔබට යම් ගැටළුවක්", font, brush, layout, formatCenter);
                offset = offset + fontHeight;
                layout = new RectangleF(new PointF(startX, startY + offset - 60), layoutSize);
                graphic.DrawString("ඇත්නම් බිල්පත් දිනයේ සිට දින 3 ක් ඇතුලත ", font, brush, layout, formatCenter);
                offset = offset + fontHeight;
                layout = new RectangleF(new PointF(startX, startY + offset - 60), layoutSize);
                graphic.DrawString("බිල්පත සමඟ අප හමුවන්න.", font, brush, layout, formatCenter);
                offset = offset + fontHeight;
                layout = new RectangleF(new PointF(startX, startY + offset - 60), layoutSize);
                graphic.DrawString("නැතහොත් දූ. අංක  0777398852 අමතන්න.", font, brush, layout, formatCenter);
                offset = offset + fontHeight;

                layout = new RectangleF(new PointF(startX, startY + offset - 60), layoutSize);
                graphic.DrawString("---------------------------------------------------------".PadRight(25, '_'), new Font("Courier New", 5), brush, layout, formatLeft);
                offset = offset + lineheight12;

                layout = new RectangleF(new PointF(startX, startY + offset - 70), layoutSize);
                graphic.DrawString("මෘදුකාංග නිර්මාණය  : හසිනි මධුවන්ති ", font, brush, layout, formatCenter);
                offset = offset + fontHeight;
                layout = new RectangleF(new PointF(startX, startY + offset - 70), layoutSize);
                graphic.DrawString("දූ.අංක : 0775816190.", font, brush, layout, formatCenter);
                offset = offset + fontHeight;

                layout = new RectangleF(new PointF(startX, startY + offset - 70), layoutSize);
                graphic.DrawString("---------------------------------------------------------".PadRight(25, '_'), new Font("Courier New", 5), brush, layout, formatLeft);
                offset = offset + lineheight12;

            }
            catch
            {
               
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox1 != null)
            {
               
                    textBox8.Text = Payment.SetValueForText7;
                    textBox29.Text = Payment.SetValueForText8;

                    if (textBox8 != null && textBox29.Text != null)
                    {
                        {
                            {
                                int n = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (dataGridView1.Rows.Count != n + 1)
                                    {
                                        dataGridView3.Rows.Add();
                                        dataGridView3.Rows[n].Cells[0].Value = row.Cells[0].Value.ToString();
                                        dataGridView3.Rows[n].Cells[1].Value = row.Cells[3].Value.ToString();
                                        dataGridView3.Rows[n].Cells[2].Value = DateTime.Now.ToString("MM/dd/yyyy");
                                        dataGridView3.Rows[n].Cells[3].Value = row.Cells[8].Value.ToString();
                                        dataGridView3.Rows[n].Cells[4].Value = row.Cells[12].Value.ToString();
                                        dataGridView3.Rows[n].Cells[5].Value = textBox4.Text.ToString();
                                    }
                                    n += 1;
                                }
                                MySqlConnection MyConn2 = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery");
                                MyConn2.Open();
                                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                                {

                                    MySqlCommand MyCommand2 = new MySqlCommand("INSERT INTO selling_details(Item_No,Quantity,Date,S_Tot,Tot,Bill) VALUES('" + dataGridView3.Rows[i].Cells["Item_No"].Value + "','" + dataGridView3.Rows[i].Cells["Quantity"].Value + "','" + dataGridView3.Rows[i].Cells["Date"].Value + "','" + dataGridView3.Rows[i].Cells["S_Tot"].Value + "','" + dataGridView3.Rows[i].Cells["Tot"].Value + "','" + dataGridView3.Rows[i].Cells["Bill"].Value + "')", MyConn2);

                                    MyCommand2.ExecuteNonQuery();

                                }


                                MyConn2.Close();
                            }
                        }
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                            listBox1.Items.Add(row.Cells[1].Value.ToString());
                        if (!row.IsNewRow)
                            listBox1.Items.Add(row.Cells[0].Value.ToString() + "    " + row.Cells[3].Value.ToString() + "   " + row.Cells[2].Value.ToString() + "   " + row.Cells[10].Value.ToString() + "        " + row.Cells[4].Value.ToString());
                        //dataGridView3.Rows.Add(row.Cells[0].Value.ToString());
                    }

                    printPreviewDialog1.Document = printDocument1;
                    printDocument1.Print();


                }
            
            else
            {
                // printPreviewDialog1.Document = printDocument1;
                printDocument1.Print();
                // printPreviewDialog2.ShowDialog();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox9.Text = row.Cells[0].Value.ToString();
                textBox10.Text = row.Cells[3].Value.ToString();
                textBox24.Text = row.Cells[3].Value.ToString();
                textBox40.Text = row.Cells[1].Value.ToString();
                textBox41.Text = row.Cells[11].Value.ToString();
                textBox43.Text = row.Cells[12].Value.ToString();


            }

            if (textBox9.Text != "")
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = ("select Current_Stock as 'Current_Stock',Unit_Price as 'Unit_Price',Purchase_Price as 'Purchase_Price',Tax as 'Tax',Discount as 'Discount',Best_Price as 'Best_Price' From stock_details WHERE Item_No LIKE '%" + textBox9.Text + "%';");
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {
                    textBox11.Text = MyReader2.GetString("Current_Stock");
                    textBox27.Text = MyReader2.GetString("Current_Stock");
                    textBox30.Text = MyReader2.GetString("Unit_Price");
                    textBox31.Text = MyReader2.GetString("Purchase_Price");
                    textBox32.Text = MyReader2.GetString("Tax");
                    textBox33.Text = MyReader2.GetString("Discount");
                    textBox45.Text = MyReader2.GetString("Best_Price");
                }

                MyConn2.Close();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox8.Text = Payment.SetValueForText7;
            textBox29.Text = Payment.SetValueForText8;

            if (textBox8 != null && textBox29.Text != null)
            {
                {
                    {
                        int n = 0;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (dataGridView1.Rows.Count != n + 1)
                            {
                                dataGridView3.Rows.Add();
                                dataGridView3.Rows[n].Cells[0].Value = row.Cells[0].Value.ToString();
                                dataGridView3.Rows[n].Cells[1].Value = row.Cells[3].Value.ToString();
                                dataGridView3.Rows[n].Cells[2].Value = DateTime.Now.ToString("MM/dd/yyyy");
                                dataGridView3.Rows[n].Cells[3].Value = row.Cells[8].Value.ToString();
                                dataGridView3.Rows[n].Cells[4].Value = row.Cells[12].Value.ToString();
                                dataGridView3.Rows[n].Cells[5].Value = textBox4.Text.ToString();
                            }
                            n += 1;
                        }
                        MySqlConnection MyConn2 = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery");
                        MyConn2.Open();
                        for (int i = 0; i < dataGridView3.Rows.Count; i++)
                        {

                            MySqlCommand MyCommand2 = new MySqlCommand("INSERT INTO selling_details(Item_No,Quantity,Date,S_Tot,Tot,Bill) VALUES('" + dataGridView3.Rows[i].Cells["Item_No"].Value + "','" + dataGridView3.Rows[i].Cells["Quantity"].Value + "','" + dataGridView3.Rows[i].Cells["Date"].Value + "','" + dataGridView3.Rows[i].Cells["S_Tot"].Value + "','" + dataGridView3.Rows[i].Cells["Tot"].Value + "','" + dataGridView3.Rows[i].Cells["Bill"].Value + "')", MyConn2);

                            MyCommand2.ExecuteNonQuery();

                        }


                        MyConn2.Close();
                    }
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                        listBox1.Items.Add(row.Cells[11].Value.ToString() + "   " + row.Cells[1].Value.ToString() + "      " + row.Cells[2].Value.ToString() + "    " + row.Cells[3].Value.ToString() + "    " + row.Cells[4].Value.ToString());
                    //dataGridView3.Rows.Add(row.Cells[0].Value.ToString());
                }

                printPreviewDialog1.Document = printDocument1;
               // printPreviewDialog1.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please make your Payment");
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            comboBox3.Text = "";
            comboBox2.Text = "";

            textBox29.Clear();
            textBox8.Clear();
            listBox1.Items.Clear();
            textBox6.Clear();
            tb.Clear();
            dataGridView1.DataSource = null;
            textBox46.ResetText();
            label5.ResetText();
            label8.ResetText();
            label7.ResetText();
            label99.ResetText();
            label11.ResetText();
            textBox4.Clear();
            textBox3.Clear();
            textBox38.Clear();
            textBox14.Clear();
            textBox1.Clear();
            textBox60.Clear();
            textBox61.Clear();
            textBox62.Clear();
            textBox39.Clear();
            textBox48.Clear();
            textBox49.Clear();
            Home hm = new Home();
            hm.Show();

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox8.Text = Payment.SetValueForText7;
            textBox29.Text = Payment.SetValueForText8;

            if (textBox8 != null && textBox29.Text != null)
            {
                {
                    {
                        int n = 0;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (dataGridView1.Rows.Count != n + 1)
                            {
                                dataGridView3.Rows.Add();
                                dataGridView3.Rows[n].Cells[0].Value = row.Cells[0].Value.ToString();
                                dataGridView3.Rows[n].Cells[1].Value = row.Cells[3].Value.ToString();
                                dataGridView3.Rows[n].Cells[2].Value = DateTime.Now.ToString("MM/dd/yyyy");
                                dataGridView3.Rows[n].Cells[3].Value = row.Cells[8].Value.ToString();
                                dataGridView3.Rows[n].Cells[4].Value = row.Cells[12].Value.ToString();
                                dataGridView3.Rows[n].Cells[5].Value = textBox4.Text.ToString();
                            }
                            n += 1;
                        }
                        MySqlConnection MyConn2 = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery");
                        MyConn2.Open();
                        for (int i = 0; i < dataGridView3.Rows.Count; i++)
                        {

                            MySqlCommand MyCommand2 = new MySqlCommand("INSERT INTO selling_details(Item_No,Quantity,Date,S_Tot,Tot,Bill) VALUES('" + dataGridView3.Rows[i].Cells["Item_No"].Value + "','" + dataGridView3.Rows[i].Cells["Quantity"].Value + "','" + dataGridView3.Rows[i].Cells["Date"].Value + "','" + dataGridView3.Rows[i].Cells["S_Tot"].Value + "','" + dataGridView3.Rows[i].Cells["Tot"].Value + "','" + dataGridView3.Rows[i].Cells["Bill"].Value + "')", MyConn2);

                            MyCommand2.ExecuteNonQuery();

                        }


                        MyConn2.Close();
                    }
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                        listBox1.Items.Add(row.Cells[1].Value.ToString());
                    if (!row.IsNewRow)
                        listBox1.Items.Add(row.Cells[0].Value.ToString() + "    " + row.Cells[3].Value.ToString() + "   " + row.Cells[2].Value.ToString() + "   " + row.Cells[10].Value.ToString() + "        " + row.Cells[4].Value.ToString());
                    //dataGridView3.Rows.Add(row.Cells[0].Value.ToString());
                }

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please make your Payment");
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
               
                button4.PerformClick();
                textBox1.Focus();
            }
        }

        private void textBox14_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox3.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                comboBox1.Focus();
            }
           
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                textBox14.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
               
                button5.PerformClick();
                textBox61.Focus();
            }
        }

        private void textBox61_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                button3.PerformClick();
                textBox14.Focus();
            }
        }

        private void button59_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                button12.PerformClick();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != "")
            {
                try
                {
                    string MyConnection2 = "server=localhost;user id=root;database=gallolowa_grocery";
                    string Query = ("select Customer_Cat as ' Customer_Cat', Sub_Balance as 'Sub_Balance',Balance_Limit as 'Balance_Limit',Customer_No as 'Customer_No' from Customer_details WHERE Customer_No  = '"+ textBox3.Text + "' || Customer_Name = '" + textBox3.Text + "' ;");
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {
                        textBox38.Text = MyReader2.GetString("Customer_Cat");
                        textBox39.Text = MyReader2.GetString("Sub_Balance");
                        textBox49.Text = MyReader2.GetString("Balance_Limit");
                        textBox51.Text = MyReader2.GetString("Customer_No");
                    }

                    MyConn2.Close();
                }
                catch
                {
                   
                    
                    MessageBox.Show("Invalid customer");
                }
            }

                else{
                    try
                    {
                        string MyConnection2 = "server=localhost;user id=root;database=gallolowa_grocery";
                        string Query = ("select Sum(Sub_Balance) as 'Sub_Balance' from bill_details WHERE Customer = '" + textBox3.Text + "' ;");
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            textBox39.Text = MyReader2.GetString("Sub_Balance");
                        }

                        MyConn2.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Not in customer lists.");
                    }
                }

            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox8.Text = Payment.SetValueForText7;
            textBox29.Text = Payment.SetValueForText8;

            if (textBox8 != null && textBox29.Text != null)
            {
                {
                    {
                        int n = 0;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (dataGridView1.Rows.Count != n + 1)
                            {
                                dataGridView3.Rows.Add();
                                dataGridView3.Rows[n].Cells[0].Value = row.Cells[0].Value.ToString();
                                dataGridView3.Rows[n].Cells[1].Value = row.Cells[3].Value.ToString();
                                dataGridView3.Rows[n].Cells[2].Value = DateTime.Now.ToString("MM/dd/yyyy");
                                dataGridView3.Rows[n].Cells[3].Value = row.Cells[8].Value.ToString();
                                dataGridView3.Rows[n].Cells[4].Value = row.Cells[12].Value.ToString();
                                dataGridView3.Rows[n].Cells[5].Value = textBox4.Text.ToString();
                            }
                            n += 1;
                        }
                        MySqlConnection MyConn2 = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery");
                        MyConn2.Open();
                        for (int i = 0; i < dataGridView3.Rows.Count; i++)
                        {

                            MySqlCommand MyCommand2 = new MySqlCommand("INSERT INTO selling_details(Item_No,Quantity,Date,S_Tot,Tot,Bill) VALUES('" + dataGridView3.Rows[i].Cells["Item_No"].Value + "','" + dataGridView3.Rows[i].Cells["Quantity"].Value + "','" + dataGridView3.Rows[i].Cells["Date"].Value + "','" + dataGridView3.Rows[i].Cells["S_Tot"].Value + "','" + dataGridView3.Rows[i].Cells["Tot"].Value + "','" + dataGridView3.Rows[i].Cells["Bill"].Value + "')", MyConn2);

                            MyCommand2.ExecuteNonQuery();

                        }


                        MyConn2.Close();
                    }



                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                        listBox1.Items.Add(row.Cells[11].Value.ToString() + "   " + row.Cells[1].Value.ToString() + "      " + row.Cells[2].Value.ToString() + "    " + row.Cells[3].Value.ToString() + "    " + row.Cells[4].Value.ToString());
                    //dataGridView3.Rows.Add(row.Cells[0].Value.ToString());
                }

                printPreviewDialog1.Document = printDocument1;
              //  printPreviewDialog1.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please make your Payment");
            }           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Reports re = new Reports();
            re.Show();
            this.Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Dealer de = new Dealer();

            de.Show();

            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            cus.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Backup bk = new Backup();
            bk.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            About ab = new About();
           ab.Show();
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select Customer_Name from customer_details";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    comboBox1.DisplayMember = "Customer_Name";
                    comboBox1.ValueMember = "Customer_Name";
                    comboBox1.DataSource = ds.Tables["com"];

                   
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {
             {
             string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = "SELECT Item_No FROM stock_details where Barcode LIKE '"+textBox47.Text+"'";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();

            while (MyReader2.Read())
            {
                textBox14.Text = MyReader2.GetString("Item_No");
       
            }

            MyConn2.Close();
        }
          //  button5.PerformClick();
            button4.PerformClick();
       

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                button13.PerformClick();
                textBox47.Focus();
            }
        }

        private void textBox47_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                button22.PerformClick();
                textBox14.Focus();
            }
        }

        private void button22_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
               textBox47.Focus();
            }
        }

        private void button58_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                comboBox1.Focus();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.Show();

            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("select Unit_Price as 'Price',Item_Name as'Name' from stock_details WHERE Item_Name LIKE '%" + textBox1.Text + "%';");
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
            dataGridView4.DataSource = dTable;


            foreach (DataGridViewColumn col in dataGridView4.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                col.DefaultCellStyle.Font = new Font("Arial", 13F, GraphicsUnit.Pixel);
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();

            while (MyReader2.Read())
            {

            }

            MyConn2.Close();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
             //  textBox14.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
          
            }
            dataGridView4.Hide();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView4.Show();

            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("select Item_No as 'No',Item_Name as 'Name',Category as 'Category' ,Sub_Category as 'Sub_Category' from stock_details WHERE  Category LIKE '%" + comboBox2.Text + "%';");
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
            dataGridView4.DataSource = dTable;


            foreach (DataGridViewColumn col in dataGridView4.Columns)
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView4.Show();

            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("select Item_No as 'No',Item_Name as 'Name',Category as 'Category',Sub_Category as 'Sub_Category' from stock_details WHERE  Sub_Category LIKE '%" + comboBox3.Text + "%';");
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
            dataGridView4.DataSource = dTable;


            foreach (DataGridViewColumn col in dataGridView4.Columns)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.Show();

            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("select Customer_No as 'No', Customer_Name as 'Name' from customer_details WHERE Customer_Name LIKE '%" + textBox3.Text + "%' || Customer_No LIKE '%" + textBox3.Text+"%';");
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
            dataGridView2.DataSource = dTable;


            foreach (DataGridViewColumn col in dataGridView4.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                col.DefaultCellStyle.Font = new Font("Arial", 13F, GraphicsUnit.Pixel);
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();

            while (MyReader2.Read())
            {

            }

            MyConn2.Close();
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            label23.Show();
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            label23.Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {

            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = ("select Stock_Code,Item_Code,P_Stock,P_Price,U_Price,Tax,Dis,B_Price,Ex_Date from stock WHERE Item_Code  = '" + textBox14.Text + "';");
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {
                    textBox52.Text = MyReader2.GetString("Item_Code");
                    textBox53.Text = MyReader2.GetString("Stock_Code");
                    textBox54.Text = MyReader2.GetString("P_Stock");
                    textBox55.Text = MyReader2.GetString("P_Price");
                    textBox56.Text = MyReader2.GetString("U_Price");
                    textBox57.Text = MyReader2.GetString("Tax");
                    textBox58.Text = MyReader2.GetString("Dis");
                    textBox59.Text = MyReader2.GetString("Ex_Date");
                    textBox63.Text = MyReader2.GetString("B_Price");

                }

                MyConn2.Close();
                if (textBox52.Text == "")
                {
                   // MessageBox.Show("No Extra Stock");
                    //double qtyb = double.Parse(textBox7.Text);
                    //double rest;
                    //rest = -(qtyb);              
                    //MessageBox.Show(rest.ToString(), "Higaya No stock");
                    string MyConnection3 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query1 = "update stock_details set Current_Stock = '" + textBox54.Text + "' where Item_No = '" + textBox14.Text + "'";
                    MySqlConnection MyConn3 = new MySqlConnection(MyConnection3);
                    MySqlCommand MyCommand3 = new MySqlCommand(Query1, MyConn3);
                    MySqlDataReader MyReader3;
                    MyConn3.Open();
                    MyReader3 = MyCommand3.ExecuteReader();
                    while (MyReader3.Read())
                    {

                    }
                    MyConn3.Close();
                }
                else
                {
                    MessageBox.Show("Update Stock");
                    double qty = double.Parse(textBox54.Text);
                    double qtyb = double.Parse(textBox7.Text);
                    double rest;
                    rest = qty + (qtyb);
                    textBox64.Text = rest.ToString();
                    string MyConnection3 = "server=localhost;user id=root;password=;database=gallolowa_grocery";

                    string Query1 = "update stock_details set Stock_Code = '" + textBox53.Text + "',Purchase_Stock = '" + textBox54.Text + "',Current_Stock = '" + textBox64.Text + "',Purchase_Price = '" + textBox55.Text + "',Unit_Price = '" + textBox56.Text + "',Tax = '" + textBox57.Text + "',Discount= '" + textBox58.Text + "',Ex_Date= '" + textBox59.Text + "',Best_Price= '" + textBox63.Text + "' where Item_No = '" + textBox52.Text + "'";
                    MySqlConnection MyConn3 = new MySqlConnection(MyConnection3);
                    MySqlCommand MyCommand3 = new MySqlCommand(Query1, MyConn3);
                    MySqlDataReader MyReader3;
                    MyConn3.Open();
                    MyReader3 = MyCommand3.ExecuteReader();
                    while (MyReader3.Read())
                    {

                    }

                    MyConn3.Close();

                    string MyConnection4 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query2 = ("Delete from stock WHERE Item_Code ='" + textBox52.Text + "' && Stock_Code = '" + textBox53.Text + "';");
                    MySqlConnection MyConn4 = new MySqlConnection(MyConnection4);
                    MySqlCommand MyCommand4 = new MySqlCommand(Query2, MyConn4);
                    MySqlDataReader MyReader4;
                    MyConn4.Open();
                    MyReader4 = MyCommand4.ExecuteReader();

                    while (MyReader4.Read())
                    {

                    }

                    MyConn4.Close();
                    textBox52.Text = "";
                    textBox53.Text = "";
                    textBox54.Text = "";
                    textBox55.Text = "";
                    textBox56.Text = "";
                    textBox57.Text = "";
                    textBox58.Text = "";
                    textBox59.Text = "";
                    textBox63.Text = "";
                    textBox64.Text = "";
                }
            }
            catch
            {
            }

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
        }

        private void textBox61_TextChanged(object sender, EventArgs e)
        {

            //if (textBox50.Text == "")
            //{
            //    string MyConnection3 = "server=localhost;user id=root;password=;database= gallolowa_grocery;Charset=utf8";
            //    string Query1 = "insert into stock_details(Item_No,Item_Name,Unit_Price,Best_Price) values('" + this.textBox14.Text + "','" + this.textBox1.Text + "','" + this.textBox60.Text + "','" + this.textBox5.Text + "');";
            //    MySqlConnection MyConn3 = new MySqlConnection(MyConnection3);
            //    MySqlCommand MyCommand3 = new MySqlCommand(Query1, MyConn3);
            //    MySqlDataReader MyReader3;
            //    MyConn3.Open();
            //    MyReader3 = MyCommand3.ExecuteReader();
            //    MessageBox.Show("Save Data");
            //    while (MyReader3.Read())
            //    {

            //    }

            //    MyConn3.Close();

                string x = textBox1.Text;
                textBox50.Text = x.ToString();
               
           // }
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.Hide();
        }

        private void textBox52_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox64_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox53_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                //  textBox14.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();

            }
            dataGridView2.Hide();
        }
    }
}




    

