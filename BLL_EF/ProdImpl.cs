using BLL;
using DataAccesLayer;
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
        readonly SklepContext _sklepContext;

        public ProdImpl(SklepContext context)
        {
            _sklepContext = context;
        }
        public void ActivateProduct(int productId)
        {
            var product = _sklepContext.Product.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new ArgumentException("Nie można odnaleźć produktu o podanym identyfikatorze.");

            if (product.IsActive)
                throw new InvalidOperationException("Produkt jest już aktywny.");

            product.IsActive = true;
            _sklepContext.SaveChanges();
        }

        public void AddProduct(ProductDTO product)
        {
            if (product.Price <= 0)
                throw new ArgumentException("Cena produktu musi być większa niż 0.");

            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                IsActive = product.IsActive,
                BasketPositions = new List<BasketPosition>() // Inicjowanie kolekcji BasketPositions
            };

            _sklepContext.Product.Add(newProduct);
            _sklepContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = _sklepContext.Product.FirstOrDefault(p => p.Id == productId);
            if (productToDelete == null)
                throw new ArgumentException("Nie można odnaleźć produktu o podanym identyfikatorze.");
            _sklepContext.Product.Remove(productToDelete);
            _sklepContext.SaveChanges();
        }

        public void EditProduct(int productId, ProductDTO product)
        {
            var existingProduct = _sklepContext.Product.FirstOrDefault(p => p.Id == productId);
            if (existingProduct == null)
                throw new ArgumentException("Nie można odnaleźć produktu o podanym identyfikatorze.");

            if (product.Price <= 0)
                throw new ArgumentException("Cena produktu musi być większa niż 0.");

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Image = product.Image;
            existingProduct.IsActive = product.IsActive;

            _sklepContext.SaveChanges();
        }

        public IEnumerable<ProductDTO> GetProducts(int page, int pageSize, string nameFiltr, bool? isActiveFiltr, string sort, bool isAscending)
        {
            IQueryable<Product> query = _sklepContext.Product;

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

            return query.Skip((page) * pageSize).Take(pageSize)
                        .Select(p => new ProductDTO
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price,
                            Image = p.Image,
                            IsActive = p.IsActive
                        }).ToList();
        }
    }
}
