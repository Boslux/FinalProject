using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely Coupled: Bir bağımlılık var fakat soyuta bağımlı.
        //naming convertion
        //IoC Container -- Inversion of Control
        //AOP
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //IProductService productService = new ProductManager(new EfProductDal());
            var result= _productService.GetAll();
            if (result.Success) 
            {
                return Ok(result.Data);  //başarılı
            }
            return BadRequest(result.Message); // başarısız
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) 
        {
            var result=_productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPatch("add")]
        public IActionResult Add(Product product)
        {
            var result  = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
