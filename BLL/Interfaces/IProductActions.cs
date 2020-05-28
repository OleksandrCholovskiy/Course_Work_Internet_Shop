using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// Интерфейс для сервиса товаров
    /// </summary>
    interface IProductActions
    {
        List<MProduct> GetProducts();

        MProduct GetProductById(int id);

        bool AddProduct(MProduct newproduct);

        bool DeleteProductByID(int id);

        bool ChangeProduct(MProduct newproduct);
    }
}
