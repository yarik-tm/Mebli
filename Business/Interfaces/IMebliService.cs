using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Business.DTO;

namespace Business.Interfaces
{
    public interface IMebliService
    {
        List<Mebli> All();
        Mebli Id(int Id);
        void Add(MebliDTO mebli);
        void Edit(MebliDTO mebli, int Id);
        void Delete(int Id);
    }
}
