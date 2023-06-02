using DataObects;

namespace DataAccess
 
{
    public interface IRepository
    {
        List<Product> GetAllProducts();
        Product GetById(int id);
        bool Add(Product product);
    }

    public class Repository : IRepository
    {
        List<Product> Products = new List<Product>
        {
            new Product() { Id = 1, Name = "Apple", Price = 20 },
            new Product() { Id = 2, Name = "Pear", Price = 30 },
            new Product() { Id = 3, Name = "Orange", Price = 40 }
        };

        public List<Product> GetAllProducts()=> Products;
      

        public Product GetById(int id) => Products.FirstOrDefault(item => item.Id == id);

        public bool Add(Product product)
        {
            try
            {
                Products.Add(new Product()
                {
                    Id = Products.Count + 1,
                    Name = product.Name,
                    Price = product.Price

                });
                return true;
            }


            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return false;
        }


    }
}