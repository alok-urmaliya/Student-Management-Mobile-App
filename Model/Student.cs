using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.Model
{
    public class Student
    {
        [PrimaryKey]
        [AutoIncrement]
        public int studentid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string email { get; set; }
    }
}
