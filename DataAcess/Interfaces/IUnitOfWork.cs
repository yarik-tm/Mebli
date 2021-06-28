using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMebliRepository Mebli { get; }
        IPocupciRepository Pocupci { get; }
        IOpisRepository Opis { get; }
        IZamovlennyaRepository Zamovlennya { get; }
        IProdavciRepository Prodavci { get; }
        IRobitnikiRepository Robitniki { get; }
        int Save();
        void Dispose();
    }
}
