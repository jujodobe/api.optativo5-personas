using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Repository.Database.Postgres
{
    public class PostgresConnection
    {
        private readonly string connectionString = "Host=192.168.121.18;Usename=postgres;Password=12345;Database=Despensa;Port=5432;";
        private NpgsqlConnection connection;
        public PostgresConnection(string _connetionString)
        {
            this.connectionString = _connetionString;
        }

        public NpgsqlConnection conexionDB() 
        { 
            
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
