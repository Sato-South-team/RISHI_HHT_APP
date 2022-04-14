using RISHI_HHT_APP.CommonClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RISHI_HHT_APP.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();

        }
        CommonClass.iService_Method objsc = DependencyService.Get<CommonClass.iService_Method>();

        private bool ControlValidation()
        {
            string text = this.txtUserID.Text;
            if (this.txtUserID.Text == "" && this.txtUserID.Text == (null))
            {
                CommonMethod.ToastMsg("ENTER USER ID", "Error");
                this.txtUserID.Focus();
                return false;
            }
            if (!(this.txtPassowrd.Text == "") || this.txtPassowrd.Text == (null))
                return true;
            CommonMethod.ToastMsg("ENTER PASSWORD", "Error");
            this.txtPassowrd.Focus();
            return false;
        }

        private void ValidateLogin()
        {
            if (!this.ControlValidation())
                return;
            string str = this.objsc.ValidateLogin(this.txtUserID.Text, this.txtPassowrd.Text, nameof(Login));
            if (str.StartsWith("VALID CREDENTIAL"))
            {
                string[] strArray = str.Split('+');
                CommonVariables.Loggedin = this.txtUserID.Text;
                CommonVariables.LoggedName = strArray[1];
                CommonVariables.Rights = strArray[2];
                Application.Current.MainPage = (Page)new HomePage();
            }
            else if (str.StartsWith("INVALID CREDENTIAL"))
            {
                CommonMethod.ToastMsg("INVALID CREDENTIAL", "Error");
                this.txtUserID.Focus();
            }
            else if (str.StartsWith("INVALID PASSWORD"))
            {
                CommonMethod.ToastMsg("INVALID PASSWORD", "Error");
                this.txtPassowrd.Focus();
            }
            else if (str.StartsWith("INVALID USER ID"))
            {
                CommonMethod.ToastMsg("INVALID USER ID", "Error");
                this.txtUserID.Focus();
            }
        }

        private void TxtPassowrd_Completed(object sender, EventArgs e)
        {
            try
            {
                this.ValidateLogin();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void ImgLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                this.ValidateLogin();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void ImgExit_Clicked(object sender, EventArgs e)
        {
            try
            {
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void ContentPage_LayoutChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtUserID.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

    }
}