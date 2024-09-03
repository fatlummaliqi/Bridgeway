namespace Bridgeway;

/// <summary>
/// Indicates that a class represents a broker and assigns it an alias.
/// </summary>
/// <remarks>
/// This attribute is used to specify an alias for a broker class, which can be useful for 
/// identifying or referencing the broker in various contexts.
/// </remarks>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class BrokerAliasAttribute : Attribute
{
    /// <summary>
    /// Gets the alias for the broker.
    /// </summary>
    public string Alias { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrokerAliasAttribute"/> class with the specified alias.
    /// </summary>
    /// <param name="alias">
    /// The alias to be assigned to the broker. Must not be null or whitespace.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown when the <paramref name="alias"/> is null or whitespace.
    /// </exception>
    public BrokerAliasAttribute(string alias)
    {
        if (string.IsNullOrWhiteSpace(alias)) throw new ArgumentException("Broker can not be marked with null or empty alis.");

        Alias = alias;
    }
}
