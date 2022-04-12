namespace MyHandMadeShop.Web.ViewModels.Cities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CityCreateInputModel
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
