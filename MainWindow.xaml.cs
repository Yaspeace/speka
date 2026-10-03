using Speka.Models;
using Speka.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Speka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is ListViewItem lvi && lvi.DataContext is FileSystemNode node && DataContext is MainViewModel vm)
            {
                vm.SelectedItem = node;
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem { DataContext: FileSystemNode node } &&
                DataContext is MainViewModel viewModel)
            {
                viewModel.OpenItem(node);
                e.Handled = true;
            }
        }

    }
}