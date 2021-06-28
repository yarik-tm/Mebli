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
    public class ZamovlennyaController : ControllerBase
    {
        private readonly IZamovlennyaService serv;
        public ZamovlennyaController(IZamovlennyaService serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<Zamovlennya> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public Zamovlennya Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] ZamovlennyaDTO zamovlennya)
        {
            serv.Add(zamovlennya);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] ZamovlennyaDTO zamovlennya, int id)
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
