using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoLogApp.Models.FormModels
{
    public class RegistrationFormModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

        public void ClearPassword()
        {
            Password = string.Empty;
            PasswordConfirmation = string.Empty; ;
        }
    }
}