namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products=new();
        private static readonly List<Category> _categories = new();
        static Repository()
        {
            _categories.Add(new Category {CategoryId=1, Name="Phone"});
            Categories.Add(new Category{CategoryId=2, Name="Computer"});

            _products.Add(new Product {ProductId=1, Name="Iphone 10", Price=15000, IsActive= true, Image="1.jpg", CategoryId=1});
            _products.Add(new Product {ProductId=2, Name="Iphone 11", Price=20000, IsActive= true, Image="2.jpg", CategoryId=1});
            _products.Add(new Product {ProductId=3, Name="Iphone 12", Price=25000, IsActive= true, Image="3.jpg", CategoryId=1});
            _products.Add(new Product {ProductId=4, Name="Iphone 13", Price=30000, IsActive= true, Image="4.jpg", CategoryId=1});
            _products.Add(new Product {ProductId=5, Name="Iphone 14", Price=35000, IsActive= true, Image="5.jpg", CategoryId=1});

            _products.Add(new Product {ProductId=6, Name="Macbook Air", Price=50000, IsActive= true, Image="6.jpg", CategoryId=2});
            _products.Add(new Product {ProductId=7, Name="Macbook Pro", Price=80000, IsActive= true, Image="7.jpg", CategoryId=2});
        }

        public static List<Product> Products
        {
            get{
                return _products;
            }
        }

        public static void CreateProduct(Product entity)
        {
            _products.Add(entity);
        }

        public static void EditProduct(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p=> p.ProductId==updatedProduct.ProductId);
            if(entity != null)
            {
                entity.Name=updatedProduct.Name;
                entity.Price=updatedProduct.Price;
                entity.Image=updatedProduct.Image;
                entity.CategoryId=updatedProduct.CategoryId;
                entity.IsActive=updatedProduct.IsActive;
            }
        }

        public static void DeleteProduct(Product deletedProduct)
        {
            var entity=_products.FirstOrDefault(p=>p.ProductId==deletedProduct.ProductId);
            if(entity!=null)
            {
                _products.Remove(entity);
            }
        }

        public static List<Category> Categories
        {
            get{
                return _categories;
            }
        }
    }
}