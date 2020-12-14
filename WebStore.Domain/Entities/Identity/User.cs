using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public const string Administrator = "admin";

        public const string DefaultAdminPassword = "admin";

        public string Description { get; set; }
    }

    public class Role : IdentityRole
    {
        public const string Administrator = "Administrators";

        public const string User = "Users";

        public string Description { get; set; }
    }
}
