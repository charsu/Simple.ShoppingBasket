using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.ShoppingBasket.API.Core.Models.Entities {
   public class ShoppingCart : IEntity {
      public int Id { get; set; }
      public int ClientId { get; set; }
      public virtual List<Product> Products { get; set; }
      public DateTime CreationTime { get; set; } = DateTime.Now;
   }
}
