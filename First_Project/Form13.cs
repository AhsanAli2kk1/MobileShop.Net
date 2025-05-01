using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Project
{
    public partial class Form13 : Form
    {
        public static Form13 instance;
        public System.Windows.Forms.TextBox tb1;
        public System.Windows.Forms.TextBox tb2;
        public Form13()
        {
            InitializeComponent();
            instance = this;
            tb1 = Installment_No_Box;
            tb2 = Amount_Box;
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            Installment_No_Box.Enabled = false;

        }

        private void Installment_No_Box_TextChanged(object sender, EventArgs e)
        {


        }

        private void Okay_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure? \nyou want to ADD this record!! ", "ADD MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form10 form = new Form10();
                Form10.installement_amount = Convert.ToInt32(Amount_Box.Text);
                this.Hide();
            }
            else 
            {
                Form10 form = new Form10();
                Form10.installement_amount = -9999999;
                this.Hide();
            }
        
        }

        private void Close_Btn_Click(object sender, EventArgs e)
        {
            Form10 form = new Form10();
            Form10.installement_amount = -9999999;
            this.Hide();
        }

        private void Amount_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Amount_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
