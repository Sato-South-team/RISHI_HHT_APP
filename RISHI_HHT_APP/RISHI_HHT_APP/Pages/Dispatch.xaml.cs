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
	public partial class Dispatch : ContentPage
	{
		public Dispatch ()
		{
			InitializeComponent ();
		}
        private iService_Method objsc = DependencyService.Get<iService_Method>();
        private DataSet ds = new DataSet();
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
            if (Type == "GetDispatchWorkOrderNo")
            {
                this.ds = this.objsc.HHTScanning(Type, TransactionType, "", "", "", "", "", "", "", "", "", CommonVariables.Loggedin, "", "", "", "", this.txtWeight.Text, "");
                CommonMethod.FillComboBox(this.pklWO, this.ds.Tables[0], "WorkOrderNo");
            }
            if (!(Type == "Save"))
                return;
            DataTable table = this.objsc.HHTScanning(Type, TransactionType, "", this.txtROllBarcode.Text, "", txtInvoiceNo.Text, "", "", "", "", "", CommonVariables.Loggedin, "", "", "", this.pklWO.SelectedItem.ToString(), this.txtWeight.Text, "").Tables[0];
            if (table.Rows.Count > 0)
            {
                if (table.Rows[0][0].ToString() == "Saved")
                {
                    this.lblCount.Text = table.Rows[0][1].ToString();
                    this.txtROllBarcode.Text = "";
                    this.txtWeight.Text = "";
                    this.txtROllBarcode.Focus();
                    CommonMethod.ToastMsg("TRANSACTION DONE SUCCESSFULL", "Success");
                }
                else
                    CommonMethod.ToastMsg(table.Rows[0][0].ToString(), "Error");
            }
        }

        private void TxtWeight_Completed(object sender, EventArgs e)
        {
            try
            {
                if (!this.ControlValidation())
                    return;
                this.Transaction("Save", nameof(Dispatch));
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void PklWO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pklWO.SelectedIndex <= -1)
                    return;
                for (int index = 0; index < this.ds.Tables[0].Rows.Count; ++index)
                {
                    if (this.pklWO.SelectedItem.ToString() == this.ds.Tables[0].Rows[index]["WorkOrderNo"].ToString())
                    {
                        this.lblCount.Text = this.ds.Tables[0].Rows[index]["Count"].ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private bool ControlValidation()
        {
            if (this.pklWO.SelectedIndex == -1)
            {
                CommonMethod.ToastMsg("PLEASE SELECT WORKORDER NO", "Error");
                return false;
            }
            if (this.txtROllBarcode.Text == "" || this.txtROllBarcode.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE SCAN ROLL BARCODE", "Error");
                this.txtROllBarcode.Focus();
                return false;
            }
            if (!(this.txtWeight.Text == "") && this.txtWeight.Text != null)
                return true;
            CommonMethod.ToastMsg("PLEASE ENTER WEIGHT", "Error");
            this.txtWeight.Focus();
            return false;
        }

        private void ContentPage_LayoutChanged(object sender, EventArgs e)
        {
            try
            {
                this.Transaction("GetDispatchWorkOrderNo", "");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }


    }
}