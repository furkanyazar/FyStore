using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LogManager : ILogService
    {
        private ILogDal _logDal;

        public LogManager(ILogDal logDal)
        {
            _logDal = logDal;
        }

        public IResult Add(Custom2022 logDetail)
        {
            _logDal.Add(logDetail);

            return new SuccessResult();
        }
    }
}
