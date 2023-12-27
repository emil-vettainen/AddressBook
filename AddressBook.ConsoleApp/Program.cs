using AddressBook.ConsoleApp.Services;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IFileService, FileService>();
    services.AddSingleton<IAddressBookService, AddressBookService>();
    services.AddSingleton<MenuService>();

}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.DisplayMainMenu();