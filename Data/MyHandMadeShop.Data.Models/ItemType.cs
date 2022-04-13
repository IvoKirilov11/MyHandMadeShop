namespace MyHandMadeShop.Data.Models
{
    using System.Collections.Generic;

    using MyHandMadeShop.Data.Common.Models;

    public class ItemType : BaseDeletableModel<string>
    {

        public ItemType()
        {
            this.Items = new HashSet<Item>();
        }

        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}
