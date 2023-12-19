using AddressBook.MAUI.Pages;

namespace AddressBook.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ContactListPage), typeof(ContactListPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(ContactDetailsPage), typeof(ContactDetailsPage));
            Routing.RegisterRoute(nameof(ContactEditPage), typeof(ContactEditPage));

          

        }
    }
}
