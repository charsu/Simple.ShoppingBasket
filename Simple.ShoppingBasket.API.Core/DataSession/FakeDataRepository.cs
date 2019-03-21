using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Simple.ShoppingBasket.API.Core.Models.Dto;
using Simple.ShoppingBasket.API.Core.Models.Entities;

namespace Simple.ShoppingBasket.API.Core.DataSession {
   public class FakeDataRepository : IDataRepository {
      private static readonly ConcurrentDictionary<Type, object> _storage = new ConcurrentDictionary<Type, object>();

      public FakeDataRepository() {
      }

      public IQueryable<TDto> GetSet<TDto, TEntity>()
         where TEntity : IEntity
         where TDto : IDto
         => InternalSet<TEntity>().Values.AsQueryable().ProjectTo<TDto>();

      public TDto Save<TDto, TEntity>(TDto dto)
         where TEntity : IEntity
         where TDto : IDto {
         if (dto != null) {
            var set = InternalSet<TEntity>();
            if (dto.Id <= 0) {
               dto.Id = set.Max(x => x.Key) + 1;
            }
            set[dto.Id] = Mapper.Map<TEntity>(dto);
         }
         return dto;
      }

      public void Remove<T>(T entity) where T : IDto {
         if (entity != null) {
            var set = InternalSet<T>();
            set.TryRemove(entity.Id, out var t);
         }
      }

      #region internal 
      public ConcurrentDictionary<int, T> InternalSet<T>()
         => _storage.GetOrAdd(typeof(T), new ConcurrentDictionary<int, T>()) as ConcurrentDictionary<int, T>;

      #endregion 

   }
}
