using BLL;
using Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class BasketImpl : BasketInt
    {
        public readonly List<BasketPositionDTO> _basketPositions;
        public readonly List<ProductDTO> _products;

        public BasketImpl(List<ProductDTO> products)
        {
            _basketPositions = new List<BasketPositionDTO>();
            _products = products ?? throw new ArgumentNullException(nameof(products));
        }
        public void AddToBasket(int userId, int productId, int amount)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);

            if (product == null || !product.IsActive)
                throw new InvalidOperationException("Nie można dodać nieaktywnego produktu do koszyka.");

            if (amount <= 0)
                throw new ArgumentException("Ilość produktu w koszyku musi być większa niż zero.");

            var existingPosition = _basketPositions.FirstOrDefault(bp => bp.UserId == userId && bp.ProductId == productId);
            if (existingPosition != null)
            {
                existingPosition.Amount += amount;
            }
            else
            {
                var newPosition = new BasketPositionDTO
                {
                    UserId = userId,
                    ProductId = productId,
                    Amount = amount
                };
                _basketPositions.Add(newPosition);
            }
        }

        public void ChangeAmount(int basketPositionId, int amount)
        {
            var positionToChange = _basketPositions.FirstOrDefault(bp => bp.Id == basketPositionId);
            if (positionToChange != null)
            {
                positionToChange.Amount = amount;
            }
            else
            {
                throw new ArgumentException("Nie można odnaleźć pozycji koszyka o podanym identyfikatorze.");
            }
        }

        public void DeleteFromBasket(int basketPositionId)
        {
            var positionToDelete = _basketPositions.FirstOrDefault(bp => bp.Id == basketPositionId);
            if (positionToDelete != null)
            {
                _basketPositions.Remove(positionToDelete);
            }
            else
            {
                throw new ArgumentException("Nie można odnaleźć pozycji koszyka o podanym identyfikatorze.");
            }
        }

        public IEnumerable<BasketPositionDTO> GetBasketPositions(int userId)
        {
            return _basketPositions.Where(bp => bp.UserId == userId).ToList();
        }
    }
}
