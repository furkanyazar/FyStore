using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLogDal : EfEntityRepositoryBase<Custom2022, LogDbContext>, ILogDal
    {
    }
}
