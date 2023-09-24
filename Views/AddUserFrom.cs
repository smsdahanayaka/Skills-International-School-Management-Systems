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
                        MessageBox.Show("Added User Successfull", "Add User");
                        clearFeilds();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error");
                }
            }
            else {
                MessageBox.Show("All feilds are required", "Add User");
            }
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddUserFrom_Load(object sender, EventArgs e)
        {

        }


        // check input feilds
        public Boolean checkFeilds() {
            
            return txtBoxUserName.Text=="" || txtFirstName.Text=="" || txtLastName.Text=="" || txtBoxEmail.Text=="" || textBoxAddress.Text=="" || txtBoxMobileNumber.Text=="" || textBoxPassword.Text=="" ? false : true;

        }


        // Back to home page
        private void btnExit_Click(object sender, EventArgs e)
        {
            // back to home page 
            new Form1().Show();
            this.Hide();
        }

        // serch button action
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
                    MessageBox.Show("Can't find User", "Search User");
                }
            }
            else {

                MessageBox.Show("Please input User Name", "Search User");
            }
            
        }
        // btn clear
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

            // display confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure, Do you want to delete this record...?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //check user choice
            if (result == DialogResult.Yes)
            {

                try
                {

                    if (searchUser != null)
                    {
                        Boolean bl = Controller.deleteUsers(searchUser.getUserName());

                        if (bl)
                        {
                            MessageBox.Show("Record Delete Successful", "Delete User");
                            clearFeilds();
                        }
                        else
                        {

                            MessageBox.Show("Not Deleted", "Delete User");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't Find User", "Delete User");
                        clearFeilds();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error " + ex.Message, "Error");
                }
;
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

                        MessageBox.Show("Successfully Updated", "Update User");
                        clearFeilds();
                    }
                    else {
                        MessageBox.Show("Update Not Completed", "Update User");
                    }

                }
                else
                {
                    MessageBox.Show("Con't Find User ", "Update User");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error "+ex.Message, "Error");
            }
        }

        



    }
}
