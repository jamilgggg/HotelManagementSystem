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
    public partial class CheckIn : Form
    {
        HotelDataDataContext aa = new HotelDataDataContext();
        private int BookID = 0;
        private string RoomNo;

        public CheckIn()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BookID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RoomNo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void CheckIn_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.view_pending();
        }

        private void checkin_button_Click(object sender, EventArgs e)
        {
            if(BookID!=0)
            {
                aa.check_in(BookID, "CHECKED-IN");
                MessageBox.Show("Succesfully Checked in", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = aa.view_pending();
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            if(BookID!=0)
            {
                aa.cancel_booking2(BookID);
                aa.delete_invoice(BookID);
                aa.cancel_booking(BookID);
                aa.change_room_status2(RoomNo, "Vacant");
                MessageBox.Show("Booking Cancelled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = aa.view_pending();
            }
        }
    }
}
