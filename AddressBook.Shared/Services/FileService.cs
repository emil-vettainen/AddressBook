using AddressBook.Shared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;


namespace AddressBook.Shared.Services;

internal class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;

    public bool AddContactToFile(string contact)
    {
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(contact); 
            }
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }   
        return false;
    }


    public string GetContactFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using (var sr = new StreamReader(_filePath))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }


    public bool UpDateContactInFile(IContact contact)
    {
        try
        {
            if (File.Exists(_filePath))
            {
                var existingContent = GetContactFromFile();
                var existingContacts = JsonConvert.DeserializeObject<List<IContact>>(existingContent, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })!;

                var contactToUpdate = existingContacts.FirstOrDefault(x => x.Email == contact.Email);

                if (contactToUpdate != null)
                {
                    contactToUpdate.FirstName = contact.FirstName;
                    contactToUpdate.LastName = contact.LastName;
                    contactToUpdate.PhoneNumber = contact.PhoneNumber;
                    contactToUpdate.Email = contact.Email;
                    contactToUpdate.StreetName = contact.StreetName;
                    contactToUpdate.PostalCode = contact.PostalCode;
                    contactToUpdate.PostTown = contact.PostTown;

                    AddContactToFile(JsonConvert.SerializeObject(existingContacts, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    }));

                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }


    public bool DeleteContactFromFile(IContact contactModel)
    {
        try
        {
            if (File.Exists(_filePath)) 
            {
                var existingContent = GetContactFromFile();
                var existingContacts = JsonConvert.DeserializeObject<List<IContact>>(existingContent, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })!;
                var contactToRemove = existingContacts.FirstOrDefault(x => x.Email == contactModel.Email);

                if (contactToRemove != null)
                {
                    existingContacts.Remove(contactToRemove);
                    AddContactToFile(JsonConvert.SerializeObject(existingContacts, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    }));
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}