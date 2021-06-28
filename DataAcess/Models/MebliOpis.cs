using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class MebliOpis
    {
        public int Id { get; set; }
        public string Virobnik { get; set; }
        public string Material { get; set; }
        public int MebliID { get; set; }
        public Mebli Mebli { get; set; }
    }
}
