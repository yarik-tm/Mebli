using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Interfaces;
using Dapper;

namespace DataAccess.Repository
{
    public class ZamovlennyaRepository : IZamovlennyaRepository
    {
        private readonly string _con;
        private readonly ContextDB context;
        public ZamovlennyaRepository(ContextDB context)
        {
            this.context = context;
            _con = "Data Source=ASUS-DESKTOP\\SQLEXPRESS;Database=Mebl;Trusted_Connection=True;";
        }
        public List<Zamovlennya> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var result = new List<Zamovlennya>();
                using (var reader = sql.ExecuteReader("[GetZamovlennya]"))
                {
                    while (reader.Read())
                    {
                        result.Add(
                                new Zamovlennya
                                {
                                    Id = (int)reader["Id"],
                                    MebliID = (int)reader["MebliID"],
                                    PocupciID = (int)reader["PocupciID"]
                                }
                            );
                    }
                    return result;
                }
            }
        }
        public Zamovlennya Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                Zamovlennya result = null;
                using (var reader = sql.ExecuteReader("[GetZamovlennya] @Id = @Id", new { Id = Id }))
                {
                    while (reader.Read())
                    {
                        result = new Zamovlennya
                        {
                            Id = (int)reader["Id"],
                            MebliID = (int)reader["MebliID"],
                            PocupciID = (int)reader["PocupciID"]
                        };
                    }
                }
                return result;
            }
        }
        public void Add(Zamovlennya zamovlennya)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[AddZamovlennya]";
                var vars = new
                {
                    CarID = zamovlennya.MebliID,
                    CustomerID = zamovlennya.PocupciID
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Edit(Zamovlennya order, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[EditZamovlennya]";
                var vars = new
                {
                    Id = Id,
                    MebliID = order.MebliID,
                    PocupciID = order.PocupciID
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[DeleteZamovlennya]";
                var vars = new
                {
                    Id = Id
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
