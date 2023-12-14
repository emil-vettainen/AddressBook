﻿using AddressBook.MAUI.ViewModels;
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
                });


            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AddressBookService>();    

    		builder.Logging.AddDebug();


            return builder.Build();
        }
    }
}