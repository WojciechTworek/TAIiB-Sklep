using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface OrderInt
    {
        void CreateOrder(int userId);
        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<OrderDTO> GetOrders(int userId);
        IEnumerable<OrderPositionDTO> GetOrderPosition(int userId);
    }
}
