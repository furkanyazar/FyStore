using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetAllWithProductDetailDto();

        ProductDetailDto GetByIdWithProductDetail(int productId);

        List<ProductDetailDto> GetAllByCategoryIdWithProductDetailDto(int categoryId);
    }
}
