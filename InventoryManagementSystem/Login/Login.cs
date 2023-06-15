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

namespace InventoryManagementSystem.Login
{
    public partial class Login : Form
    {
        public static string role = "";
        SqlConnection con = new SqlConnection(@"Data Source=JAWAD\SQLEXPRESS;Initial Catalog=inventoryDB;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                role = cmbRole.SelectedItem.ToString();
                if (role == "Admin")
                {
                    cm = new SqlCommand("EXEC GetAdminCredentials @Username, @Password;",con);
                    cm.Parameters.AddWithValue("@Username", txtusername.Text);
                    cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                    con.Open();
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        con.Close();
                        formDashboard db = new formDashboard(role);
                        this.Hide();
                        db.ShowDialog();
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("Invalid Username or Password..!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (role == "Cashier")
                {
                    cm = new SqlCommand("EXEC GetCashierCredentials @Username, @Password;", con);
                    cm.Parameters.AddWithValue("@Username", txtusername.Text);
                    cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                    con.Open();
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        con.Close();
                        formDashboard db = new formDashboard(role);
                        this.Hide();
                        db.ShowDialog();
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("Invalid Username or Password..!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (role == "Salesman")
                {
                    cm = new SqlCommand("EXEC GetSalesmanCredentials @Username, @Password;", con);
                    cm.Parameters.AddWithValue("@Username", txtusername.Text);
                    cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                    con.Open();
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        con.Close();
                        formDashboard db = new formDashboard(role);
                        this.Hide();
                        db.ShowDialog();
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("Invalid Username or Password..!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Valid Role..!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                try
                {
                    role = cmbRole.SelectedItem.ToString();
                    if (role == "Admin")
                    {
                        cm = new SqlCommand("EXEC GetAdminCredentials @Username, @Password;", con);
                        cm.Parameters.AddWithValue("@Username", txtusername.Text);
                        cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                        con.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            con.Close();
                            formDashboard db = new formDashboard(role);
                            this.Hide();
                            db.ShowDialog();
                        }
                        else
                        {
                            con.Close();
                            MessageBox.Show("Invalid Username or Password..!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (role == "Cashier")
                    {
                        cm = new SqlCommand("EXEC GetCashierCredentials @Username, @Password;", con);
                        cm.Parameters.AddWithValue("@Username", txtusername.Text);
                        cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                        con.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            con.Close();
                            formDashboard db = new formDashboard(role);
                            this.Hide();
                            db.ShowDialog();
                        }
                        else
                        {
                            con.Close();
                            MessageBox.Show("Invalid Username or Password..!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (role == "Salesman")
                    {
                        cm = new SqlCommand("EXEC GetSalesmanCredentials @Username, @Password;", con);
                        cm.Parameters.AddWithValue("@Username", txtusername.Text);
                        cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                        con.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            con.Close();
                            formDashboard db = new formDashboard(role);
                            this.Hide();
                            db.ShowDialog();
                        }
                        else
                        {
                            con.Close();
                            MessageBox.Show("Invalid Username or Password..!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Valid Role..!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
