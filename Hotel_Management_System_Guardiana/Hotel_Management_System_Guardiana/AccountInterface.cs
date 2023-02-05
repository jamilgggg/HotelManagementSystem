using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System_Guardiana
{
    public partial class AccountInterface : Form
    {
        private int childFormNumber = 0;

        public AccountInterface()
        {
            InitializeComponent();
        }

       
        private void AccountInterface_Load(object sender, EventArgs e)
        {

        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts aa = new Accounts();
            aa.MdiParent = this;
            aa.Show();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rooms aa = new Rooms();
            aa.MdiParent = this;
            aa.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login aa = new Login();
            aa.Show();
            this.Close();
        }
    }
}
