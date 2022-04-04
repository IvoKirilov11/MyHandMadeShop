using Microsoft.EntityFrameworkCore;
using MyHandMadeShop.Data.Common.Repositories;
using MyHandMadeShop.Data.Models;
using MyHandMadeShop.Services.Mapping;
using MyHandMadeShop.Web.ViewModels.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandMadeShop.Services.Data
{
    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public OrdersService(IDeletableEntityRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task CancelAsync(int id)
        {
            var order = await this.ordersRepository.All()
                .FirstAsync(o => o.Id == id);

            this.ordersRepository.Update(order);
            await this.ordersRepository.SaveChangesAsync();

        }

        public async Task<string> CreateAsync(OrderServiceModel input)
        {

            var order = new Order()
            {
                CustomerId = input.CustomerId,
                OrderItems = (ICollection<OrderItem>)input.OrderItemModels,
            };

            await this.ordersRepository.AddAsync(order);
            await this.ordersRepository.SaveChangesAsync();

            return order.Id.ToString();
        }

        public bool CheckIfOrderExists(int id)
            => this.ordersRepository.All()
            .Any(o => o.Id == id);

        public IEnumerable<T> GetOrdersByUserId<T>(string userId)
        {
           var order = this.ordersRepository
              .All()
              .Where(o => o.CustomerId == userId)
              .OrderByDescending(o => o.CreatedOn)
              .To<T>().ToList();

            return order;
        }

        public T GetById<T>(int id)
            => this.ordersRepository.All()
            .Where(o => o.Id == id)
            .To<T>()
            .FirstOrDefault();

        public async Task<T> GetByIdAsync<T>(int id)
            => await this.ordersRepository.All()
            .Where(o => o.Id == id)
            .To<T>()
            .FirstOrDefaultAsync();

    }
}
