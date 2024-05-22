using Microsoft.AspNetCore.Identity;

namespace JobFinder.Domain.Entities.Concretes;

public class AppUser : IdentityUser {

    // Fields

    public string FullName { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation Property

    public virtual ICollection<Jobs> Jobs { get; set; }
}