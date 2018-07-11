using GDev.Umbraco.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using Umbraco.Web.Security;
using UmbracoLogApp.Models.FormModels;
using UmbracoLogApp.Services.Interfaces;

namespace UmbracoLogApp.Controllers
{
    public class RegistrationSurfaceController : SurfaceController//: BaseSurfaceController
    {
        private readonly IMemberRegistrationService _memberRegistrationService;

        public RegistrationSurfaceController(IMemberRegistrationService memberRegistrationService)
        {
            _memberRegistrationService = memberRegistrationService;
            //_memberRegistrationService.SetMemberService(ApplicationContext.Services.MemberService);
            //_memberRegistrationService.SetMembershipHelper(Members);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult HandleRegistration(RegistrationFormModel registrationFormModel)
        {
            var result = _memberRegistrationService.RegisterNewMember(registrationFormModel);
            if (result.Success)
            {
                TempData["registrationStatus"] = result.Success;
                return RedirectToCurrentUmbracoPage();
                //return RedirectToUmbracoPage(SiteHelper.GetSiteRoot());
            }
            TempData["errors"] = result.Errors;
            registrationFormModel.ClearPassword();
            TempData["formModel"] = registrationFormModel;
            return RedirectToCurrentUmbracoPage();
        }
    }
}