using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class CADCategory
    {

        private string constring;

        public CADCategory() {
            constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        }


        public bool read(ENCategory en) {
            bool found = false;

            SqlConnection con = null;
            string ins = "SELECT name FROM Categories WHERE name=@category";

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.Parameters.AddWithValue("@category", en.Name);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read()) found = true;
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
            List<ENCategory> l = new List<ENCategory>();
            SqlConnection con = null;
            string ins = "SELECT DISTINCT name FROM Categories";

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read()) {
                    ENCategory a = new ENCategory();
                    a.Name = r["name"].ToString();
                    l.Add(a);
                }
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when trying to Read: " + ex.Message);
                return l;
            }
            finally
            {
                if (con != null) con.Close();
            }


            return l;
        }
    }
}
