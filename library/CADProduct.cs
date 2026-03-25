using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADProduct
    {
        private string constring;
        public CADProduct() {
            constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        }

        public bool Create(ENProduct en) {
            bool created = false;

            SqlConnection con = null;
            string ins = "INSERT INTO Products values(" +
                    en.Name + "," + en.Code + "," + en.Amount + "," + en.Price + "," + en.Category + ","
                    + en.CreationDate + ")";
            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.ExecuteNonQuery();
                created = true;
            }
            catch (SqlException ex) {
                Console.WriteLine("Error when trying to execute Create: " + ex.Message);
                return false;
            }

            return created; ;

        }

        public bool Update(ENProduct en) {
            bool changed = false;

            SqlConnection con = null;
            string ins = "UPDATE Products SET " 
               + "name = " + en.Name + ", "
               + "amount = " + en.Amount + ", "
               + "price = " + en.Price + ", "
               + "category = " + en.Category + ", "
               + "creationDate = " + en.CreationDate + ", "
                + "WHERE code = " + en.Code;

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.ExecuteNonQuery();
                changed = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when trying to execute Update: " + ex.Message);
                return false;
            }
            finally {
                if (con != null) con.Close();
            }


            return changed;
        }

        public bool Delete(ENProduct en) {
            bool deleted = false;

            SqlConnection con = null;
            string ins = "DELETE FROM Products "
                + "WHERE code = " + en.Code;

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.ExecuteNonQuery();
                deleted = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when trying to Delete: " + ex.Message);
                return false;
            }
            finally
            {
                if (con != null) con.Close();
            }


            return deleted;
        }

        public bool Read(ENProduct en) {
            bool found = false;

            SqlConnection con = null;
            string ins = "SELECT * FROM Products "
                + "WHERE code = " + "'" + en.Code + "'";

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read()) {

                    en.Name = r["name"].ToString();
                    en.Amount = Convert.ToInt32(r["amount"]);
                    en.Price = Convert.ToSingle(r["price"]);
                    en.Category = Convert.ToInt32(r["category"]);
                    en.CreationDate = Convert.ToDateTime(r["date"]);

                    found = true;
                
                }
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

        public bool ReadFirst(ENProduct en) { 
        
        }

        public bool ReadNext(ENProduct en) { 
        
        }

        public bool ReadPrev(ENProduct en) { 
        
        
        }


    }
}
