using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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

        public List<Product> GetAllByCategory(int id)
        {
            return _efProductDal.GetAll(p=>p.CategoryId == id);
        }

        public List<Product> GetAllUnitPrice(decimal min, decimal max)
        {
            return _efProductDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }

        public List<Product> GetProducts()
        {
            return _efProductDal.GetAll();
        }
    }
}
