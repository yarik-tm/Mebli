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
    public class PocupciController : ControllerBase
    {
        private readonly IPocupciService serv;
        public PocupciController(IPocupciService serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<Pocupci> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public Pocupci Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] PocupciDTO pocupci)
        {
            serv.Add(pocupci);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] PocupciDTO pocupci, int id)
        {
            serv.Edit(pocupci, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
