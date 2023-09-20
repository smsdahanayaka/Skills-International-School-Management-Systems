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
using _2023091801_shammi.Modal;

namespace _2023091801_shammi.Views
{
    public partial class StudentRegistrationFrom : Form
    {
        private int currentStudentId;
        private int[] studentRegNumArray;
        private String txtGender;
        public StudentRegistrationFrom()
        {

            InitializeComponent();

            
            currentStudentId = Controller.getStudentId();// get last reqistation number and set new one

            if (currentStudentId == 0)
            {
                currentStudentId = 1000;
            }
            else {
                currentStudentId += 1;
                
            }

            lblReg.Text = "Student Registation No : " + currentStudentId; //set to screen student registare number

            studentRegNumArray = Controller.getStudentRegNumArray(); // get student registation numbers from database

            for(int i=0;i< studentRegNumArray.Length;i++) {
                regNumComboBox.Items.Insert(i, studentRegNumArray[i]); // set student registation numbers to combo box
            }

            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // back to home page 
            new Form1().Show();
            this.Hide();    
        }

        private void StudentRegistrationFrom_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // logout 
            new LoginForm().Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // exit in the system

            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }


        // student add button action
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtFirstName.Text == "" || txtLastName.Text == "" || birthDateTimePicker1.Text == "" || txtGender == "" || txtAddress.Text == "" || txtBoxEmail.Text =="" || txtBoxMobileNumber.Text =="" || txtBoxHomeNumber.Text =="" || txtParentName.Text =="" || txtNIC.Text=="" || txtContactNumber.Text=="" ) {

                    MessageBox.Show("All Feilds Are Required","Required");
                }
                else {
                    Student student = new Student(10, txtFirstName.Text, txtLastName.Text, birthDateTimePicker1.Text, txtGender, txtAddress.Text, txtBoxEmail.Text, int.Parse(txtBoxMobileNumber.Text), int.Parse(txtBoxHomeNumber.Text), txtParentName.Text, txtNIC.Text, int.Parse(txtContactNumber.Text));
                    Boolean bl = Controller.addStudent(student);

                    if (bl)
                    {
                        MessageBox.Show("Successfully Added", "Success");
                        clearFeilds();
                    }
                    else
                    {
                        MessageBox.Show("Not Added", "Error");
                    }

                }

              
            }catch (Exception ex)
            {
                MessageBox.Show("Error "+ex.Message,"Error");
            }

        }

        private void regNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clearFeilds();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        // clear input feilds
        private void clearFeilds()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            birthDateTimePicker1.Text = "";
            btnMale.Text = "";
            btnFemale.Text = "";
            txtBoxEmail.Text = "";
            txtBoxMobileNumber.Text = "";
            txtBoxHomeNumber.Text = "";
            txtAddress.Text = "";
            txtParentName.Text = "";
            txtNIC.Text = "";
            txtContactNumber.Text = "";

            

        }

        private void btnFemale_CheckedChanged(object sender, EventArgs e)
        {
            txtGender = "female";
        }

        private void birthDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnMale_CheckedChanged(object sender, EventArgs e)
        {
            txtGender = "male";
        }
    }
}
