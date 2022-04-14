// Decompiled with JetBrains decompiler
// Type: RISHI_HHT_APP.CommonClass.CommonMethod
// Assembly: RISHI_HHT_APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AC79D65A-76D4-40D5-A4CF-0AA4D48B12E9
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\RISHI_HHT_APP.dll

using Android.Widget;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using Xamarin.Forms;

namespace RISHI_HHT_APP.CommonClass
{
    public class CommonMethod
    {
        public static void FillComboBox(Picker Picker, DataTable dt, string DisPlayMember)
        {
            try
            {
                Picker.ItemsSource = (IList)null;
                List<string> list = dt.Rows.OfType<DataRow>().Select<DataRow, string>((Func<DataRow, string>)(dr => (string)dr[DisPlayMember])).ToList<string>();
                Picker.ItemsSource = (IList)list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UNFill_ComboBox(Picker Picker)
        {
            try
            {
                Picker.ItemsSource = (IList)null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ToastMsg(string Msg, string MsgType)
        {
            try
            {
                SoundPlay soundPlay = DependencyService.Get<SoundPlay>();
                soundPlay.PlaySound(MsgType);
                Thread.Sleep(3000);
                Toast.MakeText(Android.App.Application.Context, Msg, ToastLength.Long).Show();
                soundPlay.StopSound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DisplayMsg(Page page, string Msg, string MsgType)
        {
            try
            {
                bool Result = false;
                Device.BeginInvokeOnMainThread((System.Action)(async () =>
                {
                    Page page1 = page;
                    SoundPlay obj = DependencyService.Get<SoundPlay>();
                    obj.PlaySound(MsgType);
                    Thread.Sleep(3000);
                    obj.StopSound();
                    Result = await page1.DisplayAlert("Alter!", Msg, "Accept", "Cancel");
                }));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
