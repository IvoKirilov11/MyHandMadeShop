using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Cities
{
    public class CityCreateInputModel
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
