using MyHandMadeShop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Data.Models
{
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
