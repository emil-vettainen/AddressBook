namespace AddressBook.Shared.Interfaces;

internal interface IFileService
{
    bool AddContactToFile(string content);
    bool DeleteContactFromFile(IContact contact);
    string GetContactFromFile();
}
