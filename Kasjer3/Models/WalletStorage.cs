using Kasjer3.ViewModels;
using System;
using System.IO;
using System.Windows;

namespace Kasjer3.Models
{
    public class WalletStorage
    {
        private string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Kasjer3.txt"; 

        public void SaveWallet(Wallet wallet)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(fileStream);
            WriteWallet(writer, wallet);
            writer.Close();
        }

        private void WriteWallet(StreamWriter writer, Wallet wallet)
        {
            writer.WriteLine(Convert.ToString(wallet.SystemValue));
            writer.WriteLine(Convert.ToString(wallet.Casket50000Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket20000Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket10000Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket5000Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket2000Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket1000Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket500Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket200Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket100Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket50Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket20Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket10Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket5Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket2Quantity));
            writer.WriteLine(Convert.ToString(wallet.Casket1Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe50000Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe20000Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe10000Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe5000Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe2000Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe1000Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe500Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe200Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe100Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe50Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe20Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe10Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe5Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe2Quantity));
            writer.WriteLine(Convert.ToString(wallet.DaySafe1Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe50000Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe20000Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe10000Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe5000Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe2000Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe1000Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe500Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe200Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe100Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe50Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe20Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe10Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe5Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe2Quantity));
            writer.WriteLine(Convert.ToString(wallet.MainSafe1Quantity));
        }


        public void LoadWallet(Wallet wallet)
        {
            if (File.Exists(fileName))
            {   
                string[] table = File.ReadAllLines(fileName);
                wallet.SystemValueString = table[0];
                wallet.Casket50000Quantity = int.Parse(table[1]);
                wallet.Casket20000Quantity = int.Parse(table[2]);
                wallet.Casket10000Quantity = int.Parse(table[3]);
                wallet.Casket5000Quantity = int.Parse(table[4]);
                wallet.Casket2000Quantity = int.Parse(table[5]);
                wallet.Casket1000Quantity = int.Parse(table[6]);
                wallet.Casket500Quantity = int.Parse(table[7]);
                wallet.Casket200Quantity = int.Parse(table[8]);
                wallet.Casket100Quantity = int.Parse(table[9]);
                wallet.Casket50Quantity = int.Parse(table[10]);
                wallet.Casket20Quantity = int.Parse(table[11]);
                wallet.Casket10Quantity = int.Parse(table[12]);
                wallet.Casket5Quantity = int.Parse(table[13]);
                wallet.Casket2Quantity = int.Parse(table[14]);
                wallet.Casket1Quantity = int.Parse(table[15]);
                wallet.DaySafe50000Quantity = int.Parse(table[16]);
                wallet.DaySafe20000Quantity = int.Parse(table[17]);
                wallet.DaySafe10000Quantity = int.Parse(table[18]);
                wallet.DaySafe5000Quantity = int.Parse(table[19]);
                wallet.DaySafe2000Quantity = int.Parse(table[20]);
                wallet.DaySafe1000Quantity = int.Parse(table[21]);
                wallet.DaySafe500Quantity = int.Parse(table[22]);
                wallet.DaySafe200Quantity = int.Parse(table[23]);
                wallet.DaySafe100Quantity = int.Parse(table[24]);
                wallet.DaySafe50Quantity = int.Parse(table[25]);
                wallet.DaySafe20Quantity = int.Parse(table[26]);
                wallet.DaySafe10Quantity = int.Parse(table[27]);
                wallet.DaySafe5Quantity = int.Parse(table[28]);
                wallet.DaySafe2Quantity = int.Parse(table[29]);
                wallet.DaySafe1Quantity = int.Parse(table[30]);
                wallet.MainSafe50000Quantity = int.Parse(table[31]);
                wallet.MainSafe20000Quantity = int.Parse(table[32]);
                wallet.MainSafe10000Quantity = int.Parse(table[33]);
                wallet.MainSafe5000Quantity = int.Parse(table[34]);
                wallet.MainSafe2000Quantity = int.Parse(table[35]);
                wallet.MainSafe1000Quantity = int.Parse(table[36]);
                wallet.MainSafe500Quantity = int.Parse(table[37]);
                wallet.MainSafe200Quantity = int.Parse(table[38]);
                wallet.MainSafe100Quantity = int.Parse(table[39]);
                wallet.MainSafe50Quantity = int.Parse(table[40]);
                wallet.MainSafe20Quantity = int.Parse(table[41]);
                wallet.MainSafe10Quantity = int.Parse(table[42]);
                wallet.MainSafe5Quantity = int.Parse(table[43]);
                wallet.MainSafe2Quantity = int.Parse(table[44]);
                wallet.MainSafe1Quantity = int.Parse(table[45]);
            }
        }


        public void LoadWallet2(Wallet wallet)
        {
            if(File.Exists(fileName))
            {
                try
                {
                    FileStream fs = new(fileName, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    wallet.Casket50000Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket20000Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket10000Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket5000Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket2000Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket1000Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket500Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket200Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket100Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket50Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket20Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket10Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket5Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket2Quantity = int.Parse(sr.ReadLine());
                    wallet.Casket1Quantity = int.Parse(sr.ReadLine());
                    sr.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            
        }
    }
}
