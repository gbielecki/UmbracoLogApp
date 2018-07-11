using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoLogApp.Controllers;
using UmbracoLogApp.Models.FormModels;
using UmbracoLogApp.Services.Interfaces;
using Xunit;

namespace UmbracoLogApp._2.Test
{
    public class RegisterSurfaceControllerTest
    {
        private UmbracoSupport support = new UmbracoSupport();

        [Fact]
        public void can_create_register_surface_controller()
        {
            support.SetupUmbraco();
            var loginServiceMock = new Mock<IMemberRegistrationService>();

            var cos = new RegistrationSurfaceController(loginServiceMock.Object);
            support.DisposeUmbraco();

            Assert.NotNull(cos);
        }

        [Fact]
        public void register_surface_controller_return_view()
        {
            support.SetupUmbraco();
            var registerServiceMock = new Mock<IMemberRegistrationService>();
            var registerForm = new RegistrationFormModel() {PasswordConfirmation= "test", Email = "test@test.te", Password = "test" };
            registerServiceMock
                .Setup(service => service.RegisterNewMember(registerForm))
                .Returns(new Models.RegistrationResult() {
                    Success = false,
                    Errors = new List<string>() { "Error" }
                });

            var cos = new RegistrationSurfaceController(registerServiceMock.Object);
            support.DisposeUmbraco();

            Assert.Equal(typeof(RedirectToUmbracoPageResult), cos.HandleRegistration(registerForm).GetType());
        }
    }
}
