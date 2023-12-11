using AddressBook.Shared.Interfaces;
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

    public bool DeleteContactFromFile(IContact contact)
    {
        try
        {
            if (File.Exists(_filePath)) 
            {
                var existingContent = GetContactFromFile();
                var existingContacts = JsonConvert.DeserializeObject<List<IContact>>(existingContent) ?? new List<IContact>();
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
}
