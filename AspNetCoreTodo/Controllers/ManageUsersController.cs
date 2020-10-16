using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //you used roleManager it should be UserManger

            var admins = (await _userManager.GetUsersInRoleAsync("Administrator")).ToArray();
            var everyone = await _userManager.Users.ToArrayAsync();
            var model = new ManageUsersViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };

            return View(model);

            //            var admins = (
            //                await   .CreateAsync(
            //new IdentityRole(Constants.AdministratorRole))

            //            //     await _userManager
            //            // .GetUsersInRoleAsync("Administrator")
            //            )
            //            .ToArray();

            //            var everyone = await _userManager.Users
            //                .ToArrayAsync();

            //            var model = new ManageUsersViewModel
            //            {
            //                Administrators = admins,
            //                Everyone = everyone
            //            };

            //            return View(model);
        }
    }
}