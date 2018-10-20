using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ETennis2.Model;
using ETennis2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ETennis2.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<TennisUser> _signInManager;
        private readonly UserManager<TennisUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<TennisRole> _roleManager;

        public RegisterModel(
               UserManager<TennisUser> userManager,
            SignInManager<TennisUser> signInManager,
            RoleManager<TennisRole> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Register As:")]
            public string UserInputRole { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            //added user data
            [DataType(DataType.Text)]
            [Display(Name = "Nick Name")]
            public string Nickname { get; set; }

            [Display(Name = "Birth Date")]
            [DataType(DataType.Date)]
            public DateTime Dob { get; set; }

            public string Gender { get; set; }
            public string Biography { get; set; }
        }

        [Authorize(Roles = "Member")]
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new TennisUser {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Nickname = Input.Nickname,
                    Dob = Input.Dob,
                    Gender = Input.Gender,
                    Biography = Input.Biography
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                { 
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _userManager.AddToRoleAsync(user, "Member");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
