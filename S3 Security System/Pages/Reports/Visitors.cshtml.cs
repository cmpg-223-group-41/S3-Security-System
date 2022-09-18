using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Data;
using S3_Security_System.Models;

namespace S3_Security_System.Pages.Reports
{
    public class VisitorsModel : PageModel
    {
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public VisitorsModel(S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _context = context;
        }

        public IList<EntranceToken> EntranceToken { get;set; } = default!;

        public async Task OnGetAsync(DateTime? reportDate)
        {
            if (reportDate == null) { reportDate = DateTime.Today; }
            if (_context.EntranceToken != null)
            {

                EntranceToken = await _context.EntranceToken
                    .Include(e => e.S3_Security_SystemUser)
                    .Include(e => e.S3_Security_SystemUser.Visitor)
                    .Where(e => e.S3_Security_SystemUser.Role == "Visitor" & e.DateObtained == reportDate).ToListAsync();
            }

            ViewData["reportDate"] = reportDate.Value.ToShortDateString();
        }
    }
}
