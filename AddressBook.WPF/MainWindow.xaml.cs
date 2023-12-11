using AddressBook.WPF.ViewModels;
using System.Windows;

namespace AddressBook.WPF;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}