using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Project
{
    public partial class Form15 : Form
    {
        public static Form15 instance;
        public System.Windows.Forms.TextBox tb1;
        public System.Windows.Forms.TextBox tb2;
        public System.Windows.Forms.TextBox tb3;
        public Form15()
        {
            InitializeComponent();
            instance = this;
            tb1 = Installment_No_Box;
            tb3 = Amount_Box;
        }

        private void Close_Btn_Click(object sender, EventArgs e)
        {
            Update_Dealer_form form = new Update_Dealer_form();
            Update_Dealer_form.installement_amount = -9999999;
            this.Hide();
        }

        private void Okay_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? \nyou want to ADD this record !! ", "ADD MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Update_Dealer_form form = new Update_Dealer_form();
                Update_Dealer_form.installement_amount = Convert.ToInt32(Amount_Box.Text);
                this.Hide();
            }
            else 
            {
                Update_Dealer_form form = new Update_Dealer_form();
                Update_Dealer_form.installement_amount = -9999999;
                this.Hide();
            }
        }

        private void Amount_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            Installment_No_Box.Enabled = false;
          
        }
    }
}
