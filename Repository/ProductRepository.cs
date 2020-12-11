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
        public ProductDto productdto;
        public static List<Product> items = new List<Product>()
        {
            new Product(){Id=1,Price=1000,Name="Keyboard",Description="..",Image_name="keyboard.png",Rating=4},
            new Product(){Id=2,Price=5000,Name="Motherboard",Description="..",Image_name="motherboard.png",Rating=4},
            new Product(){Id=3,Price=500,Name="Mouse",Description="..",Image_name="mouse.png",Rating=5},

        };
        public ProductDto SearchProductById(int prod_id)
        {
            try
            {
                _log4net.Info("Product details  have been successfully retrieved");

                Product prodItem = items.FirstOrDefault(x => x.Id == prod_id);
                ProductDto pd = new ProductDto() { Id = prodItem.Id, Name = prodItem.Name, Price = prodItem.Price,Description=prodItem.Description,Image_name=prodItem.Image_name ,Rating = prodItem.Rating };
                return pd;
                
            }
            catch (Exception e)
            {
                _log4net.Error("Error " + e.Message);
                return null;
            }
            
           
    
        }
        public ProductDto SearchProductByName(string prod_name)
        {
            try
            {
                _log4net.Info("Product details  have been successfully retrieved");
                Product prodItem= items.FirstOrDefault(x => x.Name == prod_name);
                ProductDto pd = new ProductDto() { Id = prodItem.Id, Name = prodItem.Name, Price = prodItem.Price, Description = prodItem.Description, Image_name = prodItem.Image_name, Rating = prodItem.Rating };
                return pd;
            }
            catch (Exception e)
            {
                _log4net.Error("Error " + e.Message);
                return null;
            }
            


        }
        public bool AddProductRating(ProductRatingViewModel model)
        {
            try
            {
               _log4net.Info("Getting product details for product id " + model.ProdId);
                Product p = items.FirstOrDefault(x => x.Id == model.ProdId);
                p.Rating = model.Rating;
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
