using AddressBook.Shared.Models;

namespace AddressBook.Shared.Interfaces;

public interface IAddressBook
{
    IServiceResult AddContactToList(IContact contactModel);
    IEnumerable<IContact> GetContactFromList();
    IServiceResult DeleteContactFromList(IContact contactModel );
}
