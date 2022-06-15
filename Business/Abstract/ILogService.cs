using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILogService
    {
        IResult Add(Custom2022 logDetail);
    }
}
