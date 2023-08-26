namespace OnlineLibraryAPI.Domain.Constants;
/// <summary>
///  Статический класс с константами для токенов
/// </summary>
public static class TokenConstants
{
    /// <summary>
    ///  Издатель токена
    /// </summary>
    public static string Issuer { get; } = "OnlineLibraryAPI";
    /// <summary>
    ///  Секретный ключ для токенов
    /// </summary>
    public static string TokenKey = "_MyGigaSecretKey_";
    /// <summary>
    ///  Время жизни access-токена в секундах
    /// </summary>
    public static int AccessTokenExpires { get; } = 900;
    /// <summary>
    ///  Время жизни refresh-токена в секундах
    /// </summary>
    public static int RefreshTokenExpires { get; } = 1800;
}
