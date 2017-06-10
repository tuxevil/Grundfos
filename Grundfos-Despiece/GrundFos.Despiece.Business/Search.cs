using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GrundFos.Despiece.Business
{
    public class Search
    {
        public SqlDataReader FindProducts(string name)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            SqlCommand com = new SqlCommand("sp_busqproductos", myConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@producto", SqlDbType.VarChar).Value = "%" + name + "%";
            myConnection.Open();
            return com.ExecuteReader();
        }

        public SqlDataReader FindProductsByCode(string code)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            SqlCommand com = new SqlCommand("sp_busqproductos2", myConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@producto", SqlDbType.VarChar).Value = "%" + code + "%";
            myConnection.Open();
            return com.ExecuteReader();
        }

        public DataSet FindStock(string code)
        {
            return null;
        }
    }
}
