using GamblingLicenseeManager.Models;
using Newtonsoft.Json;

namespace GamblingLicenseeManager.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _filePath = "Data/Products.json";
        private List<Product> _products;
        public ProductRepository()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            else
            {
                _products = new List<Product>();
            }
        }
        public IEnumerable<Product> GetAll() => _products;
        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
        public void Add(Product product)
        {
            _products.Add(product);
            SaveToFile();
        }
        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
                SaveToFile();
            }
        }
        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
                SaveToFile();
            }
        }
        private void SaveToFile()
        {
            var json = JsonConvert.SerializeObject(_products, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
