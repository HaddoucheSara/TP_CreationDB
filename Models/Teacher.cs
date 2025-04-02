using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CreationDB.Models
{
    public class Teacher:Person
    {
        public DateTime HireDate { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Class> Classes { get; set; }

    }
}
