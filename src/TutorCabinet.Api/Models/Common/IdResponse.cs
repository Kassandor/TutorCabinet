namespace TutorCabinet.Api.Models.Common;

/// <summary>
/// Ответ API содержащий <see cref="Guid"/>/>
/// </summary>
/// <param name="Id"><see cref="Guid"/></param>
public sealed record IdResponse(Guid Id);
