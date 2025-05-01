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
    public partial class Form16 : Form
    {

        DBAccess ObjDbAccess = new DBAccess();
        public static Form16 instance;
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
     
        private int ret_Package1;
        private int ret_DealerID1;
     


        DataTable installments = new DataTable();
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();
        public Form16()
        {
            ret_Package1 = Convert.ToInt32(Update_Dealer_form.ret_Package1);
            ret_DealerID1 = Convert.ToInt32(Update_Dealer_form.ret_DealerID1);
            InitializeComponent();
            instance = this;
             
             tb1 = CusNameBox;
             tb2 = CusLNameBox;
             tb3 = CusCNICBox;
             tb4 = CusPNumBox;
             tb9 = CusTotalAmntBox;
             tb10 = CusInstalAmntBox;
             tb11 = CusInstalDateBox;
             cb3 = CusInstalNoBox;
           
        }
        private int installmentID;

        private void Form16_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetInstallmentsByDealerIDAndPackage", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters to the stored procedure
                        command.Parameters.AddWithValue("@DealerID", ret_DealerID1);
                        command.Parameters.AddWithValue("@Package", ret_Package1);

                        // Clear existing items in the ComboBox
                        CusInstalNoBox.Items.Clear();

                        // Clear existing data in the DataTable
                        installments.Clear();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Define columns in the DataTable
                            installments.Columns.Add("InstallmentID", typeof(int));
                            installments.Columns.Add("Amount", typeof(decimal));
                            installments.Columns.Add("PaymentDate", typeof(DateTime));
                            int count=1;
                            // Add installment options to the ComboBox and populate DataTable
                            while (reader.Read())
                            {
                                int installmentID = reader.GetInt32(reader.GetOrdinal("InstallmentID"));
                                decimal amount = reader.GetDecimal(reader.GetOrdinal("Amount"));
                                DateTime paymentDate = reader.GetDateTime(reader.GetOrdinal("PaymentDate"));

                                CusInstalNoBox.Items.Add($"Installment {count++}");

                                // Add data to the DataTable
                                installments.Rows.Add(installmentID, amount, paymentDate);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }
        private int instal_ID = -1;
        private void CusInstalNoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (installments != null && installments.Rows.Count > 0)
            {
                int selectedInstallmentIndex = CusInstalNoBox.SelectedIndex;
                if (selectedInstallmentIndex >= 0 && selectedInstallmentIndex < installments.Rows.Count)
                {
                    // Retrieve installment information from the DataTable based on selected index
                    DataRow selectedRow = installments.Rows[selectedInstallmentIndex];

                    // Display amount and date in TextBoxes
                    CusInstalAmntBox.Text = selectedRow["Amount"].ToString();
                    CusInstalDateBox.Text = selectedRow["PaymentDate"].ToString();

                    // Store installment ID
                    instal_ID = Convert.ToInt32(selectedRow["InstallmentID"]);
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

            if (CusInstalAmntBox.Text != null && CusInstalDateBox.Text != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                    {
                        connection.Open();

                        // Define the SQL update query
                        string updateQuery = @"UPDATE DealerInstallments
                               SET Amount = @NewAmount,
                                   PaymentDate = @NewPaymentDate
                               WHERE InstallmentID = @InstallmentID";

                        // Create a SqlCommand object with the update query and connection
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Add parameters to the SQL query
                            command.Parameters.AddWithValue("@NewAmount", CusInstalAmntBox.Text); // Replace newAmount with the new amount value
                            command.Parameters.AddWithValue("@NewPaymentDate", CusInstalDateBox.Text); // Replace newPaymentDate with the new payment date value
                            command.Parameters.AddWithValue("@InstallmentID", instal_ID); // Replace installmentID with the specific installment ID to update

                            // Execute the update query
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Update successful
                                MessageBox.Show("Update successful.", "Success");
                                this.Close();
                            }
                            else
                            {
                                // No rows updated (installment ID not found)
                                MessageBox.Show("No rows updated. Installment ID not found.", "Information");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                }
            }
            else 
            {
                MessageBox.Show("Select Installment record. Which you want to update !!");
            }
        }
    }
}
