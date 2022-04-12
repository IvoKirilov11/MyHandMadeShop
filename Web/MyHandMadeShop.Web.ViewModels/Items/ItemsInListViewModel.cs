namespace MyHandMadeShop.Web.ViewModels.Items
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using MyHandMadeShop.Data.Models;
    using MyHandMadeShop.Services.Mapping;

    public class ItemsInListViewModel : IMapFrom<Item>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Name { get; set; }

        public string ItemTypeId { get; set; }

        [Required]
        public string ItemTypeName { get; set; }

        public decimal Price { get; set; }

        public string Quantity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Item, ItemsInListViewModel>().ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/image/items/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));

        }
    }
}
