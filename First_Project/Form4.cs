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

namespace First_Project
{
    public partial class Add_Dealer_Form : Form
    {
        DBAccess ObjdBAccess = new DBAccess();
        DataTable userInfo = new DataTable();

        public int updatedBrand;
        public int updatedModel;
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();
        public Add_Dealer_Form()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            DisableCheckBox2Fields();
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
            DeIMEI1Box.MaxLength = 15;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {

                e.Handled = true;
            }
        }

        private void DeIMEI2textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CusIMEI2Box.MaxLength = 15;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If checkBox1 is checked, uncheck checkBox2 and perform actions
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;  
                DeInstallment_Amount_Box.Text = "";
                DeTotal_Amount_Installement_Box.Text = "";
                DeTotalAmntBox.BackColor = Color.White;

            }

            // Enable/disable textboxes based on the state of checkBox1
    
            DeInstallment_Amount_Box.Enabled = !checkBox1.Checked;
            DeTotal_Amount_Installement_Box.Enabled = !checkBox1.Checked;   
            DeInstallment_Amount_Box.BackColor = Color.Gray;
            DeTotal_Amount_Installement_Box.BackColor = Color.Gray;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // If checkBox2 is checked, uncheck checkBox1 and perform actions
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                DeTotalAmntBox.Text = "";
                DeInstallment_Amount_Box.BackColor = Color.White;
                DeTotal_Amount_Installement_Box.BackColor = Color.White;

            }

            // Enable/disable textbox based on the state of checkBox2
            DeTotalAmntBox.Enabled = !checkBox2.Checked;
            DeTotalAmntBox.BackColor = Color.Gray;

        }
        private void DisableCheckBox2Fields()
        {
            // Add additional fields as needed
            DeInstallment_Amount_Box.Enabled = false;
            DeTotal_Amount_Installement_Box.Enabled = false;
            DeInstallment_Amount_Box.BackColor = Color.Gray;
            DeTotal_Amount_Installement_Box.BackColor = Color.Gray;

        }
        private int DealerID;
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? \nyou want to ADD this record !! ", "ADD MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                string payment_type = "";
                if (checkBox1.Checked == true)
                {
                    payment_type = "Full Payment";
                }
                if (checkBox2.Checked == true)
                {
                    payment_type = "Installments";
                }
                string name = DeNameBox.Text;
                string lname = DeLastNameBox.Text;
                string pnum = DePhoNumBox.Text;
                string cnic = DeCNICBox.Text;
                int totalamnt;
                int InstTotalpayamnt;
                int OneInstpayamnt;
                if (int.TryParse(DeTotalAmntBox.Text, out totalamnt))
                { }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid integer.");
                }

                if (int.TryParse(DeInstallment_Amount_Box.Text, out OneInstpayamnt))
                { }
                if (int.TryParse(DeTotal_Amount_Installement_Box.Text, out InstTotalpayamnt))
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

                if (InstTotalpayamnt == 0 && payment_type == "Installments")
                {
                    DeTotal_Amount_Installement_Box.BackColor = Color.LightPink;
                    hasEmptyField = true;
                }

                if (InstTotalpayamnt == 0 && payment_type == "Installments")
                {
                    DeInstallment_Amount_Box.BackColor = Color.LightPink;
                }
                if (hasEmptyField)
                {
                    MessageBox.Show("Please fill in all fields", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (checkBox1.Checked == true)
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

                            string imei1;
                            string imei2;
                            int phoneID;
                            // Execute the INSERT and retrie
                            totalamnt = totalamnt / imei1List.Items.Count;

                            for (int i = 0; i < imei1List.Items.Count && i < imei2List.Items.Count; i++)
                            {
                                imei1 = imei1List.Items[i].ToString();
                                imei2 = imei2List.Items[i].ToString();
                                SqlCommand insertPhoneQuery = new SqlCommand("INSERT INTO MobilePhones (IMEI1, IMEI2, BrandID, ModelID) VALUES (@IMEI1, @IMEI2, @BrandID, @ModelID); SELECT SCOPE_IDENTITY();");
                                insertPhoneQuery.Parameters.AddWithValue("@IMEI1", imei1);
                                insertPhoneQuery.Parameters.AddWithValue("@IMEI2", imei2);
                                insertPhoneQuery.Parameters.AddWithValue("@BrandID", updatedBrand);  // Provide the actual BrandID
                                insertPhoneQuery.Parameters.AddWithValue("@ModelID", updatedModel);
                                phoneID = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertPhoneQuery));

                                SqlCommand insertPurchaseQuery = new SqlCommand("INSERT INTO PurchaseMobileInventory (DealerID, PhoneID, PurchaseDate, TransactionType, TotalPrice) VALUES (@DealerID, @PhoneID, @PurchaseDate, @TransactionType, @TotalPrice); SELECT SCOPE_IDENTITY();");
                                insertPurchaseQuery.Parameters.AddWithValue("@DealerID", DealerID); //
                                insertPurchaseQuery.Parameters.AddWithValue("@PhoneID", phoneID); //
                                insertPurchaseQuery.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                                insertPurchaseQuery.Parameters.AddWithValue("@TransactionType", "Full Payment"); // Assuming the transaction type is Full Payment
                                insertPurchaseQuery.Parameters.AddWithValue("@TotalPrice", totalamnt); // Replace totalAmount with the actual total amount
                                int purchaseID = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertPurchaseQuery));

                                SqlCommand insertMobileSalesQuery = new SqlCommand("INSERT INTO MobilePhoneSales (PhoneID, isSold) VALUES (@PhoneID, @isSold);");
                                insertMobileSalesQuery.Parameters.AddWithValue("@PhoneID", phoneID);
                                insertMobileSalesQuery.Parameters.AddWithValue("@isSold", 0);
                                ObjdBAccess.executeQuery_2(insertMobileSalesQuery);





                            }
                            MessageBox.Show("Mobile purchase added successfully: ");


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
                    if (checkBox2.Checked == true)
                    {
                        int installment_amount;
                        if (int.TryParse(DeTotal_Amount_Installement_Box.Text, out totalamnt)) { };
                        if (int.TryParse(DeInstallment_Amount_Box.Text, out installment_amount)) { };


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
                        string imei1;
                        string imei2;
                        int phoneID;
                        int Balance = 0, totalAmnt;
                        totalAmnt = InstTotalpayamnt;//Save Total Amount
                        Balance = InstTotalpayamnt - OneInstpayamnt;//Calculate Balance
                        InstTotalpayamnt = InstTotalpayamnt / imei1List.Items.Count;//Calculate Amount for each Mobile

                        for (int i = 0; i < imei1List.Items.Count && i < imei2List.Items.Count; i++)
                        {
                            imei1 = imei1List.Items[i].ToString();
                            imei2 = imei2List.Items[i].ToString();
                            SqlCommand insertPhoneQuery = new SqlCommand("INSERT INTO MobilePhones (IMEI1, IMEI2, BrandID, ModelID) VALUES (@IMEI1, @IMEI2, @BrandID, @ModelID); SELECT SCOPE_IDENTITY();");
                            insertPhoneQuery.Parameters.AddWithValue("@IMEI1", imei1);
                            insertPhoneQuery.Parameters.AddWithValue("@IMEI2", imei2);
                            insertPhoneQuery.Parameters.AddWithValue("@BrandID", updatedBrand);  // Provide the actual BrandID
                            insertPhoneQuery.Parameters.AddWithValue("@ModelID", updatedModel);
                            phoneID = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertPhoneQuery));


                            SqlCommand insertPurchaseQuery = new SqlCommand("INSERT INTO PurchaseMobileInventory (DealerID, PhoneID, PurchaseDate, TransactionType, TotalPrice) VALUES (@DealerID, @PhoneID, @PurchaseDate, @TransactionType, @TotalPrice); SELECT SCOPE_IDENTITY();");
                            insertPurchaseQuery.Parameters.AddWithValue("@DealerID", DealerID); //
                            insertPurchaseQuery.Parameters.AddWithValue("@PhoneID", phoneID); //
                            insertPurchaseQuery.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                            insertPurchaseQuery.Parameters.AddWithValue("@TransactionType", "Installments"); // Assuming the transaction type is Full Payment
                            insertPurchaseQuery.Parameters.AddWithValue("@TotalPrice", InstTotalpayamnt); // Replace totalAmount with the actual total amount
                            int purchaseID = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertPurchaseQuery));





                            SqlCommand insertMobileSalesQuery = new SqlCommand("INSERT INTO MobilePhoneSales (PhoneID, isSold) VALUES (@PhoneID, @isSold);");
                            insertMobileSalesQuery.Parameters.AddWithValue("@PhoneID", phoneID);
                            insertMobileSalesQuery.Parameters.AddWithValue("@isSold", 0);
                            ObjdBAccess.executeQuery_2(insertMobileSalesQuery);

                        }
                        //Table Dealer Installment 
                        try
                        {
                            // Provide the necessary parameters for the stored procedure
                            using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                            {
                                connection.Open();

                                using (SqlCommand command = new SqlCommand("AddDealerInstallment", connection))
                                {
                                    command.CommandType = CommandType.StoredProcedure;

                                    // Add parameters to the stored procedure
                                    command.Parameters.AddWithValue("@DealerID", DealerID);
                                    command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                                    command.Parameters.AddWithValue("@BrandID", updatedBrand);  // Provide the actual BrandID
                                    command.Parameters.AddWithValue("@ModelID", updatedModel);
                                    command.Parameters.AddWithValue("@Balance", Balance);
                                    command.Parameters.AddWithValue("@TotalAmount", totalAmnt);
                                    command.Parameters.AddWithValue("@Amount", OneInstpayamnt);

                                    // Execute the stored procedure
                                    int packageNumber = (int)command.ExecuteScalar();
                                    MessageBox.Show($"Dealer installment added successfully! Package number: {packageNumber}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}");
                        }

                        MessageBox.Show("Mobile purchase added successfully: ");

                    }


                    imei1List.Items.Clear();
                    imei2List.Items.Clear();
                    MessageBox.Show($"Name: {name}\nLast Name: {lname}\nPhone Number: {pnum}\nCNIC: {cnic}", "Printed Values");
                    List<string> informationList = new List<string>
                {
                $"Name: {name}",
                $"Last Name: {lname}",
                $"Phone Number: {pnum}",
                $"CNIC: {cnic}"

                };
                    Console.WriteLine(informationList);
                    this.Close();

                }

            }

        }


        

        private void textBox3_TextChanged(object sender, EventArgs e)
        { 

        }

        

        private void Add_Dealer_Form_Load(object sender, EventArgs e)
        {

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

            // Assuming ModelComboBox1 is the ComboBox control
           


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

                                BrandComboBox.Items.Add($"{dtBrands.Rows[count]["BrandName"]}");
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

                        ModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            ModelComboBox.Items.Add($"{row["ModelName"]}");
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
                    autoCompleteCollection.Add(row["ModelName"].ToString());
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

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (DeIMEI1Box.Text!="" && CusIMEI2Box.Text!="")
            {
                imei1List.Items.Add(DeIMEI1Box.Text);
                DeIMEI1Box.Text = "";
                imei2List.Items.Add(CusIMEI2Box.Text);
                CusIMEI2Box.Text = "";

            }
            else
            {
                MessageBox.Show("Fill above information");
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
            updatedBrand = Convert.ToInt32(dtBrands.Rows[Row_No]["BrandID"]);
            //MessageBox.Show($"{updatedBrand}");
            ModelComboBox.Text = "";
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

                        ModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            ModelComboBox.Items.Add($"{row["ModelName"]}");
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
            updatedModel = Convert.ToInt32(dtModels.Rows[Row_No]["ModelID"]);
           // MessageBox.Show($"{updatedModel}");
        }
        
        
        //bckbtn
        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
