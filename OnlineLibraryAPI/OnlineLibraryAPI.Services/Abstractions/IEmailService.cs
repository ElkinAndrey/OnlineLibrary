namespace OnlineLibraryAPI.Services.Abstractions;
/// <summary>
///  Интерфейс сервиса для работы с email
/// </summary>
public interface IEmailService
{
    /// <summary>
    ///  Проверка email на существование в базе данных с нормализацией
    /// </summary>
    /// <param name="nonNormalizedEmail">Ненормализовання электронная почта</param>>
    public Task<bool> IsExistingEmailAsync(string nonNormalizedEmail);
    /// <summary>
    ///  Получение нормализованной версии электронной почты
    /// </summary>
    /// /// <param name="email">Электронная почта</param>>
    public string GetNormalize(string email);
}
