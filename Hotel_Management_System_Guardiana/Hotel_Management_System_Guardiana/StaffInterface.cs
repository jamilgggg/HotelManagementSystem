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
    public partial class StaffInterface : Form
    {
        private int childFormNumber = 0;

        public StaffInterface()
        {
            InitializeComponent();
        }

       

        private void StaffInterface_Load(object sender, EventArgs e)
        {

        }

        private void guestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guests aa = new Guests();
            aa.MdiParent = this;
            aa.Show();
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bookings aa = new Bookings();
            aa.MdiParent = this;
            aa.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login aa = new Login();
            aa.Show();
            this.Close();
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckIn aa = new CheckIn();
            aa.MdiParent = this;
            aa.Show();
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckOut aa = new CheckOut();
            aa.MdiParent = this;
            aa.Show();
        }
    }
}
