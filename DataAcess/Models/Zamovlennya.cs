using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Zamovlennya
    {
        public int Id { get; set; }
        public int MebliID { get; set; }
        public Mebli Mebli { get; set; }
        public int PocupciID { get; set; }
        public Pocupci Pocupci { get; set; }
        public List<Robitniki> Robitnikis { get; set; } = new List<Robitniki>();
    }
}
