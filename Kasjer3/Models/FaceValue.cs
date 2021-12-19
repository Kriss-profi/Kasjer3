using System;

namespace Kasjer3.Models
{
    public class FaceValue
    {
        
        public FaceValue(int nominal)
        {
            Name = "";
            Quantity = 0;
            FValue = Convert.ToDecimal(nominal) / 100;
            if (FValue >= 1)
            {
                Name = Convert.ToString(FValue) + " zł.";
            }
            else
            {
                Name = $"{Convert.ToString(nominal)} gr.";
            }
        }

        private string _name;
        private decimal _fvalue;
        private decimal _fvAmount;
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }


        public decimal FVAmount
        {
            //get { return FValue * Quantity; }
            get { return _fvAmount; }
            set { _fvAmount = value; }
        }

        public decimal FValue
        {
            get { return _fvalue; }
            set { _fvalue = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
