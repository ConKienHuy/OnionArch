using System.ComponentModel.DataAnnotations;

namespace Core.Entites;

public class User
{
    public int UserStatus;

    [Key] public int UserID { get; set; }

    [Required] public string? UserName { get; set; }

    [Required] public string? UserPassword { get; set; }

    [Required] public string? UserEmail { get; set; }
}