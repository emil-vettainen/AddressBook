using AddressBook.MAUI.ViewModels;

namespace AddressBook.MAUI.Pages;

public partial class ContactListPage : ContentPage
{
	public ContactListPage(ContactListViewModel contactListViewModel)
	{
		InitializeComponent();
		BindingContext = contactListViewModel;
    }
}