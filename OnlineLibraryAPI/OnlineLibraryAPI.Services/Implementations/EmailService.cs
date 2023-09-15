using Microsoft.EntityFrameworkCore;
using OnlineLibraryAPI.Services.Abstractions;
using OnlineLibraryAPI.Services.Persistence;

namespace OnlineLibraryAPI.Services.Implementations;

public class EmailService : IEmailService
{
    private AppDbContext DbContext { get; set; }
    public EmailService(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public async Task<bool> IsExistingEmailAsync(string email)
    {
        return await DbContext.Users.FirstOrDefaultAsync(u => u.Email == GetNormalize(email)) != null;
    }

    public string GetNormalize(string email)
    {
        return email.ToLower().Normalize();
    }
}
