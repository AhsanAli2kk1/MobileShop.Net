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
    public partial class Shop_Items : Form
    {
        DBAccess ObjDbAccess = new DBAccess();
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();
        public int updatedModel;
        public int updatedBrand;
        public Shop_Items()
        {
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void ModelBox_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void AddBtn_Click(object sender, EventArgs e)
        {
            String Brand = BrandBox.Text, Model = ModelBox.Text;

            if (Brand!="" && Model!="") {
                if (MessageBox.Show("Are you sure? \nyou want to Add this record!! ", "ADD MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("AddBrandAndModel", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                // Add parameters to the stored procedure
                                command.Parameters.AddWithValue("@BrandName", Brand);
                                command.Parameters.AddWithValue("@ModelName", Model);

                                // Execute the stored procedure
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int brandID = reader.GetInt32(reader.GetOrdinal("BrandID"));
                                        int modelID = reader.GetInt32(reader.GetOrdinal("ModelID"));

                                        if (brandID == -1 && modelID == -1)
                                        {
                                            MessageBox.Show("Brand and Model  already available !!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Brand and Model added successfully!");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to add Brand and Model. No changes were applied.");
                                    }
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
                MessageBox.Show("  Please Fill the above Feilds !!");
            }


           


        }

        private void Shop_Items_Load(object sender, EventArgs e)
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? \nyou want to Delete this record !! ", "DELETE MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("DeleteBrandAndModel", connection))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;

                            // Add parameters to the stored procedure
                            command.Parameters.AddWithValue("@BrandID", updatedBrand); // Replace with the actual brandID
                            command.Parameters.AddWithValue("@ModelID", updatedModel); // Replace with the actual modelID

                            // Execute the stored procedure
                            command.ExecuteNonQuery();

                            MessageBox.Show("Brand and Model Deleted Successfully!");
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
}
