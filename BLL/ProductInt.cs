namespace BLL
{
    public interface ProductInt
    {
        IEnumerable<List<ProductDTO>> GetProducts(int page, int pageSize, string nameFiltr, bool? isActiveFiltr, string sort, bool isAscending);
        void AddProduct(ProductDTO product);
        void EditProduct(int productId, ProductDTO product);
        void DeleteProduct(int productId);
        void ActivateProduct(int productId);
    }
}
