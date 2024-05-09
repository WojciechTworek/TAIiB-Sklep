using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Taiib2.Models;
using BLL;

namespace Taiib2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private  BasketInt _basketService;

        public BasketController(BasketInt basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetBasketPositions(int userId)
        {
            var basketPositions = _basketService.GetBasketPositions(userId);
            return Ok(basketPositions);
        }

        [HttpPost]
        public IActionResult AddToBasket(int userId, int productId, int amount)
        {
            try
            {
                _basketService.AddToBasket(userId, productId, amount);
                return Ok("Product added to basket successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{basketPositionId}")]
        public IActionResult ChangeAmount(int basketPositionId, int amount)
        {
            try
            {
                _basketService.ChangeAmount(basketPositionId, amount);
                return Ok("Basket position amount changed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{basketPositionId}")]
        public IActionResult DeleteFromBasket(int basketPositionId)
        {
            try
            {
                _basketService.DeleteFromBasket(basketPositionId);
                return Ok("Basket position deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
