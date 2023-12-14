using AddressBook.MAUI.ViewModels;

namespace AddressBook.MAUI
{
    public partial class MainPage : ContentPage
    {
   

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

      
    }

}
