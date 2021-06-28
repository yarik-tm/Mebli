using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Interfaces;
using Dapper;

namespace DataAccess.Repository
{
    public class PocupciRepository : IPocupciRepository
    {
        private readonly string _con;
        private readonly ContextDB context;
        public PocupciRepository(ContextDB context)
        {
            this.context = context;
            _con = "Data Source=ASUS-DESKTOP\\SQLEXPRESS;Database=Mebl;Trusted_Connection=True;";
        }
        public List<Pocupci> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var result = new List<Pocupci>();
                using (var reader = sql.ExecuteReader("[GetPocupci]"))
                {
                    while (reader.Read())
                    {
                        result.Add(
                                new Pocupci
                                {
                                    Id = (int)reader["Id"],
                                    FullName = reader["FullName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                }
                            );
                    }
                    return result;
                }
            }
        }
        public Pocupci Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                Pocupci result = null;
                using (var reader = sql.ExecuteReader("[GetPocupci] @Id = @Id", new { Id = Id }))
                {
                    while (reader.Read())
                    {
                        result = new Pocupci
                        {
                            Id = (int)reader["Id"],
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                        };
                    }
                }
                return result;
            }
        }
        public void Add(Pocupci pocupci)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[AddPocupci]";
                var vars = new
                {
                    FullName = pocupci.FullName,
                    Email = pocupci.Email
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Edit(Pocupci pocupci, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[EditPocupci]";
                var vars = new
                {
                    Id = Id,
                    FullName = pocupci.FullName,
                    Email = pocupci.Email
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[DeletePocupci]";
                var vars = new
                {
                    Id = Id
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
