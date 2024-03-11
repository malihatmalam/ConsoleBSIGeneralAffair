using BSIGeneralAffairBO_C;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using static Dapper.SqlMapper;

namespace BSIGeneralAffairDAL_C
{
    public class DALDashboard
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public Dashboard GetDashboard() {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"[GeneralAffair].[USP_CMS_Dashboard]";
                    var param = new { };
                    var results = conn.QuerySingleOrDefault<Dashboard>(strSql, param);
                    return results;

                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"{sqlEx.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
