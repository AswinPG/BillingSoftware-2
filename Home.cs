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
    public partial class Home : Form
    {
       



        Login log = new Login();
        Dealer deal = new Dealer();
        Form1 frm1 = new Form1();
        Reports rep = new Reports();
        Inventory stock = new Inventory();
        Customer cust = new Customer();
        About ab = new About();
        Backup back = new Backup();
       



        public Home()
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

        private void button2_Click(object sender, EventArgs e)
        {

            //stock.Location = new Point(
            //     this.ClientSize.Width / 2 - stock.Size.Width / 2,
            //    this.ClientSize.Height / 2 - stock.Size.Height / 2);
            //stock.Anchor = AnchorStyles.None;

       stock.Show();
       frm1.Hide();
       cust.Hide();
       rep.Hide();
       deal.Hide();
       ab.Hide();
       back.Hide();
       this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //cust.Location = new Point(
            //     this.ClientSize.Width / 2 - cust.Size.Width / 2,
            //    this.ClientSize.Height / 2 - cust.Size.Height / 2);
            //cust.Anchor = AnchorStyles.None;

            stock.Hide();
            frm1.Hide();
            cust.Show();
            rep.Hide();
            deal.Hide();
            ab.Hide();
            back.Hide();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            //deal.Location = new Point(
            //     this.ClientSize.Width / 2 - deal.Size.Width / 2,
            //    this.ClientSize.Height / 2 - deal.Size.Height / 2);
            //deal.Anchor = AnchorStyles.None;

            deal.Show();
            stock.Hide();
            frm1.Hide();
            cust.Hide();
            rep.Hide();
            ab.Hide();
            back.Hide();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            //rep.Location = new Point(
            //     this.ClientSize.Width / 2 - rep.Size.Width / 2,
            //    this.ClientSize.Height / 2 - rep.Size.Height / 2);
            //rep.Anchor = AnchorStyles.None;

            rep.Show();
            stock.Hide();
            frm1.Hide();
            cust.Hide();
            deal.Hide();
            ab.Hide();
            back.Hide();
            this.Hide();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            log.DesktopLocation = new Point(
                 this.ClientSize.Width / 2 - log.Size.Width / 2,
                this.ClientSize.Height / 2 - log.Size.Height / 2
                );
            log.Anchor = AnchorStyles.Top;
            this.Hide();
            log.Show();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //frm1.Location = new Point(
            //              this.ClientSize.Width / 2 - frm1.Size.Width / 2,
            //             this.ClientSize.Height / 2 - frm1.Size.Height / 2);
            //frm1.Anchor = AnchorStyles.None;
          
            stock.Hide();
            frm1.Show();
            cust.Hide();
            rep.Hide();
            deal.Hide();
            ab.Hide();
            back.Hide();
            this.Hide();
            frm1.button58.PerformClick();
            frm1.textBox4.Focus();
           
        }

        private void Home_Load(object sender, EventArgs e)
        {
            setFullScreen();
            button1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ab.Show();
            stock.Hide();
            frm1.Hide();
            cust.Hide();
            rep.Hide();
            deal.Hide();
            back.Hide();
           
           //ab.Location = new Point(
           //             this.ClientSize.Width / 2 - ab.Size.Width / 2,
           //            this.ClientSize.Height / 2 - ab.Size.Height / 2);
           //ab.Anchor = AnchorStyles.Top;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ab.Hide();
            stock.Hide();
            frm1.Hide();
            cust.Hide();
            rep.Hide();
            deal.Hide();
            back.Show();
            this.Hide();

            //back.Location = new Point(
            //             this.ClientSize.Width / 2 - back.Size.Width / 2,
            //            this.ClientSize.Height / 2 - back.Size.Height / 2);
            //back.Anchor = AnchorStyles.None;
        }

    }
}
