using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        //kurallar
        where TEntity: class,IEntity, new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //Referansı yakaladım
                addedEntity.State = EntityState.Added;  //O eklenecek bir nesne onu ekle
                context.SaveChanges();  //İşlemleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //Referansı yakaladım
                deletedEntity.State = EntityState.Deleted;  //O silinecek bir nesne onu sil
                context.SaveChanges();  //İşlemleri kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Product ile çalışacağım ve Veri tabanındeki tabloyu listeye çevir ve getir.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //Referansı yakaladım
                updatedEntity.State = EntityState.Modified;  //O güncellenecek bir nesne onu güncelle
                context.SaveChanges();  //İşlemleri kaydet
            }
        }
    }
}
