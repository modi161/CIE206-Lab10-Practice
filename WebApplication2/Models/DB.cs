using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.Models

{
    public class DB
    {
        public SqlConnection con { get; set; }

        public DB()
        {
            string conStr = "Data Source=DESKTOP-KDC2LT0;Initial Catalog=RealUsers;Integrated Security=True";
            con = new SqlConnection(conStr);
        }


        public DataTable ReadTable(string tableName)
        {
            DataTable dt = new DataTable();
            string Q = "Select * From " + tableName;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        public void AddUser(User u) //here
        {
            string Q = $"INSERT INTO Users (First_name, Last_name, Email, Gender) VALUES ('{u.Fname}', '{u.Lname}', '{u.Email}', '{u.Gender}');";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }

        }

        public void DeleteUser(int id)
        {

            string Q = $"DELETE FROM Users WHERE id = {id};";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }

        }

        public User GetUserInfo(int id)
        {
            string Q = $"select * from Users where id = {id}";
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }

            User u = new User();

            u.ID = id;
            u.Fname = (string)dt.Rows[0]["First_name"];
            u.Lname = (string)dt.Rows[0]["Last_name"];
            u.Email = (string)dt.Rows[0]["Email"];
            u.Gender = (string)dt.Rows[0]["Gender"];

            return u;
      
        }

        public void UpdateUserInfo(User u)
        {
            string Q = $"UPDATE Users SET First_name = '{u.Fname}', Last_name = '{u.Lname}', Email = '{u.Email}', Gender = '{u.Gender}' WHERE id = {u.ID};";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }


        }



    }



}
