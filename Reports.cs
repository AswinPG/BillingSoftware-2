using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApplication1
{
    public partial class Reports : Form
    {


        DataTable db = new DataTable();
        DataTable tb = new DataTable();
        DataTable gv = new DataTable();



        public Reports()
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
     

        private void label1_MouseHover(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reports_Load(object sender, EventArgs e)
        {
            setFullScreen();

            panel8.Location = new Point(
                 this.ClientSize.Width / 2 - panel8.Size.Width / 2,
                this.ClientSize.Height / 2 - panel8.Size.Height / 2
                );
            panel8.Anchor = AnchorStyles.Top;
            
            
            //  DataGridView DGV1 = dataGridView1;
            DataGridView DGV2 = dataGridView2;
            DataGridView DGV6 = dataGridView6;
            DataGridView DGV3 = dataGridView3;

            //  DGV1.Hide();
            DGV2.Hide();
            DGV6.Hide();
            DGV3.Hide();

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy-MM-dd";
            dateTimePicker3.ShowUpDown = false;
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "yyyy-MM-dd";
            dateTimePicker4.ShowUpDown = false;


        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // DataGridView DGV1 = dataGridView1;
                DataGridView DGV2 = dataGridView2;
                DataGridView DGV6 = dataGridView6;
                DataGridView DGV3 = dataGridView3;

                DGV2.Show();
                //     DGV1.Hide();
                DGV6.Hide();
                DGV3.Hide();
                textBox15.Text = "Bill Reports";
                comboBox2.Text = "";

                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = ("select Bill_No as 'Bill_No',Customer as 'Customer',Net_Total as 'Net_Total',Discount as 'Discount',Tax as 'Tax',Total as 'Total',Cash as 'Cash',Balance as 'Balance',Sale_Total as 'Sale_Total',Items as 'Items',Date as 'Date' from bill_details WHERE Date between '" + this.dateTimePicker4.Value.Date.ToString("yyyy-MM-dd") + "'and '" + this.dateTimePicker3.Value.Date.ToString("yyyy-MM-dd") + "'ORDER BY Bill_No ASC;");
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


                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {

                }

                MyConn2.Close();




                double Total = 0;
                double Sale_Total = 0;
                double Profit;




                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    Sale_Total += Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                }
                textBox1.Text = Sale_Total.ToString();

                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    Total += Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                }
                textBox2.Text = Sale_Total.ToString();

                Profit = (Total - Sale_Total);
                textBox3.Text = Profit.ToString();

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox15.Text = "Billing Report";
                //  DataGridView DGV1 = dataGridView1;
                DataGridView DGV2 = dataGridView2;
                DataGridView DGV6 = dataGridView6;
                DataGridView DGV3 = dataGridView3;
                //    DGV1.Hide();
                DGV6.Hide();
                DGV3.Hide();
                if (comboBox2.Text != "")
                {
                    DGV2.Show();

                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Bill_No as 'Bill_No',Customer as 'Customer',Net_Total as 'Net_Total',Discount as 'Discount',Tax as 'Tax',Total as 'Total',Cash as 'Cash',Balance as 'Balance',Sale_Total as 'Sale_Total',Items as 'Items',Date as 'Date' from bill_details WHERE Date  between '" + this.dateTimePicker4.Value.Date.ToString("yyyy-MM-dd") + "'and '" + this.dateTimePicker3.Value.Date.ToString("yyyy-MM-dd") + "'&& Customer LIKE '%" + this.comboBox2.Text + "%';");

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


                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();

                    double Total = 0;
                    double Sale_Total = 0;
                    double Profit;




                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        Sale_Total += Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                    }
                    textBox1.Text = Sale_Total.ToString();

                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        Total += Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                    }
                    textBox2.Text = Sale_Total.ToString();

                    Profit = (Total - Sale_Total);
                    textBox3.Text = Profit.ToString();
                }

            }
            catch
            {
                MessageBox.Show("Invalid Date Range or Customer Name");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                comboBox8.Text = "";
                //double Selling_Stock;
                //double Income;
                //double Deposit;

                double Profit;
                // DataGridView DGV1 = dataGridView1;
                DataGridView DGV2 = dataGridView2;
                DataGridView DGV6 = dataGridView6;
                DataGridView DGV3 = dataGridView3;
                DGV2.Hide();
                // DGV1.Hide();
                DGV3.Hide();
                //  if (comboBox8.Text != "")
                {
                    DGV6.Show();

                    textBox32.Text = "Item Report";



                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Item_No as 'Item_No',Item_Name as 'Item_Name',Dealer as 'Dealer',Purchase_Stock as 'Pur_Stock',Current_Stock as 'Cur_Stock',(Purchase_Stock - Current_Stock) as 'Sel_Stock',(Purchase_Stock*Purchase_Price)as 'Deposit',((Purchase_Stock - Current_Stock)*Unit_Price)as'Income' from stock_details WHERE Item_No LIKE '%" + comboBox7.Text + "%';");
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

                    dataGridView6.DataSource = dTable;


                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();



                    double TIncome = 0;
                    double TDeposit = 0;
                    double TSell = 0;

                    for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                    {
                        TSell += Convert.ToInt32(dataGridView6.Rows[i].Cells[5].Value);
                    }
                    textBox8.Text = TSell.ToString();

                    for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                    {
                        TIncome += Convert.ToInt32(dataGridView6.Rows[i].Cells[7].Value);
                    }
                    textBox12.Text = TIncome.ToString();

                    for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                    {
                        TDeposit += Convert.ToInt32(dataGridView6.Rows[i].Cells[6].Value);
                    }
                    textBox13.Text = TDeposit.ToString();


                    Profit = -(TIncome - TDeposit);
                    textBox23.Text = Profit.ToString();



                }
            }
            catch
            {
                MessageBox.Show("Invalid Item Code");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        try{

            double Profit;
            //    DataGridView DGV1 = dataGridView1;
            DataGridView DGV2 = dataGridView2;
            DataGridView DGV6 = dataGridView6;
            DataGridView DGV3 = dataGridView3;
            DGV2.Hide();
            //   DGV1.Hide();
            DGV3.Hide();
            if (comboBox8.Text != "")
            {
                DGV6.Show();

                textBox32.Text = "Dealer Report";





                string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                string Query = ("select Item_No as 'Item_No',Item_Name as 'Item_Name',Dealer as 'Dealer',Purchase_Stock as 'Pur_Stock',Current_Stock as 'Cur_Stock',(Purchase_Stock - Current_Stock) as 'Sel_Stock',(Purchase_Stock*Purchase_Price)as 'Deposit',((Purchase_Stock - Current_Stock)*Unit_Price)as'Income' from stock_details WHERE Dealer LIKE%" + this.comboBox8.Text + "%';");
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

                dataGridView6.DataSource = dTable;


                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {

                }

                MyConn2.Close();



                double TIncome = 0;
                double TDeposit = 0;
                double TSell = 0;

                for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                {
                    TSell += Convert.ToInt32(dataGridView6.Rows[i].Cells[5].Value);
                }
                textBox8.Text = TSell.ToString();

                for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                {
                    TIncome += Convert.ToInt32(dataGridView6.Rows[i].Cells[7].Value);
                }
                textBox12.Text = TIncome.ToString();

                for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                {
                    TDeposit += Convert.ToInt32(dataGridView6.Rows[i].Cells[6].Value);
                }
                textBox13.Text = TDeposit.ToString();


                Profit = (TIncome - TDeposit);
         
                textBox23.Text = Profit.ToString();
            }
    }

        catch {
            MessageBox.Show("Invalid Dealer");
                 }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports report = new Reports();
            report.Show();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }



        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
            this.Refresh();
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView6.DataSource = null;
            textBox3.Clear();
            textBox15.Clear();
            comboBox2.ResetText();
           // dataGridView2.Hide();
            textBox44.Clear();
            textBox53.Clear();
            textBox23.Clear();
            textBox32.Clear();
            textBox8.Clear();
            comboBox1.ResetText();
            comboBox7.ResetText();
            comboBox8.ResetText();
            textBox16.Clear();
            textBox18.Clear();
            comboBox3.ResetText();
            comboBox4.ResetText();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1.Print();
            }
            catch
            {

                printPreviewDialog1.Document = printDocument1;
               // printPreviewDialog1.ShowDialog();
                printDocument1.Print();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView DGV2 = dataGridView2;
                DataGridView DGV6 = dataGridView6;
                DGV2.Hide();
                DGV6.Hide();
                textBox53.Text = "Selling Reports";
                DataGridView DGV3 = dataGridView3;
                DGV3.Show();
                {
                    MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery");
                    using (MySqlCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        cmd.CommandText = "SELECT S.Item_No,S.Item_Name,E.Quantity,E.Date,E.S_Tot,E.Tot FROM stock_details S INNER JOIN selling_details E ON E.Item_No = S.Item_No";
                        MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adap.Fill(ds);
                        dataGridView3.DataSource = ds.Tables[0].DefaultView;
                    }
                }
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView3.DataSource;
                    bs.Filter = "Date like '%" + textBox16.Text + "%' AND Item_No like '%" + textBox17.Text + "%'";
                    //  bs.Filter = "Date Between '%" + textBox16.Text + "%' AND '%" + textBox22.Text + "%'";// AND Item_No like '%" + textBox17.Text + "%'";
                    //  bs.Filter = "Item_No like '%" + textBox17.Text + "%'";
                    dataGridView3.DataSource = bs;
                }
                {
                    int sumq = 0;

                    for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                    {
                        sumq += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
                    }
                    textBox18.Text = sumq.ToString();
                }
                {
                    int sumST = 0;

                    for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                    {
                        sumST += Convert.ToInt32(dataGridView3.Rows[i].Cells[4].Value);
                    }
                    textBox19.Text = sumST.ToString();
                }
                {
                    int sumT = 0;

                    for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                    {
                        sumT += Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value);
                    }
                    textBox20.Text = sumT.ToString();
                }

                double ST = double.Parse(textBox19.Text);
                double T = double.Parse(textBox20.Text);

                double profit;

                profit = (T - ST);
                textBox44.Text = profit.ToString();


            }
            catch
            {
                MessageBox.Show("Invalid Item Code");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridView DGV2 = dataGridView2;
                DataGridView DGV6 = dataGridView6;
                DGV2.Hide();
                DGV6.Hide();

                textBox53.Text = "Selling Reports";
                DataGridView DGV3 = dataGridView3;
                DGV3.Show();
                MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery");
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "SELECT S.Item_No,S.Item_Name,E.Quantity,E.Date,E.S_Tot,E.Tot FROM stock_details S INNER JOIN selling_details E ON E.Item_No = S.Item_No  WHERE E.Date  between '" + this.dateTimePicker1.Value.Date.ToString("MM/dd/yyyy") + "'and '" + this.dateTimePicker2.Value.Date.ToString("MM/dd/yyyy") + "'&& S.Item_No LIKE '%" + this.comboBox3.Text + "%';";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    dataGridView3.DataSource = ds.Tables[0].DefaultView;
                }
                {
                    int sumq = 0;

                    for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                    {
                        sumq += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
                    }
                    textBox18.Text = sumq.ToString();
                }
                {
                    int sumST = 0;

                    for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                    {
                        sumST += Convert.ToInt32(dataGridView3.Rows[i].Cells[4].Value);
                    }
                    textBox19.Text = sumST.ToString();
                }
                {
                    int sumT = 0;

                    for (int i = 0; i < dataGridView3.Rows.Count; ++i)
                    {
                        sumT += Convert.ToInt32(dataGridView3.Rows[i].Cells[5].Value);
                    }
                    textBox20.Text = sumT.ToString();
                }

                double ST = double.Parse(textBox19.Text);
                double T = double.Parse(textBox20.Text);

                double profit;

                profit = (T - ST);
                textBox44.Text = profit.ToString();

            }
            catch
            {
                MessageBox.Show("Invalid Item Code");
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Title : " + "  " + this.textBox15.Text, this.textBox15.Font, Brushes.Black, 100, 50);

            e.Graphics.DrawString("Profit : " + "  " + this.textBox3.Text, this.textBox15.Font, Brushes.Black, 600, 50);
            int i = 0;
            int width = 0;

            int height = 0;

            StringFormat str = new StringFormat();

            str.Alignment = StringAlignment.Near;

            str.LineAlignment = StringAlignment.Center;

            str.Trimming = StringTrimming.EllipsisCharacter;

            Pen p = new Pen(Color.Black, 2.5f);

            #region Draw Column 1


            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);

            e.Graphics.DrawString(dataGridView2.Columns[0].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(25, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
            #endregion

            #region Draw column 2

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + dataGridView2.Columns[0].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + dataGridView2.Columns[0].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);

            e.Graphics.DrawString(dataGridView2.Columns[1].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(25 + dataGridView2.Columns[0].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);


            //Drawcolumn 3
            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height);

            e.Graphics.DrawString(dataGridView2.Columns[2].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(125 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[1].Height), str);

            //Drawcolumn 4
            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height);

            e.Graphics.DrawString(dataGridView2.Columns[3].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(225 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[1].Height), str);

            //Drawcolumn 5
            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height);

            e.Graphics.DrawString(dataGridView2.Columns[4].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(325 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[1].Height), str);

            //Drawcolumn 6
            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height);

            e.Graphics.DrawString(dataGridView2.Columns[5].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(425 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[1].Height), str);

            //Drawcolumn 6
            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height);

            e.Graphics.DrawString(dataGridView2.Columns[6].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(525 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[1].Height), str);

            //Drawcolumn 7
            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height);

            e.Graphics.DrawString(dataGridView2.Columns[7].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(625 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[1].Height), str);

            ////Drawcolumn 8
            //e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            //e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height);

            //e.Graphics.DrawString(dataGridView2.Columns[8].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(725 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[1].Height), str);

            ////Drawcolumn 9
            //e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            //e.Graphics.DrawRectangle(Pens.Black, 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height);

            //e.Graphics.DrawString(dataGridView2.Columns[9].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(900 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[1].Height), str);

            ////Drawcolumn 10
            //e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height));

            //e.Graphics.DrawRectangle(Pens.Black, 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 +  dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[1].Width, dataGridView2.Rows[0].Height);

            //e.Graphics.DrawString(dataGridView2.Columns[10].HeaderText, dataGridView2.Font, Brushes.Black, new RectangleF(1000+ dataGridView2.Columns[1].Width, 100, dataGridView2.Columns[0].Width, dataGridView2.Rows[1].Height), str);


            width = 100 + dataGridView2.Columns[0].Width;

            height = 100;

            //variable i is declared at class level to preserve the value of i if e.hasmorepages is true
            while (i < dataGridView2.Rows.Count)
            {
                if (height > e.MarginBounds.Height)
                {

                    height = 100;

                    width = 100;

                    e.HasMorePages = true;

                    return;
                }
                height += dataGridView2.Rows[i].Height;
                e.Graphics.DrawRectangle(Pens.Black, 25, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[0].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(25, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 25 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[1].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(25 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 125 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[2].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(125 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 225 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[3].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(225 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 325 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[4].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(325 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 425 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[5].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(425 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 525 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[6].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(525 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 625 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[7].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(625 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                //e.Graphics.DrawRectangle(Pens.Black, 725 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                //e.Graphics.DrawString(dataGridView2.Rows[i].Cells[8].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(725 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                //e.Graphics.DrawRectangle(Pens.Black,900+ dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                //e.Graphics.DrawString(dataGridView2.Rows[i].Cells[9].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(900 + dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);
                //e.Graphics.DrawRectangle(Pens.Black,1000+ dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height);
                //e.Graphics.DrawString(dataGridView2.Rows[i].Cells[10].FormattedValue.ToString(), dataGridView2.Font, Brushes.Black, new RectangleF(1000+ dataGridView2.Columns[0].Width, height, dataGridView2.Columns[0].Width, dataGridView2.Rows[0].Height), str);

                width += dataGridView2.Columns[0].Width;
                i++;
            }
            #endregion
        }

      
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("select Item_No ,Item_Name as 'Item_Name' from stock_details WHERE Item_No LIKE '%" + comboBox7.Text + "%';");
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;

            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();

            while (MyReader2.Read())
            {
                comboBox1.Text = (MyReader2["Item_Name"].ToString());
            }

            MyConn2.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("select Item_No ,Item_Name as 'Item_Name' from stock_details WHERE Item_Name LIKE '%" + comboBox1.Text + "%';");
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;

            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();

            while (MyReader2.Read())
            {
                comboBox7.Text = (MyReader2["Item_No"].ToString());
            }

            MyConn2.Close();

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox17.Text = comboBox3.Text;

            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("select Item_No ,Item_Name as 'Item_Name' from stock_details WHERE Item_No LIKE '%" + comboBox3.Text + "%';");
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;

            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();

            while (MyReader2.Read())
            {
                comboBox4.Text = (MyReader2["Item_Name"].ToString());
            }

            MyConn2.Close();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("select Item_No ,Item_Name as 'Item_Name' from stock_details WHERE Item_Name LIKE '%" + comboBox4.Text + "%';");
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;

            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();

            while (MyReader2.Read())
            {
                comboBox3.Text = (MyReader2["Item_No"].ToString());
            }

            MyConn2.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox16.Text = dateTimePicker1.Value.Date.ToString("MM/dd/yyyy");
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
           

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                textBox15.Text = "Billing Report";
                //  DataGridView DGV1 = dataGridView1;
                DataGridView DGV2 = dataGridView2;
                DataGridView DGV6 = dataGridView6;
                //   DGV1.Hide();
                DGV6.Hide();
                if (comboBox2.Text != "")
                {
                    DGV2.Show();
                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Bill_No as 'Bill_No',Customer as 'Customer',Net_Total as 'Net_Total',Discount as 'Discount',Tax as 'Tax',Total as 'Total',Sale_Total as 'Sale_Total',Date as 'Date' from bill_details WHERE  Customer LIKE '%" + this.comboBox2.Text + "%';");

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


                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();

                    double Total = 0;
                    double Sale_Total = 0;
                    double Profit;




                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        Sale_Total += Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);
                    }
                    textBox1.Text = Sale_Total.ToString();

                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        Total += Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                    }
                    textBox2.Text = Sale_Total.ToString();

                    Profit = (Total - Sale_Total);
                    textBox3.Text = Profit.ToString();

                }

            }
            catch
            {
                MessageBox.Show("Invalid Customer Name");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            PdfPTable table = new PdfPTable(dataGridView3.Columns.Count);

            for (int j = 0; j < dataGridView3.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView3.Columns[j].HeaderText));

            }
            table.HeaderRows = 1;

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView3.Columns.Count; k++)
                {
                    if (dataGridView3[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView3[k, i].Value.ToString()));
                    }
                }
            }
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport7.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 100f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(new Phrase(this.textBox15.Text.ToString().PadLeft(50)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("From  : ".PadLeft(43)));
                pdfDoc.Add(new Phrase(this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd").PadLeft(20)));
                pdfDoc.Add(new Phrase("To    : ".PadLeft(100)));
                pdfDoc.Add(new Phrase(this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd").PadLeft(20)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(table);
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("Selling Stock".PadLeft(48)));
                pdfDoc.Add(new Phrase(this.textBox18.Text.ToString().PadLeft(10)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("Profit (Rs:)".PadLeft(48)));
                pdfDoc.Add(new Phrase(this.textBox3.Text.ToString().PadLeft(13)));


                pdfDoc.Close();
                stream.Close();
            }

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;

            startInfo.FileName = @"C:\PDFs\DataGridViewExport7.pdf";
            process.Start();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PdfPTable table = new PdfPTable(dataGridView2.Columns.Count);

            for (int j = 0; j < dataGridView2.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView2.Columns[j].HeaderText));

            }
            table.HeaderRows = 1;

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView2.Columns.Count; k++)
                {
                    if (dataGridView2[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView2[k, i].Value.ToString()));
                    }
                }
            }
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport8.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 100f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(new Phrase(this.textBox15.Text.ToString().PadLeft(48)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("From  : ".PadLeft(43)));
                pdfDoc.Add(new Phrase(this.dateTimePicker4.Value.Date.ToString("yyyy-MM-dd").PadLeft(20)));
                pdfDoc.Add(new Phrase("To    : ".PadLeft(100)));
                pdfDoc.Add(new Phrase(this.dateTimePicker3.Value.Date.ToString("yyyy-MM-dd").PadLeft(20)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("Customer :".PadLeft(45)));
                pdfDoc.Add(new Phrase(this.comboBox2.Text.ToString().PadLeft(10)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(table);
                //pdfDoc.Add(new Phrase("\n"));
                //pdfDoc.Add(new Phrase("Selling Stock".PadLeft(48)));
                //pdfDoc.Add(new Phrase(this.textBox18.Text.ToString().PadLeft(10)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("Profit (Rs :)".PadLeft(48)));
                pdfDoc.Add(new Phrase(this.textBox3.Text.ToString().PadLeft(13)));


                pdfDoc.Close();
                stream.Close();
            }

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;

            startInfo.FileName = @"C:\PDFs\DataGridViewExport8.pdf";
            process.Start();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            PdfPTable table = new PdfPTable(dataGridView6.Columns.Count);

            for (int j = 0; j < dataGridView6.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView6.Columns[j].HeaderText));

            }
            table.HeaderRows = 1;

            for (int i = 0; i < dataGridView6.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView6.Columns.Count; k++)
                {
                    if (dataGridView6[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView6[k, i].Value.ToString()));
                    }
                }
            }
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport9.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 100f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(new Phrase(this.textBox15.Text.ToString().PadLeft(50)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("Date  : ".PadLeft(43)));
                pdfDoc.Add(new Phrase(DateTime.Now.ToString("yyyy-MM-dd").PadLeft(20)));
                //  pdfDoc.Add(new Phrase("To    : ".PadLeft(100)));
                //pdfDoc.Add(new Phrase(this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd").PadLeft(20)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("Dealer :".PadLeft(45)));
                pdfDoc.Add(new Phrase(this.comboBox8.Text.ToString().PadLeft(10)));
                pdfDoc.Add(table);
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("Selling Stock  :".PadLeft(48)));
                pdfDoc.Add(new Phrase(this.textBox8.Text.ToString().PadLeft(10)));
                pdfDoc.Add(new Phrase("\n"));
                pdfDoc.Add(new Phrase("Profit (Rs:)".PadLeft(48)));
                pdfDoc.Add(new Phrase(this.textBox3.Text.ToString().PadLeft(13)));


                pdfDoc.Close();
                stream.Close();
            }

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;

            startInfo.FileName = @"C:\PDFs\DataGridViewExport9.pdf";
            process.Start();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument2.Print();
            }
            catch
            {
                printPreviewDialog2.Document = printDocument2;
                printDocument2.Print();
               // printPreviewDialog2.ShowDialog();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
        }

        private void printDocument2_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            

        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Title : " + "  " + this.textBox32.Text, this.textBox32.Font, Brushes.Black, 100, 50);

            e.Graphics.DrawString("Profit : " + "  " + this.textBox23.Text, this.textBox44.Font, Brushes.Black, 600, 50);

            int i = 0;
            int width = 0;

            int height = 0;

            StringFormat str = new StringFormat();

            str.Alignment = StringAlignment.Near;

            str.LineAlignment = StringAlignment.Center;

            str.Trimming = StringTrimming.EllipsisCharacter;

            Pen p = new Pen(Color.Black, 2.5f);

            #region Draw Column 1

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            e.Graphics.DrawString(dataGridView6.Columns[0].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(25, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);

            #endregion

            #region Draw column 2

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            e.Graphics.DrawString(dataGridView6.Columns[1].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(25 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);



            // Draw column 3

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            e.Graphics.DrawString(dataGridView6.Columns[2].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(125 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);



            //Draw column 4

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            e.Graphics.DrawString(dataGridView6.Columns[3].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(225 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);

            // Draw column 5

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            e.Graphics.DrawString(dataGridView6.Columns[4].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(325 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);



            // Draw column 6

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            e.Graphics.DrawString(dataGridView6.Columns[5].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(425 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);


            // Draw column 7

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            e.Graphics.DrawString(dataGridView6.Columns[6].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(525 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);



            //Draw column 8

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(25 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 25 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            e.Graphics.DrawString(dataGridView6.Columns[7].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(625 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);

            //// Draw column 9

            //e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            //e.Graphics.DrawRectangle(Pens.Black, 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            //e.Graphics.DrawString(dataGridView6.Columns[8].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(800 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);



            //// Draw column 10

            //e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height));

            //e.Graphics.DrawRectangle(Pens.Black, 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + 100 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);

            //e.Graphics.DrawString(dataGridView6.Columns[9].HeaderText, dataGridView6.Font, Brushes.Black, new RectangleF(900 + dataGridView6.Columns[0].Width, 100, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);





            width = 100 + dataGridView6.Columns[0].Width;
            height = 100;
            //variable i is declared at class level to preserve the value of i if e.hasmorepages is true
            while (i < dataGridView6.Rows.Count)
            {
                if (height > e.MarginBounds.Height)
                {

                    height = 100;

                    width = 100;

                    e.HasMorePages = true;

                    return;
                }
                height += dataGridView6.Rows[i].Height;
                e.Graphics.DrawRectangle(Pens.Black, 25, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                e.Graphics.DrawString(dataGridView6.Rows[i].Cells[0].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(25, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 25 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                e.Graphics.DrawString(dataGridView6.Rows[i].Cells[1].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(25 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 125 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                e.Graphics.DrawString(dataGridView6.Rows[i].Cells[2].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(125 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 225 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                e.Graphics.DrawString(dataGridView6.Rows[i].Cells[3].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(225 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 325 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                e.Graphics.DrawString(dataGridView6.Rows[i].Cells[4].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(325 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 425 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                e.Graphics.DrawString(dataGridView6.Rows[i].Cells[5].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(425 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 525 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                e.Graphics.DrawString(dataGridView6.Rows[i].Cells[6].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(525 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 625 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                e.Graphics.DrawString(dataGridView6.Rows[i].Cells[7].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(625 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);
                //.Graphics.DrawRectangle(Pens.Black, 800 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                //.Graphics.DrawString(dataGridView6.Rows[i].Cells[8].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(800 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);
                //.Graphics.DrawRectangle(Pens.Black, 900 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height);
                //.Graphics.DrawString(dataGridView6.Rows[i].Cells[9].FormattedValue.ToString(), dataGridView6.Font, Brushes.Black, new RectangleF(900 + dataGridView6.Columns[0].Width, height, dataGridView6.Columns[0].Width, dataGridView6.Rows[0].Height), str);

                width += dataGridView6.Columns[0].Width;
                i++;
            }

            #endregion

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog3.Document = printDocument3;
            printPreviewDialog3.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument3.Print();
            }
            catch
            {
                printPreviewDialog3.Document = printDocument3;
               // printPreviewDialog3.ShowDialog();
                printDocument3.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Title : " + "  " + this.textBox53.Text, this.textBox53.Font, Brushes.Black, 100, 50);

            e.Graphics.DrawString("Profit : " + "  " + this.textBox44.Text, this.textBox44.Font, Brushes.Black, 600, 50);

            int i = 0;
            int width = 0;

            int height = 0;

            StringFormat str = new StringFormat();

            str.Alignment = StringAlignment.Near;

            str.LineAlignment = StringAlignment.Center;

            str.Trimming = StringTrimming.EllipsisCharacter;

            Pen p = new Pen(Color.Black, 2.5f);

            #region Draw Column 1

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 100, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);

            e.Graphics.DrawString(dataGridView3.Columns[0].HeaderText, dataGridView3.Font, Brushes.Black, new RectangleF(100, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);

            #endregion

            #region Draw column 2

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);

            e.Graphics.DrawString(dataGridView3.Columns[1].HeaderText, dataGridView3.Font, Brushes.Black, new RectangleF(100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);



            // Draw column 3

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100 + 100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 100 + 100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);

            e.Graphics.DrawString(dataGridView3.Columns[2].HeaderText, dataGridView3.Font, Brushes.Black, new RectangleF(200 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);



            //Draw column 4

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100 + 100 + 100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 100 + 100 + 100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);

            e.Graphics.DrawString(dataGridView3.Columns[3].HeaderText, dataGridView3.Font, Brushes.Black, new RectangleF(300 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);

            // Draw column 5

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100 + 100 + 100 + 100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 100 + 100 + 100 + 100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);

            e.Graphics.DrawString(dataGridView3.Columns[4].HeaderText, dataGridView3.Font, Brushes.Black, new RectangleF(400 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);



            // Draw column 6

            e.Graphics.FillRectangle(Brushes.LightGray, new System.Drawing.Rectangle(100 + 100 + 100 + 100 + 100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height));

            e.Graphics.DrawRectangle(Pens.Black, 100 + 100 + 100 + 100 + 100 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);

            e.Graphics.DrawString(dataGridView3.Columns[5].HeaderText, dataGridView3.Font, Brushes.Black, new RectangleF(500 + dataGridView3.Columns[0].Width, 100, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);




            width = 100 + dataGridView3.Columns[0].Width;
            height = 100;
            //variable i is declared at class level to preserve the value of i if e.hasmorepages is true
            while (i < dataGridView3.Rows.Count)
            {
                if (height > e.MarginBounds.Height)
                {

                    height = 100;

                    width = 100;

                    e.HasMorePages = true;

                    return;
                }
                height += dataGridView3.Rows[i].Height;
                e.Graphics.DrawRectangle(Pens.Black, 100, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);
                e.Graphics.DrawString(dataGridView3.Rows[i].Cells[0].FormattedValue.ToString(), dataGridView3.Font, Brushes.Black, new RectangleF(100, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 100 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);
                e.Graphics.DrawString(dataGridView3.Rows[i].Cells[1].FormattedValue.ToString(), dataGridView3.Font, Brushes.Black, new RectangleF(100 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 200 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);
                e.Graphics.DrawString(dataGridView3.Rows[i].Cells[2].FormattedValue.ToString(), dataGridView3.Font, Brushes.Black, new RectangleF(200 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 300 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);
                e.Graphics.DrawString(dataGridView3.Rows[i].Cells[3].FormattedValue.ToString(), dataGridView3.Font, Brushes.Black, new RectangleF(300 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 400 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);
                e.Graphics.DrawString(dataGridView3.Rows[i].Cells[4].FormattedValue.ToString(), dataGridView3.Font, Brushes.Black, new RectangleF(400 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);
                e.Graphics.DrawRectangle(Pens.Black, 500 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height);
                e.Graphics.DrawString(dataGridView3.Rows[i].Cells[5].FormattedValue.ToString(), dataGridView3.Font, Brushes.Black, new RectangleF(500 + dataGridView3.Columns[0].Width, height, dataGridView3.Columns[0].Width, dataGridView3.Rows[0].Height), str);

                width += dataGridView3.Columns[0].Width;
                i++;
            }

            #endregion


            //Bitmap bm = new Bitmap(this.dataGridView3.Width, this.dataGridView3.Height);
            //dataGridView3.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, this.dataGridView3.Width, this.dataGridView3.Height));
            //e.Graphics.DrawImage(bm, 100, 50);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView6.DataSource = null;
            textBox3.Clear();
            textBox15.Clear();
            comboBox2.ResetText();
           // dataGridView2.Hide();
           // printDialog1.Reset();

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
            string Query = ("select Item_No ,Item_Name as 'Item_Name' from stock_details WHERE Item_No LIKE '%" + comboBox7.Text + "%';");
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;

            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();

            while (MyReader2.Read())
            {
                comboBox1.Text = (MyReader2["Item_Name"].ToString());
            }

            MyConn2.Close();

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text == "")
            {
                double Profit;
               // DataGridView DGV1 = dataGridView1;
                DataGridView DGV2 = dataGridView2;
                DataGridView DGV6 = dataGridView6;
                DataGridView DGV3 = dataGridView3;
                DGV2.Hide();
                // DGV1.Hide();
                DGV3.Hide();
                //  if (comboBox8.Text != "")
                {
                    DGV6.Show();

                    textBox15.Text = "Item Report";



                    string MyConnection2 = "server=localhost;user id=root;password=;database=gallolowa_grocery";
                    string Query = ("select Item_No as 'Item_No',Item_Name as 'Item_Name',Dealer as 'Dealer',Purchase_Stock as 'Pur_Stock',Current_Stock as 'Cur_Stock',(Purchase_Stock - Current_Stock) as 'Sel_Stock',(Purchase_Stock*Purchase_Price)as 'Deposit',((Purchase_Stock - Current_Stock)*Unit_Price)as'Income' from stock_details WHERE Item_No LIKE '%" + this.textBox7.Text + "%';");
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

                    dataGridView6.DataSource = dTable;


                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {

                    }

                    MyConn2.Close();



                    double TIncome = 0;
                    double TDeposit = 0;
                    double TSell = 0;

                    for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                    {
                        TSell += Convert.ToInt32(dataGridView6.Rows[i].Cells[5].Value);
                    }
                    textBox8.Text = TSell.ToString();

                    for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                    {
                        TIncome += Convert.ToInt32(dataGridView6.Rows[i].Cells[7].Value);
                    }
                    textBox12.Text = TIncome.ToString();

                    for (int i = 0; i < dataGridView6.Rows.Count; ++i)
                    {
                        TDeposit += Convert.ToInt32(dataGridView6.Rows[i].Cells[6].Value);
                    }
                    textBox13.Text = TDeposit.ToString();


                    Profit = -(TIncome - TDeposit);
                    textBox3.Text = Profit.ToString();

                }
            }
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView6.DataSource = null;
            textBox44.Clear();
            textBox53.Clear();
            textBox16.Clear();
            textBox18.Clear();
            comboBox3.ResetText();
            comboBox4.ResetText();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView6.DataSource = null;
            textBox23.Clear();
            textBox32.Clear();
            textBox8.Clear();
            comboBox1.ResetText();
            comboBox7.ResetText();
            comboBox8.ResetText();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog3_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog2_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            textBox16.Text = dateTimePicker1.Value.Date.ToShortDateString();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
            fm.button58.PerformClick();
            fm.textBox4.Focus();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.Show();

            this.Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Dealer de = new Dealer();
            de.Show();
            this.Hide();

        }

        private void button26_Click(object sender, EventArgs e)
        {

            Customer cus = new Customer();
            cus.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {


            Backup bk = new Backup();
            bk.Show();
            this.Hide();


        }

        private void button21_Click(object sender, EventArgs e)
        {

            About ab = new About();
            ab.Show();
            this.Hide();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select DISTINCT Customer from bill_details";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    comboBox2.DisplayMember = "Customer";
                    comboBox2.ValueMember = "Customer";
                    comboBox2.DataSource = ds.Tables["com"];
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
        }

        private void comboBox7_DropDown(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select DISTINCT Item_No from stock_details";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    comboBox7.DisplayMember = "Item_No";
                    comboBox7.ValueMember = "Item_No";
                    comboBox7.DataSource = ds.Tables["com"];
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select DISTINCT Item_Name from stock_details";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    comboBox1.DisplayMember = "Item_Name";
                    comboBox1.ValueMember = "Item_Name";
                    comboBox1.DataSource = ds.Tables["com"];
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
        }

        private void comboBox8_DropDown(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select DISTINCT Dealer from stock_details";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    comboBox8.DisplayMember = "Dealer";
                    comboBox8.ValueMember = "Dealer";
                    comboBox8.DataSource = ds.Tables["com"];
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select DISTINCT Item_No from stock_details";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    comboBox3.DisplayMember = "Item_No";
                    comboBox3.ValueMember = "Item_No";
                    comboBox3.DataSource = ds.Tables["com"];
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
        }

        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=;database=gallolowa_grocery"))
            {
                try
                {
                    string query = "select DISTINCT Item_Name from stock_details";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "com");
                    comboBox4.DisplayMember = "Item_Name";
                    comboBox4.ValueMember = "Item_Name";
                    comboBox4.DataSource = ds.Tables["com"];
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
        }
    }
}

