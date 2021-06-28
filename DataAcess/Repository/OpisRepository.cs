using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Interfaces;
using Dapper;

namespace DataAccess.Repository
{
    public class OpisRepository : IOpisRepository
    {
        private readonly string _con;
        private readonly ContextDB context;
        public OpisRepository(ContextDB context)
        {
            this.context = context;
            _con = "Data Source=ASUS-DESKTOP\\SQLEXPRESS;Database=Mebl;Trusted_Connection=True;";
        }
        public List<MebliOpis> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var result = new List<MebliOpis>();
                using (var reader = sql.ExecuteReader("[GetOpis]"))
                {
                    while (reader.Read())
                    {
                        result.Add(
                                new MebliOpis
                                {
                                    Id = (int)reader["Id"],
                                    Virobnik = reader["Virobnik"].ToString(),
                                    Material = reader["Material"].ToString(),
                                    MebliID = (int)reader["MebliID"]
                                }
                            );
                    }
                    return result;
                }
            }
        }
        public MebliOpis Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                MebliOpis result = null;
                using (var reader = sql.ExecuteReader("[GetOpis] @Id = @Id", new { Id = Id }))
                {
                    while (reader.Read())
                    {
                        result = new MebliOpis
                        {
                            Id = (int)reader["Id"],
                            Virobnik = reader["Virobnik"].ToString(),
                            Material = reader["Material"].ToString(),
                            MebliID = (int)reader["MebliID"]
                        };
                    }
                }
                return result;
            }
        }
        public void Add(MebliOpis desc)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[AddOpis]";
                var vars = new
                {
                    Virobnik = desc.Virobnik,
                    Material = desc.Material,
                    MebliID = desc.MebliID
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Edit(MebliOpis desc, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[EditOpis]";
                var vars = new
                {
                    Id = Id,
                    Virobnik = desc.Virobnik,
                    Material = desc.Material,
                    MebliID = desc.MebliID
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                var query = "[DeleteOpis]";
                var vars = new
                {
                    Id = Id
                };
                sql.Query(query, vars, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
