namespace OnlineLibraryAPI.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;

    public Role Role { get; set; } = null!;
    public List<RefreshToken> RefreshTokens { get; set; } = null!;
}
