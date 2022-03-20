using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyHandMadeShop.Common;
using MyHandMadeShop.Data;
using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Data;
using MyHandMadeShop.Web.Controllers;
using MyHandMadeShop.Web.ViewModels.Items;
using System;
using System.Threading.Tasks;

namespace MyHandMadeShop.Web.Areas.Administration.Controllers
{
    public class ItemsController : BaseController
    {
        private readonly ApplicationDbContext db;
        private readonly IItemsTypeService itemTypeService;
        private readonly IItemsServices itemsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;


        public ItemsController(
            IItemsTypeService itemTypeService,
            IItemsServices itemsService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment
            )
        {
            this.itemTypeService = itemTypeService;
            this.itemsService = itemsService;
            this.userManager = userManager;
            this.environment = environment;

        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateItemsInputModel();
            viewModel.ItemType = this.itemTypeService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateItemsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.ItemType = this.itemTypeService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.itemsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/image");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.ItemType = this.itemTypeService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            this.TempData["Message"] = "Item added successfully.";

            return this.RedirectToAction("All");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;
            var viewModel = new ItemsViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ItemsCount = this.itemsService.GetCount(),
                Items = this.itemsService.GetAll<ItemsInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var item = this.itemsService.GetById<SingleItemViewModel>(id);
            return this.View(item);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.itemsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }

    }
}
