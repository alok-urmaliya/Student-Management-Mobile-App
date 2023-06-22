using App01.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.Services
{
    public class StudentService : IStudentService
    {
        bool IStudentService.AddStudent(Student student)
        {
            return true;    
        }

        List<Student> IStudentService.GetStudents()
        {
            List<Student> students = new List<Student>();
            string connectionString = "Data Source=192.168.29.78;Initial Catalog=StudentDb;User Id=developer;Password=dev@123;Trusted_Connection=True;TrustServerCertificate=true;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection == null)
                {
                    throw new Exception("connection was not established");
                }
                    
                connection.Open();

                SqlCommand comm = new SqlCommand("SELECT * FROM students", connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Student s = new Student();
                    s.studentid = (int)row["studentid"];
                    s.Firstname = row["Firstname"].ToString();
                    s.Lastname = row["Lastname"].ToString();
                    s.email = row["email"].ToString();

                    students.Add(s);
                }
                comm.ExecuteNonQuery();
            }
            return students;
        }

        bool IStudentService.RemoveStudent(Student student)
        {
            throw new NotImplementedException();
        }

        bool IStudentService.UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
