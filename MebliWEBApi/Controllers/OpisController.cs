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
    public class OpisController : ControllerBase
    {
        private readonly IOpisService serv;
        public OpisController(IOpisService serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<MebliOpis> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public MebliOpis Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] OpisDTO opis)
        {
            serv.Add(opis);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] OpisDTO desc, int id)
        {
            serv.Edit(desc, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
