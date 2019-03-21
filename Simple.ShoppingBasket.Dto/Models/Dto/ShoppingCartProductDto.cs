using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.ShoppingBasket.API.Core.Models.Dto {
   public class ShoppingCartProductDto : IDto {
      public int Id { get; set; }
      public int Quantity { get; set; }
      public int ProductId { get; set; }
   }
}
