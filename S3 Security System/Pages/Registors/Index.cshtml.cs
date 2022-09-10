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
    public class IndexModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public IndexModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

        public IList<Registor> Registor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Registor != null)
            {
                Registor = await _context.Registor
                .Include(r => r.Teacher).ToListAsync();
            }
        }
    }
}
