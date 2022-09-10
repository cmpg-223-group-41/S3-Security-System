using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.Registors
{
    public class DetailsModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public DetailsModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

      public Registor Registor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Registor == null)
            {
                return NotFound();
            }

            var registor = await _context.Registor.FirstOrDefaultAsync(m => m.ID == id);
            if (registor == null)
            {
                return NotFound();
            }
            else 
            {
                Registor = registor;
            }
            return Page();
        }
    }
}
