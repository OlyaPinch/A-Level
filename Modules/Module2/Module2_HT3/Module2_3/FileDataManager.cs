using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Text.Json;

namespace Module2_3;

class FileDataManager : IDataManager
{
    private string fileName = "products.json";
    private Product[] _product;

    public Product[] LoadProducts()
    {
        if (File.Exists(fileName))
        {
            var readAllText = File.ReadAllText(fileName);
            _product = JsonSerializer.Deserialize<Product[]>(readAllText);
        }
        return _product;
    }
    
    public void SaveProducts()
    {
        string json = JsonSerializer.Serialize(_product);
        File.WriteAllText(fileName, json);
    }
}