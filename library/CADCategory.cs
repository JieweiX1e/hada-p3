using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADCategory
    {

        private string constring;

        public CADCategory() {
            constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        }


        public bool read(ENCategory en) {
            bool found = false;

            SqlConnection con = null;
            string ins = "SELECT category FROM Products "
                + "WHERE category = " + en.Category;

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.ExecuteNonQuery();
                found = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when trying to Read: " + ex.Message);
                return false;
            }
            finally
            {
                if (con != null) con.Close();
            }


            return found;
        }

        public List<ENCategory> readAll() {
        
               
        }
    }
}
