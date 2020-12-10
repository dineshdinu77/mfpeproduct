using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProvider prodprovider;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProductController));
        public ProductController(IProvider _prodProvider)
        {

            prodprovider = _prodProvider;
        }

        [HttpGet]
        [Route("searchProductById/{prod_id}")]
        public IActionResult searchProductById(int prod_id)
        {


            _log4net.Info(" Http GET in controller is accesed");

            var result = prodprovider.searchProductById(prod_id);
            _log4net.Info("method execution in controller completed");

            if (result == null)
            {
                _log4net.Info("method returns a null value");
                return null;
            }
            _log4net.Info("product with id " + prod_id + " is " + result);
            return Ok(result);


        }
        [HttpGet]
        [Route("searchProductByName/{prod_name}")]
        public IActionResult searchProductByName(string prod_name)
        {


            _log4net.Info(" Http GET in controller is accesed");

            var result = prodprovider.searchProductByName(prod_name);
            _log4net.Info("method execution in controller completed");

            if (result == null)
            {
                _log4net.Info("method returns a null value");
                return null;
            }
            _log4net.Info("product with id " + prod_name + " is " + result);
            return Ok(result);


        }
        [HttpPost]
        public IActionResult addProductRating(int prod_id,[FromBody] int rating)
        {
            var res = prodprovider.addProductRating(prod_id, rating);
            _log4net.Info("method execution in controller completed");

            if (res == false)
            {
                _log4net.Info("method returns a null value");
                return NotFound();
            }
            _log4net.Info("rating "+rating+ " for the product with id=" + prod_id + " is assigned");
            return Ok(res);
        }
    }
}
