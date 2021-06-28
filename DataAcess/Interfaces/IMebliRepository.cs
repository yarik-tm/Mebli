using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IMebliRepository
    {
        List<Mebli> All();
        Mebli Id(int id);
        void Add(Mebli car);
        void Edit(Mebli car, int Id);
        void Delete(int Id);
    }
}
