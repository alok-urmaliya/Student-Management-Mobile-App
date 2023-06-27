using App01.Model;
using SQLite;

namespace App01.Services
{
    public class StudentService : IStudentService
    {
        private SQLiteAsyncConnection _dbConnection;
        public StudentService()
        {
            SetupDb();
        }

        public async void SetupDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Student>();
            }
        }
        
        async Task<List<Student>> IStudentService.GetStudents()
        {
            //USING SQLITE3

            var students = await _dbConnection.Table<Student>().ToListAsync();
            return students;

            //For SQL SERVER

            //List<Student> students = new List<Student>();
            //string connectionString = "Data Source=SERVER_IP_;TrustServerCertificate=True;Trusted_Connection=True;Initial Catalog=StudentDb;User Id=developer;Password=dev@123";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    if (connection == null)
            //    {
            //        throw new Exception("connection was not established");
            //    }
                    
            //    connection.Open();

            //    SqlCommand comm = new SqlCommand("SELECT * FROM students", connection);
            //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
            //    DataTable dataTable = new DataTable();
            //    sqlDataAdapter.Fill(dataTable);

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        Student s = new Student();
            //        s.studentid = (int)row["studentid"];
            //        s.Firstname = row["Firstname"].ToString();
            //        s.Lastname = row["Lastname"].ToString();
            //        s.email = row["email"].ToString();

            //        students.Add(s);
            //    }
            //    comm.ExecuteNonQuery();
            //}
            //return students;
        }
        Task<int> IStudentService.AddStudent(Student student)
        {
            return _dbConnection.InsertAsync(student);
        }
        Task<int> IStudentService.RemoveStudent(Student student)
        {
            return _dbConnection.DeleteAsync(student);
        }

        Task<int> IStudentService.UpdateStudent(Student student)
        {
            return _dbConnection.UpdateAsync(student);
        }

        async Task<List<string>> IStudentService.GetEmails()
        {
            var students = await _dbConnection.Table<Student>().ToListAsync();
            List<string> emails = new List<string>();
            foreach(Student student in students)
            {
                emails.Add(student.email);
            }
            return emails;
        }
    }
}
