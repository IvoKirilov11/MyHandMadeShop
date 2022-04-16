namespace MyHandMadeShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

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

        public IEnumerable<T> GetAll<T>()
        {
            return this.ordersRepository.All()
                .To<T>().ToList();
        }

    }
}
