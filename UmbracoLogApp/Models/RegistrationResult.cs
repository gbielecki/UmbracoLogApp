using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoLogApp.Models
{
    public class RegistrationResult
    {
        public RegistrationResult()
        {
            Errors = new List<string>();
        }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}