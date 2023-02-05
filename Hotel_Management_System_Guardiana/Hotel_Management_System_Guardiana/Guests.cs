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
    public partial class Guests : Form
    {
        HotelDataDataContext aa = new HotelDataDataContext();
        private int ID = 0;

        public Guests()
        {
            InitializeComponent();
        }

        private void Guests_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.guest_view();
        }

        private bool NullChecker()
        {
            bool result = true;

            if (name.Text == "")
                result = false;
            if (address.Text == "")
                result = false;
            if (contact.Text == "")
                result = false;

            return result;
        }
        private void ClearInput()
        {
            name.Text = "";
            address.Text = "";
            contact.Text = "";
        }
        private void save_button_Click(object sender, EventArgs e)
        {
            if(NullChecker() == true)
            {
                aa.guest_add(name.Text,address.Text,contact.Text);
                ClearInput();
                dataGridView1.DataSource = aa.guest_view();
            }
            else
                MessageBox.Show("Please input every field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                if (NullChecker() == true)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure with your choice", "Warning", buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        aa.guest_edit(ID,name.Text, address.Text, contact.Text);
                        ClearInput();
                        dataGridView1.DataSource = aa.guest_view();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            address.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            contact.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Are you sure with your choice", "Warning", buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    aa.guest_delete(ID);
                    ClearInput();
                    dataGridView1.DataSource = aa.guest_view();
                }
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.guest_search(searchBox.Text);
        }
    }
}
