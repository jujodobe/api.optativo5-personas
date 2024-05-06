using Repository.Models;
using Repository.Repository.Referenciales;
using Repository.Repository.Referenciales.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Logica.Referenciales
{
    public class PersonaService : IPersonaRepository
    {
        public PersonaRepository personaRepository;
        public PersonaService(string _connectionString)
        {
            personaRepository = new PersonaRepository(_connectionString);
        }

        public void add(PersonaModel persona)
        {
            if (validatePersona(persona))
            {
                personaRepository.add(persona);
            }
        }

        public IEnumerable<PersonaModel> getAll()
        {
            return personaRepository.getAll();
        }

        public void update(PersonaModel persona)
        {
            if (validatePersona(persona))
            {
                if (persona.Id > 0) personaRepository.update(persona);
                else throw new Exception("Id del registro incorrecto...");
            }
        }
        public PersonaModel get(int id)
        {
            throw new NotImplementedException();
        }

        private bool validatePersona(PersonaModel persona)
        {
            if(persona == null) return false;
            if(string.IsNullOrEmpty(persona.Cedula)) return false;
            if(string.IsNullOrEmpty(persona.Nombre)) return false;
            if (string.IsNullOrEmpty(persona.Apellido)) return false;
            return true;
        }
    }
}
