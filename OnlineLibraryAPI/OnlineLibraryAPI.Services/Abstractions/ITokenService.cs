using OnlineLibraryAPI.Domain.Entities;

namespace OnlineLibraryAPI.Services.Abstractions;
/// <summary>
///  Интерфейс сервиса для работы с access- и refresh- токенами
/// </summary>
public interface ITokenService
{
    /// <summary>
    ///  Создание access-токена
    /// </summary>
    public string CreateAccessToken(User user);
}