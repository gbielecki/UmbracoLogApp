using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Services;
using Umbraco.Web.Security;
using UmbracoLogApp.Models;
using UmbracoLogApp.Models.FormModels;

namespace UmbracoLogApp.Services.Interfaces
{
    public interface IMemberRegistrationService
    {
        RegistrationResult RegisterNewMember(RegistrationFormModel registrationFormModel);
        void SetMemberService(IMemberService memberService);
        void SetMembershipHelper(MembershipHelper membershipHelper);
    }
}