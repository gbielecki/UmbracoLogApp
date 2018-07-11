using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using UmbracoLogApp.Models.FormModels;

namespace UmbracoLogApp.Models
{
    public class Product
    {
        public Product()
        {

        }
        public Product(ProductFormModel productFormModel, MediaImage reciept)
        {
            Identifier = productFormModel.Identifier;
            ShopNo = productFormModel.ShopNo;
            DateOfPurchase = productFormModel.DateOfPurchase;
            Reciept = reciept;
            GenerateLuckyNumbers();
        }

        public string Identifier { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string ShopNo { get; set; }
        public MediaImage Reciept { get; set; }
        public List<int> LuckyNumbers { get; set; }

        private  void GenerateLuckyNumbers()
        {
            var LuckyNumbers = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                LuckyNumbers.Add(random.Next(10000, 99999));
            }
            LuckyNumbers.Add(12222);
        }
    }
}