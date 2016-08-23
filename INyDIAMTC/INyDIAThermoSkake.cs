using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using InhecoMTCdll;

namespace INyDIAMTC
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("973447BF-0A16-4F0D-92E5-8BB5106216BA")]
    public interface INyDIAThermoSkake
    {
        //void shake();
        void SetTargetTemperature(int TTemperatureinCelsiusTenthDegrees);
        void ActionTemperatureEnable(bool bONorOFF);
        void SetShakerShape(int iShape);
        void SetShakerRevolutions(int iRevolutions);
        void ActionShakerEnable(bool bONorOFF);

        //int ReportTargetTemperature();
        //int ReportActualTemperature();
        //float TemperatureInCelsiusDegrees { set; get; }
        //string RotationsPerMinute { set; get; }
    }

    public class INyDIAMTC : INyDIAThermoSkake
    {

        private GlobCom INyGo = new GlobCom();
        public void SetTargetTemperature(int TTemperatureinCelsiusTenthDegrees)
        {
            int ID;
            ID = (int)0;
            if (INyGo.FindTheUniversalControl(ID) == 1)
            {
                string str = "1STT" + (TTemperatureinCelsiusTenthDegrees).ToString();
                INyGo.WriteOnly(str);
                string tmp = INyGo.ReadSync();
                //str = "1ATE1";
                //INyGo.WriteOnly(str);
                //INyGo.ReadSync();
            }

        }

        public void ActionTemperatureEnable(bool bONorOFF)
        {
            int ID;
            ID = (int)0;
            if (INyGo.FindTheUniversalControl(ID) == 1)
            {
                if (bONorOFF)
                {
                    string str = "1ATE1"; // +(TTemperatureinCelsiusTenthDegrees).ToString();
                    INyGo.WriteOnly(str);
                    string tmp = INyGo.ReadSync();
                    //str = "1ATE1";
                    //INyGo.WriteOnly(str);
                    //INyGo.ReadSync();
                }
                else
                {
                    string str = "1ATE0"; // +(TTemperatureinCelsiusTenthDegrees).ToString();
                    INyGo.WriteOnly(str);
                    string tmp = INyGo.ReadSync();
                    //str = "1ATE1";
                    //INyGo.WriteOnly(str);
                    //INyGo.ReadSync();
                }
            }

        }

        public void SetShakerShape(int iShape)
        {
            int ID;
            ID = (int)0;
            if (INyGo.FindTheUniversalControl(ID) == 1)
            {
                string str = "1SSS" + (iShape).ToString();
                INyGo.WriteOnly(str);
                string tmp = INyGo.ReadSync();
                //str = "1ATE1";
                //INyGo.WriteOnly(str);
                //INyGo.ReadSync();
            }

        }

        public void SetShakerRevolutions(int iRevolutions)
        {
            int ID;
            ID = (int)0;
            if (INyGo.FindTheUniversalControl(ID) == 1)
            {
                string str = "1SSR" + (iRevolutions).ToString();
                INyGo.WriteOnly(str);
                string tmp = INyGo.ReadSync();
                //str = "1ATE1";
                //INyGo.WriteOnly(str);
                //INyGo.ReadSync();
            }

        }

        public void ActionShakerEnable(bool bONorOFF)
        {
            int ID;
            ID = (int)0;
            if (INyGo.FindTheUniversalControl(ID) == 1)
            {
                if (bONorOFF)
                {
                    string str = "1ASE1"; // +(TTemperatureinCelsiusTenthDegrees).ToString();
                    INyGo.WriteOnly(str);
                    string tmp = INyGo.ReadSync();
                    //str = "1ATE1";
                    //INyGo.WriteOnly(str);
                    //INyGo.ReadSync();
                }
                else
                {
                    string str = "1ASE0"; // +(TTemperatureinCelsiusTenthDegrees).ToString();
                    INyGo.WriteOnly(str);
                    string tmp = INyGo.ReadSync();
                    //str = "1ATE1";
                    //INyGo.WriteOnly(str);
                    //INyGo.ReadSync();
                }
            }

        }

        //private float mFlt_TemperatureInCelsiusDegrees;

        public float CurrentTemperature
        {
            get
            {
                int ID;
                ID = (int)0;
                if (INyGo.FindTheUniversalControl(ID) == 1)
                {
                    string str;
                    string tmp;
                    str = "0RAT1";
                    INyGo.WriteOnly(str);
                    tmp = INyGo.ReadSync();
                    return System.Convert.ToSingle(tmp.Substring(4)) / 10; //tmp.Substring(4); //tmp; // System.Convert.ToSingle(tmp, System.Globalization.CultureInfo.InvariantCulture) / 10;
                }
                else { return 0; }
            }
        }

        //private string m_Int_RotationsPerMinute;
        //public string RotationsPerMinute
        //{
        //    get
        //    {
        //        int ID;
        //        ID = (int)0;
        //        if (INyGo.FindTheUniversalControl(ID) == 1)
        //        {
        //            string str;
        //            string tmp;
        //            str = "1RSR";
        //            INyGo.WriteOnly(str);
        //            tmp = INyGo.ReadSync();
        //            return tmp; //System.Convert.ToInt16(tmp.Substring(2)); //tmp.Substring(4); //tmp; // System.Convert.ToSingle(tmp, System.Globalization.CultureInfo.InvariantCulture) / 10;
        //        }
        //        else { return "0"; }
        //    }
        //    set
        //    {
        //        m_Int_RotationsPerMinute = value;
        //    }
        //}

        //public void shake()
        //{
        //    int ID;
        //    ID = (int)0;
        //    if (INyGo.FindTheUniversalControl(ID) == 1)
        //    {
        //        string tmp;
        //        string str = "1RSE";
        //        INyGo.WriteOnly(str);
        //        tmp = INyGo.ReadSync();
        //        //Console.WriteLine(tmp);
        //        char[] chararray = tmp.ToCharArray();
        //        if (chararray[5] == 0x30)
        //        {
        //            str = "1ASE1";
        //            INyGo.WriteOnly(str);
        //        }
        //        else
        //        {
        //            str = "1ASE0";
        //            INyGo.WriteOnly(str);
        //        }
        //        tmp = INyGo.ReadSync();
        //        //Console.WriteLine(tmp);
        //    }
        //    else { Console.WriteLine("Thermoshake not found."); }
        //}
    }
}
