using AddressBook.Shared.Enums;

namespace AddressBook.Shared.Interfaces;

public interface IServiceResult
{
    object Result { get; set; }
    ResultStatus Status { get; set; }   
}
