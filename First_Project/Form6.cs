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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace First_Project
{
    public partial class Update_Customer_Form : Form
    {
        DBAccess ObjdBAccess = new DBAccess();
        DataTable userInfo = new DataTable();
        public static Update_Customer_Form instance;
        
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
        public string cus_ID;
        public string phone_ID;
        public int updatedBrand;
        public int updatedModel;
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();
        // Constructor with DataTable parameter

        public Update_Customer_Form()
        {
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
            update = UpdateBtn;
            cus_ID = Customer_ID;
            phone_ID = Phone_ID;


        }

        public DataTable RecievedDataTable { get; set; }

        private void Update_Customer_Form_Load(object sender, EventArgs e)
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

        private void CusNameBox_TextChanged(object sender, EventArgs e)
        {

        }
        private string Customer_ID,Phone_ID,Payment_Type;

        private void UpdModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = UpdModelComboBox.SelectedIndex;
            updatedModel = Convert.ToInt32(dtModels.Rows[Row_No]["ModelID"]);
           // MessageBox.Show($"{updatedModel}");


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

        private void UpdBrandComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdModelComboBox.Text = "";
            updatedModel = 0;
            updatedBrand = 0;

        }
        //backbtn
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

        private void UpdateBtn_Click(object sender, EventArgs e)
                    
        {
            Customer_ID = Form10.cus_ID ;
            Phone_ID = Form10.phone_ID;
            Payment_Type = Form10.payment_type;

            if (Payment_Type == "Full Payment") {

                string customerName = CusNameBox.Text;
                string updatedLastName = CusLNameBox.Text;
                string updatedCNIC = CusCNICBox.Text;
                string updatedPhoneNumber = CusPNumBox.Text;
                string updatedIMEI1 = CusIMEI1Box.Text;
                string updatedIMEI2 = CusIMEI2Box.Text;
                string updatedTotalAmount = CusTotalAmntBox.Text;

                if (Payment_Type == "Full Payment")
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("UpdateCustomer_FullPay", connection))
                            {
                                command.CommandType = System.Data.CommandType.StoredProcedure;

                                // Add parameters to the stored procedure
                                command.Parameters.AddWithValue("@PhoneID", Phone_ID); // Replace with the actual phoneID
                                command.Parameters.AddWithValue("@CustomerID", Customer_ID); // Replace with the actual customerID
                                command.Parameters.AddWithValue("@NewFirstName", customerName);
                                command.Parameters.AddWithValue("@NewLastName", updatedLastName);
                                command.Parameters.AddWithValue("@NewCNIC", updatedCNIC);
                                command.Parameters.AddWithValue("@NewPhoneNumber", updatedPhoneNumber);
                                command.Parameters.AddWithValue("@NewIMEI1", updatedIMEI1);
                                command.Parameters.AddWithValue("@NewIMEI2", updatedIMEI2);
                                command.Parameters.AddWithValue("@NewBrandID", updatedBrand);
                                command.Parameters.AddWithValue("@NewModelID", updatedModel);
                                command.Parameters.AddWithValue("@NewTotalPrice", updatedTotalAmount);

                                // Execute the stored procedure
                                if (MessageBox.Show("Are you sure ? \nyou want to Delete this record !! ", "DELETE MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Data Updated Successfully!");
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                    

                   /* 
                    Form10 form10 = new Form10();
                    form10.ShowDialog();*/

                }



            }
            else if(Payment_Type == "Installments")
            {

                string customerName = CusNameBox.Text;
                string updatedLastName = CusLNameBox.Text;
                string updatedCNIC = CusCNICBox.Text;
                string updatedPhoneNumber = CusPNumBox.Text;
                //string updatedBrand = CusCompBox.Text;
                //string updatedModel = CusModelBox.Text;
                string updatedIMEI1 = CusIMEI1Box.Text;
                string updatedIMEI2 = CusIMEI2Box.Text;
                string updatedTotalAmount = CusTotalAmntBox.Text;



            }
           



        }
    }

        
   }
