using BLL;
using Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    internal class OrderImpl : OrderInt
    {
        private readonly List<OrderDTO> _orders;
        private readonly List<OrderPositionDTO> _orderPositions;

        public OrderImpl(List<OrderDTO> orders, List<OrderPositionDTO> orderPositions)
        {
            _orders = orders;
            _orderPositions = orderPositions;
        }


        public void CreateOrder(int userId)
        {
            var newOrder = new OrderDTO
            {
                Id = GenerateUniqueId(),
                UserId = userId,
                Date = DateTime.Now,
                OrderPositions = _orderPositions.Where(op => op.OrderId == userId).ToList()
            };

            _orders.Add(newOrder);
        }

        private int GenerateUniqueId()
        {
            return new Random().Next(1, 1000);
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return _orders;
        }

        public IEnumerable<OrderPositionDTO> GetOrderPosition(int userId)
        {
            var userOrders = _orders.Where(o => o.UserId == userId);

            var orderIds = userOrders.Select(o => o.Id);

            var orderPositions = _orderPositions.Where(op => orderIds.Contains(op.OrderId));

            return orderPositions;
        }

        public IEnumerable<OrderDTO> GetOrders(int userId)
        {
            return _orders.Where(o => o.UserId == userId);
        }
    }
}
