using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace First_Project
{
    public partial class Customer_Add_form : Form
    {
        private int brandID;
        private int modelID;
        private int brandID1;
        private int modelID1;
        private int DealerID;
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();
        DBAccess ObjdBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        public Customer_Add_form()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            DisableCheckBox2Fields();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            // Assuming BrandComboBox is the ComboBox control
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
            ModelComboBox1.DropDownStyle = ComboBoxStyle.DropDown; // Allow manual entry
            ModelComboBox1.IntegralHeight = false; // Allow the drop-down to be larger than the specified height
            ModelComboBox1.MaxDropDownItems = 10; // Set the maximum number of visible items
            ModelComboBox1.DropDownHeight = ModelComboBox1.ItemHeight * ModelComboBox1.MaxDropDownItems; // Set the

            // Assuming BrandComboBox1 is the ComboBox control
            BrandComboBox1.DropDownStyle = ComboBoxStyle.DropDown; // Allow manual entry
            BrandComboBox1.IntegralHeight = false; // Allow the drop-down to be larger than the specified height
            BrandComboBox1.MaxDropDownItems = 10; // Set the maximum number of visible items
            BrandComboBox1.DropDownHeight = BrandComboBox1.ItemHeight * BrandComboBox1.MaxDropDownItems; // Set the height of the drop-down to fit the specified number of items




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
                            StringBuilder installmentDetails = new StringBuilder();
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

                    using (SqlCommand command = new SqlCommand("GetBrandNames", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters to the stored procedure


                        ObjdBAccess.readDatathroughAdapter("GetBrandNames", dtBrands);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            StringBuilder installmentDetails = new StringBuilder();
                            int count = 0;

                            while (reader.Read())
                            {

                                BrandComboBox1.Items.Add($"{dtBrands.Rows[count]["BrandName"]}");
                                count++;

                            }
                        }

                    }


                }
                BrandAutoComplete1();

            }
            catch
            {
                MessageBox.Show("Program tu warr Gaya");
            }



        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CusPhoNumBox.MaxLength = 11;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CusCNICBox.MaxLength = 13;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void CusIMEI2Box_KeyPress(object sender, KeyPressEventArgs e)

        {
            CusIMEI2Box.MaxLength = 15;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void CusIMEI1Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            CusIMEI1Box.MaxLength = 15;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {

                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // If checkBox2 is checked, uncheck checkBox1 and perform actions
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
               

                CusTotalAmntBox.Text = "";

               

                Installment_Amount_Box.BackColor = Color.White;
                Total_Amount_Installement_Box.BackColor = Color.White;
               

            }

            // Enable/disable textbox based on the state of checkBox2
          

            CusTotalAmntBox.Enabled =!checkBox2.Checked;
            


            CusTotalAmntBox.BackColor = Color.Gray;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If checkBox1 is checked, uncheck checkBox2 and perform actions
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                

                Installment_Amount_Box.Text = "";
                Total_Amount_Installement_Box.Text = "";

                

                CusTotalAmntBox.BackColor = Color.White;
               

            }

            // Enable/disable textboxes based on the state of checkBox1

            Installment_Amount_Box.Enabled = !checkBox1.Checked;
            Total_Amount_Installement_Box.Enabled = !checkBox1.Checked;

         


            

            Installment_Amount_Box.BackColor = Color.Gray;
            Total_Amount_Installement_Box.BackColor = Color.Gray;


        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                BrandComboBox1.Enabled = true;
                ModelComboBox1.Enabled = true;
                CusIMEI2Box1.Enabled = true;
                CusIMEI1Box1.Enabled = true;
                RepAmount.Enabled = true;


                BrandComboBox1.BackColor = Color.White;
                ModelComboBox1.BackColor = Color.White;
                CusIMEI2Box1.BackColor = Color.White;
                CusIMEI1Box1.BackColor = Color.White;
                RepAmount.BackColor = Color.White;

            }
            if (checkBox3.Checked == false) 
            {
                BrandComboBox1.Enabled = false;
                ModelComboBox1.Enabled = false;
                CusIMEI2Box1.Enabled = false;
                CusIMEI1Box1.Enabled = false;
                RepAmount.Enabled = false;

                BrandComboBox1.BackColor = Color.Gray;
                ModelComboBox1.BackColor = Color.Gray;
                CusIMEI2Box1.BackColor = Color.Gray;
                CusIMEI1Box1.BackColor = Color.Gray;
                RepAmount.BackColor = Color.Gray;
            }

            // Enable/disable textboxes based on the state of checkBox1

            

            
        }


        private void CusTotalAmntBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisableCheckBox2Fields()
        {
            // Add additional fields as needed

            Installment_Amount_Box.Enabled = false;
            Total_Amount_Installement_Box.Enabled = false;
            BrandComboBox1.Enabled =false;
            ModelComboBox1.Enabled =false;
            CusIMEI2Box1.Enabled = false;
            CusIMEI1Box1.Enabled = false;
            RepAmount.Enabled= false;

            BrandComboBox1.BackColor = Color.Gray;
            ModelComboBox1.BackColor = Color.Gray;
            CusIMEI2Box1.BackColor = Color.Gray;
            CusIMEI1Box1.BackColor = Color.Gray;
            RepAmount.BackColor = Color.Gray;
            Installment_Amount_Box.BackColor = Color.Gray;
            Total_Amount_Installement_Box.BackColor = Color.Gray;


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private int customerID;
       
        private void Save_Click(object sender, EventArgs e)
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
                string name = CusNameBox.Text;
                string lname = CusLastNameBox.Text;
                string pnum = CusPhoNumBox.Text;
                string cnic = CusCNICBox.Text;
                string imei1 = CusIMEI1Box.Text;
                string imei2 = CusIMEI2Box.Text;
                string Dimei1 = CusIMEI1Box1.Text;
                string Dimei2 = CusIMEI2Box1.Text;
                int totalamnt;
                int payamnt;
                int phoneID1, DealerAmount;
                int phoneID = 0;




                // Reset the border color of all textboxes to default before checking
                CusNameBox.BackColor = Color.White;
                CusLastNameBox.BackColor = Color.White;
                CusPhoNumBox.BackColor = Color.White;
                CusCNICBox.BackColor = Color.White;

                // Check if any field is empty
                bool hasEmptyField = false;

                if (string.IsNullOrEmpty(name))
                {
                    CusNameBox.BackColor = Color.LightPink;
                    hasEmptyField = true;
                }

                if (string.IsNullOrEmpty(lname))
                {
                    CusLastNameBox.BackColor = Color.LightPink;
                    hasEmptyField = true;
                }

                if (string.IsNullOrEmpty(pnum) || pnum.Length < 11)
                {
                    CusPhoNumBox.BackColor = Color.LightPink;
                    hasEmptyField = true;
                }

                if (string.IsNullOrEmpty(cnic) || cnic.Length < 13)
                {
                    CusCNICBox.BackColor = Color.LightPink;
                    hasEmptyField = true;
                }
                if (string.IsNullOrEmpty(BrandComboBox.Text) ||
                    string.IsNullOrEmpty(ModelComboBox.Text) ||
                    string.IsNullOrEmpty(CusIMEI2Box.Text) ||
                    string.IsNullOrEmpty(CusIMEI1Box.Text))
                {

                    MessageBox.Show("  Please Select Mobile and Model!!  ");
                    return;

                }




                // If any field is empty, show a message and return
                if (hasEmptyField)
                {
                    MessageBox.Show("Please fill in all fields", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    if (checkBox1.Checked == true)
                    {
                        /////
                        ///


                        if (int.TryParse(CusTotalAmntBox.Text, out totalamnt))
                        {

                        }
                        else if (string.IsNullOrEmpty(CusTotalAmntBox.Text))
                        {
                            MessageBox.Show("Feild Can't be Empty!!");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Invalid input. Please enter a valid integer.");
                        }
                        ///


                        if (checkBox3.Checked)
                        {
                            if (string.IsNullOrEmpty(BrandComboBox1.Text) ||
                                string.IsNullOrEmpty(ModelComboBox1.Text) ||
                                string.IsNullOrEmpty(CusIMEI2Box1.Text) ||
                                string.IsNullOrEmpty(CusIMEI1Box1.Text) ||
                                string.IsNullOrEmpty(RepAmount.Text))
                            {

                                MessageBox.Show("Please fill in all the fields.");
                                return;
                            }


                        }




                        bool MobileExist, SoldMobile = false;

                        //Cudtomer
                        try
                        {


                            // Initialize PhoneID to 0 or any default value

                            string query = $"SELECT PhoneID FROM MobilePhones WHERE IMEI1 = '{imei1}' AND IMEI2 = '{imei2}' AND BrandID = {brandID} AND ModelID = {modelID}";


                            using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                            {
                                connection.Open();

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    // Execute the query
                                    object result = command.ExecuteScalar();

                                    // Check if the result is not null and can be cast to int
                                    if (result != null && int.TryParse(result.ToString(), out phoneID))
                                    {
                                        // PhoneID successfully obtained from the query
                                        MobileExist = true;
                                        MessageBox.Show(phoneID.ToString());
                                    }
                                    else
                                    {
                                        // PhoneID could not be retrieved
                                        MobileExist = false;

                                    }
                                }
                            }


                            if (MobileExist == true)
                            {
                                try
                                {
                                    using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                                    {
                                        using (SqlCommand command = new SqlCommand("SellMobilePhone", connection))
                                        {
                                            command.CommandType = CommandType.StoredProcedure;
                                            command.Parameters.AddWithValue("@PhoneID", phoneID);

                                            connection.Open();

                                            // Execute the stored procedure
                                            int success = (int)command.ExecuteScalar();

                                            if (success == 1)
                                            {
                                                MessageBox.Show("Mobile sold successfully!");
                                                SoldMobile = true;
                                            }
                                            else if (success == 0)
                                            {
                                                MessageBox.Show("Mobile is already sold!");
                                                SoldMobile = false;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Error occurred while selling the mobile.");
                                                // Log or handle the error appropriately
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("An error occurred: " + ex.Message);
                                }


                                if (SoldMobile == true)
                                {

                                    try
                                    {
                                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                                        {
                                            connection.Open();

                                            using (SqlCommand command = new SqlCommand("InsertCustomer", connection))
                                            {
                                                command.CommandType = System.Data.CommandType.StoredProcedure;

                                                // Add parameters to the stored procedure
                                                command.Parameters.AddWithValue("@FName", name);
                                                command.Parameters.AddWithValue("@LName", lname);
                                                command.Parameters.AddWithValue("@CNIC", cnic);
                                                command.Parameters.AddWithValue("@PhoneNumber", pnum);

                                                //Output parameters 
                                                SqlParameter outputParameter1 = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int);
                                                outputParameter1.Direction = System.Data.ParameterDirection.Output;
                                                command.Parameters.Add(outputParameter1);

                                                // Execute the stored procedure
                                                command.ExecuteNonQuery();

                                                customerID = (int)outputParameter1.Value;
                                                MessageBox.Show("Customer Updated successfully with ID: " + customerID);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"An error occurred: {ex.Message}");
                                    }

                                    // Inserting a new sale with full payment
                                    SqlCommand insertSaleQuery = new SqlCommand("INSERT INTO Sales (CustomerID, PhoneID, SaleDate, TransactionType, TotalPrice) VALUES (@CustomerID, @PhoneID, @SaleDate, @TransactionType, @TotalPrice); Select SCOPE_IDENTITY();");
                                    insertSaleQuery.Parameters.AddWithValue("@CustomerID", customerID);
                                    insertSaleQuery.Parameters.AddWithValue("@PhoneID", phoneID);
                                    insertSaleQuery.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                                    insertSaleQuery.Parameters.AddWithValue("@TransactionType", "Full Payment");
                                    insertSaleQuery.Parameters.AddWithValue("@TotalPrice", totalamnt);

                                    int SaleID = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertSaleQuery));
                                    MessageBox.Show("Customer added successfully with SaleID: " + SaleID);

                                    //This id to Make Mobile Sold in MobilePhoneSales TAble
                                   
                                }
                                else
                                {

                                }


                            }
                            else
                            {
                                MessageBox.Show("Mobile Is not available in inventry!!");
                            }
                            if (checkBox3.Checked && SoldMobile == true)
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
                                // For Deaker Amount
                                if (int.TryParse(RepAmount.Text, out DealerAmount))
                                {

                                }
                                else if (string.IsNullOrEmpty(CusTotalAmntBox.Text))
                                {
                                    MessageBox.Show("Feild Can't be Empty!!");
                                }
                                else
                                {
                                    MessageBox.Show("Invalid input. Please enter a valid integer.");
                                }
                                //
                                //For Dealer Insert 
                                SqlCommand insertPhoneQuery = new SqlCommand("INSERT INTO MobilePhones (IMEI1, IMEI2, BrandID, ModelID) VALUES (@IMEI1, @IMEI2, @BrandID, @ModelID); SELECT SCOPE_IDENTITY();");
                                insertPhoneQuery.Parameters.AddWithValue("@IMEI1", Dimei1);
                                insertPhoneQuery.Parameters.AddWithValue("@IMEI2", Dimei2);
                                insertPhoneQuery.Parameters.AddWithValue("@BrandID", brandID1);  // Provide the actual BrandID
                                insertPhoneQuery.Parameters.AddWithValue("@ModelID", modelID1);
                                phoneID1 = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertPhoneQuery));

                                SqlCommand insertPurchaseQuery = new SqlCommand("INSERT INTO PurchaseMobileInventory (DealerID, PhoneID, PurchaseDate, TransactionType, TotalPrice, ReplacementPhoneID) VALUES (@DealerID, @PhoneID, @PurchaseDate, @TransactionType, @TotalPrice, @ReplacementPhoneID); SELECT SCOPE_IDENTITY();");

                                insertPurchaseQuery.Parameters.AddWithValue("@DealerID", DealerID);
                                insertPurchaseQuery.Parameters.AddWithValue("@PhoneID", phoneID1);
                                insertPurchaseQuery.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                                insertPurchaseQuery.Parameters.AddWithValue("@TransactionType", "Full Payment"); // Assuming the transaction type is Full Payment
                                insertPurchaseQuery.Parameters.AddWithValue("@TotalPrice", DealerAmount); // Replace DealerAmount with the actual total amount
                                insertPurchaseQuery.Parameters.AddWithValue("@ReplacementPhoneID", phoneID); // Assuming phoneID is the replacement phone ID
                                int purchaseID = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertPurchaseQuery));


                                SqlCommand insertMobileSalesQuery = new SqlCommand("INSERT INTO MobilePhoneSales (PhoneID, isSold) VALUES (@PhoneID, @isSold);");
                                insertMobileSalesQuery.Parameters.AddWithValue("@PhoneID", phoneID1);
                                insertMobileSalesQuery.Parameters.AddWithValue("@isSold", 0);
                                ObjdBAccess.executeQuery_2(insertMobileSalesQuery);
                            }

                            SoldMobile = false;

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                        finally
                        {
                            ObjdBAccess.closeConn();
                        }
                        MessageBox.Show($"Name: {name}\nLast Name: {lname}\nPhone Number: {pnum}\nCNIC: {cnic}", "Printed Values");
                        List<string> informationList = new List<string>
                          {
                             $"Name: {name}",
                             $"Last Name: {lname}",
                             $"Phone Number: {pnum}",
                             $"CNIC: {cnic}"
                          };
                        Console.WriteLine(informationList);
                        SaveToFile(informationList);





                    }
                    if (checkBox2.Checked == true)
                    {
                        int installment_amount;

                        if (int.TryParse(Installment_Amount_Box.Text, out installment_amount)) { }
                        else if (string.IsNullOrEmpty(Installment_Amount_Box.Text))
                        {
                            MessageBox.Show(" Feild Can't be Empty!!");
                        }
                        else
                        {
                            MessageBox.Show("Invalid input. Please enter a valid integer.");
                        }
                        if (int.TryParse(Total_Amount_Installement_Box.Text, out payamnt))
                        {
                        }
                        else if (string.IsNullOrEmpty(Total_Amount_Installement_Box.Text))
                        {
                            MessageBox.Show(" Feild Can't be Empty!!");
                        }
                        else
                        {
                            MessageBox.Show("Invalid input. Please enter a valid integer.");
                        }

                        bool MobileExist, SoldMobile = false;
                        // Initialize PhoneID to 0 or any default value

                        string query = $"SELECT PhoneID FROM MobilePhones WHERE IMEI1 = '{imei1}' AND IMEI2 = '{imei2}' AND BrandID = {brandID} AND ModelID = {modelID}";


                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Execute the query
                                object result = command.ExecuteScalar();

                                // Check if the result is not null and can be cast to int
                                if (result != null && int.TryParse(result.ToString(), out phoneID))
                                {
                                    // PhoneID successfully obtained from the query
                                    MobileExist = true;
                                    MessageBox.Show(phoneID.ToString());
                                }
                                else
                                {
                                    // PhoneID could not be retrieved
                                    MobileExist = false;

                                }
                            }
                        }

                        if (MobileExist == true)
                        {
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                                {
                                    using (SqlCommand command = new SqlCommand("SellMobilePhone", connection))
                                    {
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.AddWithValue("@PhoneID", phoneID);

                                        connection.Open();

                                        // Execute the stored procedure
                                        int success = (int)command.ExecuteScalar();

                                        if (success == 1)
                                        {
                                            MessageBox.Show("Mobile sold successfully!");
                                            SoldMobile = true;
                                        }
                                        else if (success == 0)
                                        {
                                            MessageBox.Show("Mobile is already sold!");
                                            SoldMobile = false;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error occurred while selling the mobile.");
                                            // Log or handle the error appropriately
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occurred: " + ex.Message);
                            }




                            if (SoldMobile == true)
                            {
                                try
                                {
                                    using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                                    {
                                        connection.Open();

                                        using (SqlCommand command = new SqlCommand("InsertCustomer", connection))
                                        {
                                            command.CommandType = System.Data.CommandType.StoredProcedure;

                                            // Add parameters to the stored procedure
                                            command.Parameters.AddWithValue("@FName", name);
                                            command.Parameters.AddWithValue("@LName", lname);
                                            command.Parameters.AddWithValue("@CNIC", cnic);
                                            command.Parameters.AddWithValue("@PhoneNumber", pnum);

                                            //Output parameters 
                                            SqlParameter outputParameter1 = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int);
                                            outputParameter1.Direction = System.Data.ParameterDirection.Output;
                                            command.Parameters.Add(outputParameter1);

                                            // Execute the stored procedure
                                            command.ExecuteNonQuery();

                                            customerID = (int)outputParameter1.Value;
                                            MessageBox.Show("Customer Updated successfully with ID: " + customerID);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}");
                                }


                                // Inserting a new sale with full payment
                                SqlCommand insertSaleQuery = new SqlCommand("INSERT INTO Sales (CustomerID, PhoneID, SaleDate, TransactionType, TotalPrice) VALUES (@CustomerID, @PhoneID, @SaleDate, @TransactionType, @TotalPrice); Select SCOPE_IDENTITY();");
                                insertSaleQuery.Parameters.AddWithValue("@CustomerID", customerID);
                                insertSaleQuery.Parameters.AddWithValue("@PhoneID", phoneID);
                                insertSaleQuery.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                                insertSaleQuery.Parameters.AddWithValue("@TransactionType", "Installments");
                                insertSaleQuery.Parameters.AddWithValue("@TotalPrice", payamnt);
                                int SaleID = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertSaleQuery));
                                MessageBox.Show("Customer added successfully with SaleID: " + SaleID);


                                SqlCommand insertinstallmentQuery = new SqlCommand("INSERT INTO Installments (SaleID,PaymentDate,Amount) VALUES (@SaleID, @PaymentDate,@Amount)");
                                insertinstallmentQuery.Parameters.AddWithValue("@SaleID", SaleID);
                                insertinstallmentQuery.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                                insertinstallmentQuery.Parameters.AddWithValue("@Amount", installment_amount);
                                ObjdBAccess.executeQuery_2(insertinstallmentQuery);
                            }
                            else
                            {
                                MessageBox.Show("Mobile Is not available in inventry!!");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mobile Is not available in inventry!!");
                        }

                        if (checkBox3.Checked && SoldMobile == true)
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
                            // For Deaker Amount
                            if (int.TryParse(RepAmount.Text, out DealerAmount))
                            {

                            }
                            else if (string.IsNullOrEmpty(CusTotalAmntBox.Text))
                            {
                                MessageBox.Show("Feild Can't be Empty!!");
                            }
                            else
                            {
                                MessageBox.Show("Invalid input. Please enter a valid integer.");
                            }
                            //
                            //For Dealer Insert 
                            SqlCommand insertPhoneQuery = new SqlCommand("INSERT INTO MobilePhones (IMEI1, IMEI2, BrandID, ModelID) VALUES (@IMEI1, @IMEI2, @BrandID, @ModelID); SELECT SCOPE_IDENTITY();");
                            insertPhoneQuery.Parameters.AddWithValue("@IMEI1", Dimei1);
                            insertPhoneQuery.Parameters.AddWithValue("@IMEI2", Dimei2);
                            insertPhoneQuery.Parameters.AddWithValue("@BrandID", brandID1);  // Provide the actual BrandID
                            insertPhoneQuery.Parameters.AddWithValue("@ModelID", modelID1);
                            phoneID1 = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertPhoneQuery));

                            SqlCommand insertPurchaseQuery = new SqlCommand("INSERT INTO PurchaseMobileInventory (DealerID, PhoneID, PurchaseDate, TransactionType, TotalPrice, ReplacementPhoneID) VALUES (@DealerID, @PhoneID, @PurchaseDate, @TransactionType, @TotalPrice, @ReplacementPhoneID); SELECT SCOPE_IDENTITY();");

                            insertPurchaseQuery.Parameters.AddWithValue("@DealerID", DealerID);
                            insertPurchaseQuery.Parameters.AddWithValue("@PhoneID", phoneID1);
                            insertPurchaseQuery.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                            insertPurchaseQuery.Parameters.AddWithValue("@TransactionType", "Full Payment"); // Assuming the transaction type is Full Payment
                            insertPurchaseQuery.Parameters.AddWithValue("@TotalPrice", DealerAmount); // Replace DealerAmount with the actual total amount
                            insertPurchaseQuery.Parameters.AddWithValue("@ReplacementPhoneID", phoneID); // Assuming phoneID is the replacement phone ID
                            int purchaseID = Convert.ToInt32(ObjdBAccess.executeQuery_2(insertPurchaseQuery));


                            SqlCommand insertMobileSalesQuery = new SqlCommand("INSERT INTO MobilePhoneSales (PhoneID, isSold) VALUES (@PhoneID, @isSold);");
                            insertMobileSalesQuery.Parameters.AddWithValue("@PhoneID", phoneID1);
                            insertMobileSalesQuery.Parameters.AddWithValue("@isSold", 0);
                            ObjdBAccess.executeQuery_2(insertMobileSalesQuery);
                            SoldMobile = false;


                        }
                        MessageBox.Show($"Name: {name}\nLast Name: {lname}\nPhone Number: {pnum}\nCNIC: {cnic}", "Printed Values");
                        List<string> informationList = new List<string>
                          {
                             $"Name: {name}",
                             $"Last Name: {lname}",
                             $"Phone Number: {pnum}",
                             $"CNIC: {cnic}"
                          };
                        Console.WriteLine(informationList);
                        SaveToFile(informationList);



                    }






                }
               
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void SaveToFile(List<String> Info)
        {
            string file_name = Path.Combine(Environment.CurrentDirectory, "record.txt");

            try
            {
                //Appending Values in record.txt
                using (StreamWriter writer = new StreamWriter(file_name, true))
                {
                    // Convert the list to a single string with a delimiter
                    string infoString = string.Join("|", Info);

                    writer.WriteLine(infoString);
                    writer.WriteLine();

                }
                MessageBox.Show("Information Saved");
            }
            catch (Exception ex)
            {
                // Display an error message if saving fails
                MessageBox.Show($"Error saving information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       

       

       


        private void CusIMEI2Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void BrandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = BrandComboBox.SelectedIndex;
            brandID = Convert.ToInt32(dtBrands.Rows[Row_No]["BrandID"]);
            //MessageBox.Show($"{brandID}");
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
                        command.Parameters.AddWithValue("@TargetID", brandID);

                        // Remove the unused SqlParameter 'parameter'
                        SqlParameter parameter = new SqlParameter("@TargetID", SqlDbType.Int, 32);
                        parameter.Value = brandID;

                        ObjdBAccess.readDatathroughAdapter_2("GetModelNames", dtModels, parameter);

                        // Clear the ComboBox items
                        ModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            ModelComboBox.Items.Add($"{row["ModelName"]}");
                        }
                    }
                }

                // Move SetupAutoComplete outside the try block if it's not directly related
                ModelAutoComplete();
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
            catch (Exception ex){
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


        private void ModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = ModelComboBox.SelectedIndex;
            modelID = Convert.ToInt32(dtModels.Rows[Row_No]["ModelID"]);
           // MessageBox.Show($"{modelID}");

            
        }

        //backbtn
        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }





        private void ModelAutoComplete1()
        {
            // Assuming dtBrands is your DataTable containing brand names
            try
            {
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                foreach (DataRow row in dtModels.Rows)
                {
                    autoCompleteCollection.Add(row["ModelName"].ToString());
                }

                ModelComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                ModelComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                ModelComboBox1.AutoCompleteCustomSource = autoCompleteCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occurred : {ex}");
            }

        }
        private void BrandAutoComplete1()
        {
            // Assuming dtBrands is your DataTable containing brand names
            try
            {
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                foreach (DataRow row in dtBrands.Rows)
                {
                    autoCompleteCollection.Add(row["BrandName"].ToString());
                }

                BrandComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                BrandComboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                BrandComboBox1.AutoCompleteCustomSource = autoCompleteCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occurred : {ex}");
            }
        }

        private void BrandComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = BrandComboBox1.SelectedIndex;
            brandID1 = Convert.ToInt32(dtBrands.Rows[Row_No]["BrandID"]);
           // MessageBox.Show($"{brandID1}");
            ModelComboBox1.Text = "";
            dtModels.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetModelNames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TargetID", brandID1);

                        // Remove the unused SqlParameter 'parameter'
                        SqlParameter parameter = new SqlParameter("@TargetID", SqlDbType.Int, 32);
                        parameter.Value = brandID1;

                        ObjdBAccess.readDatathroughAdapter_2("GetModelNames", dtModels, parameter);

                        // Clear the ComboBox items
                        ModelComboBox1.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            ModelComboBox1.Items.Add($"{row["ModelName"]}");
                        }
                    }
                }

                // Move SetupAutoComplete outside the try block if it's not directly related
                ModelAutoComplete1();
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show($"Error Occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModelComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Row_No = ModelComboBox1.SelectedIndex;
            modelID1 = Convert.ToInt32(dtModels.Rows[Row_No]["ModelID"]);
            //MessageBox.Show(modelID1.ToString());
        }

        private void CusIMEI1Box1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CusIMEI1Box1.MaxLength = 15;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {

                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void CusIMEI2Box1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CusIMEI2Box1.MaxLength = 15;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {

                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }


}