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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace First_Project
{
    public partial class Form12 : Form
    {
        DBAccess ObjDbAccess = new DBAccess();
        public static Form12 instance;
        public System.Windows.Forms.TextBox tb1;
        public System.Windows.Forms.TextBox tb2;
        public System.Windows.Forms.TextBox tb3;
        public System.Windows.Forms.TextBox tb4;
        public System.Windows.Forms.ComboBox cb1;
        public System.Windows.Forms.ComboBox cb2;
        public System.Windows.Forms.TextBox tb7;
        public System.Windows.Forms.TextBox tb8;
        public System.Windows.Forms.TextBox tb9;
        public System.Windows.Forms.TextBox tb10;
        public System.Windows.Forms.TextBox tb11;
        public System.Windows.Forms.ComboBox cb3;
        public string cus_ID;
        public string phone_ID;
        private int Sale_ID;
        public int updatedModel;
        public int updatedBrand;
        

        DataTable installments = new DataTable();
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();

        public Form12()
        {
            Sale_ID = Convert.ToInt32(Form10.sale_ID);
            InitializeComponent();
            instance = this;
            tb1 = CusNameBox;
            tb2 = CusLNameBox;
            tb3 = CusCNICBox;
            tb4 = CusPNumBox;
            cb1 = UpdBrandComboBox;
            cb2 = UpdModelComboBox;
            tb7 = CusIMEI1Box;
            tb8 = CusIMEI2Box;
            tb9 = CusTotalAmntBox;
            tb10 = CusInstalAmntBox;
            tb11 = CusInstalDateBox;
            cb3 = CusInstalNoBox;
            cus_ID = Customer_ID;
            phone_ID = Phone_ID;

        }





        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private string Customer_ID, Phone_ID, Payment_Type;

        private void CusInstalNoBox_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }
        private int instal_ID=-1;
        private void CusInstalNoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = CusInstalNoBox.SelectedIndex;
            CusInstalAmntBox.Text = installments.Rows[Row_No]["Amount"].ToString();
            CusInstalDateBox.Text = installments.Rows[Row_No]["PaymentDate"].ToString();
            instal_ID = Convert.ToInt32(installments.Rows[Row_No]["InstallmentID"].ToString()); 





        }


        private void Form12_Load(object sender, EventArgs e)
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





            Sale_ID = Convert.ToInt32(Form10.sale_ID);
            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetUserInstallments", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters to the stored procedure
                        command.Parameters.AddWithValue("@TargetSaleID", Sale_ID); // Replace with the actual SaleID

                        SqlParameter parameter = new SqlParameter("@TargetSaleID", SqlDbType.Int, 32);
                        parameter.Value = Sale_ID;
                        ObjDbAccess.readDatathroughAdapter_2("GetUserInstallments", installments, parameter);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            StringBuilder installmentDetails = new StringBuilder();
                            int count = 1;

                            while (reader.Read())
                            {

                                CusInstalNoBox.Items.Add($"Installment No {count}");
                                count++;

                            }

                            MessageBox.Show(installmentDetails.ToString(), "Installment Details");
                        }
                       
                    }


                }
            }
            catch {
                MessageBox.Show("Program tu warr Gaya");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetBrandNames", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters to the stored procedure


                        ObjDbAccess.readDatathroughAdapter("GetBrandNames", dtBrands);

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

                        ObjDbAccess.readDatathroughAdapter_2("GetModelNames", dtModels, parameter);

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
    


        private void UpdateBtn_Click(object sender, EventArgs e)
        {

            Customer_ID = Form10.cus_ID;
            Phone_ID = Form10.phone_ID;
            Payment_Type = Form10.payment_type;
            string updated_name = CusNameBox.Text;
            string updated_lname = CusLNameBox.Text;
            string updated_cnic = CusCNICBox.Text;
            string updated_pnum = CusPNumBox.Text;
            string updated_imei1 = CusIMEI1Box.Text;
            string updated_imei2 = CusIMEI2Box.Text;
            string updated_total_amount = CusTotalAmntBox.Text;
            string updated_instal_amount;
            string updated_date;
            if (instal_ID == -1)
            {
                updated_instal_amount = installments.Rows[0]["Amount"].ToString();
                updated_date = installments.Rows[0]["PaymentDate"].ToString();

            }
            else
            {
                updated_instal_amount = CusInstalAmntBox.Text;
                updated_date = CusInstalDateBox.Text;
            }
            if (Payment_Type == "Installments")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("UpdateCustomer_Installments", connection))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;

                            // Add parameters to the stored procedure
                            command.Parameters.AddWithValue("@PhoneID", Phone_ID); // Replace with the actual phoneID

                            command.Parameters.AddWithValue("@CustomerID", Customer_ID); // Replace with the actual customerID
                            command.Parameters.AddWithValue("@NewFirstName", updated_name);
                            command.Parameters.AddWithValue("@NewLastName", updated_lname);
                            command.Parameters.AddWithValue("@NewCNIC", updated_cnic);
                            command.Parameters.AddWithValue("@NewPhoneNumber", updated_pnum);
                            command.Parameters.AddWithValue("@NewIMEI1", updated_imei1);
                            command.Parameters.AddWithValue("@NewIMEI2", updated_imei2);
                            command.Parameters.AddWithValue("@NewBrand", updatedBrand);
                            command.Parameters.AddWithValue("@NewModel", updatedModel);
                            command.Parameters.AddWithValue("@NewTotalPrice", Convert.ToDecimal(updated_total_amount));
                            command.Parameters.AddWithValue("@InstallmentID", instal_ID);
                            command.Parameters.AddWithValue("@NewPaymentDate", Convert.ToDateTime(updated_date));
                            command.Parameters.AddWithValue("@NewAmount", Convert.ToDecimal(updated_instal_amount));
                            // Execute the stored procedure
                            if (MessageBox.Show("Are you sure? \nyou want to Update this record!! ", "UPDATE MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                command.ExecuteNonQuery();

                                MessageBox.Show("Data Updated Successfully!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }


                this.Close();


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

        private void UpdBrandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = UpdBrandComboBox.SelectedIndex;
            updatedBrand = Convert.ToInt32(dtBrands.Rows[Row_No]["BrandID"]);
           // MessageBox.Show($"{updatedBrand}");
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

                        ObjDbAccess.readDatathroughAdapter_2("GetModelNames", dtModels, parameter);

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
          //  MessageBox.Show($"{updatedModel}");

        }

        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdBrandComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdModelComboBox.Text = "";
            updatedModel = 0;
            updatedBrand = 0;


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

    }



}
