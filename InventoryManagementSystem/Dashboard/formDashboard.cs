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

namespace InventoryManagementSystem
{
    public partial class formDashboard : Form
    {
        public SqlConnection connection;
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
        }

        private void btnAllstocks_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnAllstocks.Height;
            sideBar.Top = btnAllstocks.Top;
        }

        private void btnMastercategories_Click(object sender, EventArgs e)
        {
            // Click Effect
            sideBar.Height = btnMastercategories.Height;
            sideBar.Top = btnMastercategories.Top;

            // Functions
            MainTabControl.SelectedIndex = 1;
        }

        private void btnMasterusers_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnMasterusers.Height;
            sideBar.Top = btnMasterusers.Top;
        }

        private void btnSellinghistory_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnSellinghistory.Height;
            sideBar.Top = btnSellinghistory.Top;
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
}

