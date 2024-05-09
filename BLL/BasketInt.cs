using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public interface BasketInt
    {
        public void AddToBasket(int userId, int productId, int amount);
        public void DeleteFromBasket(int basketPositionId);
        public void ChangeAmount(int basketPositionId,int amount);
        public IEnumerable<BasketPositionDTO> GetBasketPositions(int userId);
    }
}
