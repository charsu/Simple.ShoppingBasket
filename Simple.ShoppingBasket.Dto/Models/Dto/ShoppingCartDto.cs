using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.ShoppingBasket.API.Core.Models.Dto {
   public class ShoppingCartDto : IDto {
      public int Id { get; set; }
      public virtual List<ShoppingCartProductDto> Products { get; set; }
   }
}
