using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Robitniki
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Staj { get; set; }
        public List<Zamovlennya> Zamovlennyas { get; set; } = new List<Zamovlennya>();
    }
}
