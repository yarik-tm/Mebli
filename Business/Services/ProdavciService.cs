using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.Interfaces;
using Business.Interfaces;
using Business.FluentValidation;
using Microsoft.Extensions.Configuration;
using Business.DTO;
using AutoMapper;
namespace Business.Services
{
    public class ProdavciService : IProdavciService
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private ProdavciValidator validator { get; set; }
        public ProdavciService(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new ProdavciValidator();
        }
        public List<Prodavci> All()
        {
            return Data.Prodavci.All();
        }
        public Prodavci Id(int Id)
        {
            return Data.Prodavci.Id(Id);
        }
        public void Add(ProdavciDTO prodavci)
        {
            var res = validator.Validate(prodavci);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<ProdavciDTO, Prodavci>()));
                Data.Prodavci.Add(mapper.Map<ProdavciDTO, Prodavci>(prodavci));
            }
            Data.Save();
        }
        public void Edit(ProdavciDTO prodavci, int Id)
        {
            var res = validator.Validate(prodavci);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<ProdavciDTO, Prodavci>()));
                Data.Prodavci.Edit(mapper.Map<ProdavciDTO, Prodavci>(prodavci), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Prodavci.Delete(Id);
            Data.Save();
        }
    }
}
