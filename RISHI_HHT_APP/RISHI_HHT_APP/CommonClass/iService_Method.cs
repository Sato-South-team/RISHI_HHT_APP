// Decompiled with JetBrains decompiler
// Type: RISHI_HHT_APP.CommonClass.iService_Method
// Assembly: RISHI_HHT_APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC79D65A-76D4-40D5-A4CF-0AA4D48B12E9
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\RISHI_HHT_APP.dll

using System.Data;

namespace RISHI_HHT_APP.CommonClass
{
    public interface iService_Method
    {
        string ValidateLogin(string UserId, string Password, string Type);

        DataSet HHTScanning(
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
          string CustID);

        DataSet FetchMySqlData(string Type, string Values);
    }
}
