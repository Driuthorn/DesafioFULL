using DesafioBackend.Data.Database.Context;
using DesafioBackend.Data.Database.Entities;
using DesafioBackend.Data.Database.Interface;

namespace DesafioBackend.Data.Database.Repository
{
    public class ParcelaRepository : BaseRepository<Parcela>, IParcelaRepository
    {
        public ParcelaRepository(DesafioBackendContext context) : base(context)
        { }
    }
}
