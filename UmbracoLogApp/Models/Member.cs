using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoLogApp.Models
{
    public abstract class Member
    {
        public abstract void AddProduct(Product product);
        public abstract IEnumerable<Product> GetProducts();
    }
}