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
    public partial class Rooms : Form
    {
        HotelDataDataContext aa = new HotelDataDataContext();
        private int ID = 0;
        public Rooms()
        {
            InitializeComponent();
        }

        public bool NullChecker()
        {
            bool result = true;

            if (num.Text == "")
                result = false;
            if (type.Text == "")
                result = false;
            if (max.Text == "")
                result = false;
            if (status.Text == "")
                result = false;
            if (price.Text == "")
                result = false;

            return result;
        }
        private void ClearInput()
        {
            num.Text = "";
            type.Text = "";
            max.Text = "";
            status.Text = "";
            price.Text = "";
        }
        private void save_button_Click(object sender, EventArgs e)
        {
            if(NullChecker()==true)
            {
                int m = int.Parse(max.Text);
                int p = int.Parse(price.Text);
                aa.room_add(num.Text, type.Text, m, status.Text, p);
                ClearInput();
                dataGridView1.DataSource = aa.room_view();
            }
            else
                MessageBox.Show("Please input every field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.room_view();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                if (NullChecker() == true)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure with your choice", "Warning", buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int m = int.Parse(max.Text);
                        int p = int.Parse(price.Text);
                        aa.room_edit(ID,num.Text, type.Text, m, status.Text, p);
                        ClearInput();
                        dataGridView1.DataSource = aa.room_view();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            num.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            type.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            max.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            status.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            price.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Are you sure with your choice", "Warning", buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    aa.room_delete(ID);
                    ClearInput();
                    dataGridView1.DataSource = aa.room_view();
                }
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.room_search(searchBox.Text);
        }
    }
}
