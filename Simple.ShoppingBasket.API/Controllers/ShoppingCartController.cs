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

      // POST api/values
      [HttpPost]
      public void Post([FromBody] string value) {
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value) {
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public void Delete(int id) {
      }
   }
}
