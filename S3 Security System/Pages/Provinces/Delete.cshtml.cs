using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.Provinces
{
    public class DeleteModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public DeleteModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Province Province { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Province == null)
            {
                return NotFound();
            }

            var province = await _context.Province.FirstOrDefaultAsync(m => m.ID == id);

            if (province == null)
            {
                return NotFound();
            }
            else 
            {
                Province = province;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Province == null)
            {
                return NotFound();
            }
            var province = await _context.Province.FindAsync(id);

            if (province != null)
            {
                Province = province;
                _context.Province.Remove(Province);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
