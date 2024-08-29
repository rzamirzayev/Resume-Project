using Domain.Entities.Membership;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using System.Security.Claims;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ResumeUser> userManager;
        private readonly SignInManager<ResumeUser> signInManager;
        private readonly IEmailService emailService;

        public AccountController(UserManager<ResumeUser> userManager,SignInManager<ResumeUser> signInManager,IEmailService emailService) {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailService = emailService;
                }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string email,string password)
        {
            var user = new ResumeUser
            {
                UserName = email,
                Email = email

            };
            var result=await userManager.CreateAsync(user,password);
            if(!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View();
            }
            var token= await userManager.GenerateEmailConfirmationTokenAsync(user);

            string link = $"{Request.Scheme}://{Request.Host}/approve-account?token={token}";

            string message = $"Hesabi tesdiq etmek ucun <a href=\"{link}\">link</a>'le davem edin";

            await emailService.SendEmail(email, "Approve Registration", message);
            return RedirectToAction("Index","Home");
        }

        [Route("/signin.html")]
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        [Route("/signin.html")]
        public async Task<IActionResult> Signin(string email,string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
            {
                ModelState.AddModelError("User", "username or password incorrect!");
                goto l1;
            }
            var result=await signInManager.CheckPasswordSignInAsync(user, password, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("User", "please try again adter 3seconsds!");
                goto l1;
            }
            else if (!result.Succeeded)
            {
                ModelState.AddModelError("User", "username or password incorrect!");
                goto l1;
            }
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("User", "Email not confirmed");
                goto l1;
            }

            //await signInManager.SignInAsync(user,true);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
            var now=DateTime.UtcNow;
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent= true,
                IssuedUtc= now,
                ExpiresUtc= now.AddMinutes(10)
            };
            await Request.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,properties);

            var callbackUrl = Request.Query["ReturnUrl"];
            if (!string.IsNullOrWhiteSpace(callbackUrl))
            {
                return Redirect(callbackUrl);

            }
            return RedirectToAction("Index", "Home");
        l1:
            return View();
        }


        [Route("/approve-account")]
        public async Task<IActionResult> RegisterConfirm(string token)
        {
            var user = await userManager.FindByEmailAsync("rza.mirzeyev12@gmail.com");

            await userManager.ConfirmEmailAsync(user, token);

            return RedirectToAction("Index", "Home");
        }
    }
}
