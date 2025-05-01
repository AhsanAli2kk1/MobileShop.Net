using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Project
{
    public partial class Accessories_form : Form
    {
        DBAccess ObjdBAccess = new DBAccess();
        DataTable userInfo = new DataTable();
        
        public int updatedBrand;
        public int updatedModel;
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();
        public Accessories_form()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CusPhoNumBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CusPhoNumBox.MaxLength = 11;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {

                e.Handled = true;
            }

        }

        private void CusIMEI1Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {

                e.Handled = true;
            }
        }

        private void CusTotalAmntBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {

                e.Handled = true;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void CusNameBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            string name = CusNameBox.Text;
            string lname = CusLastNameBox.Text;
            string pnum = CusPhoNumBox.Text;
            int quantity = Convert.ToInt32(AccQuantityBox.Text);
            DateTime purchasedate = DateTime.Now;
            int amnt = Convert.ToInt32(AccAmntBox.Text);
            int totalamnt = Convert.ToInt32(AccTotalAmntBox.Text);



            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("CheckBrandModelInventory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the stored procedure
                        command.Parameters.AddWithValue("@BrandID", updatedBrand);
                        command.Parameters.AddWithValue("@ModelID", updatedModel);

                        // Execute the stored procedure
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            bool exists = reader.GetBoolean(reader.GetOrdinal("Exist"));
                            int totalQuantity = reader.GetInt32(reader.GetOrdinal("TotalQuantity"));
                            int totalSold = reader.GetInt32(reader.GetOrdinal("TotalSold"));
                            int remaing=totalQuantity-totalSold;

                            if (exists)
                            {
                                if(remaing>quantity) 
                                {
                                    
                                    UpdateAccTable();
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Brand and model combination does not exist or all sold.");
                                return;
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void UpdateAccTable() 
        {
           
        }

        private void AccQuantityBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AccAmntBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Parse the text values to integers


                if (AccAmntBox.Text != "")
                {
                    int quantity = Convert.ToInt32(AccQuantityBox.Text);
                    int amount = Convert.ToInt32(AccAmntBox.Text);

                    // Calculate the total amount
                    int totalAmount = quantity * amount;
                    // Display the total amount in AccTotalAmntBox
                    AccTotalAmntBox.Text = totalAmount.ToString();
                }
                else {
                    AccTotalAmntBox.Text = "";
                }
            }
            catch (FormatException)
            {
                // Handle the case where input is not a valid integer
                MessageBox.Show("Please enter valid integer values for quantity and amount.");
            }
        }

        private void Accessories_form_Load(object sender, EventArgs e)
        {

            // For UpdBrandComboBox
            UpdBrandComboBox.DropDownStyle = ComboBoxStyle.DropDown; // Allow manual entry
            UpdBrandComboBox.IntegralHeight = false; // Allow the drop-down to be larger than the specified height
            UpdBrandComboBox.MaxDropDownItems = 10; // Set the maximum number of visible items
            UpdBrandComboBox.DropDownHeight = UpdBrandComboBox.ItemHeight * UpdBrandComboBox.MaxDropDownItems; // Set the height of the drop-down to fit the specified number of items

            // For UpdModelComboBox
            UpdModelComboBox.DropDownStyle = ComboBoxStyle.DropDown; // Allow manual entry
            UpdModelComboBox.IntegralHeight = false; // Allow the drop-down to be larger than the specified height
            UpdModelComboBox.MaxDropDownItems = 10; // Set the maximum number of visible items
            UpdModelComboBox.DropDownHeight = UpdModelComboBox.ItemHeight * UpdModelComboBox.MaxDropDownItems; // Set the height of the drop-down to fit the specified number of items

            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetAccBrandNames", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters to the stored procedure


                        ObjdBAccess.readDatathroughAdapter("GetAccBrandNames", dtBrands);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int count = 0;

                            while (reader.Read())
                            {

                                UpdBrandComboBox.Items.Add($"{dtBrands.Rows[count]["AccBrandName"]}");
                                count++;

                            }
                        }


                    }

                }
                BrandAutoComplete();

            }
            catch
            {
                MessageBox.Show("Program tu warr Gaya");
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetAccModelNames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TargetID", updatedBrand);

                        // Remove the unused SqlParameter 'parameter'
                        SqlParameter parameter = new SqlParameter("@TargetID", SqlDbType.Int, 32);
                        parameter.Value = updatedBrand;

                        ObjdBAccess.readDatathroughAdapter_2("GetAccModelNames", dtModels, parameter);

                        UpdModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            UpdModelComboBox.Items.Add($"{row["AccModelName"]}");
                        }
                    }
                }
                ModelAutoComplete();

                // Move SetupAutoComplete outside the try block if it's not directly related
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show($"Error Occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void BrandAutoComplete()
        {
            // Assuming dtBrands is your DataTable containing brand names
            try
            {
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                foreach (DataRow row in dtBrands.Rows)
                {
                    autoCompleteCollection.Add(row["AccBrandName"].ToString());
                }

                UpdBrandComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                UpdBrandComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                UpdBrandComboBox.AutoCompleteCustomSource = autoCompleteCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occurred : {ex}");
            }
        }
        private void ModelAutoComplete()
        {
            // Assuming dtBrands is your DataTable containing brand names
            try
            {
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                foreach (DataRow row in dtModels.Rows)
                {
                    autoCompleteCollection.Add(row["AccModelName"].ToString());
                }

                UpdModelComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                UpdModelComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                UpdModelComboBox.AutoCompleteCustomSource = autoCompleteCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occurred : {ex}");
            }
        }

        private void UpdBrandComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdModelComboBox.Text = "";
            updatedModel = 0;
            updatedBrand = 0;
        }

        private void UpdBrandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = UpdBrandComboBox.SelectedIndex;
            updatedBrand = Convert.ToInt32(dtBrands.Rows[Row_No]["AccBrandID"]);
            //MessageBox.Show($"{updatedBrand}");
            UpdModelComboBox.Text = "";
            dtModels.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetAccModelNames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TargetID", updatedBrand);

                        // Remove the unused SqlParameter 'parameter'
                        SqlParameter parameter = new SqlParameter("@TargetID", SqlDbType.Int, 32);
                        parameter.Value = updatedBrand;

                        ObjdBAccess.readDatathroughAdapter_2("GetAccModelNames", dtModels, parameter);

                        UpdModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            UpdModelComboBox.Items.Add($"{row["AccModelName"]}");
                        }
                    }
                }
                ModelAutoComplete();

                // Move SetupAutoComplete outside the try block if it's not directly related
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show($"Error Occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = UpdModelComboBox.SelectedIndex;
            updatedModel = Convert.ToInt32(dtModels.Rows[Row_No]["AccModelID"]);
          //  MessageBox.Show($"{updatedModel}");
        }
        //backbtn
        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Accessories_Click(object sender, EventArgs e)
        {

        }
    }
}
