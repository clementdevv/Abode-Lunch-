
using AbodeLunch.Domain.Models;

namespace AbodeLunch.Domain.Host.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public Guid Value { get; }

    private MenuReviewId(Guid value) 
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}