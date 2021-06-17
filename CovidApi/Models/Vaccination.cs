using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApi.Models
{
    public class Vaccination
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Aadhar { get; set; }
    }
}
