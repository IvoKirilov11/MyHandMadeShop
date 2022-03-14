using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Countries
{
    public class CountryEditViewModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
