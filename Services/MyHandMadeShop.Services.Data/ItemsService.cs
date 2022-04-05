using MoiteRecepti.Data.Models;
using MyHandMadeShop.Data.Common.Repositories;
using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using MyHandMadeShop.Web.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public class ItemsService : IItemsServices
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif","jpeg" };
        private readonly IDeletableEntityRepository<Item> itemsRepository;


        public ItemsService(IDeletableEntityRepository<Item> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task CreateAsync(CreateItemsInputModel input, string userId, string imagePath)
        {
            var items = new Item
            {
                ItemTypeId = input.ItemTypeId,
                Description = input.Description,
                Name = input.Name,
                Quantity = input.Quantity,
                Price = input.Price,

            };

            Directory.CreateDirectory($"{imagePath}/items/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    Extension = extension,
                };
                items.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/items/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.itemsRepository.AddAsync(items);
            await this.itemsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var recipe = this.itemsRepository.All().FirstOrDefault(x => x.Id == id);
            this.itemsRepository.Delete(recipe);
            await this.itemsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6)
        {
            var items = this.itemsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return items;
        }

        public T GetById<T>(int id)
        {
            var item = this.itemsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return item;
        }

        public int GetCount()
        {
            return this.itemsRepository.All().Count();
        }

        public IEnumerable<T> GetByItemType<T>(IEnumerable<string> itemTypeId)
        {
            
            var query = this.itemsRepository.All().AsQueryable();

            if (itemTypeId != null)
            {

                foreach (var itemsTypeId in itemTypeId)
                {
                    query = query.Where(x => x.ItemType.Items.Any(i => i.ItemTypeId == itemsTypeId));
                }
            }

            return query.To<T>().ToList();
        }

    }
}
