using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
<<<<<<< HEAD
=======

>>>>>>> 03bf9151ed633a486e7b583651722e2a0d972290

namespace AspNetCoreTodo.Models
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrators { get; set; }

        public IdentityUser[] Everyone { get; set;}
    }
}
