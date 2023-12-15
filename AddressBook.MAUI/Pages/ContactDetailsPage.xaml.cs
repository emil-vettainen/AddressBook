using AddressBook.MAUI.ViewModels;

namespace AddressBook.MAUI.Pages;

public partial class ContactDetailsPage : ContentPage
{
	public ContactDetailsPage(ContactDetailsViewModel contactDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = contactDetailsViewModel;
	}
}