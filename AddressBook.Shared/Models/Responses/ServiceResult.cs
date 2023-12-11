using AddressBook.Shared.Enums;
using AddressBook.Shared.Interfaces;

namespace AddressBook.Shared.Models.Responses;

public class ServiceResult : IServiceResult
{
    public object Result { get; set; } = null!;
    public ResultStatus Status { get; set; }
}
