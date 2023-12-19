using AddressBook.MAUI.ViewModels;

namespace AddressBook.MAUI.Pages;

public partial class ContactEditPage : ContentPage
{
	public ContactEditPage(ContactEditViewModel contactEditViewModel)
	{
		InitializeComponent();
		BindingContext = contactEditViewModel;
	}

    
}