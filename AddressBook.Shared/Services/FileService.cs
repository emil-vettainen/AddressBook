using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;


namespace AddressBook.Shared.Services;

internal class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;

    public bool AddContactToFile(string content)
    {
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content); 
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
            //else
            //{
            //    File.WriteAllText(_filePath, string.Empty);
            //    return string.Empty;
            //}
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }



    public bool UpDateContactInFile(ContactModel contact)
    {
        try
        {
            if (File.Exists(_filePath))
            {
                var existingContent = GetContactFromFile();
                var existingContacts = JsonConvert.DeserializeObject<List<ContactModel>>(existingContent) ?? new List<ContactModel>();

                var contactToUpdate = existingContacts.FirstOrDefault(x => x.Email == contact.Email);

                if (contactToUpdate != null)
                {
                    // Uppdatera kontaktens egenskaper med de nya värdena
                    contactToUpdate.FirstName = contact.FirstName;
                    contactToUpdate.LastName = contact.LastName;
                    contactToUpdate.PhoneNumber = contact.PhoneNumber;
                    contactToUpdate.Email = contact.Email;
                    contactToUpdate.StreetName = contact.StreetName;
                    contactToUpdate.PostalCode = contact.PostalCode;
                    contactToUpdate.PostTown = contact.PostTown;
                    

                    // Uppdatera andra egenskaper enligt behov

                    // Spara uppdaterad kontaktlista till filen
                    AddContactToFile(JsonConvert.SerializeObject(existingContacts));

                    return true;
                }

                //if (contactToUpdate != null)
                //{
                //    // Kopiera egenskaperna från den nya kontakten till den befintliga kontakten
                //    JsonConvert.PopulateObject(JsonConvert.SerializeObject(contact), contactToUpdate);

                //    // Spara uppdaterad kontaktlista till filen
                //    AddContactToFile(JsonConvert.SerializeObject(existingContacts));

                //    return true;
                //}
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return false;
    }



    public bool DeleteContactFromFile(ContactModel contact)
    {
        try
        {
            if (File.Exists(_filePath)) 
            {
                var existingContent = GetContactFromFile();
                var existingContacts = JsonConvert.DeserializeObject<List<ContactModel>>(existingContent);
                var contactToRemove = existingContacts.FirstOrDefault(x => x.Email == contact.Email);

                if (contactToRemove != null)
                {
                    existingContacts.Remove(contactToRemove);
                    AddContactToFile(JsonConvert.SerializeObject(existingContacts));
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }


 
}
