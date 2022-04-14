using RISHI_HHT_APP.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RISHI_HHT_APP.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage//W
	{
        public HomePage()
        {
            InitializeComponent();

        }

        CommonClass.iService_Method objsc = DependencyService.Get<CommonClass.iService_Method>();
        private void ContentPage_LayoutChanged(object sender, EventArgs e)
        {
            try
            {
                this.Transaction("GetprocessList");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void Transaction(string Type)
        {
            if (!(Type == "GetprocessList"))
                return;
            CommonMethod.FillComboBox(this.pklProcess, this.objsc.HHTScanning(Type, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "").Tables[0], "ProcessName");
        }

        private void ImgNext_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (this.pklProcess.SelectedItem.ToString() == "")
                    CommonMethod.ToastMsg("PLEASE SELECT PROCESS NAME", "Error");
                else if (this.pklProcess.SelectedItem.ToString() == "EXTRUSION")
                    Application.Current.MainPage = (Page)new Extrusion();
                else if (this.pklProcess.SelectedItem.ToString() == "WARPING")
                    Application.Current.MainPage = (Page)new Warping();
                else if (this.pklProcess.SelectedItem.ToString() == "WEAVING")
                    Application.Current.MainPage = (Page)new Weaving();
                else if (this.pklProcess.SelectedItem.ToString() == "INSPECTION")
                    Application.Current.MainPage = (Page)new Inspection();
                else if (this.pklProcess.SelectedItem.ToString() == "DISPATCH")
                    Application.Current.MainPage = (Page)new Dispatch();
                else if (this.pklProcess.SelectedItem.ToString() == "WASTAGE")
                    Application.Current.MainPage = (Page)new Wastage();
                else if (this.pklProcess.SelectedItem.ToString() == "TRACKING")
                    Application.Current.MainPage = (Page)new Tracking();
                else if (this.pklProcess.SelectedItem.ToString() == "KNITTING")
                    Application.Current.MainPage = (Page)new Knitting();
                else
                    CommonMethod.ToastMsg("INVALID PROCESS NAME", "Error");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void ImgBack_Clicked(object sender, EventArgs e)
        {
            try
            {
                Application.Current.MainPage = (Page)new Login();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

    }
}