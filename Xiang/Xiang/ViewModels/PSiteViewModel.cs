using Xiang.Models;

namespace Xiang.ViewModels
{
    public class PSiteViewModel
    {
        private Psite _psite;    //這裡用TProduct類型的資料，下面的屬性都是TProduct類型

        public Psite product
        {
            get { return _psite; }
            set { _psite = value; }
        }
        public PSiteViewModel()  //用建構子初始化
        {
            _psite = new Psite();
        }

        //嘗試用Lambda，OK
        //public int ProductId { get => _product.ProductId; set => _product.ProductId = value; }
        public int SiteId { get => _psite.SiteId; set => _psite.SiteId = value; }
        public int? ProductId { get => _psite.ProductId; set => _psite.ProductId = value; }
        public string? Name { get => _psite.Name; set => _psite.Name = value; }
        public string? Address { get => _psite.Address; set => _psite.Address = value; }
        public string? Latitude { get => _psite.Latitude; set => _psite.Latitude = value; }
        public string? Longitude { get => _psite.Longitude; set => _psite.Longitude = value; }
        public int? UnitOrPing { get => _psite.UnitOrPing; set => _psite.UnitOrPing = value; }
        public int? UnitInStock { get => _psite.UnitInStock; set => _psite.UnitInStock = value; }
        public string? Image { get => _psite.Image; set => _psite.Image = value; }
        public string? Description { get => _psite.Description; set => _psite.Description = value; }
        public IFormFile photo { get; set; }
    }
}
