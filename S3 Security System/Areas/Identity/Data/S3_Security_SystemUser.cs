using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using S3_Security_System.Models;

namespace S3_Security_System.Areas.Identity.Data;

// Add profile data for application users by adding properties to the S3_Security_SystemUser class
public class S3_Security_SystemUser : IdentityUser
{
    [Required]
    public string Role { get; set; }
    public virtual Staff? Staff { get; set; }
    public virtual Student? Student { get; set; }
    public virtual Visitor? Visitor { get; set; }

}

