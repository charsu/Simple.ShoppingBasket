using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Simple.ShoppingBasket.API.Core.Models.Dto;
using Simple.ShoppingBasket.API.Core.Models.Entities;

namespace Simple.ShoppingBasket.API.Core.Models.Mappings {
   public class ShoppingCartProfile : Profile {
      public ShoppingCartProfile() {
         CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
      }
   }
}
