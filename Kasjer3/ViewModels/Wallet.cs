using Kasjer3.Help;
using Kasjer3.Models;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Kasjer3.ViewModels
{
    public class Wallet : INotifyPropertyChanged
    {
        public Wallet()
        {
            walletStorage.ReadVersionFile(this);
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
        FaceWalueSet fullWallet = new FaceWalueSet();

        private readonly string _kasjerVersion = "3.2.0";
        private string _newKasjerVersion;
        private string _newKasjerVersionMessage = 
            $"Jest nowa wersja Kasjera. Możesz pobrać go ze strony:" +
            $"\n\t www.kasjer.polprofi.eu ";
        private decimal _casketAmount;
        private decimal _daySafeAmount;
        private decimal _mainSafeAmount;
        private decimal _systemValue;
        private string _systemValueString;
        private decimal _walletValue;
        private decimal _differenceValue;
        private readonly WalletStorage walletStorage = new WalletStorage();

        private string _amount50000 = "0";
        private string _amount20000 = "0";
        private string _amount10000 = "0";
        private string _amount5000 = "0";
        private string _amount2000 = "0";
        private string _amount1000 = "0";
        private string _amount500 = "0";
        private string _amount200 = "0";
        private string _amount100 = "0";
        private string _amount50 = "0";
        private string _amount20 = "0";
        private string _amount10 = "0";
        private string _amount5 = "0";
        private string _amount2 = "0";
        private string _amount1 = "0";


        public string NewKasjerVersion 
        { 
            get => _newKasjerVersion; 
            set
            {
                _newKasjerVersion = value;
                CheckingVersion();
            }
        }

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
                if (value == null  || value == "")
                { value = "0.00"; }    
                String temp = value.Replace(",",".");
                //decimal tempdecimal = decimal.Parse(temp);
                decimal tempdecimal = decimal.Parse(temp, CultureInfo.InvariantCulture.NumberFormat);
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
            SetQuantityNominal();
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

        #region WRZUTNIA

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

        #region SEJF

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

        #region WALLET

        public int Quantity50000
        {
            get { return fullWallet.Nom50000.Quantity; }
            set { fullWallet.Nom50000.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount50000Str
        {
            get { return _amount50000; }
            set { _amount50000 = value; OnPropertyChanged(); }
        }

        public int Quantity20000
        {
            get { return fullWallet.Nom20000.Quantity; }
            set { fullWallet.Nom20000.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount20000Str
        {
            get { return _amount20000; }
            set { _amount20000 = value; OnPropertyChanged(); }
        }
                
        public int Quantity10000
        {
            get { return fullWallet.Nom10000.Quantity; }
            set { fullWallet.Nom10000.Quantity = value; OnPropertyChanged(); }
        }public string Amount10000Str
        {
            get { return _amount10000; }
            set { _amount10000 = value; OnPropertyChanged(); }
        }



        public int Quantity5000
        {
            get { return fullWallet.Nom5000.Quantity; }
            set { fullWallet.Nom5000.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount5000Str
        {
            get { return _amount5000; }
            set { _amount5000 = value; OnPropertyChanged(); }
        }

        public int Quantity2000
        {
            get { return fullWallet.Nom2000.Quantity; }
            set { fullWallet.Nom2000.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount2000Str
        {
            get { return _amount2000; }
            set { _amount2000 = value; OnPropertyChanged(); }
        }

        public int Quantity1000
        {
            get { return fullWallet.Nom1000.Quantity; }
            set { fullWallet.Nom1000.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount1000Str
        {
            get { return _amount1000; }
            set { _amount1000 = value; OnPropertyChanged(); }
        }


        public int Quantity500
        {
            get { return fullWallet.Nom500.Quantity; }
            set { fullWallet.Nom500.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount500Str
        {
            get { return _amount500; }
            set { _amount500 = value; OnPropertyChanged(); }
        }

        public int Quantity200
        {
            get { return fullWallet.Nom200.Quantity; }
            set { fullWallet.Nom200.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount200Str
        {
            get { return _amount200; }
            set { _amount200 = value; OnPropertyChanged(); }
        }

        public int Quantity100
        {
            get { return fullWallet.Nom100.Quantity; }
            set { fullWallet.Nom100.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount100Str
        {
            get { return _amount100; }
            set { _amount100 = value; OnPropertyChanged(); }
        }


        public int Quantity50
        {
            get { return fullWallet.Nom50.Quantity; }
            set { fullWallet.Nom50.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount50Str
        {
            get { return _amount50; }
            set { _amount50 = value; OnPropertyChanged(); }
        }

        public int Quantity20
        {
            get { return fullWallet.Nom20.Quantity; }
            set { fullWallet.Nom20.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount20Str
        {
            get { return _amount20; }
            set { _amount20 = value; OnPropertyChanged(); }
        }

        public int Quantity10
        {
            get { return fullWallet.Nom10.Quantity; }
            set { fullWallet.Nom10.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount10Str
        {
            get { return _amount10; }
            set { _amount10 = value; OnPropertyChanged(); }
        }


        public int Quantity5
        {
            get { return fullWallet.Nom5.Quantity; }
            set { fullWallet.Nom5.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount5Str
        {
            get { return _amount5; }
            set { _amount5 = value; OnPropertyChanged(); }
        }

        public int Quantity2
        {
            get { return fullWallet.Nom2.Quantity; }
            set { fullWallet.Nom2.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount2Str
        {
            get { return _amount2; }
            set { _amount2 = value; OnPropertyChanged(); }
        }

        public int Quantity1
        {
            get { return fullWallet.Nom1.Quantity; }
            set { fullWallet.Nom1.Quantity = value; OnPropertyChanged(); }
        }
        public string Amount1Str
        {
            get { return _amount1; }
            set { _amount1 = value; OnPropertyChanged(); }
        }


        private void SetQuantityNominal()
        {
            Quantity50000 = Casket50000Quantity + DaySafe50000Quantity + MainSafe50000Quantity;
            Amount50000Str = Calculate(fullWallet.Nom50000).ToString("N2");
            Quantity20000 = Casket20000Quantity + DaySafe20000Quantity + MainSafe20000Quantity;
            Amount20000Str = Calculate(fullWallet.Nom20000).ToString("N2");
            Quantity10000 = Casket10000Quantity + DaySafe10000Quantity + MainSafe10000Quantity;
            Amount10000Str = Calculate(fullWallet.Nom10000).ToString("N2");
            Quantity5000 = Casket5000Quantity + DaySafe5000Quantity + MainSafe5000Quantity;
            Amount5000Str = Calculate(fullWallet.Nom5000).ToString("N2");
            Quantity2000 = Casket2000Quantity + DaySafe2000Quantity + MainSafe2000Quantity;
            Amount2000Str = Calculate(fullWallet.Nom2000).ToString("N2");
            Quantity1000 = Casket1000Quantity + DaySafe1000Quantity + MainSafe1000Quantity;
            Amount1000Str = Calculate(fullWallet.Nom1000).ToString("N2");
            Quantity500 = Casket500Quantity + DaySafe500Quantity + MainSafe500Quantity;
            Amount500Str = Calculate(fullWallet.Nom500).ToString("N2");
            Quantity200 = Casket200Quantity + DaySafe200Quantity + MainSafe200Quantity;
            Amount200Str = Calculate(fullWallet.Nom200).ToString("N2");
            Quantity100 = Casket100Quantity + DaySafe100Quantity + MainSafe100Quantity;
            Amount100Str = Calculate(fullWallet.Nom100).ToString("N2");
            Quantity50 = Casket50Quantity + DaySafe50Quantity + MainSafe50Quantity;
            Amount50Str = Calculate(fullWallet.Nom50).ToString("N2");
            Quantity20 = Casket20Quantity + DaySafe20Quantity + MainSafe20Quantity;
            Amount20Str = Calculate(fullWallet.Nom20).ToString("N2");
            Quantity10 = Casket10Quantity + DaySafe10Quantity + MainSafe10Quantity;
            Amount10Str = Calculate(fullWallet.Nom10).ToString("N2");
            Quantity5 = Casket5Quantity + DaySafe5Quantity + MainSafe5Quantity;
            Amount5Str = Calculate(fullWallet.Nom5).ToString("N2");
            Quantity2 = Casket2Quantity + DaySafe2Quantity + MainSafe2Quantity;
            Amount2Str = Calculate(fullWallet.Nom2).ToString("N2");
            Quantity1 = Casket1Quantity + DaySafe1Quantity + MainSafe1Quantity;
            Amount1Str = Calculate(fullWallet.Nom1).ToString("N2");


        }


        #endregion

        private static decimal Calculate(FaceValue nom)
        {
            return nom.FValue * nom.Quantity;
        }

        private void CheckingVersion()
        {
            if(NewKasjerVersion != _kasjerVersion)
            {
                StringBuilder sb = new StringBuilder("Nowa wersja programu Kasjer" + _newKasjerVersion!);
                var messageVersion = sb.ToString();
                MessageBox.Show( _newKasjerVersionMessage, messageVersion, MessageBoxButton.OK, MessageBoxImage.Asterisk);
                //if (MessageBox.Show("test", "Visit", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                
            }
        }
    }
}
