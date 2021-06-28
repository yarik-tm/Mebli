using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IPocupciRepository
    {
        List<Pocupci> All();
        Pocupci Id(int id);
        void Add(Pocupci customer);
        void Edit(Pocupci customer, int Id);
        void Delete(int Id);
    }
}
