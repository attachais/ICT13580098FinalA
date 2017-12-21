using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ICT13580098FinalA.Models
{
    public class Employee
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Lastname { get; set; }

        public int Age { get; set; }

        [NotNull]
        public string Gender { get; set; }

        [NotNull]
        public string Section { get; set; }

        [MaxLength(11)]
        public string TellNo { get; set; }

        public string Email { get; set; }

        [NotNull]
        public string Address { get; set; }

        public string Engage { get; set; }

        public int Child { get; set; }

        [NotNull]
        public decimal Salary { get; set; }
    }
}
