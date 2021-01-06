using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProductManage.Dtos;
using ProductManage.Models;

namespace ProductManage.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ProductInfo, ProductDto>();
            Mapper.CreateMap<ProductDto, ProductInfo>();
        }
    }
}