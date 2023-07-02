using Microsoft.Data.SqlClient;
using System.Data;

namespace ModelBindingAssignment.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stream { get; set; }

        public static List<Student> GetAllStudents()
        {
            List<Student> lstemp = new List<Student>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From Students";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Student stud = new Student();
                    stud.Id = dr.GetInt32("Id");
                    stud.Name = dr.GetString("Name");
                    stud.Stream = dr.GetString("Stream");
                    lstemp.Add(stud);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lstemp;
        }

        public static Student GetSingleStudent(int Id)
        {
            Student stud = new Student();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=True";
            cn.Open();

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Students where Id = @Id";

                cmd.Parameters.AddWithValue("@Id", Id);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    stud.Id = dr.GetInt32("Id");
                    stud.Name = dr.GetString("Name");
                    stud.Stream = dr.GetString("Stream");
                }
                else
                {
                    stud = null;
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return stud;
        }

        public static void InsertStudent(Student stud)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=True";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Students values(@Id, @Name, @Stream)";
                cmd.Parameters.AddWithValue("@Id", stud.Id);
                cmd.Parameters.AddWithValue("@Name", stud.Name);
                cmd.Parameters.AddWithValue("@Stream", stud.Stream);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateStudent(Student stud)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Students set Id=@Id, Name=@Name, Stream=@Stream where Id = @Id";

                cmd.Parameters.AddWithValue("@Id", stud.Id);
                cmd.Parameters.AddWithValue("@Name", stud.Name);
                cmd.Parameters.AddWithValue("@Stream", stud.Stream);
                
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

        }

        public static void DeleteStudent(int Id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Students where Id =@Id";

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

        }

    }


}
