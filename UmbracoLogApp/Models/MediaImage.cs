using Our.Umbraco.Ditto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace UmbracoLogApp.Models
{
    public class MediaImage
    {
        public string Url { get; set; }
        public string Name { get; set; }
        [CurrentContentAs]
        public IPublishedContent Content { get; set; }
    }
}