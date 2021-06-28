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
    public class ProdavciController : ControllerBase
    {
        private readonly IProdavciService serv;
        public ProdavciController(IProdavciService serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<Prodavci> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public Prodavci Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] ProdavciDTO prodavci)
        {
            serv.Add(prodavci);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] ProdavciDTO prodavci, int id)
        {
            serv.Edit(prodavci, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
