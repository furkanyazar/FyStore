using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ILogService _logService;

        public ProductManager(IProductDal productDal, ILogService logService)
        {
            _productDal = productDal;
            _logService = logService;
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductNameExists(product));
            if (result is not null)
                return result;

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(int productId)
        {
            var productToCheck = _productDal.Get(x => x.ProductId == productId);
            if (productToCheck is null)
                return new ErrorResult(Messages.ProductNotFound);

            _productDal.Delete(productToCheck);

            return new SuccessResult(Messages.ProductDeleted);
        }

        [CacheAspect]
        public IDataResult<List<ProductDetailDto>> GetAll()
        {
            //_logService.Add(new Custom2022 { Message = "Test mesajı", Data = JsonConvert.SerializeObject(new { id = 1, name = "test" }) });

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetAllWithProductDetailDto());
        }

        [CacheAspect(duration: 30)]
        public IDataResult<List<ProductDetailDto>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetAllByCategoryIdWithProductDetailDto(categoryId));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<ProductDetailDto> GetById(int productId)
        {
            return new SuccessDataResult<ProductDetailDto>(_productDal.GetByIdWithProductDetail(productId));
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductNameExists(product));
            if (result is not null)
                return result;

            _productDal.Update(product);

            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckIfProductNameExists(Product product)
        {
            var result = _productDal.GetAll(x => x.ProductId != product.ProductId && x.ProductName == product.ProductName).Any();

            return result ? new ErrorResult(Messages.ProductNameAlreadyExists) : new SuccessResult();
        }
    }
}
