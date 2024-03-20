namespace BLL
{
    public interface ProductInt
    {
        Task<List<ProductDTO>> GetProducts(int page, int pageSize, string nameFiltr, bool? isActiveFiltr, string sort, bool isAscending);
        Task AddProduct(ProductDTO product);
        Task EditProduct(int productId, ProductDTO product);
        Task DeleteProduct(int productId);
        Task ActivateProduct(int productId);
    }
}
