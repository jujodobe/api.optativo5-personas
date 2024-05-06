using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Referenciales.Interfaces
{
    public interface IPersonaRepository
    {
        void add(PersonaModel persona);
        PersonaModel get(int id);
        IEnumerable<PersonaModel> getAll();
        void update(PersonaModel persona);
    }
}
