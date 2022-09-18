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

namespace S3_Security_System.Pages.Breaches
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<S3_Security_SystemUser> _userManager;
        private readonly SignInManager<S3_Security_SystemUser> _signInManager;
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public CreateModel(S3_Security_System.Data.S3_Security_SystemContext context, UserManager<S3_Security_SystemUser> userManager,
            SignInManager<S3_Security_SystemUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BreachTypeId"] = new SelectList(_context.BreachType, "ID", "BreachTypeName");
            return Page();
        }

        [BindProperty]
        public Breach Breach { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Breach.S3_Security_SystemUserId = _userManager.GetUserId(User);
            Breach.S3_Security_SystemUser = await _userManager.GetUserAsync(User);
            Breach.BreachType = await _context.BreachType.FindAsync(Breach.BreachTypeId);
            Breach.DateAndTime = DateTime.Now;
            
            if (!ModelState.IsValid || _context.Breach == null || Breach == null)
            {
                return Page();
            }
            _context.Breach.Add(Breach);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
