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
            var response = await client.PutAsync($"{ShoppingCartUrl}", null, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ShoppingCartDto>().ConfigureAwait(false);
         }
      }

      public async Task<ShoppingCartDto> AddOrUpdateProduct(int shoppingCartId, ShoppingCartProductDto shoppingCartProductDto, CancellationToken cancellationToken) {
         using (var client = GetClient()) {
            var response = await client.PostAsync($"{ShoppingCartUrl}/{shoppingCartId}", shoppingCartProductDto, new JsonMediaTypeFormatter(), cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ShoppingCartDto>().ConfigureAwait(false);
         }
      }

      public async Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken) {
         using (var client = GetClient()) {
            var response = await client.GetAsync($"{ProductUrl}", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<ProductDto>>().ConfigureAwait(false);
         }
      }

      public async Task<ShoppingCartDto> RemoveProduct(int shoppingCartId, int productId, CancellationToken cancellationToken) {
         using (var client = GetClient()) {
            var response = await client.DeleteAsync($"{ShoppingCartUrl}/{shoppingCartId}/{productId}", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ShoppingCartDto>().ConfigureAwait(false);
         }
      }

      public async Task RemoveShoppingCart(int shoppingCartId, CancellationToken cancellationToken) {
         using (var client = GetClient()) {
            var response = await client.DeleteAsync($"{ShoppingCartUrl}/{shoppingCartId}", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
         }
      }


      #region internal 

      private HttpClient GetClient()
         => new HttpClient {
            BaseAddress = new Uri(_shoppingCartSettings.BaseUrl)
         };

      #endregion
   }
}
