using Microsoft.AspNetCore.Identity;
namespace textilsalas.Models;
public class ApplicationUser : IdentityUser
{
    public string NombreCompleto { get; set; }
}
