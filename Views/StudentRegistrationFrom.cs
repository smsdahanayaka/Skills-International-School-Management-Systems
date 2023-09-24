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
        private String searchId;
        private string dateString;
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

        // logout button

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // display confirmation dialog
            DialogResult result = MessageBox.Show("Are you want to Logout", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //check user choice
            if (result == DialogResult.Yes)
            {

                // logout 
                new LoginForm().Show();
                this.Hide();
            }



            
        }

        //exit button

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // display confirmation dialog
            DialogResult result = MessageBox.Show("Are you want to exit", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //check user choice
            if (result == DialogResult.Yes)
            {

                // user click 'yes ' , so close application
                Application.Exit();
            }
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

                    MessageBox.Show("All Feilds Are Required","Required...");
                }
                else {
                    Student student = new Student(10, txtFirstName.Text, txtLastName.Text, birthDateTimePicker1.Text, txtGender, txtAddress.Text, txtBoxEmail.Text, int.Parse(txtBoxMobileNumber.Text), int.Parse(txtBoxHomeNumber.Text), txtParentName.Text, txtNIC.Text, int.Parse(txtContactNumber.Text));
                    Boolean bl = Controller.addStudent(student);

                    if (bl)
                    {
                        MessageBox.Show("Record Added Successfully", "Register Student");
                        new StudentRegistrationFrom().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Not Added", "Register Student");
                    }

                }

              
            }catch (Exception ex)
            {
                MessageBox.Show("Error "+ex.Message,"Error");
            }

        }


        // student search button action
        private void regNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {

                // display search result
                if (regNumComboBox.Text != "")
                {
                    searchId = regNumComboBox.Text;
                    Student student = Controller.searchStudent(searchId);

                    if (student!=null) {
                        txtFirstName.Text = student.getFirstName()+"";
                        txtLastName.Text = student.getLastName();
                        dateString = student.getDateOfBirth();

                        birthDateTimePicker1.Value = DateTime.Parse(dateString);//get string date ada set to dateTime(type)
                      
                        if (student.getGender() == "Male") // set gender
                        {
                            btnMale.Checked = true;
                            btnFemale.Checked = false;
                        }
                        else {
                            btnFemale.Checked = true;
                            btnMale.Checked = false;
                        }
                        txtBoxEmail.Text = student.getEmail();
                        txtBoxMobileNumber.Text = student.getMobilePhone()+"";
                        txtBoxHomeNumber.Text = student.getHomePhone()+"";
                        txtAddress.Text = student.getAddress();
                        txtParentName.Text = student.getParentName();
                        txtNIC.Text = student.getNic();
                        txtContactNumber.Text = student.getContactNo()+"";
                    }
                    else {
                        MessageBox.Show("Can't Find Student","Student Search");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error "+ex.Message,"Error");
            }
           
           
            
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
            regNumComboBox.Text = "";
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

        // get gender of student -female
        private void btnFemale_CheckedChanged(object sender, EventArgs e)
        {
            txtGender = "female";
        }

        private void birthDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        // get gender of student - male
        private void btnMale_CheckedChanged(object sender, EventArgs e)
        {
            txtGender = "male";
        }


        // delete button event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // display confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure, Do you want to delete this Recode..?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //check user choice
            if (result == DialogResult.Yes)
            {

                // user click 'yes ' , so delete student
                try
                {
                    if (searchId != "")
                    {
                        Boolean bl = Controller.deleteStudent(searchId);
                        if (bl)
                        {
                            MessageBox.Show("Record Delete Succesfully", "Delete Student");
                            new StudentRegistrationFrom().Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Not Deleted", "Delete Student");

                        }

                    }
                    else
                    {
                        MessageBox.Show("please Select Student", "Delete Student");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message, "Error");

                }
            }

            
        }

        // update button event
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                if (searchId!="") {
                    Student student = new Student(0000, txtFirstName.Text, txtLastName.Text, birthDateTimePicker1.Text, txtGender, txtAddress.Text, txtBoxEmail.Text, int.Parse(txtBoxMobileNumber.Text), int.Parse(txtBoxHomeNumber.Text), txtParentName.Text, txtNIC.Text, int.Parse(txtContactNumber.Text));
                    Boolean bl=Controller.updateStudent(searchId,student);

                    if (bl)
                    {
                        MessageBox.Show("Successfully Updated", "UPDATE");
                        new StudentRegistrationFrom().Show();
                        this.Hide();
                    }
                    else {
                        MessageBox.Show("Not Updated","UPDATE");
                    }
                }
                else {

                    MessageBox.Show("Select Student","Not Selected");
                }

            }
            catch (Exception ex) {

                MessageBox.Show("Error "+ex.Message,"Error");
            }
        }
    }
}
