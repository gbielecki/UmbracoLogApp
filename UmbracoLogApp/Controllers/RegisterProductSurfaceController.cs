using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Services;
using UmbracoLogApp.Models;
using UmbracoLogApp.Models.FormModels;

namespace UmbracoLogApp.Controllers
{
    public class RegisterProductSurfaceController : BaseSurfaceController
    {
        private readonly IMemberService _memberService;
        private readonly ReadOnlyCollection<int> LuckyNumbers = new ReadOnlyCollection<int>(new[]
            {
                10000, 10001, 10002, 10003, 12222
            });

        public RegisterProductSurfaceController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [Authorize]
        [System.Web.Mvc.HttpPost]
        public ActionResult AddProduct(ProductFormModel productFormModel)
        {
            var member = Members.GetCurrentMember();
            var umbracoMember = new UmbracoMember(_memberService.GetById(member.Id));
            //var product = new Product() { Identifier = "1", DateOfPurchase = DateTime.Now, ShopNo = "7" };
            var product = new Product(productFormModel, new MediaImage());
            product.LuckyNumbers = GenerateLuckyNumbers();
            umbracoMember.AddProduct(product);
            _memberService.Save(umbracoMember.GetUmbracoMember());
            foreach(var luckyNumber in product.LuckyNumbers)
            {
                if(LuckyNumbers.Contains(luckyNumber))
                {
                    //add winning product to review
                }
            }
            TempData["productAdded"] = true;
            return RedirectToCurrentUmbracoPage();
        }

        private List<int> GenerateLuckyNumbers()
        {
            var luckyNumbers = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                luckyNumbers.Add(random.Next(10000, 99999));
            }
            luckyNumbers.Add(12222);
            return luckyNumbers;
        }
    }
}