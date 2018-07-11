using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UmbracoLogApp.Controllers;
using UmbracoLogApp.Models.FormModels;
using UmbracoLogApp.Services.Interfaces;
using Xunit;
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace UmbracoLogApp._2.Test
{
    public class LoginSurfaceControllerTest
    {
        private UmbracoSupport support = new UmbracoSupport();

        [Fact]
        public void can_create_login_surface_controller()
        {
            support.SetupUmbraco();
            var loginServiceMock = new Mock<IMemberLoginService>();

            var cos = new LoginSurfaceController(loginServiceMock.Object);
            support.DisposeUmbraco();

            Assert.NotNull(cos);
        }

        [Fact]
        public void login_surface_controller_return_view()
        {
            support.SetupUmbraco();
            var loginServiceMock = new Mock<IMemberLoginService>();
            var loginForm = new LoginFormModel() { Email = "test@test.te", Password = "test" };

            var cos = new LoginSurfaceController(loginServiceMock.Object);
            support.DisposeUmbraco();

            Assert.Equal(typeof(PartialViewResult), cos.HandleLogin(loginForm).GetType());
        }
    }
}
