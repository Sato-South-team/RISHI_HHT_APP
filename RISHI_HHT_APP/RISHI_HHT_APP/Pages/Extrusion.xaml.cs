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
 
    public partial class Extrusion : ContentPage
	{
		public Extrusion()
		{
			InitializeComponent ();
           //Grd.Children.(0);
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

        private bool ControlValidation()
        {
            if (this.pklDOffNo.SelectedIndex == -1)
            {
                CommonMethod.ToastMsg("PLEASE SELECT DOFF NO", "Error");
                return false;
            }
            if (this.txtMachine.Text == "" || this.txtMachine.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE SCAN MACHINE", "Error");
                this.txtMachine.Focus();
                return false;
            }
            if (this.txtTrolley.Text == "" || this.txtTrolley.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE SCAN TROLLEY", "Error");
                this.txtTrolley.Focus();
                return false;
            }
            if (this.txtBatchNo.Text == "" || this.txtBatchNo.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE ENTER BATCH NO", "Error");
                this.txtBatchNo.Focus();
                return false;
            }
            if (this.txtWeight.Text == "" || this.txtWeight.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE ENTER TROLLEY WEIGHT", "Error");
                this.txtWeight.Focus();
                return false;
            }
            if (!(this.txtNoofBobbins.Text == "") && this.txtNoofBobbins.Text != null)
                return true;
            CommonMethod.ToastMsg("PLEASE ENTER NO OF BOBBINS", "Error");
            this.txtNoofBobbins.Focus();
            return false;
        }

        private void Transaction(string Type)
        {
            if (Type == "FetchDoffNo")
            {
                this.ds = this.objsc.FetchMySqlData(Type, "");
                CommonMethod.FillComboBox(this.pklDOffNo, this.ds.Tables[0], "doff_id");
            }
            if (!(Type == "Save"))
                return;
            DataTable table = this.objsc.HHTScanning(Type, nameof(Extrusion), this.txtMachine.Text, "", "", "", this.pklDOffNo.SelectedItem.ToString(), this.txtBatchNo.Text, this.txtWeight.Text, this.txtTrolley.Text, this.txtNoofBobbins.Text, CommonVariables.Loggedin, "", "", "", "", "", "").Tables[0];
            if (table.Rows[0][0].ToString() == "Saved")
            {
                this.pklDOffNo.SelectedItem = (object)"";
                this.txtNoofBobbins.Text = "";
                this.txtTrolley.Text = "";
                this.txtBatchNo.Text = "";
                this.txtWeight.Text = "";
                this.txtMachine.Text = "";
                this.txtBobbins.Text = "";
                this.Transaction("FetchDoffNo");
                CommonMethod.ToastMsg("TRANSACTION DONE SUCCESSFULL", "Success");
            }
            else
                CommonMethod.ToastMsg(table.Rows[0][0].ToString(), "Error");
        }

        private void ContentPage_LayoutChanged(object sender, EventArgs e)
        {
            try
            {
                this.Transaction("FetchDoffNo");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void PklDOffNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pklDOffNo.SelectedIndex <= -1)
                    return;
                for (int index = 0; index < this.ds.Tables[0].Rows.Count; ++index)
                {
                    if (this.pklDOffNo.SelectedItem.ToString() == this.ds.Tables[0].Rows[index]["doff_id"].ToString())
                    {
                        this.txtBobbins.Text = this.ds.Tables[0].Rows[index]["no_of_bobbins"].ToString();
                        this.txtMachine.Focus();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtNoofBobbins_Completed(object sender, EventArgs e)
        {
            try
            {
                if (!this.ControlValidation())
                    return;
                this.Transaction("Save");
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
                this.txtTrolley.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtTrolley_Completed(object sender, EventArgs e)
        {
            try
            {
                this.txtBatchNo.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtBatchNo_Completed(object sender, EventArgs e)
        {
            try
            {
                this.txtWeight.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtWeight_Completed(object sender, EventArgs e)
        {
            try
            {
                this.txtNoofBobbins.Focus();
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
                if (!this.ControlValidation())
                    return;
                this.Transaction("Save");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }
    }
}