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

        public async Task CreateOrder(string customerId, string orderId,string itemId)
        {

            var orderIdDB = ordersRepository.All().Any(x => x.Id.ToString() == orderId);
            if (!orderIdDB)
            {
                var orders = new Order
                {
                    CustomerId = customerId,
                    ItemId = itemId

                };

                await ordersRepository.AddAsync(orders);
                await ordersRepository.SaveChangesAsync();
            }

            var customerIdDB = ordersRepository.All().Any(x => x.Id.ToString() == customerId);
            if (customerIdDB)
            {
                var orders = new Order
                {
                    CustomerId = customerId,

                };

                await ordersRepository.AddAsync(orders);
                await ordersRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.ordersRepository.All()
                .To<T>().ToList();
        }

    }
}
