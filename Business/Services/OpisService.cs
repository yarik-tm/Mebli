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
    public class OpisService : IOpisService
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private OpisValidator validator { get; set; }
        public OpisService(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new OpisValidator();
        }
        public List<MebliOpis> All()
        {
            return Data.Opis.All();
        }
        public MebliOpis Id(int Id)
        {
            return Data.Opis.Id(Id);
        }
        public void Add(OpisDTO opis)
        {
            var res = validator.Validate(opis);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<OpisDTO, MebliOpis>()));
                Data.Opis.Add(mapper.Map<OpisDTO, MebliOpis>(opis));
            }
            Data.Save();
        }
        public void Edit(OpisDTO opis, int Id)
        {
            var res = validator.Validate(opis);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<OpisDTO, MebliOpis>()));
                Data.Opis.Edit(mapper.Map<OpisDTO, MebliOpis>(opis), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Opis.Delete(Id);
            Data.Save();
        }
    }
}
