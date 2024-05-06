using Repository.Database.Postgres;
using Repository.Models;
using Dapper;
using System.Data;
using Repository.Repository.Referenciales.Interfaces;

namespace Repository.Repository.Referenciales
{
    public class PersonaRepository : IPersonaRepository
    {
        private PostgresConnection connection;
        public PersonaRepository(string _connectionString)
        {
            connection = new PostgresConnection(_connectionString);
        }

        public void add(PersonaModel persona) {
            try
            {

                using IDbConnection dbConnection = connection.conexionDB();
                dbConnection.Execute("INSERT INTO persona(nombre, apellido, cedula, mail) " +
                    " values(@Nombre, @Apellido, @Cedula, @Mail)", persona);
                dbConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void update(PersonaModel persona)
        {
            try
            {

                using IDbConnection dbConnection = connection.conexionDB();
                dbConnection.Execute("UPDATE persona SET " +
                    " nombre=@Nombre, " +
                    " apellido=@Apellido, " +
                    " cedula=@Cedula, " +
                    " mail=@Mail " +
                    " WHERE idPersona = @Id", persona);
                dbConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PersonaModel> getAll()
        {
            using IDbConnection dbConnection = connection.conexionDB();
            var listado = dbConnection.Query<PersonaModel>("SELECT * FROM persona;");
            dbConnection.Close();
            return listado;
        }

        public PersonaModel get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
