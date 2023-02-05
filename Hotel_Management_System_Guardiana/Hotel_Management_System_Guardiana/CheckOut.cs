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
    public partial class CheckOut : Form
    {
        HotelDataDataContext aa = new HotelDataDataContext();
        public static int BookID;
        private string RoomNo;
        public CheckOut()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BookID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RoomNo = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.view_checked_in();
        }

        private void checkout_button_Click(object sender, EventArgs e)
        {
            DateTime current = DateTime.Today;
            if (BookID != 0)
            {
                aa.check_out(BookID, "CHECKED-OUT");
                aa.change_room_status2(RoomNo,"Vacant");
                aa.update_invoice(current,Login.AccID);
                MessageBox.Show("Succesfully Checked Out", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DisplayInvoice bb = new DisplayInvoice();
                bb.Show();
                this.Close();
            }
        }
    }
}
