using BLL;
using DataAccesLayer;
using Microsoft.EntityFrameworkCore;
using Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL_EF
{
    public class BasketImpl : BasketInt
    {
        private readonly SklepContext _context;

        public BasketImpl(SklepContext context)
        {
            _context = context;
        }
        public void AddToBasket(int userId, int productId, int amount)
        {
            var existingPosition = _context.BasketPosition.FirstOrDefault(bp => bp.UserId == userId && bp.ProductId == productId);

            if (existingPosition != null)
            {
                existingPosition.Amount += amount;
            }
            else
            {
                var newPosition = new Sklep.BasketPosition
                {
                    UserId = userId,
                    ProductId = productId,
                    Amount = amount
                };
                _context.BasketPosition.Add(newPosition);
            }

            _context.SaveChanges(); // Zapisz zmiany w bazie danych
        }

        public void ChangeAmount(int basketPositionId, int amount)
        {
            var positionToChange = _context.BasketPosition.Find(basketPositionId);

            if (positionToChange != null)
            {
                positionToChange.Amount = amount;
                _context.SaveChanges(); // Zapisz zmiany w bazie danych
            }
            else
            {
                throw new ArgumentException("Nie można odnaleźć pozycji koszyka o podanym identyfikatorze.");
            }
        }

        public void DeleteFromBasket(int basketPositionId)
        {
            var positionToDelete = _context.BasketPosition.Find(basketPositionId);

            if (positionToDelete != null)
            {
                _context.BasketPosition.Remove(positionToDelete);
                _context.SaveChanges(); // Zapisz zmiany w bazie danych
            }
            else
            {
                throw new ArgumentException("Nie można odnaleźć pozycji koszyka o podanym identyfikatorze.");
            }
        }

        public IEnumerable<BasketPositionDTO> GetBasketPositions(int userId)
        {
            return _context.BasketPosition
        .Where(bp => bp.UserId == userId)
        .Select(bp => new BasketPositionDTO
        {
            UserId = bp.UserId,
            ProductId = bp.ProductId,
            Amount = bp.Amount
        })
        .ToList();
        }
    }
}
