using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Business.DTO;

namespace Business.Interfaces
{
    public interface IProdavciService
    {
        List<Prodavci> All();
        Prodavci Id(int Id);
        void Add(ProdavciDTO seller);
        void Edit(ProdavciDTO seller, int Id);
        void Delete(int Id);
    }
}
