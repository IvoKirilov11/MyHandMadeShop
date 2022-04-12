﻿namespace MyHandMadeShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyHandMadeShop.Data.Common.Models;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }

    }
}
