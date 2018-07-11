using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using UmbracoLogApp.Helpers;

namespace UmbracoLogApp.Controllers
{
    public class BaseSurfaceController : SurfaceController
    {
        protected readonly SiteHelper SiteHelper;

        public BaseSurfaceController()
        {
            SiteHelper = new SiteHelper();
        }
    }
}