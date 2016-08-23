using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using INyDIAMTC;

namespace test_Thermoshake
{
    class Program
    {
        static void Main(string[] args)
        {
            INyDIAMTC.INyDIAMTC Thermo = new INyDIAMTC.INyDIAMTC();
            Console.Write(Thermo.CurrentTemperature); // = null;
        }
    }
}
