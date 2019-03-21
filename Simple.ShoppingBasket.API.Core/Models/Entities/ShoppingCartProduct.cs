using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.ShoppingBasket.API.Core.Models.Entities {
   public class ShoppingCartProduct : IEntity {
      public int Id { get; set; }
      public int Quantity { get; set; }
      public int ProductId { get; set; }
   }
}
