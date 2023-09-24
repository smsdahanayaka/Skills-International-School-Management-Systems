using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2023091801_shammi.Control;
using _2023091801_shammi.Views;

namespace _2023091801_shammi
{
    public partial class LoginForm : Form
    {
        
        private String user;
        private String password;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get user and password from text feilds
            user=txtBoxUser.Text;
            password=txtBoxPassword.Text;

            // Check all feilds are filled or not
            if (user!="" && password!="") {

                // check default user and password
                if (user == "Admin" && password == "Skill@123")
                {
                    // show home page
                    new Form1().Show();
                    this.Hide();

                }
                else
                {
                    // check password and user name in database
                    if (Controller.checkLogin(user, password))
                    {
                        // show home page
                        new Form1().Show();
                        this.Hide();

                    }
                    else
                    {
                        // Display Alert 
                        MessageBox.Show("Invalid Login credentials, please check your Username and Password and try again", "Invalid Login Details");
                        
                        // Clear the textboxes 
                        txtBoxUser.Clear();
                        txtBoxPassword.Clear();

                    }

                }


            }
            else {
                MessageBox.Show("All feilds are requied ","Error");
            
            }


          
        }

        private void button3_Click(object sender, EventArgs e) //exit button
        {
            // display confirmation dialog
            DialogResult result=MessageBox.Show("Are you want to exit", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //check user choice
            if (result== DialogResult.Yes) {
                
                // user click 'yes ' , so close application
                Application.Exit();
            }

            
        }

        private void txtBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e) //clear button 
        {
            txtBoxUser.Clear();
            txtBoxPassword.Clear(); 
            
        }
    }
}
