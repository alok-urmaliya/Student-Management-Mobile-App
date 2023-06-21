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
        public List<Student> GetStudents();
        public bool AddStudent(Student student);
        public bool RemoveStudent(Student student);
        public bool UpdateStudent(Student student);
    }
}
