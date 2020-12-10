using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProductRepository));
        static List<Product> items = new List<Product>()
        {
            new Product(){Id=1,Price=1000,Name="Keyboard",Description="..",Image_name="keyboard.png",Rating=4},
            new Product(){Id=2,Price=5000,Name="Motherboard",Description="..",Image_name="motherboard.png",Rating=4},
            new Product(){Id=3,Price=500,Name="Mouse",Description="..",Image_name="mouse.png",Rating=5},

        };
        public Product searchProductById(int prod_id)
        {
            
            Product  prodItem= items.FirstOrDefault(x => x.Id == prod_id);
            if (prodItem!=null)
            {
                return prodItem;
            }
            return null;
            
           
    
        }
        public Product searchProductByName(string prod_name)
        {
            
            Product prodItem= items.FirstOrDefault(x => x.Name == prod_name);
            if (prodItem != null)
            {
                return prodItem;
            }
            return null;


        }
        public bool addProductRating(int prod_id,int rating)
        {
            try
            {
               _log4net.Info("Getting product details for product id " + prod_id);
                Product p = items.FirstOrDefault(x => x.Id == prod_id);
                p.Rating = rating;
                return true;
            }
            catch (Exception e)
            {
                _log4net.Info("No product found with the given product id " + e.Message);
                return false;
            }


        }

    }
}
