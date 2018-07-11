using Newtonsoft.Json;
using Our.Umbraco.Ditto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace UmbracoLogApp.Models
{
    public class UmbracoMember : Member
    {
        private readonly IMember _umbracoMember;

        public UmbracoMember(IMember umbracoMember)
        {
            _umbracoMember = umbracoMember;
        }

        public IMember GetUmbracoMember()
        {
            return _umbracoMember;
        }

        public override void AddProduct(Product product)
        {
            var property = _umbracoMember.Properties[Constants.Alias.Products];
            //List<Product> products = new List<Product>();
            var items = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(property.Value.ToString());
            //var productsContent = property.Value as IEnumerable<IPublishedContent>;
            //List<Product> products = productsContent != null
            //    ? productsContent.As<Product>().ToList()
            //    : new List<Product>();
            items.Add(new Dictionary<string, object>()
            {
                {
                    "identifier",
                    product.Identifier
                },
                {
                    "reciept",
                    product.Reciept
                },
                {
                    "shopNo",
                    product.ShopNo
                },
                {
                    "dateOfPurchase",
                    product.DateOfPurchase
                },
            });
            //products.Add(product);
            _umbracoMember.SetValue(Constants.Alias.Products, JsonConvert.SerializeObject(items));
        }

        public override IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}