using MyHandMadeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Cities
{
    public class CityDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(City))]
        public string Name { get; set; }
    }
}
