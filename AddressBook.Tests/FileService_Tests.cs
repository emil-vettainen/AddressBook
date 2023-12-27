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
