using BLL;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Taiib2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductInt _productService;

        public ProductController(ProductInt productService)
        {
            _productService = productService;
        }

        [HttpGet("{page}/{pageSize}")]
        public IActionResult GetProducts(int page, int pageSize, string? nameFiltr, bool? isActiveFiltr, string? sort, bool isAscending)
        {
            var products = _productService.GetProducts(page, pageSize, nameFiltr, isActiveFiltr, sort, isAscending);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDTO product)
        {
            try
            {
                _productService.AddProduct(product);
                return Ok("Product added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{productId}")]
        public IActionResult EditProduct(int productId, [FromBody] ProductDTO product)
        {
            try
            {
                _productService.EditProduct(productId, product);
                return Ok("Product edited successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                _productService.DeleteProduct(productId);
                return Ok("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{productId}/activate")]
        public IActionResult ActivateProduct(int productId)
        {
            try
            {
                _productService.ActivateProduct(productId);
                return Ok("Product activated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
