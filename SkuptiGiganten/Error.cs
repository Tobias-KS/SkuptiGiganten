using System;
using System.Collections.Generic;
using System.Text;

namespace SkuptiGiganten
{
    class Error
    {
        private int errorValue;
        private string returnString;
        public Error(int input, ref string returnString)
        {
            errorValue = input;
        }

        public string errorMessage()
        {
            switch (errorValue)
            {
            // Hvis folk laver ugyldigt input
                case 1:
                    returnString = "Ugyldigt input";
                    break;
                    
            //for at undgå en fejlbesked
                default:
                    returnString = "no error";
                    break;
            }
            return returnString;






        }
    }
}
