﻿using MyHandMadeShop.Web.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public interface IItemsServices
    {
        Task CreateAsync(CreateItemsInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        IEnumerable<T> GetRandom<T>(int count);

        int GetCount();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
