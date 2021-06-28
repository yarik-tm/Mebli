using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IRobitnikiRepository
    {
        List<Robitniki> All();
        Robitniki Id(int id);
        void Add(Robitniki worker);
        void Edit(Robitniki worker, int Id);
        void Delete(int Id);
    }
}
