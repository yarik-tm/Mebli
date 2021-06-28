using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IOpisRepository
    {
        List<MebliOpis> All();
        MebliOpis Id(int id);
        void Add(MebliOpis desc);
        void Edit(MebliOpis esc, int Id);
        void Delete(int Id);
    }
}
