using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.ShoppingBasket.API.Core.Models.Entities {
   public class Product : IEntity {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public DateTime CreationTime { get; set; } = DateTime.Now;

      /* any other metadata */
   }
}
