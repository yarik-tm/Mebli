using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Prodavci
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<Mebli> Meblis { get; set; } = new List<Mebli>();
    }
}
