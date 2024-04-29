﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetAllByCategory(int id);
        List<Product> GetAllUnitPrice(decimal min, decimal max);
    }
}
