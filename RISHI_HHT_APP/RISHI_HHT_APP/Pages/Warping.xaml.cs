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
	public partial class Warping : ContentPage
	{
		public Warping ()
		{
			InitializeComponent ();
		}

        private iService_Method objsc = DependencyService.Get<iService_Method>();
        private string WO = "";
        private string DoffID = "";
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
            if (Type == "FetchInputWorkOrder")
            {
                this.ds = this.objsc.FetchMySqlData(Type, "");
                CommonMethod.FillComboBox(this.pklWONo, this.ds.Tables[0], "WorkOrderno");
            }
            if (Type == "FetchWarpingOutputWorkOrder")
                CommonMethod.FillComboBox(this.pklOutPutWONo, this.objsc.FetchMySqlData(Type, "").Tables[0], "WorkOrderno");
            if (!(Type == "Save"))
                return;
            DataTable table = this.objsc.HHTScanning(Type, TransactionType, this.txtMachine.Text, this.txtScanbobbin.Text, "", "", "", "", "", this.txtBeamAsset.Text, this.txtNoOfBobbins.Text, CommonVariables.Loggedin, this.txtWidth.Text, this.txtLenth.Text, this.txtEnds.Text, this.WO, "", "").Tables[0];
            if (table.Rows.Count > 0)
            {
                if (table.Rows[0][0].ToString() == "Saved")
                {
                    this.txtBeamAsset.Text = "";
                    this.txtScanbobbin.Text = "";
                    this.txtWidth.Text = "";
                    this.txtLenth.Text = "";
                    this.txtEnds.Text = "";
                    this.pklOutPutWONo.SelectedIndex = -1;
                    this.Transaction("FetchWarpingOutputWorkOrder", "");
                    this.txtNoOfBobbins.Text = "";
                    this.txtScanbobbin.Focus();
                    CommonMethod.ToastMsg("TRANSACTION DONE SUCCESSFULL", "Success");
                }
                else
                    CommonMethod.ToastMsg(table.Rows[0][0].ToString(), "Error");
            }
        }

        private void ContentPage_LayoutChanged(object sender, EventArgs e)
        {
            try
            {
                this.Transaction("FetchInputWorkOrder", "");
                this.Transaction("FetchWarpingOutputWorkOrder", "");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtEnds_Completed(object sender, EventArgs e)
        {
            try
            {
                if (!this.OutputControlValidation())
                    return;
                if (this.pklOutPutWONo.SelectedIndex > -1)
                    this.WO = this.pklOutPutWONo.SelectedItem.ToString();
                this.Transaction("Save", "Warping_Output");
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
                if (this.pklOutPutWONo.SelectedIndex > -1)
                    this.WO = this.pklOutPutWONo.SelectedItem.ToString();
                this.Transaction("Save", "Warping_Output");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            try
            {
                if (!this.InputControlValidation())
                    return;
                if (this.pklWONo.SelectedIndex > -1)
                    this.WO = this.pklWONo.SelectedItem.ToString();
                this.Transaction("Save", "Warping_Input");
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private bool InputControlValidation()
        {
            if (this.pklWONo.SelectedIndex == -1)
            {
                CommonMethod.ToastMsg("PLEASE SELECT INPUT WORKORDER NO", "Error");
                return false;
            }
            if (this.txtMachine.Text == "" || this.txtMachine.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE SCAN MACHINE", "Error");
                this.txtMachine.Focus();
                return false;
            }
            if (this.txtScanbobbin.Text == "" || this.txtScanbobbin.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE SCAN BOBBIN CARD", "Error");
                this.txtScanbobbin.Focus();
                return false;
            }
            if (!(this.txtNoOfBobbins.Text == "") && this.txtNoOfBobbins.Text != null)
                return true;
            CommonMethod.ToastMsg("PLEASE ENTER NO OF BOBBINS", "Error");
            this.txtNoOfBobbins.Focus();
            return false;
        }

        private bool OutputControlValidation()
        {
            if (this.pklOutPutWONo.SelectedIndex == -1)
            {
                CommonMethod.ToastMsg("PLEASE SELECT OUTPUT WORKORDER NO", "Error");
                return false;
            }
            if (this.txtBeamAsset.Text == "" || this.txtBeamAsset.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE SCAN BEAM ASSET", "Error");
                this.txtBeamAsset.Focus();
                return false;
            }
            if (this.txtWidth.Text == "" || this.txtWidth.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE SCAN WIDTH", "Error");
                this.txtWidth.Focus();
                return false;
            }
            if (this.txtLenth.Text == "" || this.txtLenth.Text == null)
            {
                CommonMethod.ToastMsg("PLEASE ENTER LENGTH", "Error");
                this.txtLenth.Focus();
                return false;
            }
            if (!(this.txtEnds.Text == "") && this.txtEnds.Text != null)
                return true;
            CommonMethod.ToastMsg("PLEASE ENTER ENDS", "Error");
            this.txtEnds.Focus();
            return false;
        }

        private void PklWONo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pklWONo.SelectedIndex <= -1)
                    return;

                DoffID = "";
                for (int index = 0; index < this.ds.Tables[0].Rows.Count; ++index)
                {
                    if (this.pklWONo.SelectedItem.ToString() == this.ds.Tables[0].Rows[index]["WorkOrderno"].ToString())
                    {
                        if(DoffID!="")
                        this.DoffID = DoffID+"/"+ this.ds.Tables[0].Rows[index]["DoffNos"].ToString();
                        else
                            this.DoffID =  this.ds.Tables[0].Rows[index]["DoffNos"].ToString();

                        //  break;
                    }
                }
                this.txtMachine.Focus();
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
                this.txtScanbobbin.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtScanbobbin_Completed(object sender, EventArgs e)
        {
            try
            {
                if (this.txtScanbobbin.Text != "")
                {
                    this.txtNoOfBobbins.Text = this.txtScanbobbin.Text.Split('|')[1].ToString();
                    if (!DoffID.Contains(this.txtScanbobbin.Text.Split('|')[2].ToString()))
                        CommonMethod.ToastMsg("DOFF NO IS NOT MATCHING", "Error");
                }
                this.txtNoOfBobbins.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void PklOutPutWONo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pklOutPutWONo.SelectedIndex <= -1)
                    return;
                this.txtBeamAsset.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtBeamAsset_Completed(object sender, EventArgs e)
        {
            try
            {
                this.txtWidth.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtWidth_Completed(object sender, EventArgs e)
        {
            try
            {
                this.txtLenth.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }

        private void TxtLenth_Completed(object sender, EventArgs e)
        {
            try
            {
                this.txtEnds.Focus();
            }
            catch (Exception ex)
            {
                CommonMethod.ToastMsg(ex.Message.ToString(), "Error");
            }
        }
    }
}