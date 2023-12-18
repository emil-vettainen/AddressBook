using AddressBook.MAUI.ViewModels;
using AddressBook.Shared.Models;

namespace AddressBook.MAUI.Pages;


public partial class ContactDetailsPage : ContentPage
{


	public ContactDetailsPage(ContactDetailsViewModel contactDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = contactDetailsViewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}