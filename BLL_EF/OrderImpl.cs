using BLL;
using DataAccesLayer;

using Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{

    public class OrderImpl : OrderInt
    {
        private readonly SklepContext _context;

        public OrderImpl(SklepContext context)
        {
            _context = context;
        }

        public void CreateOrder(int userId)
        {
            var newOrder = new Order
            {
                UserId = userId,
                Date = DateTime.Now,
                OrderPositions = new List<OrderPosition>()
                
            };

            _context.Order.Add(newOrder);
            _context.SaveChanges();
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return _context.Order.Select(o => new OrderDTO
            {
                Id = o.Id,
                UserId = o.UserId,
                Date = o.Date
            }).ToList();
        }

        public IEnumerable<OrderPositionDTO> GetOrderPosition(int userId)
        {
            var orderPositions = _context.Order
                .Where(o => o.UserId == userId)
                .SelectMany(o => o.OrderPositions)
                .Select(op => new OrderPositionDTO
                {
                    OrderId = op.OrderId,
                }).ToList();

            return orderPositions;
        }

        public IEnumerable<OrderDTO> GetOrders(int userId)
        {
            return _context.Order
                .Where(o => o.UserId == userId)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    Date = o.Date
                }).ToList();
        }
    }
}
