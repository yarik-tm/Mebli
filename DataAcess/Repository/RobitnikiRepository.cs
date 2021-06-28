using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Interfaces;
using Dapper;

namespace DataAccess.Repository
{
    public class RobitnikiRepository : IRobitnikiRepository
    {
        private readonly string _con;
        private readonly ContextDB context;
        public RobitnikiRepository(ContextDB context)
        {
            this.context = context;
            _con = "Data Source=ASUS-DESKTOP\\SQLEXPRESS;Database=Mebl;Trusted_Connection=True;";
        }
        public List<Robitniki> All()
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using (SqlCommand query = new SqlCommand("[GetRobitniki]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    var result = new List<Robitniki>();
                    sql.Open();
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(
                                    new Robitniki
                                    {
                                        Id = (int)reader["Id"],
                                        FullName = reader["FullName"].ToString(),
                                        Staj = (int)reader["Staj"]
                                    }
                                );
                        }
                        return result;
                    }
                }
            }
        }
        public Robitniki Id(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using (SqlCommand query = new SqlCommand("[GetRobitniki]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@Id", Id));
                    Robitniki result = null;
                    sql.Open();
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new Robitniki
                            {
                                Id = (int)reader["Id"],
                                FullName = reader["FullName"].ToString(),
                                Staj = (int)reader["Staj"]
                            };
                        }
                        return result;
                    }
                }
            }
        }
        public void Add(Robitniki robitniki)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using (SqlCommand query = new SqlCommand("[AddRobitniki]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@FullName", robitniki.FullName));
                    query.Parameters.Add(new SqlParameter("@Staj", robitniki.Staj));
                    sql.Open();
                    query.ExecuteNonQuery();
                }
            }
        }
        public void Edit(Robitniki robitniki, int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using (SqlCommand query = new SqlCommand("[EditRobitniki]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@Id", Id));
                    query.Parameters.Add(new SqlParameter("@FullName", robitniki.FullName));
                    query.Parameters.Add(new SqlParameter("@Staj", robitniki.Staj));
                    sql.Open();
                    query.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_con))
            {
                using (SqlCommand query = new SqlCommand("[DeleteRobitniki]", sql))
                {
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@Id", Id));
                    sql.Open();
                    query.ExecuteNonQuery();
                }
            }
        }
    }
}
