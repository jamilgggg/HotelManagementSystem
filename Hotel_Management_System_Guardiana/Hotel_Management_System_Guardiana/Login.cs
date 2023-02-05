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
    public partial class Login : Form
    {
        HotelDataDataContext aa = new HotelDataDataContext();
        public static int AccID = 0;
        public Login()
        {
            InitializeComponent();
        }
        
        private bool CheckNull() {
            bool result = true;

            if (user.Text == "")
                result = false;
            if (pass.Text == "")
                result = false;

            return result;
        }
        private void GetID()
        {
            dataGridView2.DataSource = aa.getAccountID(user.Text);
            DataGridViewRow row = dataGridView2.Rows[0];
            AccID = int.Parse(row.Cells[0].Value.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int count;

            if (CheckNull() == true)
            {
                count = aa.acc_login(user.Text, pass.Text).Count();

                if (count != 0)
                {
                    dataGridView1.DataSource = aa.getAccountType(user.Text);
                    String acctype;
                    DataGridViewRow row = dataGridView1.Rows[0];
                    acctype = row.Cells[0].Value.ToString();
                    GetID();
                    OpenInterface(acctype);
                    
                }
                else
                    MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please input every field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OpenInterface(string s)
        {
            if(s == "ADMIN")
            {
                AccountInterface bb = new AccountInterface();
                bb.Show();
                this.Hide();
            }
            if (s == "STAFF")
            {
                StaffInterface bb = new StaffInterface();
                bb.Show();
                this.Hide();
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
