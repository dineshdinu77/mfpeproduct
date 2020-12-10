using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Provider
{
    public class ProductProvider : IProvider
    {
        private readonly IProductRepository _prodRepo;

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProductProvider));
        public ProductProvider(IProductRepository prodRepository)
        {
            this._prodRepo = prodRepository;
        }
        public Product searchProductById(int prod_id)
        {
            try
            {
                _log4net.Info("Product details have been successfully recieved.");
                return _prodRepo.searchProductById(prod_id);

            }
            catch (Exception e)
            {
                _log4net.Error("Error in getting product details");
                throw e;
            }
        }
        public Product searchProductByName(string prod_name)
        {
            try
            {
                _log4net.Info("Product details have been successfully recieved.");
                return _prodRepo.searchProductByName(prod_name);

            }
            catch (Exception e)
            {
                _log4net.Error("Error in getting product details");
                throw e;
            }
        }
        public bool addProductRating(int prod_id, int rating)
        {
            try
            {
                _log4net.Info("Rating has been successfully assigned to the product.");
                return _prodRepo.addProductRating(prod_id, rating);
            }
            catch (Exception e)
            {
                _log4net.Error("Error in getting product details");
                throw e;
            }
        }

    }
}
