using DapperExtensions.Mapper;
using Directorio.Entities;

namespace Directorio.Repository.Mapper
{
    public class UsuarioMapper : ClassMapper<Usuario>
    {

        public UsuarioMapper()
        {
            Table("Usuario");

            Map(x => x.Id).Key(KeyType.Identity).Column("Id");
            Map(x => x.Nombre).Column("Nombre");
            Map(x => x.ApellidoPaterno).Column("ApellidoPaterno");
            Map(x => x.ApellidoMaterno).Column("ApellidoMaterno");
            Map(x => x.Email).Column("Email");
            Map(x => x.Status).Column("Status");

        }

    }
}
