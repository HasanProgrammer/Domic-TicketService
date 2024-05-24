using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Exceptions;

namespace Domic.Domain.Ticket.ValueObjects;

public class Title : ValueObject
{
    public readonly string Value;

    /// <summary>
    /// 
    /// </summary>
    public Title() {}
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="InValidValueObjectException"></exception>
    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("فیلد عنوان الزامی می باشد !");

        if (value.Length is > 200 or < 5)
            throw new DomainException("فیلد عنوان نباید بیشتر از 200 و کمتر از 5 عبارت داشته باشد !");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}