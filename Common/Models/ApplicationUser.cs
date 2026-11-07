using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Common.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [PersonalData]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [PersonalData]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
}
