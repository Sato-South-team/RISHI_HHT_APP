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
	public partial class Knitting : ContentPage
	{
		public Knitting ()
		{
			InitializeComponent ();
		}

        private iService_Method objsc = DependencyService.Get<iService_Method>();
        private string WO = "";
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
            if (Type == "FetchKnittingOutputWorkOrder")
                CommonMethod.FillComboBox(this.pklOutPutWONo, this.objsc.FetchMySqlData(Type, "").Tables[0], "WorkOrderno");
            if (!(Type == "Save"))
                return;
            DataTable table = this.objsc.HHTScanning(Type, TransactionType, this.txtMachine.Text, this.txtbeam.Text, "", "", this.txtWO.Text, "", "", this.txtbeam.Text, "", CommonVariables.Loggedin, "", "", "", this.WO, "", "").Tables[0];
            if (table.Rows.Count > 0)
            {
                if (table.Rows[0][0].ToString() == "Saved")
                {
                    this.txtbeam.Text = "";
                    this.txtbeam.Focus();
                    CommonMethod.ToastMsg("TRANSACTION DONE SUCCESSFULL", "Success");
                }
                else
                    CommonMethod.ToastMsg(table.Rows[0][0].ToString(), "Error");
            }
        }

        private void Txtbeam_Completed(object sender, EventArgs e)
        {
            try
            {
                if (!this.InputControlValidation() || !(this.txtbeam.Text != ""))
                    return;
                this.txtWO.Text = this.txtbeam.Text.Split('|')[0].ToString();
                this.WO = this.txtWO.Text;
                this.Transaction("Save", "Knitting_Input");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtMachine_Completed(object sender, EventArgs e)
        {
            try
            {
                this.txtbeam.Focus();
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
                if (this.pklOutPutWONo.SelectedIndex > -1)
                {
                    this.WO = this.pklOutPutWONo.SelectedItem.ToString();
                    this.Transaction("Save", "Knitting_Output");
                }
                else
                    CommonMethod.ToastMsg("PLEASE SELECT OUTPUT WORKORDER NO", "Error");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private bool InputControlValidation()
        {
            if (this.txtMachine.Text == "" || this.txtMachine.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE SCAN MACHINE", "Error");
                this.txtMachine.Focus();
                return false;
            }
            if (!(this.txtbeam.Text == "") && this.txtbeam.Text != null)
                return true;
            CommonMethod.ToastMsg("PLEASE SCAN BEAM CARD", "Error");
            this.txtbeam.Focus();
            return false;
        }

        private void ContentPage_LayoutChanged(object sender, EventArgs e)
        {
            try
            {
                this.Transaction("FetchKnittingOutputWorkOrder", "");
                this.txtMachine.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

    }
}