namespace MyHandMadeShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyHandMadeShop.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }
    }
}
