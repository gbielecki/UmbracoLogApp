using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace UmbracoLogApp.Helpers
{
    public class SiteHelper
    {
        public IPublishedContent GetSiteRoot()
        {
            var rootNode = UmbracoContext.Current.ContentCache.GetAtRoot().Single(n => n.DocumentTypeAlias == "homePage");
            return rootNode;
        }
    }
}