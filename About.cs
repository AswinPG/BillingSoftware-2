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
    public partial class About : Form
    {
        public About()
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
            fm.button58.PerformClick();
            fm.textBox4.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inv = new Inventory();
            inv.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports re = new Reports();
            re.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dealer de = new Dealer();
            de.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer cu = new Customer();
            cu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Backup bk = new Backup();
            bk.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();

        }

        private void About_Load(object sender, EventArgs e)
        {
            setFullScreen();

            panel1.Location = new Point(
                 this.ClientSize.Width / 2 - panel1.Size.Width / 2,
                this.ClientSize.Height / 2 - panel1.Size.Height / 2
                );
            panel1.Anchor = AnchorStyles.Top;
        }
    }
}
