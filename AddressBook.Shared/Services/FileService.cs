using AddressBook.Shared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;


namespace AddressBook.Shared.Services;

public class FileService: IFileService
{
    public bool AddContactToFile(string filePath, string contact)
    {
        try
        {
            using (var sw = new StreamWriter(filePath))
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

    public string GetContactFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (var sr = new StreamReader(filePath))
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


    public bool UpDateContactInFile(string filePath, IContact contact)
    {
        try
        {
            if (File.Exists(filePath))
            {
                var existingContent = GetContactFromFile(filePath);
                var existingContacts = JsonConvert.DeserializeObject<List<IContact>>(existingContent, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })!;

                var contactToUpdate = existingContacts.FirstOrDefault(x => x.Id == contact.Id);

                if (contactToUpdate != null)
                {
                    contactToUpdate.FirstName = contact.FirstName;
                    contactToUpdate.LastName = contact.LastName;
                    contactToUpdate.PhoneNumber = contact.PhoneNumber;
                    contactToUpdate.Email = contact.Email;
                    contactToUpdate.StreetName = contact.StreetName;
                    contactToUpdate.PostalCode = contact.PostalCode;
                    contactToUpdate.PostTown = contact.PostTown;
               
                    AddContactToFile(filePath, JsonConvert.SerializeObject(existingContacts, new JsonSerializerSettings
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

    public bool DeleteContactFromFile(string filePath, IContact contactModel)
    {
        try
        {
            if (File.Exists(filePath)) 
            {
                var existingContent = GetContactFromFile(filePath);
                var existingContacts = JsonConvert.DeserializeObject<List<IContact>>(existingContent, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })!;
                var contactToRemove = existingContacts.FirstOrDefault(x => x.Email == contactModel.Email);

                if (contactToRemove != null)
                {
                    existingContacts.Remove(contactToRemove);
                    AddContactToFile(filePath, JsonConvert.SerializeObject(existingContacts, new JsonSerializerSettings
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