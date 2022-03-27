using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHandMadeShop.Web.ViewModels.Cities
{
    public class CitySelectModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
