﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using S3_Security_System.Areas.Identity.Data;
using S3_Security_System.Data;
using S3_Security_System.Migrations;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.Staffs
{
    public class CreateModel : PageModel
    {
        private readonly SignInManager<S3_Security_SystemUser> _signInManager;
        private readonly UserManager<S3_Security_SystemUser> _userManager;
        private readonly IUserStore<S3_Security_SystemUser> _userStore;
        private readonly IUserEmailStore<S3_Security_SystemUser> _emailStore;
        private readonly ILogger<CreateModel> _logger;
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public CreateModel(UserManager<S3_Security_SystemUser> userManager,
            IUserStore<S3_Security_SystemUser> userStore,
            SignInManager<S3_Security_SystemUser> signInManager,
            ILogger<CreateModel> logger, S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _emailStore = GetEmailStore();
            _logger = logger;
            _context = context;
        }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [BindProperty]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [BindProperty]
        public string Email { get; set; }

        public IActionResult OnGet()
        {
        ViewData["PositionId"] = new SelectList(_context.Position, "ID", "PositionName");
        ViewData["StaffCityId"] = new SelectList(_context.City, "ID", "CityName");
        ViewData["StaffProvinceId"] = new SelectList(_context.Province, "ID", "ProvinceName");
            return Page();
        }

        [BindProperty]
        public Staff Staff { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Create user
            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, Password);

            // link user to staff instance

            Staff.StaffCity = await _context.City.FindAsync(Staff.StaffCityId);
            Staff.StaffProvince = await _context.Province.FindAsync(Staff.StaffProvinceId);
            Staff.Position = await _context.Position.FindAsync(Staff.PositionId);
            Staff.S3_Security_SystemUser = user;
            Staff.S3_Security_SystemUserId = user.Id;
            

            if (!ModelState.IsValid || _context.Staff == null || Staff == null)
            {
                return Page();
            }
            try
            {
                if (result.Succeeded)
                {
                    // Create Visitor and assign to S3_Security_SystemUser
                    user.Role = "Staff";
                    await _userManager.UpdateAsync(user);
                    _context.Staff.Add(Staff);
                    await _context.SaveChangesAsync();

                   _logger.LogInformation("User created a new account with password.");

                }
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(S3_Security_SystemUser)}'. ");
            }

            
                

            return RedirectToPage("./Index");
        }

        private S3_Security_SystemUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<S3_Security_SystemUser>();

            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(S3_Security_SystemUser)}'. " +
                    $"Ensure that '{nameof(S3_Security_SystemUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private IUserEmailStore<S3_Security_SystemUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<S3_Security_SystemUser>)_userStore;
        }
    }
}
