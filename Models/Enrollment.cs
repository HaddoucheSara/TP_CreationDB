using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CreationDB.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public Student Student { get;set; }
        public int ClassId { get;set; }
        public Class Classe { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
