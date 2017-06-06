using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace proiectLicenta.EntityFramework.Repositories
{
    public abstract class proiectLicentaRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<proiectLicentaDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected proiectLicentaRepositoryBase(IDbContextProvider<proiectLicentaDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class proiectLicentaRepositoryBase<TEntity> : proiectLicentaRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected proiectLicentaRepositoryBase(IDbContextProvider<proiectLicentaDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
