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

    public partial class Update_Dealer_form : Form
    {
        DBAccess ObjdBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        DataTable dtDealers = new DataTable();
        
        private object textBox2;
        public static Update_Dealer_form instance;
        UpdateDealer  update_form = new UpdateDealer();
        public static string De_ID = "";
        public static string phone_ID = "";
        public static string payment_type = "";
        public static int installement_amount;
        public static string ret_Package1;
        public static string ret_DealerID1;


        public Update_Dealer_form()
        {
            InitializeComponent();
        }

       

       

      

        

      

       

        private void UpdDlrSrchCNIC_TextChanged(object sender, EventArgs e)
        {

        }
        private int Row_No;
        private string ret_TransactionType;
        private bool row_click = false;
        private bool row_click1 = false;
        private int ret_Installment_No;
        private int ret_PurchaseID;
        private int ret_TotalPrice;
        private int ret_TotalPaidAmont;

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
                {
                    Row_No = e.RowIndex;
                    row_click = true;
                    ret_TransactionType = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                    ret_PurchaseID = Convert.ToInt32(dtUsers.Rows[Row_No]["PurchaseMobileID"].ToString());
                    ret_TotalPrice = Convert.ToInt32(dtUsers.Rows[Row_No]["TotalPrice"]);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show($"There is no data in this row");
            }

            /* try
             {
                 if (e.RowIndex != -1 && dtUsers.Columns.Contains("TransactionType"))
                 {
                     Row_No = e.RowIndex;
                     row_click = true;
                     ret_TransactionType = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                     ret_PurchaseID = Convert.ToInt32(dtUsers.Rows[Row_No]["PurchaseMobileID"].ToString());
                     ret_TotalPrice = Convert.ToInt32(dtUsers.Rows[Row_No]["TotalPrice"]);
                 }
             }
             catch (IndexOutOfRangeException ex)
             {
                 MessageBox.Show($"There is no data in this row");
             }*/


        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            string number = Search_Box.Text;
            dtUsers.Clear();
            dtDealers.Clear();



            SqlParameter parameter = new SqlParameter("@DealerCNIC", SqlDbType.NVarChar, 50);
            parameter.Value = number;
            ObjdBAccess.readDatathroughAdapter_2("GetAllDealerInformationByCNIC", dtUsers, parameter);

            if (dtUsers.Rows.Count >= 1)
            {
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = dtUsers;
            }

            else
            {
                MessageBox.Show("No Dealer !");
            }
            try
            {
                // Assuming CNIC is stored in a variable called cnic
                

                // Step 1: Retrieve DealerID from Dealers table based on CNIC
                int dealerID = -1; // Default value if CNIC is not found
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();
                    string query = "SELECT DealerID FROM Dealers WHERE CNIC = @CNIC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CNIC", number);
                        var result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            dealerID = Convert.ToInt32(result);
                        }
                    }
                }

                // Step 2: Query DealerInstallment table based on DealerID
                if (dealerID != -1)
                {
                    using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                    {
                        connection.Open();
                        string storedProcedureName = "GetDealerInstallmentsInformation";

                        using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@DealerID", dealerID);
                            
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            
                            adapter.Fill(dtDealers);

                            if (dtDealers.Rows.Count > 0)
                            {
                                dataGridView1.AutoGenerateColumns = false;
                                dataGridView1.DataSource = dtDealers;
                            }
                        }
                    }

                }
                else
                {
                   // MessageBox.Show("Dealer with the given CNIC not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }


        }

    
        private void Update_Dealer_form_Load(object sender, EventArgs e)
        {

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
        //update btn
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (row_click == true)
            {

                if (ret_TransactionType == "Full Payment" || ret_TransactionType == "Full Payment (Replacement)")
                {
                    UpdateDealer updateForm = new UpdateDealer();
                    UpdateDealer.instance.tb1.Text = dtUsers.Rows[Row_No]["FName"].ToString();
                    UpdateDealer.instance.tb2.Text = dtUsers.Rows[Row_No]["LName"].ToString();
                    UpdateDealer.instance.tb3.Text = dtUsers.Rows[Row_No]["CNIC"].ToString();
                    UpdateDealer.instance.tb4.Text = dtUsers.Rows[Row_No]["PhoneNumber"].ToString();
                    UpdateDealer.instance.cb1.Text = dtUsers.Rows[Row_No]["Brand"].ToString();
                    UpdateDealer.instance.cb2.Text = dtUsers.Rows[Row_No]["Model"].ToString();
                    UpdateDealer.instance.tb7.Text = dtUsers.Rows[Row_No]["IMEI1"].ToString();
                    UpdateDealer.instance.tb8.Text = dtUsers.Rows[Row_No]["IMEI2"].ToString();
                    UpdateDealer.instance.tb9.Text = dtUsers.Rows[Row_No]["TotalPrice"].ToString();
                    De_ID = dtUsers.Rows[Row_No]["DealerID"].ToString();
                    phone_ID = dtUsers.Rows[Row_No]["PhoneID"].ToString();
                    payment_type = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                    updateForm.updatedBrand = Convert.ToInt32(dtUsers.Rows[Row_No]["BrandID"]);
                    updateForm.updatedModel = Convert.ToInt32(dtUsers.Rows[Row_No]["ModelID"]);
                    updateForm.ShowDialog();

                    this.Show();
                    row_click = false;

                }
                if (ret_TransactionType == "Installments")
                {
                    UpdateDealer updateForm = new UpdateDealer();
                    UpdateDealer.instance.tb1.Text = dtUsers.Rows[Row_No]["FName"].ToString();
                    UpdateDealer.instance.tb2.Text = dtUsers.Rows[Row_No]["LName"].ToString();
                    UpdateDealer.instance.tb3.Text = dtUsers.Rows[Row_No]["CNIC"].ToString();
                    UpdateDealer.instance.tb4.Text = dtUsers.Rows[Row_No]["PhoneNumber"].ToString();
                    UpdateDealer.instance.cb1.Text = dtUsers.Rows[Row_No]["Brand"].ToString();
                    UpdateDealer.instance.cb2.Text = dtUsers.Rows[Row_No]["Model"].ToString();
                    UpdateDealer.instance.tb7.Text = dtUsers.Rows[Row_No]["IMEI1"].ToString();
                    UpdateDealer.instance.tb8.Text = dtUsers.Rows[Row_No]["IMEI2"].ToString();
                    UpdateDealer.instance.tb9.Text = dtUsers.Rows[Row_No]["TotalPrice"].ToString();
                    De_ID = dtUsers.Rows[Row_No]["DealerID"].ToString();
                    phone_ID = dtUsers.Rows[Row_No]["PhoneID"].ToString();
                    payment_type = dtUsers.Rows[Row_No]["TransactionType"].ToString();
                    updateForm.updatedBrand = Convert.ToInt32(dtUsers.Rows[Row_No]["BrandID"]);
                    updateForm.updatedModel = Convert.ToInt32(dtUsers.Rows[Row_No]["ModelID"]);
                    updateForm.ShowDialog();

                    this.Show();
                    row_click = false;

                }
            }
            else 
            {
                MessageBox.Show(" Select the row first!! ");
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
                    string ret_PurchaseDate = dtUsers.Rows[Row_No]["PurchaseDate"].ToString();
                    string ret_TotalPrice = dtUsers.Rows[Row_No]["TotalPrice"].ToString();




                    MessageBox.Show($"--------------------------------------------------------------------------------------\nDealer Info\n--------------------------------------------------------------------------------------\n First Name : {ret_First_Name} \nLast Name : {ret_LastName} \nCNIC : {ret_CNIC} \nPhone Number : {ret_PhoneNumber}\n -------------------------------------------------------------------------------------- \nMobile Info\n--------------------------------------------------------------------------------------\n" +
                        $"Brand : {ret_Brand}\n Model: {ret_Model}\n IMEI1: {ret_IMEI1}\n IMEI2: {ret_IMEI2}\n-------------------------------------------------------------------------------------- \nSales Info\n--------------------------------------------------------------------------------------\n" +
                        $"Purchase Date: {ret_PurchaseDate}\n Transaction Type: {ret_TransactionType}\n Total Price: {ret_TotalPrice}");
                    row_click = false;
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
                    string ret_PurchaseDate = dtUsers.Rows[Row_No]["PurchaseDate"].ToString();
                    string ret_TotalPrice = dtUsers.Rows[Row_No]["TotalPrice"].ToString();



                    MessageBox.Show($"--------------------------------------------------------------------------------------\nDealer Info\n--------------------------------------------------------------------------------------\n First Name : {ret_First_Name} \nLast Name : {ret_LastName} \nCNIC : {ret_CNIC} \nPhone Number : {ret_PhoneNumber}\n -------------------------------------------------------------------------------------- \nMobile Info\n--------------------------------------------------------------------------------------\n" +
                        $"Brand : {ret_Brand}\n Model: {ret_Model}\n IMEI1: {ret_IMEI1}\n IMEI2: {ret_IMEI2}\n-------------------------------------------------------------------------------------- \nSales Info\n--------------------------------------------------------------------------------------\n" +
                        $"Purchase Date: {ret_PurchaseDate}\n Transaction Type: {ret_TransactionType}\n Total Price: {ret_TotalPrice}");
                    row_click = false;



                }
                else if (ret_TransactionType == "Full Payment (Replacement)")
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
                    string ret_PurchaseDate = dtUsers.Rows[Row_No]["PurchaseDate"].ToString();
                    string ret_TotalPrice = dtUsers.Rows[Row_No]["TotalPrice"].ToString();
                    string ret_ReplacementID = dtUsers.Rows[Row_No]["ReplacementPhoneID"].ToString();




                   
                   
                    string transactionType = string.Empty;
                    decimal totalPrice = 0;
                    string brand = string.Empty;
                    string model = string.Empty;

                    using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                    {
                        try
                        {
                            connection.Open();

                            SqlCommand command = new SqlCommand("GetCustomerSaleByPhoneID", connection);
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@PhoneID", ret_ReplacementID);

                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                               
                                transactionType = reader["TransactionType"].ToString();
                                totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                                brand = reader["Brand"].ToString();
                                model = reader["Model"].ToString();
                            }

                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while retrieving customer information: " + ex.Message);
                        }
                    }

                    MessageBox.Show($"--------------------------------------------------------------------------------------\nDealer Info\n" +
                        $"--------------------------------------------------------------------------------------\n First Name : {ret_First_Name}" +
                        $" \nLast Name : {ret_LastName} \nCNIC : {ret_CNIC} \nPhone Number : {ret_PhoneNumber}\n -----------------------------------" +
                        $"--------------------------------------------------- \nMobile Info\n-------------------------------------------------------" +
                        $"-------------------------------\n" +
                        $"Brand : {ret_Brand}\n Model: {ret_Model}\n IMEI1: {ret_IMEI1}\n IMEI2: {ret_IMEI2}\n------------------------------------------" +
                        $"-------------------------------------------- \nSales Info\n-------------------------------------------------------------------" +
                        $"-------------------\n" +
                        $"Purchase Date: {ret_PurchaseDate}\n Transaction Type: {ret_TransactionType}\n Total Price: {ret_TotalPrice} \n--------------------------------------------------------------------------------------\n Relacement Mobile" +
                        $"\n--------------------------------------------------------------------------------------\n" +
                        $"Transaction Type: {transactionType}\n Total Price: {totalPrice}\n Brand: {brand}\n Model: {model}");


                    row_click = false;




                }


            }
            else
            {
                MessageBox.Show("Please select a row first");
            }
        }
        //Delete Button
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (row_click==true) 
            {
                if (MessageBox.Show("Are you sure ? \nYou want to Delete this record !! ", "DELETE MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("DeleteDealerRecord", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                // Assuming dtDealers is a DataTable containing the dealer data
                                int dealerID = Convert.ToInt32(dtUsers.Rows[Row_No]["DealerID"]);
                                int phoneID = Convert.ToInt32(dtUsers.Rows[Row_No]["PhoneID"]);

                                // Add parameters to the stored procedure
                                command.Parameters.AddWithValue("@PhoneID", phoneID);
                                command.Parameters.AddWithValue("@DealerID", dealerID);

                                // Execute the stored procedure
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Dealer Record Deleted Successfully!");
                                    row_click = false;
                                }
                                else
                                {
                                    MessageBox.Show("Mobile Phone is sold. You Can't Delete from here \n First Delete from Customers Records !!");
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
            else 
            {
                MessageBox.Show("Select the row first !! ");
            }

        }

        private void guna2GradientButton1_CursorChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2GradientButton1_MouseEnter(object sender, EventArgs e)
        {
           
        }
        
        private void guna2GradientButton1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (row_click == true)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }

        }
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
                    string ret_PurchaseDate = dtUsers.Rows[Row_No]["PurchaseDate"].ToString();
                    string ret_TotalPrice = dtUsers.Rows[Row_No]["TotalPrice"].ToString();




                    e.Graphics.DrawString($"--------------------------------------------------------------------------------------\nDealer Info\n--------------------------------------------------------------------------------------\n First Name : {ret_First_Name} \nLast Name : {ret_LastName} \nCNIC : {ret_CNIC} \nPhone Number : {ret_PhoneNumber}\n -------------------------------------------------------------------------------------- \nMobile Info\n--------------------------------------------------------------------------------------\n" +
                        $"Brand : {ret_Brand}\n Model: {ret_Model}\n IMEI1: {ret_IMEI1}\n IMEI2: {ret_IMEI2}\n-------------------------------------------------------------------------------------- \nSales Info\n--------------------------------------------------------------------------------------\n" +
                        $"Sale Date: {ret_PurchaseDate}\n Transaction Type: {ret_TransactionType}\n Total Price: {ret_TotalPrice}", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));
                    row_click = false;
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
                    string ret_PurchaseDate = dtUsers.Rows[Row_No]["PurchaseDate"].ToString();
                    string ret_TotalPrice = dtUsers.Rows[Row_No]["TotalPrice"].ToString();




                    e.Graphics.DrawString($"--------------------------------------------------------------------------------------\nDealer Info\n--------------------------------------------------------------------------------------\n First Name : {ret_First_Name} \nLast Name : {ret_LastName} \nCNIC : {ret_CNIC} \nPhone Number : {ret_PhoneNumber}\n -------------------------------------------------------------------------------------- \nMobile Info\n--------------------------------------------------------------------------------------\n" +
                        $"Brand : {ret_Brand}\n Model: {ret_Model}\n IMEI1: {ret_IMEI1}\n IMEI2: {ret_IMEI2}\n---s----------------------------------------------------------------------------------- \nSales Info\n--------------------------------------------------------------------------------------\n" +
                        $"Sale Date: {ret_PurchaseDate}\n Transaction Type: {ret_TransactionType}\n Total Price: {ret_TotalPrice}", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));
                    row_click = false;


                }
                else if (ret_TransactionType == "Full Payment (Replacement)")
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
                    string ret_PurchaseDate = dtUsers.Rows[Row_No]["PurchaseDate"].ToString();
                    string ret_TotalPrice = dtUsers.Rows[Row_No]["TotalPrice"].ToString();
                    string ret_ReplacementID = dtUsers.Rows[Row_No]["ReplacementPhoneID"].ToString();






                    string transactionType = string.Empty;
                    decimal totalPrice = 0;
                    string brand = string.Empty;
                    string model = string.Empty;

                    using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                    {
                        try
                        {
                            connection.Open();

                            SqlCommand command = new SqlCommand("GetCustomerSaleByPhoneID", connection);
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@PhoneID", ret_ReplacementID);

                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {

                                transactionType = reader["TransactionType"].ToString();
                                totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                                brand = reader["Brand"].ToString();
                                model = reader["Model"].ToString();
                            }

                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while retrieving customer information: " + ex.Message);
                        }
                    }
                    e.Graphics.DrawString($"--------------------------------------------------------------------------------------\nDealer Info\n" +
                        $"--------------------------------------------------------------------------------------\n First Name : {ret_First_Name}" +
                        $" \nLast Name : {ret_LastName} \nCNIC : {ret_CNIC} \nPhone Number : {ret_PhoneNumber}\n -----------------------------------" +
                        $"--------------------------------------------------- \nMobile Info\n-------------------------------------------------------" +
                        $"-------------------------------\n" +
                        $"Brand : {ret_Brand}\n Model: {ret_Model}\n IMEI1: {ret_IMEI1}\n IMEI2: {ret_IMEI2}\n------------------------------------------" +
                        $"-------------------------------------------- \nSales Info\n-------------------------------------------------------------------" +
                        $"-------------------\n" +
                        $"Purchase Date: {ret_PurchaseDate}\n Transaction Type: {ret_TransactionType}\n Total Price: {ret_TotalPrice} \n--------------------------------------------------------------------------------------\n Relacement Mobile" +
                        $"\n--------------------------------------------------------------------------------------\n" +
                        $"Transaction Type: {transactionType}\n Total Price: {totalPrice}\n Brand: {brand}\n Model: {model}", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));
                    row_click = false;



                }



            }
            else
            {
                MessageBox.Show("Please select a row first");
            }
        }
        private int ret_Package, ret_DealerID,Installment_No;
        private int ret_BrandID,ret_ModelID;

        private void DltInsbtn_Click(object sender, EventArgs e)
        {

            if (row_click1 == true)
            {
                if (MessageBox.Show("Are you sure? \nyou want to Delete this record!! ", "DELETE MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand Query = new SqlCommand("DELETE FROM DealerInstallments WHERE InstallmentID=@InstallmentID");
                    Query.Parameters.AddWithValue("@InstallmentID", ret_InstallID);
                    ObjdBAccess.executeQuery_2(Query);
                    MessageBox.Show(" Record Deleted Successfully!!  ");
                    row_click1 = false;
                }
            
            }
            else
            {
                MessageBox.Show("Select the row first !!");
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState=FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Normal) 
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
            this.Close();
        }
        //update Installments
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            if (row_click1 == true && row_click==true)
            {
                ret_Package1= ret_Package.ToString();
                ret_DealerID1 = ret_DealerID.ToString();
                MessageBox.Show(ret_DealerID1.ToString());
                Form16 form16 = new Form16();
                Form16.instance.tb1.Text = dtUsers.Rows[Row_No]["FName"].ToString();
                Form16.instance.tb2.Text = dtUsers.Rows[Row_No]["LName"].ToString();
                Form16.instance.tb3.Text = dtUsers.Rows[Row_No]["CNIC"].ToString();
                Form16.instance.tb4.Text = dtUsers.Rows[Row_No]["PhoneNumber"].ToString();
                Form16.instance.tb9.Text = ret_TotalAmount.ToString();
                
                form16.ShowDialog();
                row_click1 = false;
                row_click = false;

            }
            else if(row_click==true && row_click1==false)
                {
                MessageBox.Show(" Select Installmemts !!");
                }
            else if (row_click == false && row_click1 == true)
            {
                MessageBox.Show(" Select Dealer !!");
            }
            else
            {
                MessageBox.Show("Select the Row First!!");
            }



        }

        private int ret_TotalAmount, balance, ret_InstallID;
    
        private void addInstallBtn_Click(object sender, EventArgs e)
        {
            if (row_click1 == true)
            {
                SqlCommand Query = new SqlCommand("SELECT TOP 1 Balance FROM DealerInstallments WHERE DealerID=@DealerID AND Package=@Package ORDER BY InstallmentID DESC;");
                Query.Parameters.AddWithValue("@Package", ret_Package);
                Query.Parameters.AddWithValue("@DealerID", ret_DealerID);
                balance = Convert.ToInt32(ObjdBAccess.executeQuery_2(Query));
                //MessageBox.Show(balance.ToString());
                SqlCommand QueryInstallmentNo = new SqlCommand("SELECT COUNT(*)\r\nFROM DealerInstallments\r\nWHERE DealerID = @DealerID\r\n  AND Package = @Package;");
                QueryInstallmentNo.Parameters.AddWithValue("@Package", ret_Package);
                QueryInstallmentNo.Parameters.AddWithValue("@DealerID", ret_DealerID);
                Installment_No = Convert.ToInt32(ObjdBAccess.executeQuery_2(QueryInstallmentNo));
                //MessageBox.Show(Installment_No.ToString());
                row_click1 = false;
                if (balance!=0) 
                {
                    Form15 form15 = new Form15();
                    Form15.instance.tb3.Text = balance.ToString();
                    Form15.instance.tb1.Text = (Installment_No + 1).ToString();
                    form15.ShowDialog();
                }
                else
                {
                    MessageBox.Show(" All Installments Paid !!");
                }
                



                if (installement_amount != -9999999 && installement_amount != 0)
                {
                   
                    if (installement_amount <= balance)
                    {
                        balance = balance - installement_amount;
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                            {
                                connection.Open();

                                using (SqlCommand command = new SqlCommand("AddSignleDealerInstallment", connection))
                                {
                                    command.CommandType = System.Data.CommandType.StoredProcedure;


                                    MessageBox.Show(ret_DealerID.ToString());
                                    command.Parameters.AddWithValue("@Package", ret_Package);
                                    command.Parameters.AddWithValue("@DealerID", ret_DealerID);
                                    command.Parameters.AddWithValue("@BrandID", ret_BrandID);
                                    command.Parameters.AddWithValue("@ModelID", ret_ModelID);
                                    command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                                    command.Parameters.AddWithValue("@Amount", installement_amount);
                                    command.Parameters.AddWithValue("@Balance", balance);
                                    command.Parameters.AddWithValue("@TotalAmount", ret_TotalAmount);
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("New Installment Has been Added!!");


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

                        MessageBox.Show($"{installement_amount}\t Remaining Amount is \t{balance}\nYou Are Giving Input More Than That. Please Try Again With Correct Amount");
                        this.Show();

                    }
                }
                else
                {
                    this.Show();

                }
            }
            else 
            {
                MessageBox.Show("Select the Row First!!");
            }

           




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (e.RowIndex != -1 && dtDealers != null && dtDealers.Rows.Count > 0)
                {
                    

                    if (dtDealers.Columns.Contains("Amount"))
                    {
                        Row_No = e.RowIndex;
                        row_click1 = true;
                        ret_Package = Convert.ToInt32(dtDealers.Rows[Row_No]["Package"]);
                        ret_DealerID = Convert.ToInt32(dtDealers.Rows[Row_No]["DealerID"]);
                        ret_BrandID = Convert.ToInt32(dtDealers.Rows[Row_No]["BrandID"]);
                        ret_ModelID = Convert.ToInt32(dtDealers.Rows[Row_No]["ModelID"].ToString());
                        ret_TotalAmount = Convert.ToInt32(dtDealers.Rows[Row_No]["TotalAmount"]);
                        ret_InstallID = Convert.ToInt32(dtDealers.Rows[Row_No]["InstallmentID"]);
                       

                    }
                    else
                    {
                        MessageBox.Show("The DataTable does not contain the required columns.");
                    }
                }
                else
                {
                    MessageBox.Show("No data available in the DataTable.");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show($"There is no data in this row");
            }


           




        }
    }
}
