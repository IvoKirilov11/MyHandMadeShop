using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Countries
{
    public class CountryDetailsViewModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        [Display(Name = nameof(Country))]
        public string Name { get; set; }
    }
}
