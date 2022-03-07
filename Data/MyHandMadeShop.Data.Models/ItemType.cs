﻿using MyHandMadeShop.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace MyHandMadeShop.Data.Models
{
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
