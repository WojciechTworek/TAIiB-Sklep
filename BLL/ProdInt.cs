using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal interface ProdInt
    {
        Task AddProduct(ProductDTO product);
        Task UpdateProduct(int productId, ProductDTO product);
        Task DeleteProduct(int productId);
        Task Activate(int productId);
        Task<List<ProductDTO>> GetProducts(int page, int count, string nameFiltr, bool? isActive, bool isAscending);
    }
}
