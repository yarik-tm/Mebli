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
    public class ZamovlennyaService : IZamovlennyaService
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private ZamovlennyaValidator validator { get; set; }
        public ZamovlennyaService(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new ZamovlennyaValidator();
        }
        public List<Zamovlennya> All()
        {
            return Data.Zamovlennya.All();
        }
        public Zamovlennya Id(int Id)
        {
            return Data.Zamovlennya.Id(Id);
        }
        public void Add(ZamovlennyaDTO zamovlennya)
        {
            var res = validator.Validate(zamovlennya);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<ZamovlennyaDTO, Zamovlennya>()));
                Data.Zamovlennya.Add(mapper.Map<ZamovlennyaDTO, Zamovlennya>(zamovlennya));
            }
            Data.Save();
        }
        public void Edit(ZamovlennyaDTO zamovlennya, int Id)
        {
            var res = validator.Validate(zamovlennya);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<ZamovlennyaDTO, Zamovlennya>()));
                Data.Zamovlennya.Edit(mapper.Map<ZamovlennyaDTO, Zamovlennya>(zamovlennya), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Zamovlennya.Delete(Id);
            Data.Save();
        }
    }
}
