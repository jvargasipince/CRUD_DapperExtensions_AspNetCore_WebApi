using Directorio.Entities;
using System.Collections.Generic;

namespace Directorio.Services.Interfaces
{
    public interface IUsuarioService
    {

        bool Add(Usuario entity);
        bool Delete(int id);
        IEnumerable<Usuario> GetAll();
        Usuario Get(int id);

        bool Update(Usuario entity);

    }
}
