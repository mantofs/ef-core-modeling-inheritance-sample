using Application.Orders.Contracts;
using Domain.DomainServices;
using Domain.Entities;

namespace Application.Orders.Services
{
    public class OrderServiceImp : OrderService
    {
        private readonly OrderRepository orderRepository;

        public OrderServiceImp(OrderRepository orderRepository,
                               CustomerRepository customerRepository)
        {
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public bool CreateOrder(Guid customerId)
        {

            var order = new PurchaseOrder(customerId);

            var items = new List<Item>(){
                                 new Item("Jarra de Vidro",39m),
                                 new Item("Fone de ouvido",62m),
                                 new Item("Frigideira", 30m)
                                 };

            orderRepository.Add(order);

            foreach (var item in items) order.AddItem(item);

            orderRepository.SaveChanges();

            return true;

        }

        public void UpdateItem(Guid orderId)
        {
            var order = orderRepository.GetById(orderId);

            order?.AddItem(new Item("Cadeira de Praia", 85m));

            orderRepository.SaveChanges();

        }

        public IEnumerable<Order> GetOrders() => orderRepository.Get();

        public void RemoveItem(Guid orderId)
        {
            var order = orderRepository.GetById(orderId);

            order?.RemoveItem(order.Items.First());

            orderRepository.SaveChanges();
        }
    }
}