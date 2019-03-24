using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Simple.ShoppingBasket.API.Core.Models.Dto;

namespace Simple.ShoppingBasket.Client.Core {
   public interface IShoppingCart {
      Task<ShoppingCartDto> CreateShoppingCart(CancellationToken cancellationToken);
      Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken);
      Task<ShoppingCartDto> AddOrUpdateProduct(int shoppingCartId, ShoppingCartProductDto shoppingCartProductDto, CancellationToken cancellationToken);
      Task<ShoppingCartDto> RemoveProduct(int shoppingCartId, int productId, CancellationToken cancellationToken);
      Task RemoveShoppingCart(int shoppingCartId, CancellationToken cancellationToken);
   }
}
