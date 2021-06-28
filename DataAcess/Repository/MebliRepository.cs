using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Interfaces;
using Dapper;

namespace DataAccess.Repository
{
    public class MebliRepository : IMebliRepository
    {
        private readonly string _con;
        private readonly ContextDB context;
        private DbSet<Mebli> cars;
        public MebliRepository(ContextDB context)
        {
            this.context = context;
            cars = context.Set<Mebli>();
            _con = "Data Source=ASUS-DESKTOP\\SQLEXPRESS;Database=Mebl;Trusted_Connection=True;";
        }
        public List<Mebli> All()
        {
            return cars.ToListAsync().Result;
            
        }
        public Mebli Id(int Id)
        {
            return cars.Find(Id);
           
        }
        public void Add(Mebli car)
        {
            cars.Add(car);
           
        }
        public void Edit(Mebli car, int Id)
        {
            context.Entry(car).State = EntityState.Modified;
           
        }
        public void Delete(int Id)
        {
            var car = cars.Find(Id);
            cars.Remove(car);
            
        }
    }
}
