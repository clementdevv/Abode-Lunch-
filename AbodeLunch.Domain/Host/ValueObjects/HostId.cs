
using AbodeLunch.Domain.Models;

namespace AbodeLunch.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value) 
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}