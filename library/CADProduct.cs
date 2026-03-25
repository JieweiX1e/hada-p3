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
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.ExecuteNonQuery();
                created = true;
            }
            catch (SqlException ex) {
                Console.WriteLine("Error in when trying to execute Create: " + ex.Message);
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
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.ExecuteNonQuery();
                changed = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error in when trying to execute Update: " + ex.Message);
                return false;
            }
            finally {
                if (con != null) con.Close();
            }


            return changed;
        }

        public bool Delete(ENProduct en) { 
        
        }

        public bool Read(ENProduct en) { 
        
        
        }

        public bool ReadFirst(ENProduct en) { 
        
        }

        public bool ReadNext(ENProduct en) { 
        
        }

        public bool ReadPrev(ENProduct en) { 
        
        
        }


    }
}
