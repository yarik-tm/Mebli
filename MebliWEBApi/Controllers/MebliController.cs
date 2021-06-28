using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Business.Interfaces;
using Business.DTO;

namespace MebliWEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MebliController : ControllerBase
    {
        private readonly IMebliService serv;
        public MebliController(IMebliService serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<Mebli> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public Mebli Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] MebliDTO mebli)
        {
            serv.Add(mebli);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] MebliDTO car, int id)
        {
            serv.Edit(car, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
