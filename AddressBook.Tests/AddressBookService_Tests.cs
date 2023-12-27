using AddressBook.Shared.Enums;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models.Responses;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using Moq;
using Newtonsoft.Json;

namespace AddressBook.Tests;

public class AddressBookService_Tests
{
    [Fact]
    public void AddContactToListShould_AddOneContactToContactsList_ReturnServiceResult()
    {
        // Arrange
        var fileServiceMock = new Mock<IFileService>();
        var addressBookService = new AddressBookService(fileServiceMock.Object);
        IServiceResult _serviceResult = new ServiceResult();
        IContact contactModel = new ContactModel
        {
            FirstName = "Emil",
            LastName = "Vettainen",
            PhoneNumber = "0707070707",
            Email = "emil@domain.com",
            StreetName = "Skara",
            PostalCode = "12345",
            PostTown = "Skara"
        };

        // Act
        _serviceResult = addressBookService.AddContactToList(contactModel);

        // Assert
        Assert.NotNull(_serviceResult);
        Assert.Equal(ResultStatus.Successed, _serviceResult.Status);
        fileServiceMock.Verify(fs => fs.AddContactToFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void GetAllContactFromListShould_CallFileService_AndReturnListOfContacts()
    {
        // Arrange
        var fileServiceMock = new Mock<IFileService>();
        var expectedContacts = new List<IContact> { new ContactModel {
            FirstName = "Emil",
            LastName = "Vettainen",
            PhoneNumber = "0707070707",
            Email = "emil@domain.com",
            StreetName = "Skara",
            PostalCode = "12345",
            PostTown = "Skara"
        }};

        var serializedContacts = JsonConvert.SerializeObject(expectedContacts, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
        });
        fileServiceMock.Setup(fs => fs.GetContactFromFile(It.IsAny<string>())).Returns(serializedContacts);
        var addressBookService = new AddressBookService(fileServiceMock.Object);

        // Act
        var result = addressBookService.GetContactFromList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedContacts.Count, result.Count());
        Assert.Equal("emil@domain.com", result.First().Email);
        IContact contact = result.First();
        Assert.Equal(contact.Id, result.First().Id );
        fileServiceMock.Verify(fs => fs.GetContactFromFile(It.IsAny<string>()), Times.Once);
    }


    [Fact]
    public void UpdateContactToListShould_UpdateExistingContactInList_ReturnUpdatedServiceResult()
    {
        // Arrange
        var fileServiceMock = new Mock<IFileService>();
        var addressBookService = new AddressBookService(fileServiceMock.Object);
        IContact originalContact = new ContactModel
        {
            FirstName = "Emil",
            LastName = "Vettainen",
            PhoneNumber = "0707070707",
            Email = "emil@domain.com",
            StreetName = "Skara",
            PostalCode = "12345",
            PostTown = "Skara"
        };
        fileServiceMock.Setup(fs => fs.UpDateContactInFile(It.IsAny<string>(), It.IsAny<IContact>())).Returns(true);

        // Act
        addressBookService.AddContactToList(originalContact);
        IContact updatedContact = new ContactModel
        {
            FirstName = "Emil",
            LastName = "Vettainen",
            PhoneNumber = "0707070708",
            Email = "emil@newdomain.com",
            StreetName = "Skara",
            PostalCode = "12345",
            PostTown = "Skara"
        };
        var serviceResult = addressBookService.UpdateContactToList(updatedContact);

        // Assert
        Assert.NotNull(serviceResult);
        Assert.Equal(ResultStatus.Updated, serviceResult.Status);
        fileServiceMock.Verify(fs => fs.UpDateContactInFile(It.IsAny<string>(), updatedContact), Times.Once);
    }

    [Fact]
    public void DeleteContactFromListShould_RemoveContactFromList_ReturnDeletedServiceResult()
    {
        // Arrange
        var fileServiceMock = new Mock<IFileService>();
        var addressBookService = new AddressBookService(fileServiceMock.Object);
        var contactModel = new ContactModel
        {
            FirstName = "Emil",
            LastName = "Vettainen",
            PhoneNumber = "0707070707",
            Email = "emil@domain.com",
            StreetName = "Skara",
            PostalCode = "12345",
            PostTown = "Skara"
        };
        fileServiceMock.Setup(fs => fs.DeleteContactFromFile(It.IsAny<string>(), It.IsAny<IContact>())).Returns(true);

        // Act
        addressBookService.AddContactToList(contactModel);
        var serviceResult = addressBookService.DeleteContactFromList(contactModel);

        // Assert
        Assert.NotNull(serviceResult);
        Assert.Equal(ResultStatus.Deleted, serviceResult.Status);
        fileServiceMock.Verify(fs => fs.DeleteContactFromFile(It.IsAny<string>(), contactModel), Times.Once);
    }
}
