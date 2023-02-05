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
    public partial class DisplayInvoice : Form
    {
        HotelDataDataContext aa = new HotelDataDataContext();
        public DisplayInvoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayInvoice_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.view_invoice(CheckOut.BookID);

            DataGridViewRow row;

            row = dataGridView1.Rows[0];
            Days.Text = row.Cells[0].Value.ToString();
            Total.Text = row.Cells[1].Value.ToString();
            IssuedTo.Text = row.Cells[2].Value.ToString();
            IssuedBy.Text = row.Cells[3].Value.ToString() + " " +
             row.Cells[4].Value.ToString();
            RoomNum.Text = row.Cells[5].Value.ToString();

        }
    }
}
