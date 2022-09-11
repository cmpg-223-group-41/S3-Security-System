using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S3_Security_System.Areas.Identity.Data;
using S3_Security_System.Models;



namespace S3_Security_System.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<S3_Security_SystemUser> _userManager;
        private readonly SignInManager<S3_Security_SystemUser> _signInManager;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, UserManager<S3_Security_SystemUser> userManager,
            SignInManager<S3_Security_SystemUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public string? UserRole { get; set; }

        public void OnGet(S3_Security_SystemUser user)
        {
            
        }
    }
}