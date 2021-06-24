using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace contact
{
    class contactrepository : Interface
    {
        private string connectionString = "Data Source=. ; Initial Catalog = Content_DB; Integrated Security=True ";

        //public DataTable SelectAll()
        //{
        //    string query = "select * from Contacts_DB";
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
        //    DataTable data = new DataTable();
        //    adapter.Fill(data);
        //    return data;
        //}

        //public DataTable SelectRow(int ContactID)
        //{
        //    string query = "select * from Contacts_DB where ContactID=" + ContactID;
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
        //    DataTable data = new DataTable();
        //    adapter.Fill(data);
        //    return data;
        //}

        //public bool Insert(string name, string family, string mobail, string email, int age, string address)
        //{
        //    SqlConnection Connection = new SqlConnection(connectionString);
        //    try
        //    {

        //        string query = "Insert Into Contacts_DB (Name,Family,Email,Age,Mobail,Address) values (@Name,@Family,@Email,@Age,@Mobail,@Address) ";
        //        SqlCommand command = new SqlCommand(query, Connection);
        //        command.Parameters.AddWithValue("@Name", name);
        //        command.Parameters.AddWithValue("@Family", family);
        //        command.Parameters.AddWithValue("@Mobail", mobail);
        //        command.Parameters.AddWithValue("@Email", email);
        //        command.Parameters.AddWithValue("@Age", age);
        //        command.Parameters.AddWithValue("@Address", address);
        //        Connection.Open();
        //        command.ExecuteNonQuery();
        //        return true;

        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        Connection.Close();
        //    }
        //}

        //public bool Update(int ContactID, string name, string family, string mobail, string email, int age, string address)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    try
        //    {
        //        string query = "Update Contacts_DB Set Name=@Name,Family=@Family,Mobail=@Mobail,Email=@Email,Age=@Age,Address=@Address Where ContactID=@ID";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@ID", ContactID);
        //        command.Parameters.AddWithValue("@Name", name);
        //        command.Parameters.AddWithValue("@Family", family);
        //        command.Parameters.AddWithValue("@Email", email);
        //        command.Parameters.AddWithValue("@Age", age);
        //        command.Parameters.AddWithValue("@Mobail", mobail);
        //        command.Parameters.AddWithValue("@Address", address);
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

        //public bool Delete(int ContactID)
        //{
        //    SqlConnection connction = new SqlConnection(connectionString);
        //    try
        //    {
        //        string query = "Delete from Contacts_DB where ContactID=@ID ";
        //        SqlCommand command = new SqlCommand(query, connction);
        //        command.Parameters.AddWithValue("@ID", ContactID);
        //        connction.Open();
        //        command.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        connction.Close();
        //    }
        //}


        //public DataTable Search(string KeyWord)
        //{
        //    string query = "select * from Contacts_DB Where Name like @KeyWord Or Family like @KeyWord";
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
        //    adapter.SelectCommand.Parameters.AddWithValue("@KeyWord", "%" + KeyWord + "%");
        //    DataTable data = new DataTable();
        //    adapter.Fill(data);
        //    return data;
        //}

        public DataTable SelectAll()
        {
            string query = "select * from Data_DB";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int ContactID)
        {
            string query = "select * from Data_DB where ContactID=" + ContactID;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable Search(string KeyWord)
        {
            string query = "select * from Data_DB Where Name like @KeyWord Or Family like @KeyWord";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@KeyWord", "%" + KeyWord + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Insert(string name, string family, string mobail, string email, int age, string address, string country, string nationality, string nationalitycode)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {

                string query = "Insert Into Data_DB (Name,Family,Email,Age,Mobail,Address,Country,Nationality,Nationalitycode) values (@Name,@Family,@Email,@Age,@Mobail,@Address,@Country,@Nationality,@Nationalitycode) ";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobail", mobail);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@Nationality", nationality);
                command.Parameters.AddWithValue("@Nationalitycode", nationalitycode);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            { 
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool Update(int ContactID, string name, string family, string mobail, string email, int age, string address, string country, string nationality, string nationalitycode)
        {
            SqlConnection connction = new SqlConnection(connectionString);
            try
            {
                string query = "Update Data_DB Set Name=@Name,Family=@Family,Email=@Email,Age=@Age,Mobail=@Mobail,Address=@Address,Country=@Country,Nationality=@Nationality,Nationalitycode=@Nationalitycode  where ContactID=@ID ";
                SqlCommand command = new SqlCommand(query, connction);
                command.Parameters.AddWithValue("@ID", ContactID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobail", mobail);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@Nationality", nationality);
                command.Parameters.AddWithValue("@Nationalitycode", nationalitycode);
                connction.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {

                connction.Close();
            }
        }

        public bool Delete(int ContactID)
        {
            SqlConnection connction = new SqlConnection(connectionString);
            try
            {
                string query = "Delete from Data_DB where ContactID=@ID ";
                SqlCommand command = new SqlCommand(query, connction);
                command.Parameters.AddWithValue("@ID", ContactID);
                connction.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connction.Close();
            }
        }
    }
}
