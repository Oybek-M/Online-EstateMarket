using Microsoft.AspNetCore.Identity;

namespace Online_EstateMarket.Data.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; }

    public string PhonrNumber { get; set; }

    public string Password { get; set; }

    public int Age { get; set; }

    public Role Role { get; set; } = Role.User;

    public string Address { get; set; }

    public List<Order> Orders { get; set; } = new();
}

public enum Role
{
    SuperAdmin,
    Admin,
    User
}