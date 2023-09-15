namespace OnlineLibraryAPI.Domain.Entities;

public class RefreshToken
{
    public Guid Token { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Expires { get; set; }
    public User User { get; set; } = null!;
}
