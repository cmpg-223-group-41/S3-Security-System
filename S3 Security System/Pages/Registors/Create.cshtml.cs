using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.Registors
{
    public class CreateModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public CreateModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["S3_Security_SystemUserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Registor Registor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Registor == null || Registor == null)
            {
                return Page();
            }

            _context.Registor.Add(Registor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
