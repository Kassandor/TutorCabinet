namespace TutorCabinet.Core.ValueObjects;

/// <summary>
/// Значимый объект Email
/// </summary>
public sealed class Email : IEquatable<Email>
{
    public string Address { get; }

    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !address.Contains('@'))
            throw new ArgumentException("Недопустимый формат email", nameof(address));
        Address = address;
    }

    public override bool Equals(object? obj) => Equals(obj as Email);
    public bool Equals(Email? other) => other != null && Address == other.Address;
    public override int GetHashCode() => Address.GetHashCode();
    public override string ToString() => Address;
}