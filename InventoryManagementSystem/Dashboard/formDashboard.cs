﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class formDashboard : Form
    {

        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=JAWAD\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True");
        public formDashboard(string role)
        {
            InitializeComponent();
            lblRole.Text = role;
            if (role == "Cashier")
            {
                btnMasterusers.Enabled = false;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Click Effect
            sideBar.Height = btnDashboard.Height;
            sideBar.Top = btnDashboard.Top;
            // Functions
            MainTabControl.SelectedIndex = 0;
        }

        private void btnmakesales_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnmakesales.Height;
            sideBar.Top = btnmakesales.Top;

            // Functions
            MainTabControl.SelectedIndex = 5;
        }

        private void btnAllstocks_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnAllstocks.Height;
            sideBar.Top = btnAllstocks.Top;

            // Functions
            MainTabControl.SelectedIndex = 2;

        }

        private void btnMastercategories_Click(object sender, EventArgs e)
        {
            // Click Effect
            sideBar.Height = btnMastercategories.Height;
            sideBar.Top = btnMastercategories.Top;

            // Functions
            MainTabControl.SelectedIndex = 4;


        }

        private void btnMasterusers_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnMasterusers.Height;
            sideBar.Top = btnMasterusers.Top;

            // Functions
            MainTabControl.SelectedIndex = 1;
        }

        private void btnSellinghistory_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnSellinghistory.Height;
            sideBar.Top = btnSellinghistory.Top;

            // Functions
            MainTabControl.SelectedIndex = 3;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Login.Login login = new Login.Login();
            login.ShowDialog();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDBDataSet2.CartView' table. You can move, or remove it, as needed.
            this.cartViewTableAdapter.Fill(this.inventoryDBDataSet2.CartView);
            // TODO: This line of code loads data into the 'inventoryDBDataSet21.CartView' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'inventoryDBDataSet2.CartView' table. You can move, or remove it, as needed.
            PopulateComboBox();
            // TODO: This line of code loads data into the 'inventoryDBDataSet1.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.inventoryDBDataSet1.Products);
            // TODO: This line of code loads data into the 'inventoryDBDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.inventoryDBDataSet.Users);

        }

        private void UsersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = UsersDataGridView.Rows[e.RowIndex];

                    // Retrieve the data from the selected row
                    int userId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    string userName = selectedRow.Cells[1].Value.ToString();
                    string firstName = selectedRow.Cells[2].Value.ToString();
                    string lastName = selectedRow.Cells[3].Value.ToString();
                    string password = selectedRow.Cells[4].Value.ToString();
                    string email = selectedRow.Cells[5].Value.ToString();
                    DateTime birthdate = Convert.ToDateTime(selectedRow.Cells[6].Value);
                    int age = Convert.ToInt32(selectedRow.Cells[7].Value);
                    string gender = selectedRow.Cells[8].Value.ToString();
                    string role = selectedRow.Cells[9].Value.ToString();
                    long salary = Convert.ToInt64(selectedRow.Cells[10].Value);
                    DateTime joinDate = Convert.ToDateTime(selectedRow.Cells[11].Value);
                    string nid = selectedRow.Cells[12].Value.ToString();
                    long phone = Convert.ToInt64(selectedRow.Cells[13].Value);
                    string address = selectedRow.Cells[14].Value.ToString();
                    string currentCity = selectedRow.Cells[15].Value.ToString();
                    string bloodGroup = selectedRow.Cells[16].Value.ToString();

                    // Populate the respective input fields with the retrieved data
                    txtUserId.Text = userId.ToString();
                    txtUsername.Text = userName;
                    txtFirstName.Text = firstName;
                    txtLastName.Text = lastName;
                    txtPassword.Text = password;
                    txtEmail.Text = email;
                    dtpBirthDate.Value = birthdate;
                    txtAge.Text = age.ToString();
                    cmbGender.SelectedItem = gender;
                    cmbRole.SelectedItem = role;
                    txtSalary.Text = salary.ToString();
                    dtpJoinDate.Value = joinDate;
                    txtNID.Text = nid;
                    txtPhone.Text = phone.ToString();
                    txtAddress.Text = address;
                    txtCurrentCity.Text = currentCity;
                    cmbBloodGroup.SelectedItem = bloodGroup;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserId.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(dtpBirthDate.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(cmbGender.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text) ||
                string.IsNullOrWhiteSpace(txtSalary.Text) ||
                string.IsNullOrWhiteSpace(dtpJoinDate.Text) ||
                string.IsNullOrWhiteSpace(txtNID.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCurrentCity.Text) ||
                string.IsNullOrWhiteSpace(cmbBloodGroup.Text))
                {
                    MessageBox.Show("Please Input Missing Fields");
                    return;
                }
                try
                {
                    using (SqlCommand command = new SqlCommand("UpdateUser", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                        command.Parameters.AddWithValue("@UserName", txtUsername.Text);
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Birthdate", dtpBirthDate.Value.Date);
                        command.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
                        command.Parameters.AddWithValue("@Gender", cmbGender.Text);
                        command.Parameters.AddWithValue("@Role", cmbRole.Text);
                        command.Parameters.AddWithValue("@Salary", Convert.ToInt64(txtSalary.Text));
                        command.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value.Date);
                        command.Parameters.AddWithValue("@NID", txtNID.Text);
                        command.Parameters.AddWithValue("@Phone", Convert.ToInt64(txtPhone.Text));
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@CurrentCity", txtCurrentCity.Text);
                        command.Parameters.AddWithValue("@BloodGroup", cmbBloodGroup.Text);

                        // Open the connection
                        con.Open();

                        // Execute the stored procedure
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data updated successfully");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    con.Close();
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(dtpBirthDate.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(cmbGender.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text) ||
                string.IsNullOrWhiteSpace(txtSalary.Text) ||
                string.IsNullOrWhiteSpace(dtpJoinDate.Text) ||
                string.IsNullOrWhiteSpace(txtNID.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCurrentCity.Text) ||
                string.IsNullOrWhiteSpace(cmbBloodGroup.Text))
                {
                    MessageBox.Show("Please Input Missing Fields");
                    return;
                }

                // Save data to the database
                try
                {
                    using (SqlCommand command = new SqlCommand("InsertUser", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@UserId", txtUserId.Text);
                        command.Parameters.AddWithValue("@UserName", txtUsername.Text);
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Birthdate", dtpBirthDate.Value.Date);
                        command.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
                        command.Parameters.AddWithValue("@Gender", cmbGender.Text);
                        command.Parameters.AddWithValue("@Role", cmbRole.Text);
                        command.Parameters.AddWithValue("@Salary", Convert.ToInt64(txtSalary.Text));
                        command.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value.Date);
                        command.Parameters.AddWithValue("@NID", txtNID.Text);
                        command.Parameters.AddWithValue("@Phone", Convert.ToInt64(txtPhone.Text));
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@CurrentCity", txtCurrentCity.Text);
                        command.Parameters.AddWithValue("@BloodGroup", cmbBloodGroup.Text);

                        // Open the connection
                        con.Open();

                        // Execute the stored procedure
                        command.ExecuteNonQuery();

                        MessageBox.Show("Data saved successfully");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    con.Close();
                }
            }
        }

        private void btnRefreshUser_Click_1(object sender, EventArgs e)
        {
            // Initialize data adapter and data table
            dataAdapter = new SqlDataAdapter("SELECT * FROM Users", con);
            dataTable = new DataTable();
            // Fill the data table with data from the database
            dataAdapter.Fill(dataTable);
            // Bind the data table to the data grid view
            UsersDataGridView.DataSource = dataTable;
            try
            {
                // Clear the data table
                dataTable.Clear();
                // Fill the data table with updated data from the database
                dataAdapter.Fill(dataTable);
                // Notify the data grid view that the data has changed
                UsersDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while refreshing data: " + ex.Message);
            }
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtUsername.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            dtpBirthDate.Value = DateTime.Now; // Set to default value or clear it based on your requirement
            txtAge.Text = "";
            cmbGender.SelectedIndex = -1; // Clear the selected gender
            cmbRole.SelectedIndex = -1; // Clear the selected role
            txtSalary.Text = "";
            dtpJoinDate.Value = DateTime.Now; // Set to default value or clear it based on your requirement
            txtNID.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCurrentCity.Text = "";
            cmbBloodGroup.SelectedIndex = -1; // Clear the selected blood group
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (UsersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = UsersDataGridView.SelectedRows[0];

            // Get the UserId (primary key) value from the selected row
            int userId = Convert.ToInt32(selectedRow.Cells[0].Value);
            string Fname = selectedRow.Cells[3].Value.ToString();
            string Lname = selectedRow.Cells[4].Value.ToString();

            // Execute the delete query or stored procedure to remove the row from the database
            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Users WHERE UserId = @UserId", con))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    // Open the connection
                    con.Open();

                    // Execute the query
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data deleted successfully");

                    // Remove the selected row from the DataGridView
                    UsersDataGridView.Rows.Remove(selectedRow);
                    MessageBox.Show(Fname + " " + Lname + " - Delete Succeeded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Get the search keyword from the text box
            string keyword = txtSearch.Text.Trim();
            try
            {
                // Create the SQL query based on the search keyword
                string query = "SELECT * FROM Users WHERE FirstName LIKE @Keyword OR LastName LIKE @Keyword OR CurrentCity LIKE @Keyword OR Gender LIKE @Keyword OR Role LIKE @Keyword OR BloodGroup LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Add the search keyword parameter to the command
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    // Create a DataTable to store the search results
                    DataTable dataTable = new DataTable();

                    // Create a SqlDataAdapter to fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Open the connection
                        con.Open();

                        // Fill the DataTable with the search results
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataTable to the DataGridView
                    UsersDataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }

        
        private void PopulateComboBox()
        {
            try
            {
                    // Open the database connection
                    con.Open();

                    // Create a query to retrieve data from the Brands table
                    string query = "SELECT BrandName FROM Brands";

                    // Create a SqlCommand object
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        // Create a SqlDataReader object to read the data
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Clear existing items from the ComboBox
                            cmbBrand.Items.Clear();

                            // Loop through the data and add each item to the ComboBox
                            while (reader.Read())
                            {
                                // Retrieve the value from the "BrandName" field
                                string brandName = reader.GetString(0);

                                // Add the value to the ComboBox
                                cmbBrand.Items.Add(brandName);
                            }
                            con.Close();
                            reader.Close();
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(cmbBrand.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPerUnitPrice.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text) ||
                string.IsNullOrWhiteSpace(txtWeight.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please Input Missing Fields");
                    return;
                }
                try
                {

                    // Retrieve the BrandId from the database based on the selected brand name
                    string brandId = "";
                    con.Open();

                    // Execute a query to retrieve the BrandId based on the BrandName
                    string query = "SELECT BrandId FROM Brands WHERE BrandName = '" + cmbBrand.SelectedItem.ToString() + "'";
                    SqlCommand command = new SqlCommand(query, con);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        brandId = Convert.ToString(reader["BrandId"]);
                    }
                    con.Close();
                    reader.Close();

                    string query1 = "exec UpdateProduct '" + Convert.ToInt32(txtProductId.Text) + "','" + txtProductName.Text + "','" + Convert.ToInt32(brandId) + "','" + Convert.ToInt32(txtQuantity.Text) + "','" + Convert.ToInt32(txtPerUnitPrice.Text) + "','" + cmbStatus.Text + "','" + Convert.ToInt32(txtWeight.Text) + "','" + txtDescription.Text + "'";
                    // Open the connection
                    con.Open();
                    command = new SqlCommand(query1, con);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data updated successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    con.Close();
                }

            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(cmbBrand.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPerUnitPrice.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text) ||
                string.IsNullOrWhiteSpace(txtWeight.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please Input Missing Fields");
                    return;
                }


                // Retrieve the BrandId from the database based on the selected brand name
                string brandId="";
                con.Open();

                // Execute a query to retrieve the BrandId based on the BrandName
                string query = "SELECT * FROM Brands WHERE BrandName = '"+ cmbBrand.SelectedItem.ToString() + "'";
                SqlCommand command = new SqlCommand(query, con);
              

                    SqlDataReader reader;
                    reader = command.ExecuteReader();


                    if (reader.Read())
                    {
                        brandId = Convert.ToString(reader["BrandId"]);
                    }
                    con.Close();
                    reader.Close();
                

                // Save data to the database
                try
                {
                    con.Open();
                string query2 = "exec InsertProduct '" + txtProductName.Text + "','" + brandId + "','" + Convert.ToInt32(txtQuantity.Text) + "','" + Convert.ToInt32(txtPerUnitPrice.Text) + "','" + cmbStatus.Text + "','" + Convert.ToInt32(txtWeight.Text) + "','" + txtDescription.Text + "'";
                    command = new SqlCommand(query2, con);
                    command.ExecuteNonQuery();
                  
                    MessageBox.Show("Data saved successfully");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
                
            
        }
    }

        private void ProductsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ProductsDataGridView.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = ProductsDataGridView.Rows[e.RowIndex];

                    // Extract the data from the row
                    int productId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    string productName = Convert.ToString(selectedRow.Cells[1].Value);
                    int brandId = Convert.ToInt32(selectedRow.Cells[2].Value);
                    int productQuantity = Convert.ToInt32(selectedRow.Cells[3].Value);
                    int productUnitPrice = Convert.ToInt32(selectedRow.Cells[4].Value);
                    string productStatus = Convert.ToString(selectedRow.Cells[5].Value);
                    int productWeight = Convert.ToInt32(selectedRow.Cells[6].Value);
                    string productDescription = Convert.ToString(selectedRow.Cells[7].Value);
                    // Fetch the brand name based on the BrandId from the Brands table
                    try
                    {
                        // Create the SQL query
                        con.Open();
                        string query = "SELECT * FROM Brands WHERE BrandId ='"+brandId+"'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            cmbBrand.SelectedItem = Convert.ToString(read["BrandName"]);
                        }
                        con.Close();
                        read.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred while fetching brand name: " + ex.Message);
                    }




                    // Populate the input fields
                    txtProductId.Text = productId.ToString();
                    txtProductName.Text = productName;
                    cmbBrand.SelectedValue = brandId; // Assuming you have set up the ComboBox data source with BrandId and BrandName
                    txtQuantity.Text = productQuantity.ToString();
                    txtPerUnitPrice.Text = productUnitPrice.ToString();
                    cmbStatus.SelectedItem = productStatus;
                    txtQuantity.Text = productQuantity.ToString();
                    txtWeight.Text = productWeight.ToString();
                    txtDescription.Text = productDescription;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefreshProducts_Click(object sender, EventArgs e)
        {
            // Initialize data adapter and data table
            dataAdapter = new SqlDataAdapter("SELECT * FROM Products", con);
            dataTable = new DataTable();
            // Fill the data table with data from the database
            dataAdapter.Fill(dataTable);
            // Bind the data table to the data grid view
            ProductsDataGridView.DataSource = dataTable;
            try
            {
                // Clear the data table
                dataTable.Clear();
                // Fill the data table with updated data from the database
                dataAdapter.Fill(dataTable);
                // Notify the data grid view that the data has changed
                ProductsDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while refreshing data: " + ex.Message);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (ProductsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = ProductsDataGridView.SelectedRows[0];

            // Get the UserId (primary key) value from the selected row
            int ProductId = Convert.ToInt32(selectedRow.Cells[0].Value);
            string ProductName = Convert.ToString(selectedRow.Cells[1].Value);

            // Execute the delete query or stored procedure to remove the row from the database
            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ProductId = @ProductId", con))
                {
                    command.Parameters.AddWithValue("@ProductId", ProductId);

                    // Open the connection
                    con.Open();

                    // Execute the query
                    command.ExecuteNonQuery();


                    // Remove the selected row from the DataGridView
                    ProductsDataGridView.Rows.Remove(selectedRow);
                    MessageBox.Show( ProductName + " - Delete Succeeded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }

        private void btnCancelProduct_Click(object sender, EventArgs e)
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            cmbBrand.SelectedValue = -1;
            txtPerUnitPrice.Text = "";
            cmbStatus.SelectedItem = -1;
            txtWeight.Text = "";
            txtDescription.Text = "";
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Get the search keyword from the text box
            string keyword = guna2TextBox1.Text.Trim();
            try
            {
                // Create the SQL query based on the search keyword
                string query = "SELECT * FROM Products WHERE ProductName LIKE @Keyword OR  ProductStatus LIKE @Keyword OR ProductDescription LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Add the search keyword parameter to the command
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    // Create a DataTable to store the search results
                    DataTable dataTable = new DataTable();

                    // Create a SqlDataAdapter to fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Open the connection
                        con.Open();

                        // Fill the DataTable with the search results
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataTable to the DataGridView
                    ProductsDataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }

        private void CartDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CartDataGridView.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = CartDataGridView.Rows[e.RowIndex];

                    // Extract the data from the row
                    int productId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    string productName = Convert.ToString(selectedRow.Cells[1].Value);
                    int brandId = Convert.ToInt32(selectedRow.Cells[3].Value);
                    int productUnitPrice = Convert.ToInt32(selectedRow.Cells[2].Value);
                    string productStatus = Convert.ToString(selectedRow.Cells[4].Value);
                    // Fetch the brand name based on the BrandId from the Brands table
                    try
                    {
                        // Create the SQL query
                        con.Open();
                        string query = "SELECT * FROM Brands WHERE BrandId ='" + brandId + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            txtBrandName.Text = Convert.ToString(read["BrandName"]);
                        }
                        con.Close();
                        read.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred while fetching brand name: " + ex.Message);
                    }




                    // Populate the input fields
                    txt_ProductId.Text = productId.ToString();
                    txt_ProductName.Text = productName;
                    txtPrice.Text = productUnitPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFillData_Click(object sender, EventArgs e)
        {
            int productid = int.Parse(txt_ProductId.Text);
            string brandid = ""; 
            try
            {
                // Create the SQL query
                con.Open();
                string query = "SELECT * FROM Products WHERE ProductId ='" + productid + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    txt_ProductName.Text = Convert.ToString(read["ProductName"]);
                    txtPrice.Text = Convert.ToString(read["ProductUnitPrice"]);
                    brandid = Convert.ToString(read["BrandId"]);
                    
                }
                con.Close();
                read.Close();

                // Create the SQL query
                con.Open();
                string query1 = "SELECT * FROM Brands WHERE BrandId ='" + int.Parse(brandid) + "'";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataReader read1 = cmd1.ExecuteReader();
                if (read1.Read())
                {
                    txtBrandName.Text = Convert.ToString(read1["BrandName"]);
                }
                con.Close();
                read1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while fetching Data: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_ProductId.Text = "";
            txt_ProductName.Text = "";
            txtBrandName.Text = "";
            txtPrice.Text = "";
            txt_Quantity.Text = "";
            cmbSellBy.SelectedIndex = 0;
            txtCustomerName.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerAddress.Text = "";
            cmbPaymentMethod.SelectedIndex= 0;
            txtCustomerPhone.Text = "";
            dtpPayDate.Value =DateTime.Now;
            txtTotalAmount.Text = "";
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            // Initialize data adapter and data table
            dataAdapter = new SqlDataAdapter("SELECT * FROM CartView", con);
            dataTable = new DataTable();
            // Fill the data table with data from the database
            dataAdapter.Fill(dataTable);
            // Bind the data table to the data grid view
            CartDataGridView.DataSource = dataTable;
            try
            {
                // Clear the data table
                dataTable.Clear();
                // Fill the data table with updated data from the database
                dataAdapter.Fill(dataTable);
                // Notify the data grid view that the data has changed
                CartDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while refreshing data: " + ex.Message);
            }
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            //double price = Convert.ToDouble(txtPrice.Text);
            //double quantity = Convert.ToDouble(txt_Quantity);
            //double totalAmount = price * quantity;
            //txtTotalAmount.Text = Convert.ToString(totalAmount);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Quantity.Text))
            {
                double price = Convert.ToDouble(txtPrice.Text);
                double quantity = Convert.ToDouble(txt_Quantity.Text);
                double totalAmount = price * quantity;
                txtTotalAmount.Text = Convert.ToString(totalAmount);
            }
        }

        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txt_Quantity.Text))
                    {
                        double price = Convert.ToDouble(txtPrice.Text);
                        double quantity = Convert.ToDouble(txt_Quantity.Text);
                        double totalAmount = price * quantity;
                        txtTotalAmount.Text = Convert.ToString(totalAmount);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPlaceOrderToSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ProductName.Text) ||
                string.IsNullOrWhiteSpace(txt_Quantity.Text) ||
                string.IsNullOrWhiteSpace(cmbSellBy.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerPhone.Text) ||
                string.IsNullOrWhiteSpace(dtpPayDate.Text) ||
                string.IsNullOrWhiteSpace(txtTotalAmount.Text))
            {
                MessageBox.Show("Please Input Missing Fields");
                return;
            }
            else
            {
                string userid = "";


                try
                {
                    con.Open();
                    string query = "SELECT * FROM Users WHERE Role ='" + cmbRole.Text.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        userid = Convert.ToString(read["UserId"]);
                    }
                    read.Close();
                    MessageBox.Show("User id " + userid + " is this");
                    SqlCommand command = new SqlCommand("InsertOrder", con);
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@OrderDate", dtpPayDate.Value.Date);
                    command.Parameters.AddWithValue("@OrderQuantity", int.Parse(txt_Quantity.Text));
                    command.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text);
                    command.Parameters.AddWithValue("@TotalAmount", int.Parse(txtTotalAmount.Text));
                    command.Parameters.AddWithValue("@CustomerFullName", txtCustomerName.Text);
                    command.Parameters.AddWithValue("@CustomerPhone", int.Parse(txtCustomerPhone.Text));
                    command.Parameters.AddWithValue("@CustomerEmail", txtCustomerEmail.Text);
                    command.Parameters.AddWithValue("@CustomerAddress", txtCustomerAddress.Text);
                    command.Parameters.AddWithValue("@UserId", int.Parse(userid));
                    command.Parameters.AddWithValue("@ProductId", int.Parse(txt_ProductId.Text));

                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                    con.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}


