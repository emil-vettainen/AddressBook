﻿using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Models.Responses;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Diagnostics;


namespace AddressBook.Shared.Services;

public class AddressBookService 
{
    private readonly IFileService _fileService = new FileService(@"C:\CSharp\AddressBook\AddressBook.MAUI\ContactList.json");
    private List<IContact> _contacts = [];
    IServiceResult result = new ServiceResult();

    public IServiceResult AddContactToList(IContact contactModel)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contactModel.Email))
            {
                _contacts.Add(contactModel);
                //_fileService.AddContactToFile(JsonConvert.SerializeObject(_contacts));
                _fileService.AddContactToFile(JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                }));
                result.Status = Enums.ResultStatus.Successed;
            }
            else
            {
                result.Status = Enums.ResultStatus.AlreadyExist;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            result.Status = Enums.ResultStatus.Failed;
        }
        return result;
    }

    public IServiceResult DeleteContactFromList(IContact contactModel)
    {
        try
        {
            _fileService.DeleteContactFromFile(contactModel);
            result.Status = Enums.ResultStatus.Deleted;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            result.Status = Enums.ResultStatus.Failed;
        }
        return result;
    }

    public IEnumerable<IContact> GetContactFromList()
    {
        try
        {
            var content = _fileService.GetContactFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                //_contacts = JsonConvert.DeserializeObject<List<ContactModel>>(content)!;    

                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                })!;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return _contacts;
    }
}
