using AddressBook.MAUI.Pages;
using AddressBook.MAUI.Services;
using AddressBook.MAUI.ViewModels;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace AddressBook.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

           

        

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AddressBookService>();    

            builder.Services.AddSingleton<AddContactViewModel>();
            builder.Services.AddSingleton<AddContactPage>();

            builder.Services.AddSingleton<ContactListViewModel>();
            builder.Services.AddSingleton<ContactListPage>();

            builder.Services.AddSingleton<ContactDetailsViewModel>();
            builder.Services.AddSingleton<ContactDetailsPage>();

            builder.Services.AddSingleton<ContactListService>();

            builder.Services.AddSingleton<BaseViewModel>();
           

            builder.Logging.AddDebug();


            return builder.Build();
        }
    }
}
