using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Simple.ShoppingBasket.API.Core.Models.Dto;

namespace Simple.ShoppingBasket.Client.Core {
   public class ShoppingCart : IShoppingCart {

      private readonly ShoppingCartSettings _shoppingCartSettings;

      public const string ShoppingCartUrl = "shoppingcart";
      public const string ProductUrl = "product";

      public ShoppingCart(ShoppingCartSettings shoppingCartSettings) {
         _shoppingCartSettings = shoppingCartSettings;
      }

      public async Task<ShoppingCartDto> CreateShoppingCart(CancellationToken cancellationToken) {
         using (var client = GetClient()) {
            var response = await client.PutAsync($"/{ShoppingCartUrl}", null, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ShoppingCartDto>();
         }
      }

      public async Task<ShoppingCartDto> AddOrUpdateProduct(int shoppingCartId, ShoppingCartProductDto shoppingCartProductDto, CancellationToken cancellationToken) {
         using (var client = GetClient()) {
            var response = await client.PostAsync($"{ShoppingCartUrl}/{shoppingCartId}", shoppingCartProductDto, new JsonMediaTypeFormatter(), cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ShoppingCartDto>();
         }
      }

      public async Task<List<ProductDto>> GetProducts(CancellationToken cancellationToken) {
         using (var client = GetClient()) {
            var response = await client.GetAsync($"/{ProductUrl}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<ProductDto>>();
         }
      }

      public void RemoveProduct(int shoppingCartId, ShoppingCartProductDto shoppingCartProductDto) {
         throw new NotImplementedException();
      }

      public void RemoveShoppingCart(int shoppingCartId) {
         throw new NotImplementedException();
      }


      #region internal 

      private HttpClient GetClient()
         => new HttpClient {
            BaseAddress = new Uri(_shoppingCartSettings.BaseUrl)
         };

      #endregion
   }
}
