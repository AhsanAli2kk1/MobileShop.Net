using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml.Linq;

namespace First_Project
{
    public partial class Form10 : Form

    {
        DBAccess ObjdBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        public static Form10 instance;
        Update_Customer_Form update_form = new Update_Customer_Form();
        public static string cus_ID = "";
        public static string phone_ID = "";
        public static string payment_type = "";
        public static int installement_amount ;
        public static string sale_ID;



        public Form10()
        {
            InitializeComponent();
            instance = this;

        }
        private void Form10_Load(object sender, EventArgs e)
        {

        }
        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            this.Hide();
            form10.ShowDialog();
        }

        

      

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            Customer_Add_form form = new Customer_Add_form();
            form.ShowDialog();
            this.Show();
        }
        bool CustomerExpend = false;
        private void CustomerTransition_Tick(object sender, EventArgs e)
        {
            if (CustomerExpend == false)
            {
                CustomerContainer.Height += 10;
                if (CustomerContainer.Height >= 106)
                {
                    Customerbtn.BackColor = Color.Cyan;
                    UdealerConatiner.Visible = false;
                    Dealer_Container.Visible = false;
                    CustomerTransition.Stop();
                    CustomerExpend = true;

                }
            }
            else
            {
                CustomerContainer.Height -= 10;
                if (CustomerContainer.Height <= 36)
                {
                    Customerbtn.BackColor = System.Drawing.Color.FromArgb(60, 63, 81);
                    UdealerConatiner.Visible = true;
                    Dealer_Container.Visible = true;
                    CustomerTransition.Stop();
                    CustomerExpend = false;
                }
            }

        }





        private void guna2GradientButton8_Click_1(object sender, EventArgs e)
        {

            Dealer_Container.Visible = true;
            UdealerConatiner.Visible = true;
            HistoryContainer.Visible = true;
            ContactContainer.Visible = true;
            
            CustomerTransition.Start();
        }


        bool DealerExpend = false;
        private void DealerTransition_Tick(object sender, EventArgs e)
        {
            if (DealerExpend == false)
            {
                Dealer_Container.Height += 10;
                if (Dealer_Container.Height >= 106)
                {
                    Dealerbtn.BackColor = Color.Cyan;
                    UdealerConatiner.Visible = false;
                    HistoryContainer.Visible = false;
                    DealerTransition.Stop();
                    DealerExpend = true;

                }
            }
            else
            {
                Dealer_Container.Height -= 10;
                if (Dealer_Container.Height <= 36)
                {
                    Dealerbtn.BackColor = System.Drawing.Color.FromArgb(60, 63, 81);
                    UdealerConatiner.Visible = true;
                    HistoryContainer.Visible = true;
                    DealerTransition.Stop();
                    DealerExpend = false;
                }
            }
        }

        private void Dealerbtn_Click(object sender, EventArgs e)
        {

            Dealer_Container.Visible = true;
            UdealerConatiner.Visible = true;
            HistoryContainer.Visible = true;
            ContactContainer.Visible = true;
            DealerTransition.Start();
        }
        bool UdealerExpend = false;
        private void UdealerTransition_Tick(object sender, EventArgs e)
        {
            if (UdealerExpend == false)
            {
                UdealerConatiner.Height += 10;
                if (UdealerConatiner.Height >= 106)
                {
                    Udealerbtn.BackColor = Color.Cyan;
                    HistoryContainer.Visible = false;
                    ContactContainer.Visible = false;
                    UdealerTransition.Stop();
                    UdealerExpend = true;

                }
            }
            else
            {
                UdealerConatiner.Height -= 10;
                if (UdealerConatiner.Height <= 36)
                {

                    Udealerbtn.BackColor = System.Drawing.Color.FromArgb(60, 63, 81);
                    HistoryContainer.Visible = true;
                    ContactContainer.Visible = true;
                    UdealerTransition.Stop();
                    UdealerExpend = false;
                }
            }
        }

        private void Udealerbtn_Click(object sender, EventArgs e)
        {

            Dealer_Container.Visible = true;
            UdealerConatiner.Visible = true;
            HistoryContainer.Visible = true;
            ContactContainer.Visible = true;
            UdealerTransition.Start();
        }



        private void Historybtn_Click(object sender, EventArgs e)
        {
            HistorTransition.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            Accessories_form accessories_Form = new Accessories_form();
            
            accessories_Form.ShowDialog();
            this.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Add_Dealer_Form add_Dealer_Form = new Add_Dealer_Form();
            
            add_Dealer_Form.ShowDialog();
            this.Show();

        }

        private void Dealer_Acc_btn_Click(object sender, EventArgs e)
        {
            Dealer_Acc_Form dealer_Acc_Form = new Dealer_Acc_Form();
            
            dealer_Acc_Form.ShowDialog();
            this.Show();
        }

        private void Udealer_mobile_btn_Click(object sender, EventArgs e)
        {
            Update_Dealer_form update_Dealer_Form = new Update_Dealer_form();
            
            update_Dealer_Form.ShowDialog();
            this.Show();
        }
        bool HistoryExpend = false;
        private void HistorTransition_Tick_1(object sender, EventArgs e)
        {
            if (HistoryExpend == false)
            {
                HistoryContainer.Height += 10;
                if (HistoryContainer.Height >= 106)
                {
                    Historybtn.BackColor = Color.Cyan;
                    ContactContainer.Visible = false;
                    HistorTransition.Stop();
                    HistoryExpend = true;

                }
            }
            else
            {
                HistoryContainer.Height -= 10;
                if (HistoryContainer.Height <= 36)
                {
                    Historybtn.BackColor = System.Drawing.Color.FromArgb(60, 63, 81);
                    ContactContainer.Visible = true;
                    HistorTransition.Stop();
                    HistoryExpend = false;
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool checking;


        //Update btn
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            // Using property


            // OR using method
            // form2.SetDataTable(dtUsers);


            if (ret_TransactionType == "Full Payment")
            {
                Update_Customer_Form update_Customer_Form = new Update_Customer_Form();
                
                Update_Customer_Form.instance.tb1.Text = dtUsers.Rows[Row_No]["FName"].ToString();
                Update_Customer_Form.instance.tb2.Text = dtUsers.Rows[Row_No]["LName"].ToString();
                Update_Customer_Form.instance.tb3.Text = dtUsers.Rows[Row_No]["CNIC"].ToString();
                Update_Customer_Form.instance.tb4.Text = dtUsers.Rows[Row_No]["PhoneNumber"].ToString();
                Update_Customer_Form.instance.cb1.Text = dtUsers.Rows[Row_No]["Brand"].ToString();
                Update_Customer_Form.instance.cb2.Text = dtUsers.Rows[Row_No]["Model"].ToString();
                Update_Customer_Form.instance.tb7.Text = dtUsers.Rows[Row_No]["IMEI1"].ToString();
                Update_Customer_Form.instance.tb8.Text = dtUsers.Rows[Row_No]["IMEI2"].ToString();
                Update_Customer_Form.instance.tb9.Text = dtUsers.Rows[Row_No]["TotalPrice"].ToString();
                cus_ID = dtUsers.Rows[Row_No]["CustomerID"].ToString();
                phone_ID = dtUsers.Rows[Row_No]["PhoneID"].ToString();
                payment_type = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                update_Customer_Form.updatedBrand =Convert.ToInt32( dtUsers.Rows[Row_No]["BrandID"]);
                update_Customer_Form.updatedModel= Convert.ToInt32(dtUsers.Rows[Row_No]["ModelID"]);




                update_Customer_Form.ShowDialog();
                this.Show();





            }
            if (ret_TransactionType == "Installments") { 
                Form12 form12 = new Form12();
                
                Form12.instance.tb1.Text = dtUsers.Rows[Row_No]["FName"].ToString();
                Form12.instance.tb2.Text = dtUsers.Rows[Row_No]["LName"].ToString();
                Form12.instance.tb3.Text = dtUsers.Rows[Row_No]["CNIC"].ToString();
                Form12.instance.tb4.Text = dtUsers.Rows[Row_No]["PhoneNumber"].ToString();
                Form12.instance.cb1.Text = dtUsers.Rows[Row_No]["Brand"].ToString();
                Form12.instance.cb2.Text = dtUsers.Rows[Row_No]["Model"].ToString();
                Form12.instance.tb7.Text = dtUsers.Rows[Row_No]["IMEI1"].ToString();
                Form12.instance.tb8.Text = dtUsers.Rows[Row_No]["IMEI2"].ToString();
                Form12.instance.tb9.Text = dtUsers.Rows[Row_No]["TotalPrice"].ToString();
                cus_ID = dtUsers.Rows[Row_No]["CustomerID"].ToString();
                phone_ID = dtUsers.Rows[Row_No]["PhoneID"].ToString();
                sale_ID = dtUsers.Rows[Row_No]["SaleID"].ToString();
                payment_type = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                form12.updatedBrand = Convert.ToInt32(dtUsers.Rows[Row_No]["BrandID"]);
                form12.updatedModel = Convert.ToInt32(dtUsers.Rows[Row_No]["ModelID"]);
                form12.ShowDialog();
                this.Show();


            }
        }

        private void Sales_History_Click(object sender, EventArgs e)
        {
            Sale_His_form sale_His_Form = new Sale_His_form();
            
            sale_His_Form.ShowDialog();
            this.Show();

        }

        private void Purchase_History_btn_Click(object sender, EventArgs e)
        {
            Purchase_History_form purchase_History_Form = new Purchase_History_form();
            
            purchase_History_Form.ShowDialog();
            this.Show();
        }

        private void Update_dealer_Acc_btn_Click(object sender, EventArgs e)
        {
            Dealer_Acc_Form dealer_Acc_Form = new Dealer_Acc_Form();
            
            dealer_Acc_Form.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string number = Search_Box.Text;
            dtUsers.Clear();
            if (CNICRbtn.Enabled == true)
            {


                SqlParameter parameter = new SqlParameter("@SearchValue", SqlDbType.NVarChar, 50);
                parameter.Value = number;
                ObjdBAccess.readDatathroughAdapter_2("GetCustomerDetailsBySearchValue", dtUsers, parameter);

                if (dtUsers.Rows.Count >= 1)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dtUsers;
                }

                else
                {
                    MessageBox.Show("No Customer Found !");
                }
            }


            else if (IMEIRbtn.Enabled == true)
            {
                string query = "Select * from Users WHERE IMEI_1 = '" + number + "' OR IMEI_2 = '" + number + "'";

                ObjdBAccess.readDatathroughAdapter(query, dtUsers);

                if (dtUsers.Rows.Count == 1)
                {

                    dataGridView1.DataSource = dtUsers;
                }

                else
                {
                    MessageBox.Show("No Customer Found !");
                }

            }
            else
            {
                MessageBox.Show(" Check any above !!");
            }
        }

        private void CNICRbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private int Row_No;
        private string ret_TransactionType;
        private bool row_click = false;
        private int ret_Installment_No;
        private int ret_SaleID;
        private int ret_TotalPrice;
        private int ret_TotalPaidAmont;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && dtUsers.Columns.Contains("TransactionType"))
                {
                    Row_No = e.RowIndex;
                    row_click = true;
                    ret_TransactionType = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                    ret_SaleID = Convert.ToInt32(dtUsers.Rows[Row_No]["SaleID"].ToString());
                    ret_TotalPrice = Convert.ToInt32(dtUsers.Rows[Row_No]["TotalPrice"]);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                ret_TransactionType = "";
                MessageBox.Show($"There is no data in this row");
            }
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            if (row_click == true)
            {
                if (ret_TransactionType == "Full Payment")
                {
                    string ret_First_Name = dtUsers.Rows[Row_No]["FName"].ToString();
                    string ret_LastName = dtUsers.Rows[Row_No]["LName"].ToString();
                    string ret_CNIC = dtUsers.Rows[Row_No]["CNIC"].ToString();
                    string ret_PhoneNumber = dtUsers.Rows[Row_No]["PhoneNumber"].ToString();
                    string ret_Brand = dtUsers.Rows[Row_No]["Brand"].ToString();
                    string ret_Model = dtUsers.Rows[Row_No]["Model"].ToString();
                    string ret_IMEI1 = dtUsers.Rows[Row_No]["IMEI1"].ToString();
                    string ret_IMEI2 = dtUsers.Rows[Row_No]["IMEI2"].ToString();
                    ret_TransactionType = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                    string ret_SaleDate = dtUsers.Rows[Row_No]["SaleDate"].ToString();
                    string ret_TotalPrice = dtUsers.Rows[Row_No]["TotalPrice"].ToString();




                    MessageBox.Show($"--------------------------------------------------------------------------------------\nCustomer Info\n--------------------------------------------------------------------------------------\n First Name : {ret_First_Name} \nLast Name : {ret_LastName} \nCNIC : {ret_CNIC} \nPhone Number : {ret_PhoneNumber}\n -------------------------------------------------------------------------------------- \nMobile Info\n--------------------------------------------------------------------------------------\n" +
                        $"Brand : {ret_Brand}\n Model: {ret_Model}\n IMEI1: {ret_IMEI1}\n IMEI2: {ret_IMEI2}\n-------------------------------------------------------------------------------------- \nSales Info\n--------------------------------------------------------------------------------------\n" +
                        $"Sale Date: {ret_SaleDate}\n Transaction Type: {ret_TransactionType}\n Total Price: {ret_TotalPrice}");
                    row_click = false;
                }
                else if(ret_TransactionType == "Installments")
                {
                    string ret_First_Name = dtUsers.Rows[Row_No]["FName"].ToString();
                    string ret_LastName = dtUsers.Rows[Row_No]["LName"].ToString();
                    string ret_CNIC = dtUsers.Rows[Row_No]["CNIC"].ToString();
                    string ret_PhoneNumber = dtUsers.Rows[Row_No]["PhoneNumber"].ToString();
                    string ret_Brand = dtUsers.Rows[Row_No]["Brand"].ToString();
                    string ret_Model = dtUsers.Rows[Row_No]["Model"].ToString();
                    string ret_IMEI1 = dtUsers.Rows[Row_No]["IMEI1"].ToString();
                    string ret_IMEI2 = dtUsers.Rows[Row_No]["IMEI2"].ToString();
                    ret_TransactionType = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                    string ret_SaleDate = ((DateTime)dtUsers.Rows[Row_No]["SaleDate"]).ToString("dd-MM-yyyy hh:mm:ss tt");
                    ret_TotalPrice = Convert.ToInt32(dtUsers.Rows[Row_No]["TotalPrice"]);
                    ret_SaleID = Convert.ToInt32(dtUsers.Rows[Row_No]["SaleID"].ToString());


                    MessageBox.Show(
                              $"--------------------------------------------------------------------------------------\n" +
                              $"Customer Info\n" +
                              $"--------------------------------------------------------------------------------------\n" +
                              $"First Name: {ret_First_Name}\n" +
                              $"Last Name: {ret_LastName}\n" +
                              $"CNIC: {ret_CNIC}\n" +
                              $"Phone Number: {ret_PhoneNumber}\n" +
                              $"--------------------------------------------------------------------------------------\n" +
                              $"Mobile Info\n" +
                              $"--------------------------------------------------------------------------------------\n" +
                              $"Brand: {ret_Brand}\n" +
                              $"Model: {ret_Model}\n" +
                              $"IMEI1: {ret_IMEI1}\n" +
                              $"IMEI2: {ret_IMEI2}\n" +
                              $"--------------------------------------------------------------------------------------\n" +
                              $"Sales Info\n" +
                              $"--------------------------------------------------------------------------------------\n" +
                              $"Sale Date: {ret_SaleDate}\n" +
                              $"Transaction Type: {ret_TransactionType}\n" +
                              $"Total Price: {ret_TotalPrice}\n" +
                              $"--------------------------------------------------------------------------------------\n" +
                              $"Installments Info\n" +
                              $"--------------------------------------------------------------------------------------\n"
                              );

                    if (MessageBox.Show("Show Installments Details !!", "Show MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ShowInstallmentDetails(ret_SaleID);
                    }   
                    row_click = false;



                }

            }
            else
            {
                MessageBox.Show("Please select a row first");
            }
        }

        private void ShowInstallmentDetails(int saleID)
        {

            int total_amount = Convert.ToInt32(dtUsers.Rows[Row_No]["TotalPrice"]);
            // Query to retrieve installment details for the given SaleID
            string query = "SELECT PaymentDate, Amount FROM Installments WHERE SaleID = @saleID" ;
            using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SaleID", saleID);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        StringBuilder installmentDetails = new StringBuilder();
                        installmentDetails.AppendLine($"Installment Details for SaleID {saleID}:");
                        int count = 1;

                        while (reader.Read())
                        {
                            
                            DateTime paymentDate = reader.GetDateTime(0);
                            decimal amount = reader.GetDecimal(1);
                            total_amount -= Convert.ToInt32(amount);

                            installmentDetails.AppendLine($"----------------------------------------\n" +
                                                          $"Installment No{count}\n" +
                                                          $"----------------------------------------\n" +
                                                          $"Amount: {amount:F2}" +
                                                          $"\nPaymentDate: {paymentDate.ToString("dd-MM-yyyy hh:mm:ss tt")}\n" +
                                                          $"Remaining Amount:{total_amount}");
                                                          count++;
                        }

                        MessageBox.Show(installmentDetails.ToString(), "  INSTALLMENT DETAILS ");
                    }
                }
            }
        }

        private void Close_Btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void addInstallBtn_Click(object sender, EventArgs e)
        {
            if (row_click == true)
            {
                if (ret_TransactionType == "Installments")
                {
                    

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("GetInstallmentsInfo", connection))
                            {
                                command.CommandType = System.Data.CommandType.StoredProcedure;
                               // MessageBox.Show(ret_SaleID.ToString());

                                // Add parameters to the stored procedure
                                command.Parameters.AddWithValue("@TargetSaleID", ret_SaleID); // Replace with the actual phoneID

                                // Output parameters
                                SqlParameter outputParameter1 = new SqlParameter("@InstallmentCount", System.Data.SqlDbType.Int);
                                outputParameter1.Direction = System.Data.ParameterDirection.Output;
                                command.Parameters.Add(outputParameter1);

                                SqlParameter outputParameter2 = new SqlParameter("@TotalAmount", System.Data.SqlDbType.Int);
                                outputParameter2.Direction = System.Data.ParameterDirection.Output;
                                command.Parameters.Add(outputParameter2);


                                // Execute the stored procedure
                                command.ExecuteNonQuery();
                                
                                ret_Installment_No = (int)outputParameter1.Value;
                                ret_TotalPaidAmont = (int)outputParameter2.Value;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }



                    Form13 form13 = new Form13();
                    
                    //MessageBox.Show(ret_Installment_No.ToString());
                    Form13.instance.tb1.Text = (ret_Installment_No + 1).ToString();
                    Form13.instance.tb2.Text = (ret_TotalPrice - ret_TotalPaidAmont).ToString();


                    form13.ShowDialog();
                    //MessageBox.Show(installement_amount.ToString());
                    installement_amount = Convert.ToInt32(installement_amount.ToString());
                    this.Show();

                    if (installement_amount != -9999999)
                    {
                        if (installement_amount <= (ret_TotalPrice - ret_TotalPaidAmont))
                        {
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                                {
                                    connection.Open();

                                    using (SqlCommand command = new SqlCommand("AddInstallments", connection))
                                    {
                                        command.CommandType = System.Data.CommandType.StoredProcedure;

                                        // Add parameters to the stored procedure
                                        command.Parameters.AddWithValue("@PhoneID", dtUsers.Rows[Row_No]["PhoneID"]); // Replace with the actual phoneID
                                        command.Parameters.AddWithValue("@CustomerID", dtUsers.Rows[Row_No]["CustomerID"]); // Replace with the actual customerID
                                        command.Parameters.AddWithValue("@PaymentDate", DateTime.Now); // Replace with the actual customerID
                                        command.Parameters.AddWithValue("@Amount", installement_amount); // Replace with the actual customerID

                                        // Execute the stored procedure
                                        command.ExecuteNonQuery();

                                        MessageBox.Show("Installment Added Successfully!");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred: {ex.Message}");
                            }
                        }

                        else
                        {

                            MessageBox.Show($"Total Amount = {ret_TotalPrice}\n You Already Paid = {ret_TotalPaidAmont}\n Remaining Amount = {ret_TotalPrice - ret_TotalPaidAmont}\nYou Are Giving Input More Than That. Please Try Again With Correct Amount");
                            this.Show();

                        }
                    }
                    else
                    {
                        this.Show();

                    }


                }
                row_click = false;

            }
            else {
                MessageBox.Show("Please select a row first");
            }

        }

        private void Search_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search_Box.MaxLength = 13;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            if (row_click == true)
            {
                if (MessageBox.Show("Are you sure ? \nyou want to Delete this record !!", "DELETE MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("DeleteCustomerRecord", connection))
                            {
                                command.CommandType = System.Data.CommandType.StoredProcedure;

                                // Add parameters to the stored procedure
                                command.Parameters.AddWithValue("@CustomerID", dtUsers.Rows[Row_No]["CustomerID"]); // Replace with the actual customerID
                                command.Parameters.AddWithValue("@PhoneID", dtUsers.Rows[Row_No]["PhoneID"]); // Replace with the actual customerID

                                // Execute the stored procedure
                                command.ExecuteNonQuery();

                                MessageBox.Show("Record Deleted Successfully!");
                                row_click = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }

                }
            }
            else
            {
                MessageBox.Show("Select the row first !! ");
            }

        }

        private void Settingbtn_Click(object sender, EventArgs e)
        {
            Shop_Items Shop_Item=new Shop_Items();
            
            Shop_Item.ShowDialog();
            this.Show();
        }
        
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            if (ret_TransactionType == "Full Payment")
            {
                string ret_First_Name = dtUsers.Rows[Row_No]["FName"].ToString();
                string ret_LastName = dtUsers.Rows[Row_No]["LName"].ToString();
                string ret_CNIC = dtUsers.Rows[Row_No]["CNIC"].ToString();
                string ret_PhoneNumber = dtUsers.Rows[Row_No]["PhoneNumber"].ToString();
                string ret_Brand = dtUsers.Rows[Row_No]["Brand"].ToString();
                string ret_Model = dtUsers.Rows[Row_No]["Model"].ToString();
                string ret_IMEI1 = dtUsers.Rows[Row_No]["IMEI1"].ToString();
                string ret_IMEI2 = dtUsers.Rows[Row_No]["IMEI2"].ToString();
                ret_TransactionType = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                string ret_SaleDate = dtUsers.Rows[Row_No]["SaleDate"].ToString();
                string ret_TotalPrice = dtUsers.Rows[Row_No]["TotalPrice"].ToString();
                row_click = false;
                e.Graphics.DrawString($"--------------------------------------------------------------------------------------\nCustomer Info\n--------------------------------------------------------------------------------------\n First Name : {ret_First_Name} \nLast Name : {ret_LastName} \nCNIC : {ret_CNIC} \nPhone Number : {ret_PhoneNumber}\n -------------------------------------------------------------------------------------- \nMobile Info\n--------------------------------------------------------------------------------------\n" +
                   $"Brand : {ret_Brand}\n Model: {ret_Model}\n IMEI1: {ret_IMEI1}\n IMEI2: {ret_IMEI2}\n-------------------------------------------------------------------------------------- \nSales Info\n--------------------------------------------------------------------------------------\n" +
                   $"Sale Date: {ret_SaleDate}\n Transaction Type: {ret_TransactionType}\n Total Price: {ret_TotalPrice}", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));
            }
            else if (ret_TransactionType == "Installments")
            {
                string ret_First_Name = dtUsers.Rows[Row_No]["FName"].ToString();
                string ret_LastName = dtUsers.Rows[Row_No]["LName"].ToString();
                string ret_CNIC = dtUsers.Rows[Row_No]["CNIC"].ToString();
                string ret_PhoneNumber = dtUsers.Rows[Row_No]["PhoneNumber"].ToString();
                string ret_Brand = dtUsers.Rows[Row_No]["Brand"].ToString();
                string ret_Model = dtUsers.Rows[Row_No]["Model"].ToString();
                string ret_IMEI1 = dtUsers.Rows[Row_No]["IMEI1"].ToString();
                string ret_IMEI2 = dtUsers.Rows[Row_No]["IMEI2"].ToString();
                ret_TransactionType = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                string ret_SaleDate = ((DateTime)dtUsers.Rows[Row_No]["SaleDate"]).ToString("dd-MM-yyyy hh:mm:ss tt");
                ret_TotalPrice = Convert.ToInt32(dtUsers.Rows[Row_No]["TotalPrice"]);
                ret_SaleID = Convert.ToInt32(dtUsers.Rows[Row_No]["SaleID"].ToString());

                int saleID = ret_SaleID;

                int total_amount = Convert.ToInt32(dtUsers.Rows[Row_No]["TotalPrice"]);
                // Query to retrieve installment details for the given SaleID
                string query = "SELECT PaymentDate, Amount FROM Installments WHERE SaleID = @saleID";
                StringBuilder installmentDetails = new StringBuilder();
                installmentDetails.AppendLine($"Installment Details for SaleID {saleID}:");
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", saleID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            int count = 1;

                            while (reader.Read())
                            {

                                DateTime paymentDate = reader.GetDateTime(0);
                                decimal amount = reader.GetDecimal(1);
                                total_amount -= Convert.ToInt32(amount);

                                installmentDetails.AppendLine($"------------------" +
                                    $"----------------------\nInstallment No{count}\n-------------" +
                                    $"---------------------------\nAmount: {amount:F2}\nPaymentDate:" +
                                    $" {paymentDate.ToString("dd-MM-yyyy hh:mm:ss tt")}\nRemaining Amount:{total_amount}");
                                count++;
                            }


                        }
                    }
                }
                string printText = $"--------------------------------------------------------------------------------------\nCustomer Info" +
                 $"\n--------------------------------------------------------------------------------------\n First Name : {ret_First_Name} \n" +
                 $"Last Name : {ret_LastName} \nCNIC : {ret_CNIC} \nPhone Number : {ret_PhoneNumber}\n ------" +
                 $"-------------------------------------------------------------------------------- \nMobile Info\n--------" +
                 $"------------------------------------------------------------------------------\n" +
                 $"Brand : {ret_Brand}\n Model: {ret_Model}\n IMEI1: {ret_IMEI1}\n IMEI2: {ret_IMEI2}\n-------------------" +
                 $"------------------------------------------------------------------- \nSales Info\n-----------------------" +
                 $"---------------------------------------------------------------\n" +
                 $"Sale Date: {ret_SaleDate}\n Transaction Type: {ret_TransactionType}\n Total Price: {ret_TotalPrice}" +
                 $"\n--------------------------------------------------------------------------------------\n" +
                 $"Installments Info\n--------------------------------------------------------------------------------------" +
                 $"\n{installmentDetails.ToString()}";

                e.Graphics.DrawString(printText, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));



                row_click = false;



            }




        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            
            Form14 form14 = new Form14();
            form14.ShowDialog();
            this.Show();
        }

        private void IMEIRbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;

            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}