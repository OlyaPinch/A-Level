
using System.Collections;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Product.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
      //private static readonly string[] Productds = new string[] { "Apple", "Orange", "pear", "plum", "strawberry", "banana" };
        private readonly ILogger<ProductController> _logger;
        private IRepository _repository;
        public ProductController(ILogger<ProductController> logger, IRepository repository)


        {
            _logger = logger;
            _repository = repository;

        }

        [HttpGet(Name = "GetAllProducts")]
        public IEnumerable<DataObects.Product> Get()
        {
            return _repository.GetAllProducts().ToArray();
        }

        [HttpGet("{id}")]
       
        public DataObects.Product GetByIndex(int id)
        {
            return _repository.GetById(id) ;
           
        }

        [HttpPost(Name = "AddProduct")]
        public bool AddProductPost([FromBody]DataObects.Product product)
        {
           return _repository.Add(product);
        }
    }
 
    
}
