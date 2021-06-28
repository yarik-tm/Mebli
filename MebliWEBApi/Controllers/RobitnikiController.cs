using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Business.Interfaces;
using Business.DTO;

namespace MebliWEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobitnikiController : ControllerBase
    {
        private readonly IRobitnikiService serv;
        public RobitnikiController(IRobitnikiService serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<Robitniki> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public Robitniki Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] RobitnikiDTO zamovlennya)
        {
            serv.Add(zamovlennya);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] RobitnikiDTO zamovlennya, int id)
        {
            serv.Edit(zamovlennya, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
