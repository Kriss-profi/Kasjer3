using Kasjer3.ViewModels;
using Kasjer3.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kasjer3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Wallet();
        }

        private Wallet? MyDataContext => DataContext as Wallet;
        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox? tb = sender as TextBox;
            tb.Dispatcher.BeginInvoke(new Action(() => tb.SelectAll()));
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                TextBox? textBox = e.Source as TextBox;
                if(textBox != null)
                {
                    textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
                e.Handled = true;
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            new PrintPage(MyDataContext).ShowDialog();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            // Configure message box
            string message = "Witam\n Jeśli podoba Ci się Kasjer i chcesz dowiedzieć się więcej. \n Zobacz na stronę:\n www.polprofi.de/kasjer ";
            string caption = "Info o twórcy";
            MessageBoxButton buttons = MessageBoxButton.OKCancel;
            //MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult defaultResult = MessageBoxResult.Yes;
            MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly;
            // Show message box
            defaultResult = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);
            if (defaultResult == MessageBoxResult.OK)
            {
                //Process.Start(new ProcessStartInfo( "http://polprofi.de" ) );
            }
        }
    }
}
