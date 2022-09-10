using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.Breaches
{
    public class DeleteModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public DeleteModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Breach Breach { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Breach == null)
            {
                return NotFound();
            }

            var breach = await _context.Breach.FirstOrDefaultAsync(m => m.ID == id);

            if (breach == null)
            {
                return NotFound();
            }
            else 
            {
                Breach = breach;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Breach == null)
            {
                return NotFound();
            }
            var breach = await _context.Breach.FindAsync(id);

            if (breach != null)
            {
                Breach = breach;
                _context.Breach.Remove(Breach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
