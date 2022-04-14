// Decompiled with JetBrains decompiler
// Type: RISHI_HHT_APP.Droid.MainActivity
// Assembly: RISHI_HHT_APP.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B790BEE4-67B8-4A5A-BD9D-D0FA99DC5ADC
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\RISHI_HHT_APP.Android.dll

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using RISHI_HHT_APP.CommonClass;
using RISHI_HHT_APP.Droid.WebReference;
using Xamarin.Forms.Platform.Android;

namespace RISHI_HHT_APP.Droid
{
    [Activity(ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, Icon = "@drawable/Qrcode", Label = "RISHI_HHT_APP", MainLauncher = true, Theme = "@style/MainTheme")]
    public class MainActivity : FormsAppCompatActivity
    {
        public static Service1 objSR = new Service1();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            FormsAppCompatActivity.TabLayoutResource = 2130968641;
            FormsAppCompatActivity.ToolbarResource = 2130968642;
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init((Context)this, savedInstanceState);
            MainActivity.objSR.Timeout = 100000;
            this.LoadApplication((Xamarin.Forms.Application)new RISHI_HHT_APP.App());
            MainActivity.objSR.Url = CommonVariables.URL;
        }
    }
}
