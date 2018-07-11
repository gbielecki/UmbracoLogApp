using GDev.Umbraco.Test;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Umbraco.Core.Services;
using Umbraco.Web.Security;
using UmbracoLogApp.Controllers;
using UmbracoLogApp.Models.FormModels;
using UmbracoLogApp.Services.Interfaces;
using Xunit;

namespace ClassLibrary1
{
    public class LoginSurfaceControllerTest
    {
        //private ContextMocker _mocker;

        //[Fact]
        //public void CanCreateLoginSurfaceController()
        //{
        //    _mocker = new ContextMocker();
        //    //var mockRepository MockRepository
        //    var loginServiceMock = new Mock<IMemberLoginService>();
        //    var memberServiceMock = new Mock<IMemberService>();
        //    var serviceContext = new ServiceContext(memberService: memberServiceMock.Object);
        //    //var mockMembershipProvider = new Mock<MembershipProvider>
        //    //var servicesMock = new Mock<ServiceContext>();
        //    var lhoingForm = new LoginFormModel() { Email = "test@test.te", Password = "test" };
        //    loginServiceMock.Setup(loginService => loginService.SetMemberService(serviceContext.MemberService));
        //    loginServiceMock.Setup(loginService => loginService.SetMembershipHelper(new MembershipHelper(_mocker.UmbracoContextMock, Mock.Of<MembershipProvider>(), Mock.Of<RoleProvider>())));
        //    var cos = new LoginSurfaceController(loginServiceMock.Object);
        //    Assert.Equal(2, cos.HandleLogin(lhoingForm));
        //}
    }
}
