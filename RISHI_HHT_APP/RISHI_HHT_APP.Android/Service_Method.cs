// Decompiled with JetBrains decompiler
// Type: RISHI_HHT_APP.Droid.Service_Method
// Assembly: RISHI_HHT_APP.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B790BEE4-67B8-4A5A-BD9D-D0FA99DC5ADC
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\RISHI_HHT_APP.Android.dll

using RISHI_HHT_APP.CommonClass;
using System;
using System.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(RISHI_HHT_APP.Droid.Service_Method))]
namespace RISHI_HHT_APP.Droid
{
    public class Service_Method : iService_Method
    {
        public DataSet FetchMySqlData(string Type, string Values)
        {
            try
            {
                return MainActivity.objSR.FetchMySqlData(Type, Values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet HHTScanning(
          string Type,
          string TransactionType,
          string MachineBarcode,
          string ItemBarcode,
          string Remarks,
          string InvoiceNo,
          string Value,
          string BatchNo,
          string TotalTrolleyWeight,
          string AssetBarcode,
          string NoOfBobins,
          string CreatedBY,
          string Width,
          string Length,
          string NoofEnds,
          string WorkOrderNo,
          string FGWeight,
          string CustID)
        {
            try
            {
                return MainActivity.objSR.HHTScanning(Type, TransactionType, MachineBarcode, ItemBarcode, Remarks, InvoiceNo, Value, BatchNo, TotalTrolleyWeight, AssetBarcode, NoOfBobins, CreatedBY, Width, Length, NoofEnds, WorkOrderNo, FGWeight, CustID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidateLogin(string UserId, string Password, string Type)
        {
            try
            {
                return MainActivity.objSR.LoginValidate(UserId, Password, Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
