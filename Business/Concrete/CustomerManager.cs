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
    public class CustomerManager : ICustomerService
    {
        EfCustomerDal _efCustomerDal;

        public CustomerManager(EfCustomerDal efCustomerDal)
        {
            _efCustomerDal = efCustomerDal;
        }

        public List<Customer> GetCustomers()
        {
            return _efCustomerDal.GetAll();
        }
    }
}
