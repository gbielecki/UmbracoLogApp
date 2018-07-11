using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoLogApp.Models.FormModels
{
    public class ProductFormModel
    {
        public string Identifier { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string ShopNo { get; set; }
        public HttpPostedFileBase Reciept { get; set; }
    }
}