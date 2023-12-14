using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using AddressBook.WPF.ViewModels;
using AddressBook.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace AddressBook.WPF;

public partial class App : Application
{
    private IHost? _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton< AddressBookService>();
                services.AddSingleton<IContact, ContactModel>();    
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<ContactsListViewModel>();
                services.AddSingleton<ContactListView>();
                services.AddSingleton<ContactDetailsViewModel>();
                services.AddSingleton<ContactDetailsView>();
                services.AddSingleton<AddContactViewModel>();
                services.AddSingleton<AddContactView>();
                services.AddSingleton<SuccessWhenAddContactViewModel>();
                services.AddSingleton<SuccessWhenAddContactView>();

           


            }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host!.Start();

        var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
