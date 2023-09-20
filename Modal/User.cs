using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023091801_shammi.Modal
{
    public class User
    {
        private string userName;
        private string firstName;
        private string lastName;
        private string email;
        private string address;
        private int mobileNumber;
        private string password;

        // Constructor
        public User() { 
        
        
        }

        // Constructor with parameters
        public User(string userName, string firstName, string lastName, string email, string address, int mobileNumber, string password)
        {
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.address = address;
            this.mobileNumber = mobileNumber;
            this.password = password;
        }

        // set getters
        public string getUserName()
        {
            return userName;
        }
        public string getFirstName()
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public string getEmail()
        {
            return email;
        }
        public string getAddress()
        {
            return address;
        }
        public int getMobileNumber()
        {
            return mobileNumber;
        }
        public string getPassword()
        {
            return password;
        }

        // set seters
        public void setUserName(String userName) {
            this.userName = userName;
        }

        public void setFirstNAme(String firstName)
        {
            this.firstName = firstName;
        }
        public void setLastNAme(String lastName)
        {
            this.lastName = lastName;
        }
        public void setEmail(String email)
        {
            this.email = email;
        }
        public void setAddress(String address)
        {
            this.address = address;
        }
        public void setMobileNumber(int mobileNumber) {
            
            this.mobileNumber = mobileNumber;
        }
        public void setPassword(String password)
        {
            this.password = password;
        }

    }
}
