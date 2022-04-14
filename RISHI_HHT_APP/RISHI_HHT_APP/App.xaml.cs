using RISHI_HHT_APP.CommonClass;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RISHI_HHT_APP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CommonVariables.Path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/GreenPro_WIP";
            if (Directory.Exists(CommonVariables.Path))
            {
                if (!File.Exists(CommonVariables.Path + "/Serivce.txt"))
                {
                    File.Create(CommonVariables.Path + "/Serivce.txt");
                }
                else
                {
                    StreamReader streamReader = new StreamReader(CommonVariables.Path + "/Serivce.txt");
                    CommonVariables.URL = streamReader.ReadToEnd();
                    streamReader.Close();
                    this.MainPage = (Page)new Pages.Login();
                }
            }
            else
            {
                Directory.CreateDirectory(CommonVariables.Path);
                File.Create(CommonVariables.Path + "/Serivce.txt");
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

    }
}
