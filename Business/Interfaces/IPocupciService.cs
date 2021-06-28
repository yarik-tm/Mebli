using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Business.DTO;
namespace Business.Interfaces
{
    public interface IPocupciService
    {
        List<Pocupci> All();
        Pocupci Id(int Id);
        void Add(PocupciDTO pocupci);
        void Edit(PocupciDTO pocupci, int Id);
        void Delete(int Id);
    }
}
