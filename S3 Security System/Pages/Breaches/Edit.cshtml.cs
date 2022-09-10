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

namespace S3_Security_System.Pages.Breaches
{
    public class EditModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public EditModel(S3_Security_System.Data.S3_Security_SystemContext context)
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

            var breach =  await _context.Breach.FirstOrDefaultAsync(m => m.ID == id);
            if (breach == null)
            {
                return NotFound();
            }
            Breach = breach;
           ViewData["BreachTypeId"] = new SelectList(_context.Set<BreachType>(), "ID", "BreachTypeName");
           ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id");
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

            _context.Attach(Breach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreachExists(Breach.ID))
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

        private bool BreachExists(int id)
        {
          return (_context.Breach?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
