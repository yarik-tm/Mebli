using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Business.DTO;

namespace Business.Interfaces
{
    public interface IOpisService
    {
        List<MebliOpis> All();
        MebliOpis Id(int Id);
        void Add(OpisDTO desc);
        void Edit(OpisDTO desc, int Id);
        void Delete(int Id);
    }
}
