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
    public partial class Dealer_Acc_Form : Form
    {
        DBAccess ObjdBAccess = new DBAccess();
        DataTable userInfo = new DataTable();

        public int updatedBrand;
        public int updatedModel;
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();
        public Dealer_Acc_Form()
        {
            InitializeComponent();
            
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If checkBox1 is checked, uncheck checkBox2 and perform actions
           
        }

      
     
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            DePhoNumBox.MaxLength = 11;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {

                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            DeCNICBox.MaxLength = 13;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {

                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Dealer_Acc_Form_Load(object sender, EventArgs e)
        {
            // For UpdBrandComboBox
            BrandComboBox.DropDownStyle = ComboBoxStyle.DropDown; // Allow manual entry
            BrandComboBox.IntegralHeight = false; // Allow the drop-down to be larger than the specified height
            BrandComboBox.MaxDropDownItems = 10; // Set the maximum number of visible items
            BrandComboBox.DropDownHeight = BrandComboBox.ItemHeight * BrandComboBox.MaxDropDownItems;
            // Set the height of the drop-down to fit the specified number of items
            // Assuming ModelComboBox is the ComboBox control
            ModelComboBox.DropDownStyle = ComboBoxStyle.DropDown; // Allow manual entry
            ModelComboBox.IntegralHeight = false; // Allow the drop-down to be larger than the specified height
            ModelComboBox.MaxDropDownItems = 10; // Set the maximum number of visible items
            ModelComboBox.DropDownHeight = ModelComboBox.ItemHeight * ModelComboBox.MaxDropDownItems; //


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

                                BrandComboBox.Items.Add($"{dtBrands.Rows[count]["AccBrandName"]}");
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

                        ModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            ModelComboBox.Items.Add($"{row["AccModelName"]}");
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

                BrandComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                BrandComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                BrandComboBox.AutoCompleteCustomSource = autoCompleteCollection;
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

                ModelComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                ModelComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                ModelComboBox.AutoCompleteCustomSource = autoCompleteCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occurred : {ex}");
            }
        }

        private void AddDeBrandComboBox_TextChanged(object sender, EventArgs e)
        {
            ModelComboBox.Text = "";
            updatedModel = 0;
            updatedBrand = 0;
        }

        private void AddDeBrandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = BrandComboBox.SelectedIndex;
            updatedBrand = Convert.ToInt32(dtBrands.Rows[Row_No]["AccBrandID"]);
            //MessageBox.Show($"{updatedBrand}");
            ModelComboBox.Text = "";
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

                        ModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            ModelComboBox.Items.Add($"{row["AccModelName"]}");
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

        private void AddDeModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = ModelComboBox.SelectedIndex;
            updatedModel = Convert.ToInt32(dtModels.Rows[Row_No]["AccModelID"]);
           // MessageBox.Show($"{updatedModel}");
        }
        private int DealerID;
        private void button1_Click(object sender, EventArgs e)
        {
            string payment_type = "";
            payment_type = "Full Payment";           
            string name = DeNameBox.Text;
            string lname = DeLastNameBox.Text;
            string pnum = DePhoNumBox.Text;
            string cnic = DeCNICBox.Text;
            int quantity = (int)DeQuantity.Value;
            int totalamnt;
            int InstTotalpayamnt;
            int OneInstpayamnt;
            if (int.TryParse(DeTotalAmntBox.Text, out totalamnt))
            { }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid integer.");
            }

            DeNameBox.BackColor = Color.White;
            DeLastNameBox.BackColor = Color.White;

            DePhoNumBox.BackColor = Color.White;
            DeCNICBox.BackColor = Color.White;

            bool hasEmptyField = false;

            if (string.IsNullOrEmpty(name))
            {
                DeNameBox.BackColor = Color.LightPink;
                hasEmptyField = true;
            }

            if (string.IsNullOrEmpty(lname))
            {
                DeLastNameBox.BackColor = Color.LightPink;
                hasEmptyField = true;
            }

            if (string.IsNullOrEmpty(pnum) || pnum.Length < 11)
            {
                DePhoNumBox.BackColor = Color.LightPink;
                hasEmptyField = true;
            }

            if (string.IsNullOrEmpty(cnic) || cnic.Length < 13)
            {
                DeCNICBox.BackColor = Color.LightPink;
                hasEmptyField = true;
            }
            if (totalamnt == 0 && payment_type == "Full Payment")
            {
                DeTotalAmntBox.BackColor = Color.LightPink;
                hasEmptyField = true;
            }
            if (hasEmptyField)
            {
                MessageBox.Show("Please fill in all fields", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {              
                    try
                    {
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                            {
                                connection.Open();

                                using (SqlCommand command = new SqlCommand("InsertDealer", connection))
                                {
                                    command.CommandType = System.Data.CommandType.StoredProcedure;

                                    // Add parameters to the stored procedure
                                    command.Parameters.AddWithValue("@FName", name);
                                    command.Parameters.AddWithValue("@LName", lname);
                                    command.Parameters.AddWithValue("@CNIC", cnic);
                                    command.Parameters.AddWithValue("@PhoneNumber", pnum);

                                    //Output parameters 
                                    SqlParameter outputParameter1 = new SqlParameter("@DealerID", System.Data.SqlDbType.Int);
                                    outputParameter1.Direction = System.Data.ParameterDirection.Output;
                                    command.Parameters.Add(outputParameter1);

                                    // Execute the stored procedure
                                    command.ExecuteNonQuery();

                                    DealerID = (int)outputParameter1.Value;
                                    MessageBox.Show("Dealer added successfully with ID: " + DealerID);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}");
                        }
                    




                        // Execute the INSERT and retrieve the identity value directly
                        SqlCommand insertPurchaseQuery = new SqlCommand("INSERT INTO PurchaseAccessoryInventory (DealerID, ModelID, BrandID, PurchaseDate,Sold, TotalQuantity, TotalPrice) VALUES (@DealerID, @ModelID, @BrandID, @PurchaseDate, 0 , @TotalQuantity, @TotalPrice); SELECT SCOPE_IDENTITY();");

                        // Add parameters to the SqlCommand object
                        insertPurchaseQuery.Parameters.AddWithValue("@DealerID", DealerID); // Replace dealerID with the actual dealer ID
                        insertPurchaseQuery.Parameters.AddWithValue("ModelID",updatedModel); // Replace accModelID with the actual accessory model ID
                        insertPurchaseQuery.Parameters.AddWithValue("@BrandID", updatedBrand); // Replace accBrandID with the actual accessory brand ID
                        insertPurchaseQuery.Parameters.AddWithValue("@PurchaseDate", DateTime.Now); // Set the purchase date to the current date and time
                        insertPurchaseQuery.Parameters.AddWithValue("@TotalQuantity", quantity); // Replace quantity with the actual quantity of accessories purchased
                        insertPurchaseQuery.Parameters.AddWithValue("@TotalPrice", totalamnt); // Replace totalPrice with the actual total price of the purchase
                    
                    // Execute the query and retrieve the generated PurchaseID
                        if (MessageBox.Show("Are you sure ? \nyou want to Add this record !! ", "ADD MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                           int purchaseID = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertPurchaseQuery));

                          // Display a success message
                           MessageBox.Show("  Accessory purchase added successfully  ");
                        }





                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        ObjdBAccess.closeConn();
                    }                
            }
        }
        //backbtn
        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
