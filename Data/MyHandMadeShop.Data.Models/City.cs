namespace MyHandMadeShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyHandMadeShop.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }
    }
}
