using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<ProductDetailDto>> GetAll();

        IDataResult<ProductDetailDto> GetById(int productId);

        IResult Add(Product product);

        IResult Update(Product product);

        IResult Delete(int productId);

        IDataResult<List<ProductDetailDto>> GetAllByCategoryId(int categoryId);
    }
}
