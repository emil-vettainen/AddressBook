using AddressBook.Shared.Models;

namespace AddressBook.Shared.Interfaces;

public interface IFileService
{
    bool AddContactToFile(string content);
    bool DeleteContactFromFile(ContactModel contact);
    string GetContactFromFile();
}
