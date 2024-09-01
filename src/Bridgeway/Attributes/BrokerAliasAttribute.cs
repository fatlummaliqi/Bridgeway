namespace Bridgeway;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class BrokerAliasAttribute : Attribute
{
    public string Alias { get; }

    public BrokerAliasAttribute(string alias)
    {
        if (string.IsNullOrWhiteSpace(alias)) throw new ArgumentException("Broker can not be marked with null or empty alis.");

        Alias = alias;
    }
}
