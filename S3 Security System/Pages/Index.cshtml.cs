using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S3_Security_System.Areas.Identity.Data;
using S3_Security_System.Models;



namespace S3_Security_System.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly UserManager<S3_Security_SystemUser> _userManager;
        private readonly SignInManager<S3_Security_SystemUser> _signInManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly S3_Security_System.Data.S3_Security_SystemContext _context;

        public IndexModel(ILogger<IndexModel> logger, UserManager<S3_Security_SystemUser> userManager,
            SignInManager<S3_Security_SystemUser> signInManager, S3_Security_System.Data.S3_Security_SystemContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }
        public string? UserRole { get; set; }
        public IList<EntranceToken> EntranceToken { get; set; } = default!;
        public EntranceToken? TokenAccess { get; set; }

        public void OnGet(S3_Security_SystemUser user)
        {
           

            if (_context.EntranceToken != null)
            {
                EntranceToken = _context.EntranceToken
                .Include(e => e.S3_Security_SystemUser).ToList()
                .Where(e => e.S3_Security_SystemUser.Id == _userManager.GetUserId(User) & e.TimeOfExit == null).ToList();

                if (EntranceToken.Any())
                {
                    TokenAccess = EntranceToken.First();
                }
                
            }
            
        }
    }
}