using System;
using System.Collections.Generic;
using System.Text;
using Simple.ShoppingBasket.API.Core.Models.Dto;

namespace Simple.ShoppingBasket.Client.Core {
   public interface IShoppingCart {
      ShoppingCartDto CreateShoppingCart();
      ProductDto GetProducts();
      void AddOrUpdateProduct(int shoppingCartId, ShoppingCartProductDto shoppingCartProductDto);
      void RemoveProduct(int shoppingCartId, ShoppingCartProductDto shoppingCartProductDto);
      void RemoveShoppingCart(int shoppingCartId);
   }
}
