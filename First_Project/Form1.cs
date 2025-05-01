using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace First_Project
{
    public partial class Signin : Form
    {
        DBAccess ObjdBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        
        public Signin()
        {
            InitializeComponent();
              
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SignInBtn_Click(object sender, EventArgs e)

        {
            
            
            string username = SigninUserBox.Text;
            string password = SigninPassBox.Text;

            if (username.Equals("Admin") && password.Equals("admin")) {

                ObjdBAccess.closeConn();
                Form10 form = new Form10();
                form.ShowDialog();
                

            }

            if (username.Equals(""))
            {
                MessageBox.Show("Please Enter Username");
            }

            else if (password.Equals(""))
            {
                MessageBox.Show("Please Enter Password");
            }



            else
            {
                string query = "Select * from Admin WHERE username = '" + username + "' And password = '" + password + "'";
                

                ObjdBAccess.readDatathroughAdapter(query, dtUsers);
               
                if (dtUsers.Rows.Count == 1)
                {
                    
                    ObjdBAccess.closeConn();
                    Form10 form = new Form10();
                    this.Hide();
                    form.ShowDialog();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid Credentials!");
                    SigninUserBox.Text = "";
                    SigninPassBox.Text = "";
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SigninPassBox.UseSystemPasswordChar = false;
            }
            else
            {
                SigninPassBox.UseSystemPasswordChar = true;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void form1_Load(object sender, EventArgs e)
        {
            SigninPassBox.UseSystemPasswordChar = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void SigninUserBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Simulate a click on the SignInBtn_Click method
                SignInBtn_Click(sender, e);
            }
        }

        private void SigninPassBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Simulate a click on the SignInBtn_Click method
                SignInBtn_Click(sender, e);
            }
        }
    }
}
