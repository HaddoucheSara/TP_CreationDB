using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CreationDB.Models
{
    public class Student:Person
    {
        public int StudentNumber { get; set; }
        [NotMapped]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
