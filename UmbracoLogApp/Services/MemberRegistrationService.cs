using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Umbraco.Core.Services;
using Umbraco.Web.Security;
using UmbracoLogApp.Models;
using UmbracoLogApp.Models.FormModels;
using UmbracoLogApp.Models.Validator;
using UmbracoLogApp.Services.Interfaces;

namespace UmbracoLogApp.Services
{
    public class MemberRegistrationService : IMemberRegistrationService
    {
        private IMemberService _memberService;
        private MembershipHelper _membershipHelper;

        public RegistrationResult RegisterNewMember(RegistrationFormModel registrationFormModel)
        {
            var result = new RegistrationResult();
            var registrationModelValidator = new RegistrationModelValidator();
            var validationResult = registrationModelValidator.Validate(registrationFormModel);
            if (validationResult.IsValid)
            {
                var umbracoMemberRegistrationResult = RegisterNewmUmbracoMember(registrationFormModel);
                return umbracoMemberRegistrationResult;
            }
            result.Errors = validationResult.Errors.Select(ve => ve.ErrorMessage).ToList();
            return result;
        }

        private RegistrationResult RegisterNewmUmbracoMember(RegistrationFormModel registrationFormModel)
        {
            var result = new RegistrationResult();

            var registrationModel = _membershipHelper.CreateRegistrationModel();

            registrationModel.Email = registrationFormModel.Email;
            registrationModel.Username = registrationFormModel.Email;
            registrationModel.Password = registrationFormModel.Password;

            MembershipCreateStatus mbershipCreateStatus = new MembershipCreateStatus();
            _membershipHelper.RegisterMember(registrationModel, out mbershipCreateStatus, false);

            if(mbershipCreateStatus == MembershipCreateStatus.Success)
            {
                _memberService.AssignRole(registrationModel.Email, "Site member");
                result.Success = true;
            }

            switch(mbershipCreateStatus)
            {
                case MembershipCreateStatus.DuplicateEmail:
                    result.Errors.Add("Account with given email already exists");
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    result.Errors.Add("Account with given email already exists");
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    result.Errors.Add("Invalid email address");
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    result.Errors.Add("Invalid password");
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    result.Errors.Add("Invalid email address");
                    break;
            }


            return result;
        }

        public void SetMemberService(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public void SetMembershipHelper(MembershipHelper membershipHelper)
        {
            _membershipHelper = membershipHelper;
        }
    }
}