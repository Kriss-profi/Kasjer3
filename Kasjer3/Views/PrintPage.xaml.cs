using System.Printing;
using System.Windows;
using System.Windows.Controls;

namespace Kasjer3.Views
{
    /// <summary>
    /// Interaction logic for PrintPage.xaml
    /// </summary>
    public partial class PrintPage : Window
    {
        public PrintPage(ViewModels.Wallet dc)
        {
            InitializeComponent();
            DataContext = dc;
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument();
        }

        private void PrintDocument()
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
            printDialog.PrintTicket = printDialog.PrintQueue.DefaultPrintTicket;
            printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
            printDialog.PrintTicket.PageScalingFactor = 1;
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);

            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(WalletView, "Kasjer 3.0");
            }
            this.Close();
        }
    }
}
