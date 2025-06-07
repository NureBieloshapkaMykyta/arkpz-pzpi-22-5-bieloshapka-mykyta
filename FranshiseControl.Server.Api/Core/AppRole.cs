using Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core;

public class AppRole : IdentityRole<long>
{
    public required string Description { get; set; }
    public AppRoleType Role { get; set; }
}
