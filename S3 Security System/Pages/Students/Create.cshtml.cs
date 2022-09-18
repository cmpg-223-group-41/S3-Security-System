using System;
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
using S3_Security_System.Models;

namespace S3_Security_System.Pages.Students
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
        
        ViewData["StudentCityId"] = new SelectList(_context.City, "ID", "CityName");
        ViewData["StudentProvinceId"] = new SelectList(_context.Province, "ID", "ProvinceName");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Create user
            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, Password);

            // link user to staff instance

            Student.StudentCity = await _context.City.FindAsync(Student.StudentCityId);
            Student.StudentProvince = await _context.Province.FindAsync(Student.StudentProvinceId);
            Student.S3_Security_SystemUser = user;
            Student.S3_Security_SystemUserId = user.Id;


            if (!ModelState.IsValid || _context.Students == null || Student == null)
            {
                return Page();
            }

            try
            {
                user.Role = "Student";
                await _userManager.UpdateAsync(user);
                _context.Students.Add(Student);
                await _context.SaveChangesAsync();
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
