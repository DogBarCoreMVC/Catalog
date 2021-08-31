using Catalog.Item;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]//localhost:44386/Products

        public IActionResult GetProducts()
        {
            Data item = new Data();
            item.ProductId = 1;
            item.ProductName = "Labrador";
            item.ProductPrice = 55000;
            return Ok(item);
        }

        [HttpGet("{id}/page2/{name}")]
        //locahost:44386/1{id}/page2/Nokia_3310{name}

        public IActionResult GetProductsById(int id,string name)
        {
            return Ok(new {productsId = id , name = name});
        }

        [HttpGet("search")]
        //localhost:44386/Products/search?num=1&name=Oppo_One5G

        public IActionResult SearchProducts([FromQuery]int num , string name)
        {
            return Ok(new { productId = num, name = name});
        }

        [HttpPost]//Create Data
        //localhost:44386/Products
        public IActionResult AddProducts([FromForm] Data item)
        {

            return CreatedAtAction(nameof(GetProducts), item);//Status201 = CreatedAtAction
        }

        [HttpPut("{id}")]//Updata
        //localhost:44386/Products/id (int)
        public IActionResult UpdataProducts(int id,[FromForm] Data item)
        {
            if(id != item.ProductId)
            {
                return BadRequest();//Status 400 = BadRequest
            }
            if(item.ProductId != 191)
            {
                return NotFound();//Status 404 =  NotFound
            }
            return Ok(item);
        }

        [HttpDelete("{id}")]//delete
        //localhost:44386/Products/id (int)
        public IActionResult RemoveProducts([FromForm] int id)
        {
            return NoContent();//Status 204 = NoContent
        }
    }
}
