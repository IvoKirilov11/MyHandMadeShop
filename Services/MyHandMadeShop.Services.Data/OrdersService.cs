namespace MyHandMadeShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MyHandMadeShop.Data.Common.Repositories;
    using MyHandMadeShop.Data.Models;
    using MyHandMadeShop.Services.Mapping;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public OrdersService(IDeletableEntityRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task CreateOrder(string customerId, int orderId)
        {
            var orders = new Order
            {
                CustomerId = customerId,
                OrderItems = new List<OrderItem>(),
                Id = orderId,
            };

            await ordersRepository.AddAsync(orders);
            await ordersRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.ordersRepository.All()
                .To<T>().ToList();
        }

    }
}
