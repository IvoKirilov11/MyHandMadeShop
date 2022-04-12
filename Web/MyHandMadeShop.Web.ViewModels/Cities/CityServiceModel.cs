namespace MyHandMadeShop.Web.ViewModels.Cities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyHandMadeShop.Data.Models;
    using MyHandMadeShop.Services.Mapping;

    public class CityServiceModel : IMapFrom<City>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
