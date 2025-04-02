using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CreationDB.Models
{
    public class Student:Person
    {
        public int StudentNumber { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
