using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasjer3.Models
{
    public class FaceWalueSet
    {
        public FaceValue Nom50000 = new(50000);
        public FaceValue Nom20000 = new(20000);
        public FaceValue Nom10000 = new(10000);
        public FaceValue Nom5000 = new(5000);
        public FaceValue Nom2000 = new(2000);
        public FaceValue Nom1000 = new(1000);
        public FaceValue Nom500 = new(500);
        public FaceValue Nom200 = new(200);
        public FaceValue Nom100 = new(100);
        public FaceValue Nom50 = new(50);
        public FaceValue Nom20 = new(20);
        public FaceValue Nom10 = new(10);
        public FaceValue Nom5 = new(5);
        public FaceValue Nom2 = new(2);
        public FaceValue Nom1 = new(1);

        public decimal WalletSum()
        {
            decimal walletSum = 0;

            walletSum = (Nom50000.Quantity * Nom50000.FValue)
                + (Nom20000.Quantity * Nom20000.FValue)
                + (Nom10000.Quantity * Nom10000.FValue)
                + (Nom5000.Quantity * Nom5000.FValue)
                + (Nom2000.Quantity * Nom2000.FValue)
                + (Nom1000.Quantity * Nom1000.FValue)
                + (Nom500.Quantity * Nom500.FValue)
                + (Nom200.Quantity * Nom200.FValue)
                + (Nom100.Quantity * Nom100.FValue)
                + (Nom50.Quantity * Nom50.FValue)
                + (Nom20.Quantity * Nom20.FValue)
                + (Nom10.Quantity * Nom10.FValue)
                + (Nom5.Quantity * Nom5.FValue)
                + (Nom2.Quantity * Nom2.FValue)
                + (Nom1.Quantity * Nom1.FValue);
            return walletSum;
        }
    }
}
