using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.Visitors
{
    public class IndexModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public IndexModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

        public IList<Visitor> Visitor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Visitors != null)
            {
                Visitor = await _context.Visitors
                .Include(v => v.S3_Security_SystemUser).ToListAsync();
            }
        }
    }
}
