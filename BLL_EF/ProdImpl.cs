using BLL;
using Microsoft.EntityFrameworkCore;
using Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class ProdImpl : ProductInt
    {
        private readonly List<ProductDTO> _products;
        private readonly List<OrderPositionDTO> _orderPositions;
        private readonly List<BasketPositionDTO> _basketPositions;

        public ProdImpl(List<ProductDTO> products, List<OrderPositionDTO> orderPositions, List<BasketPositionDTO> basketPositions)
        {
            _products = products ?? throw new ArgumentNullException(nameof(products));
            _orderPositions = orderPositions ?? throw new ArgumentNullException(nameof(orderPositions));
            _basketPositions = basketPositions ?? throw new ArgumentNullException(nameof(basketPositions));
        }
        public void ActivateProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new ArgumentException("Nie można odnaleźć produktu o podanym identyfikatorze.");

            if (product.IsActive)
                throw new InvalidOperationException("Produkt jest już aktywny.");

            product.IsActive = true;
        }

        public void AddProduct(ProductDTO product)
        {
            if (product.Price <= 0)
                throw new ArgumentException("Cena produktu musi być większa niż 0.");

            _products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = _products.FirstOrDefault(p => p.Id == productId);
            if (productToDelete == null)
                throw new ArgumentException("Nie można odnaleźć produktu o podanym identyfikatorze.");

            if (IsProductAssociated(productId))
                throw new InvalidOperationException("Nie można usunąć produktu związanego z nieopłaconym zamówieniem lub koszykiem.");

            _products.Remove(productToDelete);
        }

        private bool IsProductAssociated(int productId)
        {
            var isProductInAnyOrder = _orderPositions.Any(op => op.Products.Any(p => p.Id == productId));

            var isProductInAnyBasket = _basketPositions.Any(bp => bp.ProductId == productId);

            return isProductInAnyOrder || isProductInAnyBasket;
        }

        public void EditProduct(int productId, ProductDTO product)
        {
            var existingProduct = product;
            if (existingProduct == null)
                throw new ArgumentException("Nie można odnaleźć produktu o podanym identyfikatorze.");

            if (product.Price <= 0)
                throw new ArgumentException("Cena produktu musi być większa niż 0.");

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Image = product.Image;
            existingProduct.IsActive = product.IsActive;
        }

        public IEnumerable<List<ProductDTO>> GetProducts(int page, int pageSize, string nameFiltr, bool? isActiveFiltr, string sort, bool isAscending)
        {
            IQueryable<ProductDTO> query = _products.AsQueryable();

            // Filtruj po nazwie (jeśli podano)
            if (!string.IsNullOrEmpty(nameFiltr))
                query = query.Where(p => p.Name.Contains(nameFiltr));

            // Filtruj po stanie aktywności (jeśli podano)
            if (isActiveFiltr.HasValue)
                query = query.Where(p => p.IsActive == isActiveFiltr);

            // Sortowanie
            switch (sort)
            {
                case "name":
                    query = isAscending ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    query = isAscending ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                    break;
                default:
                    query = query.OrderBy(p => p.Name);
                    break;
            }

            yield return query.ToList();
        }
    }
}
