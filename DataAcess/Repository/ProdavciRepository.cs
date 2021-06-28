using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Interfaces;
using Dapper;

namespace DataAccess.Repository
{
    public class ProdavciRepository : IProdavciRepository
    {
        private readonly string _con;
        private readonly ContextDB context;
        public ProdavciRepository(ContextDB context)
        {
            this.context = context;
            _con = "Data Source=ASUS-DESKTOP\\SQLEXPRESS;Database=Mebl;Trusted_Connection=True;";
        }
        public List<Prodavci> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var result = new List<Prodavci>();
                using (var reader = sql.ExecuteReader("[GetProdavci]"))
                {
                    while (reader.Read())
                    {
                        result.Add(
                                new Prodavci
                                {
                                    Id = (int)reader["Id"],
                                    Email = reader["Email"].ToString()
                                }
                            );
                    }
                    return result;
                }
            }
        }
        public Prodavci Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                Prodavci result = null;
                using (var reader = sql.ExecuteReader("[GetProdavci] @Id = @Id", new { Id = Id }))
                {
                    while (reader.Read())
                    {
                        result = new Prodavci
                        {
                            Id = (int)reader["Id"],
                            Email = reader["Email"].ToString()
                        };
                    }
                }
                return result;
            }
        }
        public void Add(Prodavci prodavci)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[AddProdavci]";
                var vars = new
                {
                    Email = prodavci.Email
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Edit(Prodavci prodavci, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[EditProdavci]";
                var vars = new
                {
                    Id = Id,
                    Email = prodavci.Email
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[DeleteProdavci]";
                var vars = new
                {
                    Id = Id
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
