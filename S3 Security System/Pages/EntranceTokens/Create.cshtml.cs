using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using S3_Security_System.Areas.Identity.Data;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.EntranceTokens
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<S3_Security_SystemUser> _userManager;
        private readonly SignInManager<S3_Security_SystemUser> _signInManager;
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public CreateModel(S3_Security_System.Data.S3_Security_SystemContext context, UserManager<S3_Security_SystemUser> userManager,
            SignInManager<S3_Security_SystemUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult OnGet(S3_Security_SystemUser user)
        {
        ViewData["S3_Security_SystemUserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public EntranceToken EntranceToken { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            EntranceToken.S3_Security_SystemUserId = _userManager.GetUserId(User);
            EntranceToken.S3_Security_SystemUser = await _userManager.GetUserAsync(User);
            EntranceToken.DateObtained = DateTime.Now;
            EntranceToken.AccessGranted = true;
            EntranceToken.TimeOfEntry = DateTime.Now;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (!ModelState.IsValid || _context.EntranceToken == null || EntranceToken == null)
            {
                return Page();
            }


            _context.EntranceToken.Add(EntranceToken);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
