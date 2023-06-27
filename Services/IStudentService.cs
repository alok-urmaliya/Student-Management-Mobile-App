using App01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.Services
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudents();
        public Task<int> AddStudent(Student student);
        public Task<int> RemoveStudent(Student student);
        public Task<int> UpdateStudent(Student student);
        public Task<List<string>> GetEmails();
    }
}
