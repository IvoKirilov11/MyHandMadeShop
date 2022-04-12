namespace MyHandMadeShop.Web.ViewModels.Countries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyHandMadeShop.Data.Models;
    using MyHandMadeShop.Services.Mapping;

    public class CountryEditViewModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
