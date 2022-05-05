using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, FyStoreDbContext>, IProductDal
    {
        public List<ProductDetailDto> GetAllByCategoryIdWithProductDetailDto(int categoryId)
        {
            using (var context = new FyStoreDbContext())
            {
                var result = from products in context.Products
                             join categories in context.Categories
                             on products.CategoryId equals categories.CategoryId
                             where products.CategoryId == categoryId
                             select new ProductDetailDto { ProductId = products.ProductId, CategoryName = categories.CategoryName, ProductName = products.ProductName, UnitPrice = products.UnitPrice, UnitsInStock = products.UnitsInStock, ImageUrl = products.ImageUrl };

                return result.ToList();
            }
        }

        public List<ProductDetailDto> GetAllWithProductDetailDto()
        {
            using (var context = new FyStoreDbContext())
            {
                var result = from products in context.Products
                             join categories in context.Categories
                             on products.CategoryId equals categories.CategoryId
                             select new ProductDetailDto { ProductId = products.ProductId, CategoryName = categories.CategoryName, ProductName = products.ProductName, UnitPrice = products.UnitPrice, UnitsInStock = products.UnitsInStock, ImageUrl = products.ImageUrl };

                return result.ToList();
            }
        }

        public ProductDetailDto GetByIdWithProductDetail(int productId)
        {
            using (var context = new FyStoreDbContext())
            {
                var result = from products in context.Products
                             join categories in context.Categories
                             on products.CategoryId equals categories.CategoryId
                             where products.ProductId == productId
                             select new ProductDetailDto { ProductId = products.ProductId, CategoryName = categories.CategoryName, ProductName = products.ProductName, UnitPrice = products.UnitPrice, UnitsInStock = products.UnitsInStock, ImageUrl = products.ImageUrl };

                return result.SingleOrDefault();
            }
        }
    }
}
