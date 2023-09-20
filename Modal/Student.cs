using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023091801_shammi.Modal
{
    public class Student
    {
        private int regNo;
        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private string gender;
        private string address;
        private string email;
        private int mobilePhone;
        private int homePhone;
        private string parentName;
        private string nic;
        private int contactNo;


        public Student() { 
        
        }

        // parameterlized constructor 
        public Student(int regNo, String firstName, String lastName, String dateOfBirth, String gender, String address, string email, int mobilePhone, int homePhone, string parentName, string nic, int contactNo)
        {
            this.regNo= regNo;
            this.firstName= firstName;
            this.lastName= lastName;
            this.dateOfBirth= dateOfBirth;
            this.gender=gender;
            this.address= address;
            this.email= email;
            this.mobilePhone= mobilePhone;
            this.homePhone= homePhone;
            this.parentName= parentName;
            this.nic= nic;
            this.contactNo= contactNo;
        }

        // Getter and setter for each field
        public void setRegNo(int regNo)
        {
            this.regNo = regNo;
        }

        public int getRegNo()
        {
            return regNo;
        }
        public void setFirstName(String firstName) { 
            this.firstName = firstName;
        }

        public String getFirstName()
        {
            return this.firstName;
        }
        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }
        public String getLastName()
        {
            return lastName;
        }
        public void setDateOfBirth(String dateOfBirth) 
        {
            this.dateOfBirth = dateOfBirth;
        }
        public String getDateOfBirth() 
        { 
            return dateOfBirth;
        }
       
        
        public void setGender(String gender)
        {
            this.gender = gender;
        }
        public String getGender()
        {
            return gender;
        }

        public void setAddress(String address)
        {
            this.address = address;
        }
        public String getAddress()
        {
            return address;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }
        public String getEmail()
        {
            return email;
        }

        public void setMobilePhone(int mobilePhone)
        {
            this.mobilePhone = mobilePhone;
        }
        public int getMobilePhone()
        {
            return mobilePhone;
        }

        public void setParentName(String parentName)
        {
            this.parentName = parentName;
        }
        public String getParentName()
        {
            return parentName;
        }


        public void setNic(String nic)
        {
            this.nic = nic;
        }
        public String getNic()
        {
            return nic;
        }

        public void setHomePhone(int homePhone)
        {
            this.homePhone = homePhone;
        }
        public int getHomePhone()
        {
            return homePhone;
        }

        public void setContactNo(int contactNo)
        {
            this.contactNo = contactNo;
        }
        public int getContactNo()
        {
            return contactNo;
        }

    }
}
