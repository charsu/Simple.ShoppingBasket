using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple.ShoppingBasket.API.Core.DataSession;
using Simple.ShoppingBasket.API.Core.Models.Dto;
using Simple.ShoppingBasket.API.Core.Models.Entities;

namespace Simple.ShoppingBasket.API.Controllers {
   [Route("api/[controller]")]
   [ApiController]
   public class ProductController : ControllerBase {
      private readonly IDataRepository _dataSession;

      public ProductController(IDataRepository dataSession) {
         _dataSession = dataSession;
      }

      // GET api/ShoppingCart
      [HttpGet]
      public ActionResult<IEnumerable<ProductDto>> Get()
      // we might need some form of authentication here so that we can filter them by current user 
      // and not leak information ...
         => _dataSession.GetSet<ProductDto, Product>().ToList();
   }
}