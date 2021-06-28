using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.Interfaces;
using Business.Interfaces;
using Business.DTO;
using Business.FluentValidation;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace Business.Services
{
    public class PocupciService : IPocupciService
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private PocupciValidator validator { get; set; }
        public PocupciService(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new PocupciValidator();
        }
        public List<Pocupci> All()
        {
            return Data.Pocupci.All();
        }
        public Pocupci Id(int Id)
        {
            return Data.Pocupci.Id(Id);
        }
        public void Add(PocupciDTO pocupci)
        {
            var res = validator.Validate(pocupci);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<PocupciDTO, Pocupci>()));
                Data.Pocupci.Add(mapper.Map<PocupciDTO, Pocupci>(pocupci));
            }
            Data.Save();
        }
        public void Edit(PocupciDTO pocupci, int Id)
        {
            var res = validator.Validate(pocupci);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<PocupciDTO, Pocupci>()));
                Data.Pocupci.Edit(mapper.Map<PocupciDTO, Pocupci>(pocupci), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Pocupci.Delete(Id);
            Data.Save();
        }
    }
}
