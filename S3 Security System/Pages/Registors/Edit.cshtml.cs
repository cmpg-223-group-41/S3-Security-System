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

namespace S3_Security_System.Pages.Registors
{
    public class EditModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public EditModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Registor Registor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Registor == null)
            {
                return NotFound();
            }

            var registor =  await _context.Registor.FirstOrDefaultAsync(m => m.ID == id);
            if (registor == null)
            {
                return NotFound();
            }
            Registor = registor;
           ViewData["TeacherId"] = new SelectList(_context.Staff, "Id", "Id");
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

            _context.Attach(Registor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistorExists(Registor.ID))
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

        private bool RegistorExists(int id)
        {
          return (_context.Registor?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
