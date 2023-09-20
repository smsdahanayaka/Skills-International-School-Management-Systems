using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2023091801_shammi.DBConnection;
using _2023091801_shammi.Modal;

namespace _2023091801_shammi.Control
{
    public class Controller
    {

        private static SqlConnection sqlConnection;
        private static int studentRegNumber;
        private static int[] studentRegNumArray=new int[0];

        
        // add user details to databse
        public static Boolean addUser(User user) {

            try {

                // connect with database
                sqlConnection = DBConection.getInstance().GetConnection();
                sqlConnection.Open();

                // add user details
                SqlCommand cmd = new SqlCommand("INSERT INTO logins VALUES(@UserName,@FirstName,@LastName,@Email,@Address,@MobileNumber,@Password)", sqlConnection);
                cmd.Parameters.AddWithValue("@UserName", user.getUserName());
                cmd.Parameters.AddWithValue("@FirstName", user.getFirstName());
                cmd.Parameters.AddWithValue("@LastName", user.getLastName());
                cmd.Parameters.AddWithValue("@Email", user.getEmail());
                cmd.Parameters.AddWithValue("@Address", user.getAddress());
                cmd.Parameters.AddWithValue("@MobileNumber", user.getMobileNumber());
                cmd.Parameters.AddWithValue("@Password", user.getPassword());
                int x=cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return x > 0;

            }
            catch (Exception ex) {
                MessageBox.Show("Error "+ex.Message,"Error");
            }   
            return false;
        }

        // check user and password in database
        public static Boolean checkLogin(String userName, String password) {
            try
            {
                sqlConnection= DBConection.getInstance().GetConnection(); 
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT *FROM logins WHERE userName=@user And password=@password", sqlConnection);
                cmd.Parameters.AddWithValue("@user",userName);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read()) {
                    sqlConnection.Close();
                    return true;
                }
                sqlConnection.Close();
                return false;
                
            }
            catch (Exception ex) {
                MessageBox.Show("Error "+ex.Message,"Eroor");
            
            }
            sqlConnection.Close();
            return false;
        }

        // search users 
        public static User searchUsers(String searchId)
        {
            User user=null;
            try {
                SqlConnection sqlConnection = DBConection.getInstance().GetConnection();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT *FROM logins WHERE userName='" + searchId + "'", sqlConnection);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    // Create user object
                    user=new User(dataReader["userName"].ToString(), dataReader["firstName"].ToString(), dataReader["lastName"].ToString(), dataReader["email"].ToString(), dataReader["address"].ToString(),int.Parse( dataReader["mobileNumber"].ToString()), dataReader["password"].ToString());
                    
                }
                dataReader.Close();
                sqlConnection.Close();
                return user;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error "+ex.Message,"Error");

            }
            return null;
        }

        // delete users

        public static Boolean deleteUsers(string userName )
        {
            try {

                SqlConnection sqlConnection = DBConection.getInstance().GetConnection();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM logins WHERE userName='" + userName + "'", sqlConnection);
                int x = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return x > 0;
            }
            catch (Exception ex) {
                MessageBox.Show("Error"+ex.Message,"Error");
            }
            sqlConnection.Close();
            return false;
        }


        // update users
        public static Boolean updateUsers(String userName,User user)
        {
            try { 
                
                SqlConnection sqlConnection= DBConection.getInstance().GetConnection(); 
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE logins SET firstName='"+user.getFirstName()+ "', lastName='"+user.getLastName()+ "', email='"+user.getEmail()+ "', address='"+user.getAddress()+ "', mobileNumber='"+user.getMobileNumber()+ "', password='"+user.getPassword()+"'", sqlConnection);
                int x=cmd.ExecuteNonQuery();
                sqlConnection.Close ();
                return x > 0;
                   
            }catch(Exception ex) {

                MessageBox.Show("Error "+ex.Message,"Error");
            }

            sqlConnection.Close();
            return false;
        }

        // get Last student registation number
        public static int getStudentId() {

            try
            {

                //connect data base
                SqlConnection sqlConnection = DBConection.getInstance().GetConnection();
                sqlConnection.Open();

                // get all rows
                SqlCommand cmd = new SqlCommand("SELECT * FROM Registration", sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // get student registation number
                    studentRegNumber = reader.GetInt32(0);
                    extendArray();

                    //set student registation number to array
                    studentRegNumArray[studentRegNumArray.Length - 1] = studentRegNumber;
                }

                sqlConnection.Close();
                // return last row registation number
                return studentRegNumber;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message, "Error");

            }
          
             sqlConnection.Close();
            return 10000;
        }

        //extend studentRegNumArray array
        private static void extendArray() {

            int[] tempStudentRegNumArray=new int[studentRegNumArray.Length+1];
            for (int i=0;i< studentRegNumArray.Length;i++) {
                tempStudentRegNumArray[i] = studentRegNumArray[i];
            }
            studentRegNumArray=tempStudentRegNumArray;
        }


        // return studentRegNumArray array

        public static int[] getStudentRegNumArray() { 
   
        return studentRegNumArray; 
        
        }

        // Add Student 

        public static Boolean addStudent(Student student)
        {
            try
            {
                String sql = "INSERT INTO Registration(firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contactNo) VALUES ('" + student.getFirstName() + "','" + student.getLastName() + "','" + student.getDateOfBirth() + "','" + student.getGender() + "','" + student.getAddress() + "','" + student.getEmail() + "'," + student.getMobilePhone() + "," + student.getHomePhone() + ",'" + student.getParentName() + "','" + student.getNic() + "','" + student.getContactNo() + "')";
                SqlConnection sqlConnection = DBConection.getInstance().GetConnection();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                int x = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return x > 0;

            }
            catch (SqlException ex)
            {
                //MessageBox.Show("Error "+ex.Message,"Error");
                foreach (SqlError error in ex.Errors)
                {
                    Console.WriteLine($"Error Number: {error.Number}, Message: {error.Message}");
                }
            }
            finally
            {
                sqlConnection.Close();
                
            }
            return false;
        }
    }

}
