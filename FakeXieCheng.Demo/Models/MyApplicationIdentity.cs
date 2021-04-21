using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Models
{
    public class MyApplicationIdentity: IdentityUser
    {
        public string Address { get; set; }
        //shopRecordf
        //orderForm
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin <string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public ICollection <IdentityUserRole<string>> UserRoles { get; set; }
    }
}
