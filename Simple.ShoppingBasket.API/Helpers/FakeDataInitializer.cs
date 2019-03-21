using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Simple.ShoppingBasket.API.Core.DataSession;
using Simple.ShoppingBasket.API.Core.Models.Dto;
using Simple.ShoppingBasket.API.Core.Models.Entities;

namespace Simple.ShoppingBasket.API.Helpers {
   public static class FakeDataInitializer {

      public static void AddFakeData(this IServiceCollection services) {
         var dataRepository = services.BuildServiceProvider().GetService<IDataRepository>();

         // add products 
         var products = Enumerable.Range(1, 10).Select(i =>
            new ProductDto() {
               Id = i,
               Name = $"Product {i}",
            }
         ).ToList();

         products.ForEach(p => {
            dataRepository.Save<ProductDto, Product>(p);
         });

         Enumerable.Range(1, 2).ToList().ForEach(i => {
            dataRepository.Save<ShoppingCartDto, ShoppingCart>(new ShoppingCartDto() {
               Id = i,
               Products = new List<ShoppingCartProductDto>() {
                 new ShoppingCartProductDto(){ Id = i , ProductId = i , Quantity = i +1  }
               }
            });
         });
      }
   }
}
