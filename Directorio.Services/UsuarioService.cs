
using System.Collections.Generic;
using Directorio.Entities;
using Directorio.Repository.Interfaces;
using Directorio.Services.Interfaces;

namespace Directorio.Services
{
   public class UsuarioService : IUsuarioService
    {
        IRepository<Usuario> _usuarioRepository;

        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Add(Usuario entity)
        {
            return _usuarioRepository.Add(entity);
        }

        public bool Delete(int id)
        {
            Usuario usr = Get(id);
            return _usuarioRepository.Delete(usr);
        }

        public Usuario Get(int id)
        {
            return _usuarioRepository.Get(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public bool Update(Usuario entity)
        {
            return _usuarioRepository.Update(entity);
        }
    }
}
