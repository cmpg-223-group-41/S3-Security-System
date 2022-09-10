using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.BreachTypes
{
    public class EditModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public EditModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BreachType BreachType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BreachType == null)
            {
                return NotFound();
            }

            var breachtype =  await _context.BreachType.FirstOrDefaultAsync(m => m.ID == id);
            if (breachtype == null)
            {
                return NotFound();
            }
            BreachType = breachtype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BreachType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreachTypeExists(BreachType.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BreachTypeExists(int id)
        {
          return (_context.BreachType?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
