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
    public partial class UpdateDealer : Form
    {
        DBAccess ObjdBAccess = new DBAccess();
        DataTable userInfo = new DataTable();
        public static UpdateDealer instance;

        public System.Windows.Forms.TextBox tb1;
        public System.Windows.Forms.TextBox tb2;
        public System.Windows.Forms.TextBox tb3;
        public System.Windows.Forms.TextBox tb4;
        public System.Windows.Forms.ComboBox cb1;
        public System.Windows.Forms.ComboBox cb2;
        public System.Windows.Forms.TextBox tb7;
        public System.Windows.Forms.TextBox tb8;
        public System.Windows.Forms.TextBox tb9;
        public System.Windows.Forms.Button update;
        public string De_ID;
        public string phone_ID;
        public int updatedBrand;
        public int updatedModel;
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();

        public UpdateDealer()
        {
            InitializeComponent();
            instance = this;
            tb1 = DeNameBox;
            tb2 = DeLNameBox;
            tb3 = DeCNICBox;
            tb4 = DePNumBox;
            cb1 = UpdBrandComboBox;
            cb2 = UpdModelComboBox;
            tb7 = DeIMEI1Box;
            tb8 = DeIMEI2Box;
            tb9 = DeTotalAmntBox;
            update = UpdateBtn;
           
            phone_ID = Phone_ID;
        }
        private string Dealer_ID, Phone_ID, Payment_Type;

        private void UpdateDealer_Load(object sender, EventArgs e)
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

                    using (SqlCommand command = new SqlCommand("GetBrandNames", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters to the stored procedure


                        ObjdBAccess.readDatathroughAdapter("GetBrandNames", dtBrands);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int count = 0;

                            while (reader.Read())
                            {

                                UpdBrandComboBox.Items.Add($"{dtBrands.Rows[count]["BrandName"]}");
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

                    using (SqlCommand command = new SqlCommand("GetModelNames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TargetID", updatedBrand);

                        // Remove the unused SqlParameter 'parameter'
                        SqlParameter parameter = new SqlParameter("@TargetID", SqlDbType.Int, 32);
                        parameter.Value = updatedBrand;

                        ObjdBAccess.readDatathroughAdapter_2("GetModelNames", dtModels, parameter);

                        UpdModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            UpdModelComboBox.Items.Add($"{row["ModelName"]}");
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

        private void UpdBrandComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdModelComboBox.Text = "";
            updatedModel = 0;
            updatedBrand = 0;
        }

        private void UpdBrandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = UpdBrandComboBox.SelectedIndex;
            updatedBrand = Convert.ToInt32(dtBrands.Rows[Row_No]["BrandID"]);
            //MessageBox.Show($"{updatedBrand}");
            UpdModelComboBox.Text = "";
            dtModels.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetModelNames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TargetID", updatedBrand);

                        // Remove the unused SqlParameter 'parameter'
                        SqlParameter parameter = new SqlParameter("@TargetID", SqlDbType.Int, 32);
                        parameter.Value = updatedBrand;

                        ObjdBAccess.readDatathroughAdapter_2("GetModelNames", dtModels, parameter);

                        UpdModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            UpdModelComboBox.Items.Add($"{row["ModelName"]}");
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
            updatedModel = Convert.ToInt32(dtModels.Rows[Row_No]["ModelID"]);
           // MessageBox.Show($"{updatedModel}");
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Dealer_ID = Update_Dealer_form.De_ID;
            Phone_ID = Update_Dealer_form.phone_ID;
            Payment_Type = Update_Dealer_form.payment_type;

            if (Payment_Type == "Full Payment")
            {

                string DealerName = DeNameBox.Text;
                string updatedLastName = DeLNameBox.Text;
                string updatedCNIC = DeCNICBox.Text;
                string updatedPhoneNumber = DePNumBox.Text;
                string updatedIMEI1 = DeIMEI1Box.Text;
                string updatedIMEI2 = DeIMEI2Box.Text;
                string updatedTotalAmount = DeTotalAmntBox.Text;

                if (Payment_Type == "Full Payment")
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("UpdateDealer_FullPay", connection))
                            {
                                command.CommandType = System.Data.CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@DealerID", Dealer_ID);
                                command.Parameters.AddWithValue("@PhoneID", Phone_ID); // Include PhoneID parameter
                                command.Parameters.AddWithValue("@NewFName", DealerName);
                                command.Parameters.AddWithValue("@NewLName", updatedLastName);
                                command.Parameters.AddWithValue("@NewCNIC", updatedCNIC);
                                command.Parameters.AddWithValue("@NewPhoneNumber", updatedPhoneNumber);
                                command.Parameters.AddWithValue("@NewIMEI1", updatedIMEI1);
                                command.Parameters.AddWithValue("@NewIMEI2", updatedIMEI2);
                                command.Parameters.AddWithValue("@NewBrandID", updatedBrand);
                                command.Parameters.AddWithValue("@NewModelID", updatedModel);
                                command.Parameters.AddWithValue("@NewTotalPrice", updatedTotalAmount);
                                if (MessageBox.Show("Are you sure ?  \n You want to Update this record !!", "UPDATE MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("\t\tDealer information updated successfully!\t\t");
                                    this.Hide();

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }

            }

            else if (Payment_Type == "Installments")
            {

                string DealerName = DeNameBox.Text;
                string updatedLastName = DeLNameBox.Text;
                string updatedCNIC = DeCNICBox.Text;
                string updatedPhoneNumber = DePNumBox.Text;
                string updatedIMEI1 = DeIMEI1Box.Text;
                string updatedIMEI2 = DeIMEI2Box.Text;
                string updatedTotalAmount = DeTotalAmntBox.Text;

                if (Payment_Type == "Installments")
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("UpdateDealer_FullPay", connection))
                            {
                                command.CommandType = System.Data.CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@DealerID", Dealer_ID);
                                command.Parameters.AddWithValue("@PhoneID", Phone_ID); // Include PhoneID parameter
                                command.Parameters.AddWithValue("@NewFName", DealerName);
                                command.Parameters.AddWithValue("@NewLName", updatedLastName);
                                command.Parameters.AddWithValue("@NewCNIC", updatedCNIC);
                                command.Parameters.AddWithValue("@NewPhoneNumber", updatedPhoneNumber);
                                command.Parameters.AddWithValue("@NewIMEI1", updatedIMEI1);
                                command.Parameters.AddWithValue("@NewIMEI2", updatedIMEI2);
                                command.Parameters.AddWithValue("@NewBrandID", updatedBrand);
                                command.Parameters.AddWithValue("@NewModelID", updatedModel);
                                command.Parameters.AddWithValue("@NewTotalPrice", updatedTotalAmount);
                                if (MessageBox.Show("Are you sure ?  \n You want to Update this record !!", "UPDATE MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("\t\tDealer information updated successfully!\t\t");
                                    this.Hide();

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }

            }
            else if (Payment_Type == "Full Payment(Replacement)")
            {

                string DealerName = DeNameBox.Text;
                string updatedLastName = DeLNameBox.Text;
                string updatedCNIC = DeCNICBox.Text;
                string updatedPhoneNumber = DePNumBox.Text;
                string updatedIMEI1 = DeIMEI1Box.Text;
                string updatedIMEI2 = DeIMEI2Box.Text;
                string updatedTotalAmount = DeTotalAmntBox.Text;

                if (Payment_Type == "Full Payment(Replacement)")
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("UpdateDealer_FullPay", connection))
                            {
                                command.CommandType = System.Data.CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@DealerID", Dealer_ID);
                                command.Parameters.AddWithValue("@PhoneID", Phone_ID); // Include PhoneID parameter
                                command.Parameters.AddWithValue("@NewFName", DealerName);
                                command.Parameters.AddWithValue("@NewLName", updatedLastName);
                                command.Parameters.AddWithValue("@NewCNIC", updatedCNIC);
                                command.Parameters.AddWithValue("@NewPhoneNumber", updatedPhoneNumber);
                                command.Parameters.AddWithValue("@NewIMEI1", updatedIMEI1);
                                command.Parameters.AddWithValue("@NewIMEI2", updatedIMEI2);
                                command.Parameters.AddWithValue("@NewBrandID", updatedBrand);
                                command.Parameters.AddWithValue("@NewModelID", updatedModel);
                                command.Parameters.AddWithValue("@NewTotalPrice", updatedTotalAmount);
                                if (MessageBox.Show("Are you sure ?\n You want to Update this record !!", "UPDATE MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("\t\tDealer information updated successfully!\t\t");
                                    this.Hide();

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }

            }


        }

        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void ModelAutoComplete()
        {
            // Assuming dtBrands is your DataTable containing brand names
            try
            {
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                foreach (DataRow row in dtModels.Rows)
                {
                    autoCompleteCollection.Add(row["ModelName"].ToString());
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
        private void BrandAutoComplete()
        {
            // Assuming dtBrands is your DataTable containing brand names
            try
            {
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                foreach (DataRow row in dtBrands.Rows)
                {
                    autoCompleteCollection.Add(row["BrandName"].ToString());
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

    }
}
