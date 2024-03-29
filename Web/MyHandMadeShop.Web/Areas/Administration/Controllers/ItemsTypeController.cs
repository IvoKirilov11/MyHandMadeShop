﻿namespace MyHandMadeShop.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyHandMadeShop.Data.Common.Repositories;
    using MyHandMadeShop.Data.Models;
    using MyHandMadeShop.Services.Data;
    using MyHandMadeShop.Web.ViewModels.Items;
    using MyHandMadeShop.Web.ViewModels.ItemsType;

    public class ItemsTypeController : AdministrationController
    {
        private readonly IDeletableEntityRepository<ItemType> dataRepository;
        private readonly IItemsServices itemsService;

        public ItemsTypeController(IDeletableEntityRepository<ItemType> dataRepository, IItemsServices itemsService)
        {
            this.dataRepository = dataRepository;
            this.itemsService = itemsService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await this.dataRepository.AllWithDeleted().ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            var itemType = await this.dataRepository.All()
                .FirstOrDefaultAsync(p => p.Id == id);
            if (itemType == null)
            {
                return this.NotFound();
            }

            return this.View(itemType);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] ItemType itemType)
        {
            if (itemType is null)
            {
                throw new ArgumentNullException(nameof(itemType));
            }

            if (this.ModelState.IsValid)
            {
                await this.dataRepository.AddAsync(itemType);
                await this.dataRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(itemType);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var itemType = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            if (itemType == null)
            {
                return this.NotFound();
            }

            return this.View(itemType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] ItemType itemType)
        {
            if (id != itemType.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dataRepository.Update(itemType);
                    await this.dataRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ItemTypeExists(itemType.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(itemType);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var itemType = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemType == null)
            {
                return this.NotFound();
            }

            return this.View(itemType);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var itemType = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            this.dataRepository.Delete(itemType);
            await this.dataRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ItemTypeExists(string id)
        {
            return this.dataRepository.All().Any(e => e.Id == id);
        }
    }
}
