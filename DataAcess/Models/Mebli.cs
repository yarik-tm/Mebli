using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Mebli
    {
        public int id { get; set; }
        public int Price { get; set; }
        public int ProdavecID { get; set; }
        public Prodavci Prodavci { get; set; }
        public MebliOpis Opis { get; set; }
        public List<Zamovlennya> Zamovlennyas { get; set; } = new List<Zamovlennya>();
    }
}