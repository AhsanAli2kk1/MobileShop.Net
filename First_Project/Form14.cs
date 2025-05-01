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
    public partial class Form14 : Form
    {
        DBAccess ObjDbAccess = new DBAccess();
        DataTable dtBrands = new DataTable();
        DataTable dtModels = new DataTable();
        public int updatedModel;
        public int updatedBrand;
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
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

                    using (SqlCommand command = new SqlCommand("GetAccBrandNames", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters to the stored procedure


                        ObjDbAccess.readDatathroughAdapter("GetAccBrandNames", dtBrands);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int count = 0;

                            while (reader.Read())
                            {

                                UpdBrandComboBox.Items.Add($"{dtBrands.Rows[count]["AccBrandName"]}");
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

                    using (SqlCommand command = new SqlCommand("GetAccModelNames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TargetID", updatedBrand);

                        // Remove the unused SqlParameter 'parameter'
                        SqlParameter parameter = new SqlParameter("@TargetID", SqlDbType.Int, 32);
                        parameter.Value = updatedBrand;

                        ObjDbAccess.readDatathroughAdapter_2("GetAccModelNames", dtModels, parameter);

                        UpdModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            UpdModelComboBox.Items.Add($"{row["AccModelName"]}");
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
                    autoCompleteCollection.Add(row["AccBrandName"].ToString());
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
            updatedBrand = Convert.ToInt32(dtBrands.Rows[Row_No]["AccBrandID"]);
           // MessageBox.Show($"{updatedBrand}");
            UpdModelComboBox.Text = "";
            dtModels.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetAccModelNames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TargetID", updatedBrand);

                        // Remove the unused SqlParameter 'parameter'
                        SqlParameter parameter = new SqlParameter("@TargetID", SqlDbType.Int, 32);
                        parameter.Value = updatedBrand;

                        ObjDbAccess.readDatathroughAdapter_2("GetAccModelNames", dtModels, parameter);

                        UpdModelComboBox.Items.Clear();

                        foreach (DataRow row in dtModels.Rows)
                        {
                            UpdModelComboBox.Items.Add($"{row["AccModelName"]}");
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
            updatedModel = Convert.ToInt32(dtModels.Rows[Row_No]["AccModelID"]);
           // MessageBox.Show($"{updatedModel}");
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
                    autoCompleteCollection.Add(row["AccModelName"].ToString());
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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? \nyou want to ADD this record !! ", "ADD MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String Brand = BrandBox.Text, Model = ModelBox.Text;
                if (Brand != "" && Model != "")
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBAccess.strConnString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand("AddAccBrandAndModel", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                // Add parameters to the stored procedure
                                command.Parameters.AddWithValue("@AccBrandName", Brand);
                                command.Parameters.AddWithValue("@AccModelName", Model);
                                command.Parameters.AddWithValue("@AccModelBrandName", Brand);

                                // Execute the stored procedure
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int brandID = reader.GetInt32(reader.GetOrdinal("AccBrandID"));
                                        int modelID = reader.GetInt32(reader.GetOrdinal("AccModelID"));

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
                else
                {
                    MessageBox.Show("  Please Fill the above Feilds !!");
                }
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

                        using (SqlCommand command = new SqlCommand("DeleteAccBrandAndModel", connection))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;

                            // Add parameters to the stored procedure
                            command.Parameters.AddWithValue("@AccBrandID", updatedBrand); // Replace with the actual brandID
                            command.Parameters.AddWithValue("@AccModelID", updatedModel); // Replace with the actual modelID

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
