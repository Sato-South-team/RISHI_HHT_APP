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
	public partial class Inspection : ContentPage
	{
		public Inspection ()
		{
			InitializeComponent ();
		}
        private iService_Method objsc = DependencyService.Get<iService_Method>();
        private string WO = "";
        private string Cust = "";

        private void ImgBack_Clicked(object sender, EventArgs e)
        {
            try
            {
                Application.Current.MainPage = (Page)new HomePage();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void Transaction(string Type, string TransactionType)
        {
            if (Type == "FetchInspectionOutputWorkOrder")
                CommonMethod.FillComboBox(this.pklOutPutWONo, this.objsc.FetchMySqlData(Type, "").Tables[0], "WorkOrderno");
            if (Type == "GetRollFormates")
                CommonMethod.FillComboBox(this.pklCustCode, this.objsc.HHTScanning(Type, TransactionType, this.txtMachine.Text, this.txtJamboRoll.Text, "", "", this.txtWO.Text, "", "", "", "", CommonVariables.Loggedin, "", this.txtLen.Text, "", this.WO, "", this.Cust).Tables[0], "CustCode");
            if (!(Type == "Full") && !(Type == "Short") && !(Type == "Save"))
                return;
            DataTable table = this.objsc.HHTScanning(Type, TransactionType, this.txtMachine.Text, this.txtJamboRoll.Text, "", "", this.txtWO.Text, "", "", "", "", CommonVariables.Loggedin, "", this.txtLen.Text, "", this.WO, "", this.Cust).Tables[0];
            if (table.Rows.Count > 0)
            {
                if (table.Rows[0][0].ToString() == "Saved")
                {
                    this.txtJamboRoll.Text = "";
                    this.txtJamboRoll.Focus();
                    CommonMethod.ToastMsg("TRANSACTION DONE SUCCESSFULL", "Success");
                }
                else
                    CommonMethod.ToastMsg(table.Rows[0][0].ToString(), "Error");
            }
        }

        private void TxtMachine_Completed(object sender, EventArgs e)
        {
            try
            {
                this.txtJamboRoll.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtJamboRoll_Completed(object sender, EventArgs e)
        {
            try
            {
                if (!this.InputControlValidation())
                    return;
                this.txtWO.Text = this.txtJamboRoll.Text.Split('|')[0].ToString();
                this.WO = this.txtWO.Text;
                this.Transaction("Save", "Inspection_Input");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void ImgPrint_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!this.OutputControlValidation())
                    return;
                this.WO = this.pklOutPutWONo.SelectedItem.ToString();
                this.Cust = this.pklCustCode.SelectedItem.ToString();
                this.Transaction("Full", "Inspection_Output");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void ImgShortPrint_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!this.OutputControlValidation())
                    return;
                this.WO = this.pklOutPutWONo.SelectedItem.ToString();
                this.Cust = this.pklCustCode.SelectedItem.ToString();
                this.Transaction("Short", "Inspection_Output");
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
                this.Transaction("FetchInspectionOutputWorkOrder", "");
                this.Transaction("GetRollFormates", "");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private bool OutputControlValidation()
        {
            if (this.pklOutPutWONo.SelectedIndex == -1)
            {
                CommonMethod.ToastMsg("PLEASE SELECT OUTPUT WORKORDER NO", "Error");
                return false;
            }
            if (this.pklCustCode.SelectedIndex == -1)
            {
                CommonMethod.ToastMsg("PLEASE SELECT CUST CODE", "Error");
                return false;
            }
            if (!(this.txtLen.Text == "") && this.txtLen.Text != null)
                return true;
            CommonMethod.ToastMsg("PLEASE ENTER LENGTH", "Error");
            this.txtLen.Focus();
            return false;
        }

        private bool InputControlValidation()
        {
            if (this.txtMachine.Text == "" || this.txtMachine.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE SCAN MACHINE", "Error");
                this.txtMachine.Focus();
                return false;
            }
            if (!(this.txtJamboRoll.Text == "") && this.txtJamboRoll.Text != null)
                return true;
            CommonMethod.ToastMsg("PLEASE SCAN JUMBO ROLL", "Error");
            this.txtMachine.Focus();
            return false;
        }

    }
}