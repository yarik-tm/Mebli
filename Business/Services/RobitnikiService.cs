using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.Interfaces;
using Business.FluentValidation;
using Business.Interfaces;
using Microsoft.Extensions.Configuration;
using Business.DTO;
using AutoMapper;
namespace Business.Services
{
    public class RobitnikiService : IRobitnikiService
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private RobitnikiValidator validator { get; set; }
        public RobitnikiService(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new RobitnikiValidator();
        }
        public List<Robitniki> All()
        {
            return Data.Robitniki.All();
        }
        public Robitniki Id(int Id)
        {
            return Data.Robitniki.Id(Id);
        }
        public void Add(RobitnikiDTO worker)
        {
            var res = validator.Validate(worker);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<RobitnikiDTO, Robitniki>()));
                Data.Robitniki.Add(mapper.Map<RobitnikiDTO, Robitniki>(worker));
            }
            Data.Save();
        }
        public void Edit(RobitnikiDTO robitniki, int Id)
        {
            var res = validator.Validate(robitniki);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<RobitnikiDTO, Robitniki>()));
                Data.Robitniki.Edit(mapper.Map<RobitnikiDTO, Robitniki>(robitniki), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Robitniki.Delete(Id);
            Data.Save();
        }
    }
}
