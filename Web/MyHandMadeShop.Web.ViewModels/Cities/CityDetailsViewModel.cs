namespace MyHandMadeShop.Web.ViewModels.Cities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyHandMadeShop.Data.Models;

    public class CityDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(City))]
        public string Name { get; set; }
    }
}
