using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using nctutorial.Data;

namespace nctutorial.Controllers
{
    public class FormController : Controller
    {
        protected SignInManager<AppUser> signInManager;

        public FormController(SignInManager<AppUser> _signInManager)
        {
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string ReturnUrl)
        {
            //await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            var result = await signInManager.PasswordSignInAsync("michal", "Password!23", true, true);

            if (result.Succeeded)

                if (ReturnUrl != null)
                    return Redirect(ReturnUrl);
                else
                    return Redirect("/");
            return Content("Fail", "text/html");

        }
    }
}