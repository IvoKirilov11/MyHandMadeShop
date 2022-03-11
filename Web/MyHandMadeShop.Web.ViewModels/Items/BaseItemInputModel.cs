using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Items
{
    public abstract class BaseItemInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(30)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string ItemTypeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ItemType { get; set; }

        public int Quantity { get; set; }
    }
}
