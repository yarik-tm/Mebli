using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Business.DTO;

namespace Business.Interfaces
{
    public interface IZamovlennyaService
    {
        List<Zamovlennya> All();
        Zamovlennya Id(int Id);
        void Add(ZamovlennyaDTO order);
        void Edit(ZamovlennyaDTO order, int Id);
        void Delete(int Id);
    }
}
