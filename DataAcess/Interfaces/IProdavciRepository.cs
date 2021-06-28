using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IProdavciRepository
    {
        List<Prodavci> All();
        Prodavci Id(int id);
        void Add(Prodavci seller);
        void Edit(Prodavci seller, int Id);
        void Delete(int Id);
    }
}
