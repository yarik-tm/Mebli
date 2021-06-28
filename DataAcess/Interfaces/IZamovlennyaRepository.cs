using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IZamovlennyaRepository
    {
        List<Zamovlennya> All();
        Zamovlennya Id(int id);
        void Add(Zamovlennya order);
        void Edit(Zamovlennya order, int Id);
        void Delete(int Id);
    }
}
