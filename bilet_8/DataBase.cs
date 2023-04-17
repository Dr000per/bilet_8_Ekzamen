using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bilet_8
{
    public class DataBase : IDisposable
    {
        string _connectionstring = @"Server = db.edu.cchgeu.ru; DataBase = 193_Shelylin; User = 193_Shelylin; Password = 193_Shelylin;";
        SqlConnection _connection;
        public DataBase()
        {
            ConnectionOpen();
        }
        public void ConnectionOpen()
        {
            _connection = new SqlConnection(_connectionstring);
            _connection.Open();
        }

        public void ConnectionClose()
        {
            _connection.Close();
        }

        public DataTable ExecuteSql(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, _connection);
            var reader = cmd.ExecuteReader();
            dt.Load(reader);

            return dt;
        }

        public void ExecuteSqlNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, _connection);
            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            ConnectionClose();
        }
    }

    
}
