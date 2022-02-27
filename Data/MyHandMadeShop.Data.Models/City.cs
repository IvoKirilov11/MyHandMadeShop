using MyHandMadeShop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Data.Models
{
    public class City : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }
    }
}
