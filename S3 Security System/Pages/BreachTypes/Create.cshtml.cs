using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.BreachTypes
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
            return Page();
        }

        [BindProperty]
        public BreachType BreachType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BreachType == null || BreachType == null)
            {
                return Page();
            }

            _context.BreachType.Add(BreachType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
