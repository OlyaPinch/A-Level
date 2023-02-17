namespace Module2_3;

public class MemoryDataManager : IDataManager
{
    private Product[] _product = new[]
    {
        new Product("apple", 1, 50),
        new Product("pear", 2, 60),
        new Product("plum", 3, 70),
        new Product("grave", 4, 150),
        new Product("orange", 5, 75),
        new Product("lemon", 6, 90),
        new Product("banana", 7, 52),
        new Product("cherry", 8, 150),
        new Product("watermelon", 9, 30),
        new Product("melon", 10, 150)
    };

    public Product[] LoadProducts()
    {
        return _product;
    }

    public void SaveProducts()
    {
        throw new NotImplementedException();
    }
}