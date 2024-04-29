using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //Referansı yakaladım
                addedEntity.State = EntityState.Added;  //O eklenecek bir nesne onu ekle
                context.SaveChanges();  //İşlemleri kaydet
            }
        }

        public void Delete(Product entity)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //Referansı yakaladım
                deletedEntity.State = EntityState.Deleted;  //O silinecek bir nesne onu sil
                context.SaveChanges();  //İşlemleri kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
           using(NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Product ile çalışacağım ve Veri tabanındeki tabloyu listeye çevir ve getir.
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //Referansı yakaladım
                updatedEntity.State = EntityState.Modified;  //O güncellenecek bir nesne onu güncelle
                context.SaveChanges();  //İşlemleri kaydet
            }
        }
    }
}
