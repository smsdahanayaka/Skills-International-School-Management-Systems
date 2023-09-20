using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2023091801_shammi.Control;
using _2023091801_shammi.DBConnection;
using _2023091801_shammi.Modal;

namespace _2023091801_shammi.Views
{
    public partial class AddUserFrom : Form
    {
        private SqlConnection sqlConnection;
        private String searchId;
        private User searchUser;
        public AddUserFrom()
        {
            InitializeComponent();
        }


        // Back to home page
        private void btnExit_Click(object sender, EventArgs e)
        {
            // back to home page 
            new Form1().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // add new users
        private  void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkFeilds())
            {
                try
                {

                    User user = new User(txtBoxUserName.Text, txtFirstName.Text, txtLastName.Text, txtBoxEmail.Text, textBoxAddress.Text, int.Parse(txtBoxMobileNumber.Text), textBoxPassword.Text);
                    Boolean bl = Controller.addUser(user);
                    if (bl)
                    {
                        MessageBox.Show("Added Successfull", "Success");
                        clearFeilds();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error");
                }
            }
            else {
                MessageBox.Show("All feilds are required", "Error");
            }
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddUserFrom_Load(object sender, EventArgs e)
        {

        }

        public Boolean checkFeilds() {
            
            return txtBoxUserName.Text=="" || txtFirstName.Text=="" || txtLastName.Text=="" || txtBoxEmail.Text=="" || textBoxAddress.Text=="" || txtBoxMobileNumber.Text=="" || textBoxPassword.Text=="" ? false : true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBoxUserName.Text != "")
            {
                searchId = txtBoxUserName.Text;
                searchUser = Controller.searchUsers(searchId);

                if (searchUser != null)
                {
                    txtFirstName.Text = searchUser.getFirstName();
                    txtLastName.Text = searchUser.getLastName();
                    txtBoxEmail.Text = searchUser.getEmail();
                    textBoxAddress.Text = searchUser.getAddress();
                    txtBoxMobileNumber.Text = searchUser.getMobileNumber() + "";
                    textBoxPassword.Text = searchUser.getPassword();
                }
                else
                {
                    MessageBox.Show("Can't find User", "Not find");
                }
            }
            else {

                MessageBox.Show("Please input User Name","Not Find");
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFeilds();
        }

        // all feilds clear
        private void clearFeilds() {

            txtBoxUserName.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtBoxEmail.Clear();
            textBoxAddress.Clear();
            txtBoxMobileNumber.Clear();
            textBoxPassword.Clear();
        }


        // delete user
        private void btnDelete_Click(object sender, EventArgs e)
        {

            try {

                if (searchUser != null)
                {
                    Boolean bl = Controller.deleteUsers(searchUser.getUserName());

                    if (bl)
                    {   
                        MessageBox.Show("Delete Successful", "DELETE");
                        clearFeilds();
                    }
                    else
                    {

                        MessageBox.Show("Not Delete Successful", "DELETE");
                    }
                }
                else
                {
                    MessageBox.Show("Can't Find User", "Not Find");
                    clearFeilds();
                }
            }
            catch(Exception ex)
            {

                MessageBox.Show("Error "+ex.Message, "Error");
            }


        }


        // update user
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                if (searchUser != null)
                {
                    User user = new User(txtBoxUserName.Text, txtFirstName.Text, txtLastName.Text, txtBoxEmail.Text, textBoxAddress.Text, int.Parse(txtBoxMobileNumber.Text), textBoxPassword.Text);
                    Boolean x =Controller.updateUsers(searchUser.getUserName(),user);

                    if (x)
                    {

                        MessageBox.Show("Successfully Updated", "UPDATE");
                        clearFeilds();
                    }
                    else {
                        MessageBox.Show("Update Not Completed", "UPDATE");
                    }

                }
                else
                {
                    MessageBox.Show("Cont Find User ", "Not Find");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error "+ex.Message, "Error");
            }
        }

        



    }
}
