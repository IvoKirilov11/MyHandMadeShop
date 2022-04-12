namespace MyHandMadeShop.Web.ViewModels.Countries
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CountryCreateInputModel
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
