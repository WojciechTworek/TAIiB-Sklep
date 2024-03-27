using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderDTO
    {
        public int Id { get; init; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<OrderPositionDTO> OrderPositions { get; set; }
    }
}
