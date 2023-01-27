using Xiang.Models;

namespace Xiang.ViewModels
{
    public class ProductViewModel
    {
        private Product _product;    //這裡用TProduct類型的資料，下面的屬性都是TProduct類型

        public Product product
        {
            get { return _product; }
            set { _product = value; }
        }
        public ProductViewModel()  //用建構子初始化
        {
            _product = new Product();
        }

        //嘗試用Lambda，OK
        public int ProductId { get => _product.ProductId; set => _product.ProductId = value; }
        public int? SupplierId { get => _product.SupplierId; set => _product.SupplierId = value; }
        public string? Name { get => _product.Name; set => _product.Name = value; }
        public int? UnitPrice { get => _product.UnitPrice; set => _product.UnitPrice = value; }
        public string? Image { get => _product.Image; set => _product.Image = value; }
        public IFormFile photo { get; set; }

    }
}
