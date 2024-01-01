using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Identity;

namespace eCommerceApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    public bool Status { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(3);
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    // #####

    [PersonalData]
    public string FirstName { get; set; }


    [PersonalData]
    public string LastName { get; set; }
}

