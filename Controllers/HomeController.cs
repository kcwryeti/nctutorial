using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nctutorial.Data;

namespace nctutorial.Controllers
{
    public class HomeController : Controller
    {
     
        private ApplicationDbContext context;
        protected UserManager<AppUser> userManager;
        protected SignInManager<AppUser> signInManager;


        public HomeController(ApplicationDbContext _context, UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            context = _context;
            userManager = _userManager;
            signInManager = _signInManager;
        }


        public IActionResult Index()
        {

            context.Database.EnsureCreated();
            var sql = context.Database.GenerateCreateScript();
            ViewData["sql"] = sql;
            return View();
        }

        [Route("create")]
        public async Task<IActionResult> CreateUser()
        {
            IdentityResult result = await userManager.CreateAsync(new AppUser { 
                UserName = "natalia",
                Email = "natalia@example.com"
            
            }, "p");
            
            if (result.Succeeded)
                return Content("User created","text/html");
            return Content("Fail","text/html");

        }

        [Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"Private area. Welcome : { HttpContext.User.Identity.Name }");
        }


        [Route("logout")]
        public async Task<IActionResult> Logout(string ReturnUrl)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            
            return Redirect("/");
        }

        [Route("login")]
        public async Task<IActionResult> Login(string ReturnUrl) 
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            var result = await signInManager.PasswordSignInAsync("michal","Password!23",true, true);

            if (result.Succeeded)
           
                if (ReturnUrl != null)
                    return Redirect(ReturnUrl);
                else
                    return Redirect("/");
            return Content("Fail","text/html");

        }
        
        [Route("page")]
        public IActionResult Page()
        {
            return View();
        }
    }
}
