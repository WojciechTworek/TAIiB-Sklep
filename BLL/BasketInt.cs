using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public interface BasketInt
    {
        void AddToBasket(int userId, int productId, int amount);
        void DeleteFromBasket(int basketPositionId);
        void ChangeAmount(int basketPositionId,int amount);
        IEnumerable<BasketPositionDTO> GetBasketPositions(int userId);
    }
}
