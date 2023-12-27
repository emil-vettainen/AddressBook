using AddressBook.MAUI.Pages;
using AddressBook.MAUI.ViewModels;
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Services;
using Microsoft.Extensions.Logging;


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
                    fonts.AddFont("Font-Awesome-Solid-900.OTF", "FAS");
                });


            builder.Services.AddSingleton<AddressBookService>();
            builder.Services.AddSingleton<IFileService, FileService>();  
      
            
            builder.Services.AddSingleton<AddContactViewModel>();
            builder.Services.AddSingleton<AddContactPage>();

            builder.Services.AddSingleton<ContactListViewModel>();
            builder.Services.AddSingleton<ContactListPage>();

            builder.Services.AddTransient<ContactDetailsViewModel>();
            builder.Services.AddTransient<ContactDetailsPage>();

            builder.Services.AddTransient<ContactEditViewModel>();
            builder.Services.AddTransient<ContactEditPage>();


            builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}