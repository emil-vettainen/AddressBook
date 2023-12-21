namespace AddressBook.Shared.Interfaces
{
    public interface IAddressBookService
    {
        IServiceResult AddContactToList(IContact contactModel);
        IServiceResult DeleteContactFromList(IContact contactModel);
        IEnumerable<IContact> GetContactFromList();
        IServiceResult UpdateContactToList(IContact contactModel);
    }
}