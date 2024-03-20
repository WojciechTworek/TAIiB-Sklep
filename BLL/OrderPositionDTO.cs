using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderPositionDTO
    {
        public int Id { get; init; }
        public int OrderId { get; init; }
        public int Amount { get; init; }
        public double? Price { get; init; }
        public List<ProductDTO> Products { get; init; }
    }
}
