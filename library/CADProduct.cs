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

            // mirar si existe en la base de datos
            if (Read(en)) {
                Console.WriteLine("The product already exists in the database.");
                return false;
            }


            SqlConnection con = null;
            string ins = "INSERT INTO Products (code, name, amount, price, category, creationDate) VALUES (@code, @name, @amount, @price, @category, @date)";


            try
            {
                con = new SqlConnection(constring);
                con.Open();

                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.Parameters.AddWithValue("@code", en.Code);
                cmd.Parameters.AddWithValue("@name", en.Name);
                cmd.Parameters.AddWithValue("@amount", en.Amount);
                cmd.Parameters.AddWithValue("@price", en.Price);
                cmd.Parameters.AddWithValue("@category", en.Category);
                cmd.Parameters.AddWithValue("@date", en.CreationDate);

                cmd.ExecuteNonQuery();
                created = true;
            }
            catch (SqlException ex) {
                Console.WriteLine("Error when trying to execute Create: " + ex.Message);
                return false;
            }
            finally
            {
                if (con != null) con.Close();
            }

            return created; ;

        }

        public bool Update(ENProduct en) {
            bool changed = false;

            SqlConnection con = null;
            string ins = "UPDATE Products SET name=@name, amount=@amount, price=@price, category=@category, creationDate=@creationDate WHERE code=@code";

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.Parameters.AddWithValue("@code", en.Code);
                cmd.Parameters.AddWithValue("@name", en.Name);
                cmd.Parameters.AddWithValue("@amount", en.Amount);
                cmd.Parameters.AddWithValue("@price", en.Price);
                cmd.Parameters.AddWithValue("@category", en.Category);
                cmd.Parameters.AddWithValue("@date", en.CreationDate);

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
            string ins = "DELETE FROM Products WHERE code = @code";

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.Parameters.AddWithValue("@code", en.Code);
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
            string ins = "SELECT * FROM Products WHERE code = @code";

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    en.Code = r["code"].ToString();
                    en.Name = r["name"].ToString();
                    en.Amount = Convert.ToInt16(r["amount"]);
                    en.Price = Convert.ToSingle(r["price"]);
                    en.Category = Convert.ToInt16(r["category"]);
                    en.CreationDate = Convert.ToDateTime(r["creationDate"]);

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
            bool found = false;

            SqlConnection con = null;
            string ins = "SELECT TOP 1 * FROM Products";

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read()) { 
                    en.Code = r["code"].ToString();
                    en.Name = r["name"].ToString();
                    en.Amount = Convert.ToInt16(r["amount"]);
                    en.Price = Convert.ToSingle(r["price"]);
                    en.Category = Convert.ToInt16(r["category"]);
                    en.CreationDate = Convert.ToDateTime(r["creationDate"]);

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

        public bool ReadNext(ENProduct en) {
            bool found = false;

            SqlConnection con = null;

            string ins = "SELECT TOP 1 * FROM Products WHERE id > (SELECT id FROM Products where code=@code)  ORDER BY id asc";

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    en.Code = r["code"].ToString();
                    en.Name = r["name"].ToString();
                    en.Amount = Convert.ToInt16(r["amount"]);
                    en.Price = Convert.ToSingle(r["price"]);
                    en.Category = Convert.ToInt16(r["category"]);
                    en.CreationDate = Convert.ToDateTime(r["creationDate"]);

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

        public bool ReadPrev(ENProduct en) {
            bool found = false;

            SqlConnection con = null;

            string ins = "SELECT TOP 1 * FROM Products WHERE id < (SELECT id FROM Products where code=@code)  ORDER BY id desc";

            try
            {
                con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand(ins, con);
                cmd.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    en.Code = r["code"].ToString();
                    en.Name = r["name"].ToString();
                    en.Amount = Convert.ToInt16(r["amount"]);
                    en.Price = Convert.ToSingle(r["price"]);
                    en.Category = Convert.ToInt16(r["category"]);
                    en.CreationDate = Convert.ToDateTime(r["creationDate"]);

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


    }
}
