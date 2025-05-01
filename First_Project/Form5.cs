using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;

namespace First_Project
{
    public partial class Sale_His_form : Form
    {
        DBAccess ObjdBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        public Sale_His_form()
        {
            InitializeComponent();
            checkBox1.Checked = true;
        }

        private void Purchases_Load(object sender, EventArgs e)
        {

        }
       

        private void SearchBtn_Click_1(object sender, EventArgs e)
        {
            string purchaseDate = Search_Box.Text; // Assuming "7" days from now
            dtUsers.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetAllCustomerSalesInformation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameter for purchase date
                        command.Parameters.AddWithValue("@NumDays", purchaseDate);

                        // Execute the stored procedure and fill the DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dtUsers);
                    }
                }

                if (dtUsers.Rows.Count >= 1)
                {
                    // Bind the DataTable to the DataGridView
                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.DataSource = dtUsers;
                }
                else
                {
                    MessageBox.Show("No records found for the specified purchase date.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ExportToPDF(DataGridView dataGridView)
        {
            try
            {
                // Generate a unique file name with timestamp
                string fileName = $"output_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

                // Create a PDF document
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Create a PDF table with columns based on the DataGridView
                PdfPTable table = new PdfPTable(dataGridView.Columns.Count);
                table.WidthPercentage = 100;

                // Add headers from the DataGridView to the PDF table
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    table.AddCell(column.HeaderText);
                }

                // Add rows from the DataGridView to the PDF table
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Check if the cell value is null
                        string cellValue = cell.Value != null ? cell.Value.ToString() : "";

                        table.AddCell(cellValue);
                    }
                }

                // Add the PDF table to the document
                document.Add(table);

                // Close the document
                document.Close();

                MessageBox.Show($"PDF file '{fileName}' created successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void Printbtn_Click(object sender, EventArgs e)
        {
            ExportToPDF(dataGridView2);
        }

        private void Search_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search_Box.MaxLength = 10;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        //bAckBtn
        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
