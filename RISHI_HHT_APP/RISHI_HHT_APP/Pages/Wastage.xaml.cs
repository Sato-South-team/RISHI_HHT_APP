using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RISHI_HHT_APP.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Wastage : ContentPage
	{
		public Wastage ()
		{
			InitializeComponent ();
		}
        private void ImgBack_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new Pages.HomePage();
            }
            catch (Exception ex)
            {
                CommonClass.CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }
    }
}