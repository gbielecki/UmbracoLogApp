﻿using Moq;
using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Core.Configuration.UmbracoSettings;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence;
using Umbraco.Core.Services;
using Umbraco.Tests.TestHelpers;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.Routing;

namespace UmbracoLogApp._2.Test
{
    internal class UmbracoSupport : BaseRoutingTest
    {
        public UmbracoContext UmbracoContext => umbracoContext;
        public new ServiceContext ServiceContext => serviceContext;
        public IPublishedContent CurrentPage => currentPage;
        public RouteData RouteData => routeData;
        public UmbracoHelper UmbracoHelper => umbracoHelper;
        public HttpContextBase HttpContext => umbracoContext.HttpContext;
        public string ContentCacheXml { get; set; }
        /// <summary>
        /// Initializes a stubbed Umbraco request context. Generally called from [SetUp] methods.
        /// Remember to call UmbracoSupport.DisposeUmbraco from your [TearDown].
        /// </summary>
        public void SetupUmbraco()
        {
            InitializeFixture();
            TryBaseInitialize();
            InitializeSettings();
            CreateCurrentPage();
            CreateRouteData();
            CreateContexts();
            CreateHelper();
            InitializePublishedContentRequest();
        }
        /// <summary>
        /// Cleans up the stubbed Umbraco request context. Generally called from [TearDown] methods.
        /// Must be called before another UmbracoSupport.SetupUmbraco.
        /// </summary>
        public void DisposeUmbraco()
        {
            TearDown();
        }
        /// <summary>
        /// Attaches the stubbed UmbracoContext et. al. to the Controller.
        /// </summary>
        /// <param name="controller"></param>
        public void PrepareController(Controller controller)
        {
            var controllerContext = new ControllerContext(HttpContext, RouteData, controller);
            controller.ControllerContext = controllerContext;
            routeData.Values.Add("controller", controller.GetType().Name.Replace("Controller", ""));
            routeData.Values.Add("action", "Dummy");
        }
        protected override string GetXmlContent(int templateId)
        {
            if (ContentCacheXml != null)
                return ContentCacheXml;
            return base.GetXmlContent(templateId);
        }
        private UmbracoContext umbracoContext;
        private ServiceContext serviceContext;
        private IUmbracoSettingsSection settings;
        private RoutingContext routingContext;
        private IPublishedContent currentPage;
        private RouteData routeData;
        private UmbracoHelper umbracoHelper;
        private PublishedContentRequest publishedContentRequest;
        protected override ApplicationContext CreateApplicationContext()
        {
            // Overrides the base CreateApplicationContext to inject a completely stubbed servicecontext
            serviceContext = MockHelper.GetMockedServiceContext();
            var appContext = new ApplicationContext(
                new DatabaseContext(Mock.Of<IDatabaseFactory>(), Logger, SqlSyntax, GetDbProviderName()),
                serviceContext,
                CacheHelper,
                ProfilingLogger);
            return appContext;
        }
        private void TryBaseInitialize()
        {
            // Delegates to Umbraco.Tests initialization. Gives a nice hint about disposing the support class for each test.
            try
            {
                Initialize();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.StartsWith("Resolution is frozen"))
                    throw new Exception("Resolution is frozen. This is probably because UmbracoSupport.DisposeUmbraco wasn't called before another UmbracoSupport.SetupUmbraco call.");
            }
        }
        private void InitializeSettings()
        {
            // Stub up all the settings in Umbraco so we don't need a big app.config file.
            settings = SettingsForTests.GenerateMockSettings();
            SettingsForTests.ConfigureSettings(settings);
        }
        private void CreateCurrentPage()
        {
            // Stubs up the content used as current page in all contexts
            currentPage = Mock.Of<IPublishedContent>();
        }
        private void CreateRouteData()
        {
            // Route data is used in many of the contexts, and might need more data throughout your tests.
            routeData = new RouteData();
            //routeData.DataTokens.Add(Umbraco.Core.Constants.Web.PublishedDocumentRequestDataToken, UmbracoContext.PublishedContentRequest);
            //routeData.DataTokens.Add(Constants.Web.UmbracoRouteDefinitionDataToken, UmbracoContext.PublishedContentRequest);
        }
        private void CreateContexts()
        {
            // Surface- and RenderMvcControllers need a routing context to fint the current content.
            // Umbraco.Tests creates one and whips up the UmbracoContext in the process.
            routingContext = GetRoutingContext("http://localhost", -1, routeData, true, settings);
            umbracoContext = routingContext.UmbracoContext;
        }
        private void CreateHelper()
        {
            umbracoHelper = new UmbracoHelper(umbracoContext, currentPage);
        }
        private void InitializePublishedContentRequest()
        {
            // Some deep core methods fetch the published content request from routedata
            // others access it through the context
            // in any case, this is the one telling everyone which content is the current content.
            publishedContentRequest = new PublishedContentRequest(new Uri("http://localhost"), routingContext, settings.WebRouting, s => new string[0])
            {
                PublishedContent = currentPage,
                Culture = CultureInfo.CurrentCulture
            };
            umbracoContext.PublishedContentRequest = publishedContentRequest;
            var routeDefinition = new RouteDefinition
            {
                PublishedContentRequest = publishedContentRequest
            };
            routeData.DataTokens.Add("umbraco-route-def", routeDefinition);
        }
    }
}