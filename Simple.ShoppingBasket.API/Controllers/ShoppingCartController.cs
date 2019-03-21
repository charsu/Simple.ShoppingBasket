using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.ShoppingBasket.API.Core.DataSession;
using Simple.ShoppingBasket.API.Core.Models.Dto;
using Simple.ShoppingBasket.API.Core.Models.Entities;

namespace Simple.ShoppingBasket.API.Controllers {
   [Route("api/[controller]")]
   [ApiController]
   public class ShoppingCartController : ControllerBase {
      private readonly IDataRepository _dataSession;

      public ShoppingCartController(IDataRepository dataSession) {
         _dataSession = dataSession;
      }

      // GET api/ShoppingCart
      [HttpGet]
      public ActionResult<IEnumerable<ShoppingCartDto>> Get()
      // we might need some form of authentication here so that we can filter them by current user 
      // and not leak information ...
         => _dataSession.GetSet<ShoppingCartDto, ShoppingCart>().ToList();

      // GET api/ShoppingCart/5
      [HttpGet("{id}")]
      public ActionResult<ShoppingCartDto> Get(int id)
         => _dataSession.GetSet<ShoppingCartDto, ShoppingCart>().FirstOrDefault(x => x.Id == id);

      /// <summary>
      /// Creates a new shopping cart 
      /// POST api/ShoppingCart
      /// </summary>
      [HttpPut()]
      public ActionResult<ShoppingCartDto> CreateShoppingCart()
         => _dataSession.Save<ShoppingCartDto, ShoppingCart>(new ShoppingCartDto() { });

      /// <summary>
      /// Adds or updates a product in the shopping cart 
      /// POST api/ShoppingCart/id
      /// </summary>
      [HttpPost("{id}")]
      public ActionResult<ShoppingCartDto> AddOrUpdateProduct(int id, [FromBody] ShoppingCartProductDto product) {
         var cart = _dataSession.GetSet<ShoppingCartDto, ShoppingCart>().FirstOrDefault(x => x.Id == id);
         if (cart != null) {
            return NotFound();
         }

         var p = cart.Products?.FirstOrDefault(x => x.Id == product.Id);
         if (p != null) {
            cart.Products.Remove(p);
         }

         cart.Products.Add(product);

         return _dataSession.Save<ShoppingCartDto, ShoppingCart>(cart);
      }

      // DELETE api/ShoppingCart/5
      [HttpDelete("{id}")]
      public void DeleteShoppingCart(int id) {
         _dataSession.Remove<ShoppingCartDto>(id);
      }

      // DELETE api/ShoppingCart/5
      [HttpDelete("{id}")]
      public void DeleteProductFromCart(int id, ShoppingCartProductDto product) {
         var cart = _dataSession.GetSet<ShoppingCartDto, ShoppingCart>().FirstOrDefault(x => x.Id == id);
         if (cart != null) {
            return;
         }

         var p = cart.Products?.FirstOrDefault(x => x.Id == product.Id);
         if (p != null) {
            cart.Products.Remove(p);
         }

         _dataSession.Save<ShoppingCartDto, ShoppingCart>(cart);
      }
   }
}
