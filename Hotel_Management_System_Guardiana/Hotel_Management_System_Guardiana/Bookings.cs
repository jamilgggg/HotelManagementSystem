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
    public partial class Bookings : Form
    {
        HotelDataDataContext aa = new HotelDataDataContext();
        private int RoomID = 0,GuestID = 0,GuestID2 = 0, GuestID3 = 0, BookID,days,RoomPrice;
        private string GuestName;

        public Bookings()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            RoomID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            room.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            guestforroom.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            RoomPrice = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
        }

        private void Bookings_Load(object sender, EventArgs e)
        {
            aa.CLEAR_GUEST();
            dataGridView1.DataSource = aa.room_available();
            dataGridView2.DataSource = aa.guest_view();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
        }

        private void searchBox_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.room_search_available(searchBox.Text);

            if(searchBox.Text == "")
            {
                dataGridView1.DataSource = aa.room_available();
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
           if(GuestID != 0)
            {
                aa.APPEND_GUEST(GuestID, GuestName);
                dataGridView3.DataSource = aa.DISPLAY_GUEST_ADDED();
            }
        }

        private void searchBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = aa.guest_search(searchBox2.Text);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GuestID2 = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            guest2.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GuestID = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            GuestName = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            guest.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void remove_button_Click_1(object sender, EventArgs e)
        {
            if (GuestID2 != 0)
            {
                aa.REMOVE_GUEST(GuestID2);
                dataGridView3.DataSource = aa.DISPLAY_GUEST_ADDED();
            }
        }
      
        private void booking_button_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker3.Value;
            DateTime date1 = dateTimePicker1.Value.Date;
            DateTime date2 = dateTimePicker2.Value.Date;
            int result = DateTime.Compare(date1, date2);
            TimeSpan st = new TimeSpan(dt.Hour, dt.Minute, dt.Minute);

            days = (date2 - date1).Days;

            if (RoomID != 0 && GuestID !=0)
            {
                if (result < 0)
                {
                    aa.add_booking(dateTimePicker1.Value, dateTimePicker2.Value,
                     st, "PENDING", room.Text);
                    aa.change_room_status(RoomID, "Occupied");

                    //booked guest
                    AddBookedGuest();
                    //generate invoice
                    AddInvoice();
                    MessageBox.Show("Booked Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if(result == 0)
                    MessageBox.Show("Check out date should be after the check in date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                    MessageBox.Show("Invalid Date choice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void AddBookedGuest()
        {
            int GuestID, count = 0;
            DataGridViewRow row;
            dataGridView3.DataSource = aa.DISPLAY_GUEST_ADDED();

             GetBookID();
             count = dataGridView3.Rows.Count;

             for (int i = 0; i < count-1; i++)
             {
                 row = dataGridView3.Rows[i];
                 GuestID = int.Parse(row.Cells[0].Value.ToString());
                 aa.add_booked_guest(GuestID, BookID);
             }
        }
        private void AddInvoice()
        {
            int TotalPrice = days*RoomPrice;
            DateTime current = DateTime.Today;
            DataGridViewRow row;

            row = dataGridView3.Rows[0];
            GuestID3 = int.Parse(row.Cells[0].Value.ToString());
            
            GetBookID();
            aa.create_invoice(days,TotalPrice,current,Login.AccID,BookID,GuestID3);
        }
        private void GetBookID()
        {
            dataGridView4.DataSource = aa.get_BookID(room.Text);
            DataGridViewRow row = dataGridView4.Rows[0];
            BookID = int.Parse(row.Cells[0].Value.ToString());
        }

    }
}
