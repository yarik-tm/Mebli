using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.Interfaces;
using Business.Interfaces;
using Business.DTO;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Business.FluentValidation;
namespace Business.Services
{
    public class MebliService : IMebliService
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private MebliValidator validator { get; set; }
        public MebliService(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new MebliValidator();
        }
        public List<Mebli> All()
        {
            return Data.Mebli.All();
        }
        public Mebli Id(int Id)
        {
            return Data.Mebli.Id(Id);
        }
        public void Add(MebliDTO mebli)
        {
            var res = validator.Validate(mebli);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<MebliDTO, Mebli>()));
                Data.Mebli.Add(mapper.Map<MebliDTO, Mebli>(mebli));
            }
            Data.Save();
        }
        public void Edit(MebliDTO mebli, int Id)
        {
            var res = validator.Validate(mebli);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<MebliDTO, Mebli>()));
                Data.Mebli.Edit(mapper.Map<MebliDTO, Mebli>(mebli), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Mebli.Delete(Id);
            Data.Save();
        }
    }
}
