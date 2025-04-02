using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CreationDB.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public string Level { get;set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
