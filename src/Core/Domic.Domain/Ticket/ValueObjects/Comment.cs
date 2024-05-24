using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Exceptions;

namespace Domic.Domain.Ticket.ValueObjects;

public class Comment : ValueObject
{
    public readonly string Value;

    /// <summary>
    /// 
    /// </summary>
    public Comment() {}
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="InValidValueObjectException"></exception>
    public Comment(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("فیلد توضیحات الزامی می باشد !");

        if (value.Length is > 2000 or < 10)
            throw new DomainException("فیلد توضیحات نباید بیشتر از 2000 و کمتر از 10 عبارت داشته باشد !");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}