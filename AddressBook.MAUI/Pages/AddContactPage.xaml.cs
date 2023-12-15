using AddressBook.MAUI.ViewModels;

namespace AddressBook.MAUI.Pages;

public partial class AddContactPage : ContentPage
{
	public AddContactPage(AddContactViewModel addContactViewModel)
	{
		InitializeComponent();
		BindingContext = addContactViewModel;
	}
}