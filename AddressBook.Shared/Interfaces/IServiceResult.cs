using AddressBook.Shared.Enums;

namespace AddressBook.Shared.Interfaces;

public interface IServiceResult
{
    /// <summary>
    /// Gets/sets the result of an operation.
    /// </summary>
    object Result { get; set; }

    /// <summary>
    /// Represents the result of a service operation.
    /// </summary>
    ResultStatus Status { get; set; }   
}