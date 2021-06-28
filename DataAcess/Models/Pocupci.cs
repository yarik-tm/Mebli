using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Pocupci
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Zamovlennya> Zamovlennyas { get; set; } = new List<Zamovlennya>();
    }
}
