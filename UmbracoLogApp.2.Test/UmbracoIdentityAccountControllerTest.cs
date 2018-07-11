using Microsoft.AspNet.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoIdentity.Models;
using UmbracoLogApp.Controllers;
using UmbracoLogApp.Models.UmbracoIdentity;
using Xunit;

namespace UmbracoLogApp._2.Test
{
    public class UmbracoIdentityAccountControllerTest
    {
        private UmbracoSupport support = new UmbracoSupport();

        [Fact]
        public void can_create_umbraco_identity_surface_controller()
        {
            support.SetupUmbraco();

            var controller = new UmbracoIdentityAccountController();
            support.DisposeUmbraco();

            Assert.NotNull(controller);
        }

        //[Fact]
        //public void umbraco_identity_surface_controller_return_to_current_umbraco_page()
        //{

        //    support.SetupUmbraco();


        //    //var userStore = new Mock<IUserStore<UmbracoApplicationMember>>();
        //    //var m_userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object);
        //    ////    var userStoreMock = new Mock<IUserStore<IdentityMember(int,IdentityMemberLogin<int>, IdentityMemberRole<int>, IdentityMemberClaim<int>)>>();
        //    ////    return new Mock<UserManager<ApplicationUser>>(
        //    ////        userStoreMock.Object, null, null, null, null, null, null, null, null);
        //    ////}
        //    //var userStore = new UserManager<UmbracoApplicationMember>();
        //    //var loginServiceMock = new Mock<IMemberLoginService>();
        //    //var userStoreMock = new Mock<IUserStore<UmbracoApplicationMember>>();
        //    //var cos = new UserManager<UmbracoApplicationMember>(userStoreMock);

        //    //var mockMembershipProvider = new Mock<System.Web.Security.MembershipProvider>();
        //    var postRedirectModel = new PostRedirectModel() { RedirectUrl = null };

        //    var controller = new UmbracoIdentityAccountController();
        //    support.DisposeUmbraco();

        //    Assert.Equal(typeof(RedirectToUmbracoPageResult), controller.HandleLogout(postRedirectModel).GetType());
        //}
    }
}
