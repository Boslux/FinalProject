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
    public class CategoryManager : ICategoryService
    {
        EfCategoryDal _efCategoryDal;

        public CategoryManager(EfCategoryDal efCategoryDal)
        {
            _efCategoryDal = efCategoryDal;
        }

        public List<Category> GetAll()
        {
            return _efCategoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _efCategoryDal.Get(c=>c.CategoryId == categoryId);
        }
    }
}
