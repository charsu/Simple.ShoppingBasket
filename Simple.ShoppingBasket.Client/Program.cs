using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Simple.ShoppingBasket.Client.Core;

namespace SimpleShoppingBasket.Client {
   class Program {
      static void Main(string[] args) {
         MainAsync().GetAwaiter().GetResult();
      }

      static async Task MainAsync() {
         var ctoken = new CancellationToken();

         // we assume that it is self hosted
         // probably a better way would have been to use the settings but 
         // the layout / structure of the client is not part of the test 
         // only showcasing how to integrate with the web api through the client service.
         var settings = new ShoppingCartSettings() {
            BaseUrl = "https://localhost:5001/api/"
         };

         // create a client service 
         var cartService = new ShoppingCart(settings);

         // get a list of products 
         var products = await cartService.GetProducts(ctoken).ConfigureAwait(false);

         // create a shopping bag 
         var shoppingBag = await cartService.CreateShoppingCart(ctoken).ConfigureAwait(false);

         // add 3 products 
         foreach (var p in products.Take(3)) {
            shoppingBag = await cartService.AddOrUpdateProduct(shoppingBag.Id,
               new Simple.ShoppingBasket.API.Core.Models.Dto.ShoppingCartProductDto() {
                  Id = p.Id,
                  Quantity = p.Id,
                  ProductId = p.Id
               },
               ctoken).ConfigureAwait(false);
         }

         // remove one product (last)
         shoppingBag = await cartService.RemoveProduct(shoppingBag.Id, shoppingBag.Products.FirstOrDefault().ProductId, ctoken).ConfigureAwait(false);

         // in order to remove all items we can simply just create a new bag as the server can be responsible 
         // for cleaning up any oboslete objects ( shopping carts ) after a period of inactivity.
         await cartService.RemoveShoppingCart(shoppingBag.Id, ctoken).ConfigureAwait(false);
      }
   }
}
