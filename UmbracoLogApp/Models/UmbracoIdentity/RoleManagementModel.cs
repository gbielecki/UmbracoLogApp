using System.Collections.Generic;

namespace UmbracoLogApp.Models.UmbracoIdentity
{
    public class RoleManagementModel
    {
        public IEnumerable<string> AvailableRoles { get; set; }
        public IEnumerable<string> AssignedRoles { get; set; }
    }
}
