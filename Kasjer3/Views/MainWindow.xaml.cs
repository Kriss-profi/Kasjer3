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
            string message = "Witam Ciebie drogi użytkowniku.\n " +
                "OGRANICZENIE RĘKOJMI.\n" +
                "LICENCJODAWCA NIE UDZIELA ŻADNYCH GWARANCJI, ZAPEWNIEŃ ANI OBIETNIC. LICENCJOBIORCA BIERZE NA SIEBIE RYZYKO WYNIKAJĄCE ZE SKUTKÓW UŻYTKOWANIA LUB NIEMOŻLIWOŚCI UŻYTKOWANIA OPROGRAMOWANIA. \n" +
                "LICENCJODAWCA ZRZEKA SIĘ I WYŁĄCZA WSZELKIE DOMNIEMANE GWARANCJE ODNOŚNIE POPRAWNEGO DZIAŁANIA, TYTUŁU PRAWNEGO LUB PRZYDATNOŚCI OPROGRAMOWANIA DO KONKRETNEGO CELU. LICENCJODAWCA NIE GWARANTUJE, ŻE OPROGRAMOWANIE SPEŁNI WYMAGANIA LICENCJOBIORCY, LUB ŻE OPROGRAMOWANIE I DOKUMENTACJA SĄ BEZ USZKODZEŃ LUB BŁĘDÓW, LUB ŻE OPROGRAMOWANIE BĘDZIE DZIAŁAŁO BEZ PRZESZKÓD.OGRANICZENIE ODPOWIEDZIALNOŚCI ZA EWENTUALNE SZKODY.LICENCJODAWCA NIE BĘDZIE W ŻADNYM WYPADKU ODPOWIEDZIALNY ZA JAKIEKOLWIEK POWSTAŁE SZKODY (W TYM, BEZ OGRANICZEŃ, SZKODY WYNIKŁE ZE STRAT W PROWADZONEJ DZIAŁALNOŚCI, PRZERWY W PROWADZENIU DZIAŁALNOŚCI, UTRATY INFORMACJI ZWIĄZANYCH Z PROWADZONĄ DZIAŁALNOŚCIĄ LUB INNE SZKODY PIENIĘŻNE LUB NIEPIENIĘŻNE) WYNIKAJĄCE Z UŻYTKOWANIA LUB NIEMOŻLIWOŚCI UŻYTKOWANIA OPROGRAMOWANIA LUB ŚWIADCZENIA POMOCY TECHNICZNEJ LUB JEJ NIE ZAPEWNIENIA, NAWET JEŚLI LICENCJODAWCA ZOSTAŁ POWIADOMIONY O MOŻLIWOŚCI POWSTANIA TAKICH SZKÓD. \n" +
                "\nJeśli podoba Ci się Kasjer i chcesz dowiedzieć się więcej. \n " +
                "Zobacz na stronę:\t www.kasjer.polprofi.eu " +
                "\n\tPozdrawiam KRZYSZTOF JAKUBOWSKI";
            string caption = "Kasjer 3.2.0";
            MessageBoxButton buttons = MessageBoxButton.OKCancel;
            //MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult defaultResult = MessageBoxResult.Yes;
            MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly;
            // Show message box
            defaultResult = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);
            if (defaultResult == MessageBoxResult.OK)
            {
                //Process.Start(new ProcessStartInfo( "http://kasjer.polprofi.eu" ) );
            }
        }
    }
}
