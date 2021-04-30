using DesafioBackend.Data.Database.Context;
using DesafioBackend.Data.Database.Entities;
using DesafioBackend.Data.Database.Interface;

namespace DesafioBackend.Data.Database.Repository
{
    public class TituloRepository : BaseRepository<Titulo>, ITituloRepository
    {
        public TituloRepository(DesafioBackendContext context) : base(context)
        { }
    }
}
