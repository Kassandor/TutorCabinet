namespace TutorCabinet.Core.Interfaces;

/// <summary>
/// Сервис для хеширования паролей
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Хеширование сырого пароля
    /// </summary>
    /// <param name="password"><see cref="string"/></param>
    /// <returns></returns>
    string Hash(string password);

    /// <summary>
    /// Верификация пароля
    /// </summary>
    /// <param name="password"><see cref="String"/></param>
    /// <param name="passwordHash">Хеш пароля</param>
    /// <returns></returns>
    bool Verify(string password, string passwordHash);
}
