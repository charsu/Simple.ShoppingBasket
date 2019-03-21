using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.ShoppingBasket.API.Core.Models.Dto;
using Simple.ShoppingBasket.API.Core.Models.Entities;

namespace Simple.ShoppingBasket.API.Core.DataSession {
   public interface IDataRepository {
      IQueryable<TDto> GetSet<TDto, TEntity>()
         where TEntity : IEntity
         where TDto : IDto;
      TDto Save<TDto, TEntity>(TDto dto)
         where TEntity : IEntity
         where TDto : IDto;

      void Remove<T>(T entity) where T : IDto;
      void Remove<T>(int id);
   }
}
