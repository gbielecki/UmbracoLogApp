using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Services;
using Umbraco.Web.Security;

namespace UmbracoLogApp.Services.Interfaces
{
    public interface IMemberLoginService
    {
        //LoginResult RegisterNewMember(LoginFormModel registrationFormModel);
        void SetMemberService(IMemberService memberService);
        void SetMembershipHelper(MembershipHelper membershipHelper);
    }
}