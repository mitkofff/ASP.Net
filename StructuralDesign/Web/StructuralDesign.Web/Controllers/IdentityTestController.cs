﻿namespace StructuralDesign.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Data.Models;

    [Authorize]
    [Authorize(Roles = "Administrator")]
    public class IdentityTestController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public IdentityTestController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Create()
        {
            var user = new ApplicationUser
            {
                Email = "mitkofff1@gmail.com",
                FirstName = "Dim",
                LastName = "Kar",
                CompanyName = "MicrosoftDesign",
                PhoneNumber = "123546842",
                UserName = "mitkofff",
            };
            var result = this.userManager.CreateAsync(user, "241897-aA");
            return this.Json(result);
        }

        public IActionResult Login()
        {
            var result = this.signInManager.PasswordSignInAsync("mitkofff", "241897-aA", true, true);
            return this.Json("ok");
        }

        public IActionResult LogOut()
        {
            var result = this.signInManager.SignOutAsync();
            return this.Redirect("/");
        }

        public async Task<IActionResult> WhoAmI()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var userEmail = await this.userManager.GetEmailAsync(user);
            return this.Json(userEmail);
        }

    }
}
