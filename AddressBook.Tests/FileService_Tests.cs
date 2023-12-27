using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using Newtonsoft.Json;


namespace AddressBook.Tests;

public class FileService_Tests
{
    [Fact]
    public void SaveToFile_ShouldReturnFalse_IfFileDoesNotExist()
    {
        // Arrange
        FileService fileService = new FileService();
        string filePath = @$"C:\{Guid.NewGuid()}\testlist.json";
        string content = "Test";

        // Act
        var result = fileService.AddContactToFile(filePath, content);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetContactFromFile_ShouldReturnNull_IfFileDoesNotExist()
    {
        // Arrange
        FileService fileService = new FileService();
        string filePath = @$"C:\{Guid.NewGuid()}\testlist.json";

        // Act
        var result = fileService.GetContactFromFile(filePath);

        // Assert
        Assert.Null(result);
    }


    [Fact]
    public void UpDateContactInFile_ShouldUpdateContact_IfExists()
    {
        // Arrange
        FileService fileService = new FileService();
        var filePath = Path.GetTempFileName();
        var originalContact = new ContactModel
        {
            Id = Guid.NewGuid(),
            FirstName = "Emil",
            LastName = "Vettainen",
            PhoneNumber = "1234567890",
            Email = "emil@domain.com",
            StreetName = "Skara",
            PostalCode = "12345",   
            PostTown = "Skara"
        };
        var existingContacts = new List<IContact> { originalContact };
        var content = JsonConvert.SerializeObject(existingContacts, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });
        File.WriteAllText(filePath, content);
        var updatedContact = new ContactModel
        {
            Id = originalContact.Id,
            FirstName = "Test",
            LastName = "Updated",
            PhoneNumber = "1234567890",
            Email = "annan@domain.com",
            StreetName = "Skara",
            PostalCode = "12345",
            PostTown = "Skara"
        };

        // Act
        var result = fileService.UpDateContactInFile(filePath, updatedContact);

        // Assert
        Assert.True(result);
        var updatedContent = File.ReadAllText(filePath);
        var updatedContacts = JsonConvert.DeserializeObject<List<ContactModel>>(updatedContent);
        Assert.NotNull(updatedContacts);
        var contactInFile = updatedContacts.Find(c => c.Id == originalContact.Id);
        Assert.NotNull(contactInFile);
        Assert.Equal("annan@domain.com", contactInFile.Email);
        Assert.Equal("Test", contactInFile.FirstName);
        File.Delete(filePath);
    }



    [Fact]
    public void DeleteContactFromFile_ShouldNotRemoveContact_IfEmailDoesNotExist()
    {
        // Arrange
        FileService fileService = new FileService();
        var filePath = Path.GetTempFileName();
        var existingContacts = new List<IContact>
        {
            new ContactModel { Email = "existing@domain.com" },
            new ContactModel { Email = "another@domain.com" }
        };
        var content = JsonConvert.SerializeObject(existingContacts, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });
        File.WriteAllText(filePath, content);
        var nonExistentContact = new ContactModel { Email = "nonexistent@domain.com" };

        // Act
        var result = fileService.DeleteContactFromFile(filePath, nonExistentContact);

        // Assert
        Assert.True(result);
        var updatedContent = File.ReadAllText(filePath);
        var updatedContacts = JsonConvert.DeserializeObject<List<ContactModel>>(updatedContent);
        Assert.NotNull(updatedContacts);
        Assert.Equal(existingContacts.Count, updatedContacts.Count);
        File.Delete(filePath);
    }
}
