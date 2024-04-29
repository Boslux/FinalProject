using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        ProductManager productManager=new ProductManager(new EfProductDal());

        foreach (var product in productManager.GetAllUnitPrice(10,30))
        {
            Console.WriteLine(product.ProductName);
        }
    }
}
