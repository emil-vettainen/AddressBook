using AddressBook.MAUI.ViewModels;

namespace AddressBook.MAUI.Pages;

public partial class ContactListPage : ContentPage
{
	public ContactListPage(ContactListViewModel contactListViewModel)
	{
		InitializeComponent();
		BindingContext = contactListViewModel;

        //ToolbarItems.Add(new ToolbarItem("Add Contact", null, async () =>
        //{
        //    await Shell.Current.GoToAsync("AddContactPage");
        //    // Lägg till logik för knappen här
        //}));
    }
}