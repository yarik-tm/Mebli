using DataAccess.Interfaces;
using DataAccess.Context;
using DataAccess.Repository;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextDB context;
        public IMebliRepository Mebli { get; }
        public IPocupciRepository Pocupci { get; }
        public IOpisRepository Opis { get; }
        public IZamovlennyaRepository Zamovlennya { get; }
        public IProdavciRepository Prodavci { get; }
        public IRobitnikiRepository Robitniki { get; }
        public UnitOfWork(ContextDB context)
        {
            this.context = context;
            Mebli = new MebliRepository(context);
            Pocupci = new PocupciRepository(context);
            Opis = new OpisRepository(context);
            Zamovlennya = new ZamovlennyaRepository(context);
            Prodavci = new ProdavciRepository(context);
            Robitniki = new RobitnikiRepository(context);
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
