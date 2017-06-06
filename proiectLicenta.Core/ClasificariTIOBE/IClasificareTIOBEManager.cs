using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace proiectLicenta.ClasificariTIOBE
{
    public interface IClasificareTIOBEManager : IDomainService
    {
        Task<ClasificareTIOBE> GetAsync(Guid id);

        Task<List<ClasificareTIOBE>> GetAllAsync();

        IQueryable<ClasificareTIOBE> GetAll();

    }
}
