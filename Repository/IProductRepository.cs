using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public interface IProductRepository
    {
        public Product searchProductById(int Product_Id);
        public Product searchProductByName(string Product_Name);
        public bool addProductRating(int prod_id,int rating);
    }
}
