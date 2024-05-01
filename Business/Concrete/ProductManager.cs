using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        EfProductDal _efProductDal;

        public ProductManager(EfProductDal efProductDal)
        {
            _efProductDal = efProductDal;
        }
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_efProductDal.GetAll());
        }

        public IResult Add(Product product)
        {
            //business codes
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _efProductDal.Add(product);
            return new Result(true,Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_efProductDal.GetAll(p=>p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>
                (_efProductDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>
                (_efProductDal.Get(p=>p.ProductId== productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>
                (_efProductDal.GetProductDetails());
        }

        public IDataResult<List<Product>> GetProducts()
        {
            return new SuccessDataResult<List<Product>>(_efProductDal.GetAll());
        }
    }
}
