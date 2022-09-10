using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.BreachTypes
{
    public class DetailsModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public DetailsModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

      public BreachType BreachType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BreachType == null)
            {
                return NotFound();
            }

            var breachtype = await _context.BreachType.FirstOrDefaultAsync(m => m.ID == id);
            if (breachtype == null)
            {
                return NotFound();
            }
            else 
            {
                BreachType = breachtype;
            }
            return Page();
        }
    }
}
