using Microsoft.AspNetCore.Identity;

public class Role : IdentityRole
{
    public Role() : base() { } // Podrazumevani konstruktor

    public Role(string roleName) : base(roleName) { }
}
