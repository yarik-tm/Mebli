using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Business.DTO;

namespace Business.Interfaces
{
    public interface IRobitnikiService
    {
        List<Robitniki> All();
        Robitniki Id(int Id);
        void Add(RobitnikiDTO worker);
        void Edit(RobitnikiDTO worker, int Id);
        void Delete(int Id);
    }
}
