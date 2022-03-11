using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Items
{
    public class SingleItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ItemTypeName { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

    }
}
