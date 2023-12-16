using AddressBook.Shared.Models;

namespace AddressBook.Shared.Interfaces;

public interface IFileService
{
    bool AddContactToFile(string content);
    string GetContactFromFile();
    bool UpDateContactInFile(ContactModel contact);
    bool DeleteContactFromFile(ContactModel contact);
   
}
