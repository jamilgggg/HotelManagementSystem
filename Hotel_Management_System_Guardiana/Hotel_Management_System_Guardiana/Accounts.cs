using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System_Guardiana
{
    public partial class Accounts : Form
    {
        HotelDataDataContext aa = new HotelDataDataContext();
        private int ID = 0;
        public Accounts()
        {
            InitializeComponent();
        }

        private bool NullChecker()
        {
            bool result = true;

            if (fname.Text == "")
                result = false;
            if (lname.Text == "")
                result = false;
            if (address.Text == "")
                result = false;
            if (contact.Text == "")
                result = false;
            if (user.Text == "")
                result = false;
            if (pass.Text == "")
                result = false;

            return result;
        }
        private void ClearInput()
        {
            fname.Text = "";
            lname.Text = "";
            address.Text = "";
            contact.Text = "";
            user.Text = "";
            pass.Text = "";
        }
        private bool CountPass()
        {
            String source = pass.Text;
            int count = source.Length;
            bool result = true;

            if (count < 8)
            {
                result = false;
            }

            return result;
        }
        private bool PasswordCheck2(string s)
        {
            bool result = true;

            if (Regex.IsMatch(s, "^[0-9]*$") == true)
            {
                result = false;
            }

            if (Regex.IsMatch(s, "^[a-zA-Z]*$") == true)
            {
                result = false;
            }
            return result;
        }
        private void save_button_Click(object sender, EventArgs e)
        {
            if(NullChecker() == true)
            {
                if(CountPass() == true)
                {
                    if(PasswordCheck2(pass.Text)==true)
                    {
                        string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                        aa.acc_save(fname.Text,lname.Text,address.Text,
                            contact.Text,user.Text,pass.Text,selected);
                        ClearInput();
                        dataGridView1.DataSource = aa.acc_view();

                    }
                    else
                        MessageBox.Show("Password should containt numbers and letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Password is too short", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please input every field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.acc_view();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
           
            if (NullChecker() == true)
            {
                if(ID != 0)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("Are you sure with your choice", "Warning", buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                        aa.acc_update(ID,fname.Text,lname.Text,address.Text,
                            contact.Text,user.Text,pass.Text,selected);
                        ClearInput();
                        dataGridView1.DataSource = aa.acc_view();
                    }
                }
            }
            else
                MessageBox.Show("Please input every field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            fname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            address.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            contact.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            user.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            pass.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Are you sure with your choice", "Warning", buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    aa.acc_delete(ID);
                    ClearInput();
                    dataGridView1.DataSource = aa.acc_view();
                }
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aa.acc_search(searchBox.Text);
        }
    }
}
