using GDev.Umbraco.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using umbraco.presentation;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using UmbracoLogApp.Models.FormModels;
using UmbracoLogApp.Services.Interfaces;

namespace UmbracoLogApp.Controllers
{
    public class LoginSurfaceController : SurfaceController
    {
        private readonly IMemberLoginService _memberLoginService;

        public LoginSurfaceController(IMemberLoginService memberLoginService)
        {
            _memberLoginService = memberLoginService;

            //_memberLoginService.SetMemberService(ApplicationContext.Services.MemberService);
            //_memberLoginService.SetMembershipHelper(Members);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult HandleLogin(LoginFormModel registrationFormModel)
        {
            var cos = new PartialViewResult();
            return PartialView();
        }

            //public LoginSurfaceController(Umbraco.Web.UmbracoContext context, IMemberLoginService memberLoginService) : base(context)
            //{
            //    _memberLoginService = memberLoginService;
            //}

            //public LoginSurfaceController(Umbraco.Web.UmbracoContext context, UmbracoHelper helper, IMemberLoginService memberLoginService) : base(context, helper)
            //{
            //    _memberLoginService = memberLoginService;
            //}
        }
}