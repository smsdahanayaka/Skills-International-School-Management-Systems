
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2023091801_shammi.DBConnection
{
    public class DBConection
    {
        private static DBConection dbConection;
        private SqlConnection sqlConection;
        
        public DBConection()
        {
            try
            {
                //sql connection
                sqlConection = new SqlConnection("Data Source=SMS-DAHANAYAKA\\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True;Pooling=False");
                Console.WriteLine("Connect SQL");

            }catch (Exception ex)
            {   
                // if not connect sql get error message
                MessageBox.Show("Error :"+ex.Message,"error");
            }
        }

        public SqlConnection GetConnection()
        {   
            // return sql connection
            return sqlConection;
        }
        public static DBConection getInstance(){

            // create bdConnection class object
            if (dbConection==null) { 
                dbConection = new DBConection();
            }
            return dbConection;
        }

    }
}
