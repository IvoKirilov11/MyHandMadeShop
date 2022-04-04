﻿using AutoMapper;
using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using System.Linq;

namespace MyHandMadeShop.Web.ViewModels.Items
{
    public class ItemSingleViewModel : IMapFrom<Item>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ItemTypeName { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Item, ItemSingleViewModel>().ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/image/items/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));

        }

    }
}