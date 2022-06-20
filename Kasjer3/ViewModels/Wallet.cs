using Kasjer3.Help;
using Kasjer3.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Kasjer3.ViewModels
{
    public class Wallet : INotifyPropertyChanged
    {
        public Wallet()
        {
            ZerujCommand = new RelayCommand(a => Zeruj());
            walletStorage.LoadWallet(this);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        FaceWalueSet casket = new FaceWalueSet();
        FaceWalueSet daySafe = new FaceWalueSet();
        FaceWalueSet mainSafe = new FaceWalueSet();

        private decimal _casketAmount;
        private decimal _daySafeAmount;
        private decimal _mainSafeAmount;
        private decimal _systemValue;
        private string _systemValueString;
        private decimal _walletValue;
        private decimal _differenceValue;
        private readonly WalletStorage walletStorage = new WalletStorage();

        public decimal DifferenceValue
        {
            get { return _differenceValue; }
            set
            {
                _differenceValue = value;
                OnPropertyChanged();
            }
        }

        public void SetDifferenceValue()
        {
            if(SystemValue != 0)
            {
                DifferenceValue = WalletValue - SystemValue;
            }else
            {
                DifferenceValue = 0;
            }
        }

        public decimal WalletValue
        {
            get { return _walletValue; }
            set
            {
                _walletValue = value;
                OnPropertyChanged();
            }
        }

        public string SystemValueString
        {
            get { return _systemValueString; }
            set 
            { 
                String temp = value.Replace(",",".");
                decimal tempdecimal = decimal.Parse(temp);
                _systemValueString = $"{tempdecimal:N2}";
                OnPropertyChanged(); 
                if (decimal.TryParse(_systemValueString, out decimal number))
                {
                    SystemValue = number;
                }else
                {
                    SystemValue = 0;
                    _systemValueString = "Akceptuję tylko cyfry ";
                }
            }
        }

        public decimal SystemValue
        {
            get { return _systemValue; }
            set
            {
                _systemValue = value;
                SetWalletValue();
                OnPropertyChanged();
            }
        }

        public void SetWalletValue()
        {
            SetCasketAmount();
            SetDaySafeAmount();
            SetMainSafeAmount();
            WalletValue = CasketAmount + DaySafeAmount + MainSafeAmount;
            SetDifferenceValue();
            SaveMyWallet();
            OnPropertyChanged();
        }

        private void SaveMyWallet()
        {
            walletStorage.SaveWallet(this);
        }

        public ICommand ZerujCommand { get; private set; }

        private void Zeruj()
        {
            Casket50000Quantity = 0;
            Casket20000Quantity = 0;
            Casket10000Quantity = 0;
            Casket5000Quantity = 0;
            Casket2000Quantity = 0;
            Casket1000Quantity = 0;
            Casket500Quantity = 0;
            Casket200Quantity = 0;
            Casket100Quantity = 0;
            Casket50Quantity = 0;
            Casket20Quantity = 0;
            Casket10Quantity = 0;
            Casket5Quantity = 0;
            Casket2Quantity = 0;
            Casket1Quantity = 0;
            DaySafe50000Quantity = 0;
            DaySafe20000Quantity = 0;
            DaySafe10000Quantity = 0;
            DaySafe5000Quantity = 0;
            DaySafe2000Quantity = 0;
            DaySafe1000Quantity = 0;
            DaySafe500Quantity = 0;
            DaySafe200Quantity = 0;
            DaySafe100Quantity = 0;
            DaySafe50Quantity = 0;
            DaySafe20Quantity = 0;
            DaySafe10Quantity = 0;
            DaySafe5Quantity = 0;
            DaySafe2Quantity = 0;
            DaySafe1Quantity = 0;
            MainSafe50000Quantity = 0;
            MainSafe20000Quantity = 0;
            MainSafe10000Quantity = 0;
            MainSafe5000Quantity = 0;
            MainSafe2000Quantity = 0;
            MainSafe1000Quantity = 0;
            MainSafe500Quantity = 0;
            MainSafe200Quantity = 0;
            MainSafe100Quantity = 0;
            MainSafe50Quantity = 0;
            MainSafe20Quantity = 0;
            MainSafe10Quantity = 0;
            MainSafe5Quantity = 0;
            MainSafe2Quantity = 0;
            MainSafe1Quantity = 0;
            SystemValueString = "0";
        }

        #region KASETKA

        public decimal CasketAmount
        {
            get
            {
                return _casketAmount;
            }
            set
            {
                _casketAmount = value;
                OnPropertyChanged();
            }
        }

        public void SetCasketAmount()
        {
            CasketAmount = casket.WalletSum();
        }

        #region Kasetka50000
        public string Casket50000Name
        {
            get { return casket.Nom50000.Name; }
        }

        public int Casket50000Quantity
        {
            get { return casket.Nom50000.Quantity; }
            set 
            { 
                casket.Nom50000.Quantity = value;
                Casket50000Amount = Calculate(casket.Nom50000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket50000Amount
        {
            get { return casket.Nom50000.FVAmount; }
            set { casket.Nom50000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka20000
        public string Casket20000Name
        {
            get { return casket.Nom20000.Name; }
        }

        public int Casket20000Quantity
        {
            get { return casket.Nom20000.Quantity; }
            set
            {
                casket.Nom20000.Quantity = value;
                Casket20000Amount = Calculate(casket.Nom20000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket20000Amount
        {
            get { return casket.Nom20000.FVAmount; }
            set { casket.Nom20000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka10000
        public string Casket10000Name
        {
            get { return casket.Nom10000.Name; }
        }

        public int Casket10000Quantity
        {
            get { return casket.Nom10000.Quantity; }
            set
            {
                casket.Nom10000.Quantity = value;
                Casket10000Amount = Calculate(casket.Nom10000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket10000Amount
        {
            get { return casket.Nom10000.FVAmount; }
            set { casket.Nom10000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        
        #region Kasetka5000
        public string Casket5000Name
        {
            get { return casket.Nom5000.Name; }
        }

        public int Casket5000Quantity
        {
            get { return casket.Nom5000.Quantity;  }
            set 
            { 
                casket.Nom5000.Quantity = value;
                Casket5000Amount = Calculate(casket.Nom5000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket5000Amount
        {
            get { return casket.Nom5000.FVAmount; }
            set { casket.Nom5000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka2000
        public string Casket2000Name
        {
            get { return casket.Nom2000.Name; }
        }

        public int Casket2000Quantity
        {
            get { return casket.Nom2000.Quantity; }
            set
            {
                casket.Nom2000.Quantity = value;
                Casket2000Amount = Calculate(casket.Nom2000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket2000Amount
        {
            get { return casket.Nom2000.FVAmount; }
            set { casket.Nom2000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka1000
        public string Casket1000Name
        {
            get { return casket.Nom1000.Name; }
        }

        public int Casket1000Quantity
        {
            get { return casket.Nom1000.Quantity; }
            set
            {
                casket.Nom1000.Quantity = value;
                Casket1000Amount = Calculate(casket.Nom1000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket1000Amount
        {
            get { return casket.Nom1000.FVAmount; }
            set { casket.Nom1000.FVAmount = value; OnPropertyChanged(); }
        }
    #endregion

        #region Kasetka500
        public string Casket500Name
        {
            get { return casket.Nom500.Name; }
        }

        public int Casket500Quantity
        {
            get { return casket.Nom500.Quantity; }
            set
            {
                casket.Nom500.Quantity = value;
                Casket500Amount = Calculate(casket.Nom500);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket500Amount
        {
            get { return casket.Nom500.FVAmount; }
            set { casket.Nom500.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka200
        public string Casket200Name
        {
            get { return casket.Nom200.Name; }
        }

        public int Casket200Quantity
        {
            get { return casket.Nom200.Quantity; }
            set
            {
                casket.Nom200.Quantity = value;
                Casket200Amount = Calculate(casket.Nom200);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket200Amount
        {
            get { return casket.Nom200.FVAmount; }
            set { casket.Nom200.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka100
        public string Casket100Name
        {
            get { return casket.Nom100.Name; }
        }

        public int Casket100Quantity
        {
            get { return casket.Nom100.Quantity; }
            set
            {
                casket.Nom100.Quantity = value;
                Casket100Amount = Calculate(casket.Nom100);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket100Amount
        {
            get { return casket.Nom100.FVAmount; }
            set { casket.Nom100.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region Kasetka50
        public string Casket50Name
        {
            get { return casket.Nom50.Name; }
        }

        public int Casket50Quantity
        {
            get { return casket.Nom50.Quantity; }
            set
            {
                casket.Nom50.Quantity = value;
                Casket50Amount = Calculate(casket.Nom50);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket50Amount
        {
            get { return casket.Nom50.FVAmount; }
            set { casket.Nom50.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka20
        public string Casket20Name
        {
            get { return casket.Nom20.Name; }
        }

        public int Casket20Quantity
        {
            get { return casket.Nom20.Quantity; }
            set
            {
                casket.Nom20.Quantity = value;
                Casket20Amount = Calculate(casket.Nom20);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket20Amount
        {
            get { return casket.Nom20.FVAmount; }
            set { casket.Nom20.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka10
        public string Casket10Name
        {
            get { return casket.Nom10.Name; }
        }

        public int Casket10Quantity
        {
            get { return casket.Nom10.Quantity; }
            set
            {
                casket.Nom10.Quantity = value;
                Casket10Amount = Calculate(casket.Nom10);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket10Amount
        {
            get { return casket.Nom10.FVAmount; }
            set { casket.Nom10.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region Kasetka5
        public string Casket5Name
        {
            get { return casket.Nom5.Name; }
        }

        public int Casket5Quantity
        {
            get { return casket.Nom5.Quantity; }
            set
            {
                casket.Nom5.Quantity = value;
                Casket5Amount = Calculate(casket.Nom5);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket5Amount
        {
            get { return casket.Nom5.FVAmount; }
            set { casket.Nom5.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka2
        public string Casket2Name
        {
            get { return casket.Nom2.Name; }
        }

        public int Casket2Quantity
        {
            get { return casket.Nom2.Quantity; }
            set
            {
                casket.Nom2.Quantity = value;
                Casket2Amount = Calculate(casket.Nom2);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket2Amount
        {
            get { return casket.Nom2.FVAmount; }
            set { casket.Nom2.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region Kasetka1
        public string Casket1Name
        {
            get { return casket.Nom1.Name; }
        }

        public int Casket1Quantity
        {
            get { return casket.Nom1.Quantity; }
            set
            {
                casket.Nom1.Quantity = value;
                Casket1Amount = Calculate(casket.Nom1);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal Casket1Amount
        {
            get { return casket.Nom1.FVAmount; }
            set { casket.Nom1.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #endregion

        #region SEJF DZIENNY

        public decimal DaySafeAmount
        {
            get
            {
                return _daySafeAmount;
            }
            set
            {
                _daySafeAmount = value;
                OnPropertyChanged();
            }
        }
        public void SetDaySafeAmount()
        {
            DaySafeAmount = daySafe.WalletSum();
        }


        #region SejfDzienny50000
        public string DaySafe50000Name
        {
            get { return daySafe.Nom50000.Name; }
        }

        public int DaySafe50000Quantity
        {
            get { return daySafe.Nom50000.Quantity; }
            set
            {
                daySafe.Nom50000.Quantity = value;
                DaySafe50000Amount = Calculate(daySafe.Nom50000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe50000Amount
        {
            get { return daySafe.Nom50000.FVAmount; }
            set { daySafe.Nom50000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny20000
        public string DaySafe20000Name
        {
            get { return daySafe.Nom20000.Name; }
        }

        public int DaySafe20000Quantity
        {
            get { return daySafe.Nom20000.Quantity; }
            set
            {
                daySafe.Nom20000.Quantity = value;
                DaySafe20000Amount = Calculate(daySafe.Nom20000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe20000Amount
        {
            get { return daySafe.Nom20000.FVAmount; }
            set { daySafe.Nom20000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny10000
        public string DaySafe10000Name
        {
            get { return daySafe.Nom10000.Name; }
        }

        public int DaySafe10000Quantity
        {
            get { return daySafe.Nom10000.Quantity; }
            set
            {
                daySafe.Nom10000.Quantity = value;
                DaySafe10000Amount = Calculate(daySafe.Nom10000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe10000Amount
        {
            get { return daySafe.Nom10000.FVAmount; }
            set { daySafe.Nom10000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region SejfDzienny5000
        public string DaySafe5000Name
        {
            get { return daySafe.Nom5000.Name; }
        }

        public int DaySafe5000Quantity
        {
            get { return daySafe.Nom5000.Quantity; }
            set
            {
                daySafe.Nom5000.Quantity = value;
                DaySafe5000Amount = Calculate(daySafe.Nom5000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe5000Amount
        {
            get { return daySafe.Nom5000.FVAmount; }
            set { daySafe.Nom5000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny2000
        public string DaySafe2000Name
        {
            get { return daySafe.Nom2000.Name; }
        }

        public int DaySafe2000Quantity
        {
            get { return daySafe.Nom2000.Quantity; }
            set
            {
                daySafe.Nom2000.Quantity = value;
                DaySafe2000Amount = Calculate(daySafe.Nom2000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe2000Amount
        {
            get { return daySafe.Nom2000.FVAmount; }
            set { daySafe.Nom2000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny1000
        public string DaySafe1000Name
        {
            get { return daySafe.Nom1000.Name; }
        }

        public int DaySafe1000Quantity
        {
            get { return daySafe.Nom1000.Quantity; }
            set
            {
                daySafe.Nom1000.Quantity = value;
                DaySafe1000Amount = Calculate(daySafe.Nom1000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe1000Amount
        {
            get { return daySafe.Nom1000.FVAmount; }
            set { daySafe.Nom1000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region SejfDzienny500
        public string DaySafe500Name
        {
            get { return daySafe.Nom500.Name; }
        }

        public int DaySafe500Quantity
        {
            get { return daySafe.Nom500.Quantity; }
            set
            {
                daySafe.Nom500.Quantity = value;
                DaySafe500Amount = Calculate(daySafe.Nom500);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe500Amount
        {
            get { return daySafe.Nom500.FVAmount; }
            set { daySafe.Nom500.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny200
        public string DaySafe200Name
        {
            get { return daySafe.Nom200.Name; }
        }

        public int DaySafe200Quantity
        {
            get { return daySafe.Nom200.Quantity; }
            set
            {
                daySafe.Nom200.Quantity = value;
                DaySafe200Amount = Calculate(daySafe.Nom200);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe200Amount
        {
            get { return daySafe.Nom200.FVAmount; }
            set { daySafe.Nom200.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny100
        public string DaySafe100Name
        {
            get { return daySafe.Nom100.Name; }
        }

        public int DaySafe100Quantity
        {
            get { return daySafe.Nom100.Quantity; }
            set
            {
                daySafe.Nom100.Quantity = value;
                DaySafe100Amount = Calculate(daySafe.Nom100);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe100Amount
        {
            get { return daySafe.Nom100.FVAmount; }
            set { daySafe.Nom100.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region SejfDzienny50
        public string DaySafe50Name
        {
            get { return daySafe.Nom50.Name; }
        }

        public int DaySafe50Quantity
        {
            get { return daySafe.Nom50.Quantity; }
            set
            {
                daySafe.Nom50.Quantity = value;
                DaySafe50Amount = Calculate(daySafe.Nom50);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe50Amount
        {
            get { return daySafe.Nom50.FVAmount; }
            set { daySafe.Nom50.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny20
        public string DaySafe20Name
        {
            get { return daySafe.Nom20.Name; }
        }

        public int DaySafe20Quantity
        {
            get { return daySafe.Nom20.Quantity; }
            set
            {
                daySafe.Nom20.Quantity = value;
                DaySafe20Amount = Calculate(daySafe.Nom20);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe20Amount
        {
            get { return daySafe.Nom20.FVAmount; }
            set { daySafe.Nom20.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny10
        public string DaySafe10Name
        {
            get { return daySafe.Nom10.Name; }
        }

        public int DaySafe10Quantity
        {
            get { return daySafe.Nom10.Quantity; }
            set
            {
                daySafe.Nom10.Quantity = value;
                DaySafe10Amount = Calculate(daySafe.Nom10);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe10Amount
        {
            get { return daySafe.Nom10.FVAmount; }
            set { daySafe.Nom10.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region SejfDzienny5
        public string DaySafe5Name
        {
            get { return daySafe.Nom5.Name; }
        }

        public int DaySafe5Quantity
        {
            get { return daySafe.Nom5.Quantity; }
            set
            {
                daySafe.Nom5.Quantity = value;
                DaySafe5Amount = Calculate(daySafe.Nom5);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe5Amount
        {
            get { return daySafe.Nom5.FVAmount; }
            set { daySafe.Nom5.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny2
        public string DaySafe2Name
        {
            get { return daySafe.Nom2.Name; }
        }

        public int DaySafe2Quantity
        {
            get { return daySafe.Nom2.Quantity; }
            set
            {
                daySafe.Nom2.Quantity = value;
                DaySafe2Amount = Calculate(daySafe.Nom2);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe2Amount
        {
            get { return daySafe.Nom2.FVAmount; }
            set { daySafe.Nom2.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfDzienny1
        public string DaySafe1Name
        {
            get { return daySafe.Nom1.Name; }
        }

        public int DaySafe1Quantity
        {
            get { return daySafe.Nom1.Quantity; }
            set
            {
                daySafe.Nom1.Quantity = value;
                DaySafe1Amount = Calculate(daySafe.Nom1);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal DaySafe1Amount
        {
            get { return daySafe.Nom1.FVAmount; }
            set { daySafe.Nom1.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion


        #endregion

        #region SEJF GŁÓWNY

        public decimal MainSafeAmount
        {
            get
            {
                return _mainSafeAmount;
            }
            set
            {
                _mainSafeAmount = value;
                OnPropertyChanged();
            }
        }
        public void SetMainSafeAmount()
        {
            MainSafeAmount = mainSafe.WalletSum();
        }

        #region SejfGłówny50000
        public string MainSafe50000Name
        {
            get { return mainSafe.Nom50000.Name; }
        }

        public int MainSafe50000Quantity
        {
            get { return mainSafe.Nom50000.Quantity; }
            set
            {
                mainSafe.Nom50000.Quantity = value;
                MainSafe50000Amount = Calculate(mainSafe.Nom50000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe50000Amount
        {
            get { return mainSafe.Nom50000.FVAmount; }
            set { mainSafe.Nom50000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny20000
        public string MainSafe20000Name
        {
            get { return mainSafe.Nom20000.Name; }
        }

        public int MainSafe20000Quantity
        {
            get { return mainSafe.Nom20000.Quantity; }
            set
            {
                mainSafe.Nom20000.Quantity = value;
                MainSafe20000Amount = Calculate(mainSafe.Nom20000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe20000Amount
        {
            get { return mainSafe.Nom20000.FVAmount; }
            set { mainSafe.Nom20000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny10000
        public string MainSafe10000Name
        {
            get { return mainSafe.Nom10000.Name; }
        }

        public int MainSafe10000Quantity
        {
            get { return mainSafe.Nom10000.Quantity; }
            set
            {
                mainSafe.Nom10000.Quantity = value;
                MainSafe10000Amount = Calculate(mainSafe.Nom10000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe10000Amount
        {
            get { return mainSafe.Nom10000.FVAmount; }
            set { mainSafe.Nom10000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region SejfGłówny5000
        public string MainSafe5000Name
        {
            get { return mainSafe.Nom5000.Name; }
        }

        public int MainSafe5000Quantity
        {
            get { return mainSafe.Nom5000.Quantity; }
            set
            {
                mainSafe.Nom5000.Quantity = value;
                MainSafe5000Amount = Calculate(mainSafe.Nom5000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe5000Amount
        {
            get { return mainSafe.Nom5000.FVAmount; }
            set { mainSafe.Nom5000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny2000
        public string MainSafe2000Name
        {
            get { return mainSafe.Nom2000.Name; }
        }

        public int MainSafe2000Quantity
        {
            get { return mainSafe.Nom2000.Quantity; }
            set
            {
                mainSafe.Nom2000.Quantity = value;
                MainSafe2000Amount = Calculate(mainSafe.Nom2000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe2000Amount
        {
            get { return mainSafe.Nom2000.FVAmount; }
            set { mainSafe.Nom2000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny1000
        public string MainSafe1000Name
        {
            get { return mainSafe.Nom1000.Name; }
        }

        public int MainSafe1000Quantity
        {
            get { return mainSafe.Nom1000.Quantity; }
            set
            {
                mainSafe.Nom1000.Quantity = value;
                MainSafe1000Amount = Calculate(mainSafe.Nom1000);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe1000Amount
        {
            get { return mainSafe.Nom1000.FVAmount; }
            set { mainSafe.Nom1000.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region SejfGłówny500
        public string MainSafe500Name
        {
            get { return mainSafe.Nom500.Name; }
        }

        public int MainSafe500Quantity
        {
            get { return mainSafe.Nom500.Quantity; }
            set
            {
                mainSafe.Nom500.Quantity = value;
                MainSafe500Amount = Calculate(mainSafe.Nom500);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe500Amount
        {
            get { return mainSafe.Nom500.FVAmount; }
            set { mainSafe.Nom500.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny200
        public string MainSafe200Name
        {
            get { return mainSafe.Nom200.Name; }
        }

        public int MainSafe200Quantity
        {
            get { return mainSafe.Nom200.Quantity; }
            set
            {
                mainSafe.Nom200.Quantity = value;
                MainSafe200Amount = Calculate(mainSafe.Nom200);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe200Amount
        {
            get { return mainSafe.Nom200.FVAmount; }
            set { mainSafe.Nom200.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny100
        public string MainSafe100Name
        {
            get { return mainSafe.Nom100.Name; }
        }

        public int MainSafe100Quantity
        {
            get { return mainSafe.Nom100.Quantity; }
            set
            {
                mainSafe.Nom100.Quantity = value;
                MainSafe100Amount = Calculate(mainSafe.Nom100);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe100Amount
        {
            get { return mainSafe.Nom100.FVAmount; }
            set { mainSafe.Nom100.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region SejfGłówny50
        public string MainSafe50Name
        {
            get { return mainSafe.Nom50.Name; }
        }

        public int MainSafe50Quantity
        {
            get { return mainSafe.Nom50.Quantity; }
            set
            {
                mainSafe.Nom50.Quantity = value;
                MainSafe50Amount = Calculate(mainSafe.Nom50);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe50Amount
        {
            get { return mainSafe.Nom50.FVAmount; }
            set { mainSafe.Nom50.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny20
        public string MainSafe20Name
        {
            get { return mainSafe.Nom20.Name; }
        }

        public int MainSafe20Quantity
        {
            get { return mainSafe.Nom20.Quantity; }
            set
            {
                mainSafe.Nom20.Quantity = value;
                MainSafe20Amount = Calculate(mainSafe.Nom20);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe20Amount
        {
            get { return mainSafe.Nom20.FVAmount; }
            set { mainSafe.Nom20.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny10
        public string MainSafe10Name
        {
            get { return mainSafe.Nom10.Name; }
        }

        public int MainSafe10Quantity
        {
            get { return mainSafe.Nom10.Quantity; }
            set
            {
                mainSafe.Nom10.Quantity = value;
                MainSafe10Amount = Calculate(mainSafe.Nom10);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe10Amount
        {
            get { return mainSafe.Nom10.FVAmount; }
            set { mainSafe.Nom10.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #region SejfGłówny5
        public string MainSafe5Name
        {
            get { return mainSafe.Nom5.Name; }
        }

        public int MainSafe5Quantity
        {
            get { return mainSafe.Nom5.Quantity; }
            set
            {
                mainSafe.Nom5.Quantity = value;
                MainSafe5Amount = Calculate(mainSafe.Nom5);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe5Amount
        {
            get { return mainSafe.Nom5.FVAmount; }
            set { mainSafe.Nom5.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny2
        public string MainSafe2Name
        {
            get { return mainSafe.Nom2.Name; }
        }

        public int MainSafe2Quantity
        {
            get { return mainSafe.Nom2.Quantity; }
            set
            {
                mainSafe.Nom2.Quantity = value;
                MainSafe2Amount = Calculate(mainSafe.Nom2);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe2Amount
        {
            get { return mainSafe.Nom2.FVAmount; }
            set { mainSafe.Nom2.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion
        #region SejfGłówny1
        public string MainSafe1Name
        {
            get { return mainSafe.Nom1.Name; }
        }

        public int MainSafe1Quantity
        {
            get { return mainSafe.Nom1.Quantity; }
            set
            {
                mainSafe.Nom1.Quantity = value;
                MainSafe1Amount = Calculate(mainSafe.Nom1);
                SetWalletValue();
                OnPropertyChanged();
            }
        }
        public decimal MainSafe1Amount
        {
            get { return mainSafe.Nom1.FVAmount; }
            set { mainSafe.Nom1.FVAmount = value; OnPropertyChanged(); }
        }
        #endregion

        #endregion

        private static decimal Calculate(FaceValue nom)
        {
            return nom.FValue * nom.Quantity;
        }
    }
}
