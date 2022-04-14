﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace RISHI_HHT_APP.Droid.WebReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IService1", Namespace="http://tempuri.org/")]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback LoginValidateOperationCompleted;
        
        private System.Threading.SendOrPostCallback HHTScanningOperationCompleted;
        
        private System.Threading.SendOrPostCallback FetchMySqlDataOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service1() {
            this.Url = "http://172.16.16.110/KRISHI_WIP_WEB_Service/Service1.svc";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event LoginValidateCompletedEventHandler LoginValidateCompleted;
        
        /// <remarks/>
        public event HHTScanningCompletedEventHandler HHTScanningCompleted;
        
        /// <remarks/>
        public event FetchMySqlDataCompletedEventHandler FetchMySqlDataCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IService1/LoginValidate", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string LoginValidate([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string UserID, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Password, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Type) {
            object[] results = this.Invoke("LoginValidate", new object[] {
                        UserID,
                        Password,
                        Type});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LoginValidateAsync(string UserID, string Password, string Type) {
            this.LoginValidateAsync(UserID, Password, Type, null);
        }
        
        /// <remarks/>
        public void LoginValidateAsync(string UserID, string Password, string Type, object userState) {
            if ((this.LoginValidateOperationCompleted == null)) {
                this.LoginValidateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoginValidateOperationCompleted);
            }
            this.InvokeAsync("LoginValidate", new object[] {
                        UserID,
                        Password,
                        Type}, this.LoginValidateOperationCompleted, userState);
        }
        
        private void OnLoginValidateOperationCompleted(object arg) {
            if ((this.LoginValidateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoginValidateCompleted(this, new LoginValidateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IService1/HHTScanning", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Data.DataSet HHTScanning(
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Type, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string TransactionType, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string MachineBarcode, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string ItemBarcode, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Remarks, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string PicklistNo, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Value, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string BatchNo, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string TotalTrolleyWeight, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string AssetBarcode, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string NoOfBobins, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string CreatedBY, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Width, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Length, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string NoofEnds, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string WorkOrderNo, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string FGWeight, 
                    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string CustID) {
            object[] results = this.Invoke("HHTScanning", new object[] {
                        Type,
                        TransactionType,
                        MachineBarcode,
                        ItemBarcode,
                        Remarks,
                        PicklistNo,
                        Value,
                        BatchNo,
                        TotalTrolleyWeight,
                        AssetBarcode,
                        NoOfBobins,
                        CreatedBY,
                        Width,
                        Length,
                        NoofEnds,
                        WorkOrderNo,
                        FGWeight,
                        CustID});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void HHTScanningAsync(
                    string Type, 
                    string TransactionType, 
                    string MachineBarcode, 
                    string ItemBarcode, 
                    string Remarks, 
                    string PicklistNo, 
                    string Value, 
                    string BatchNo, 
                    string TotalTrolleyWeight, 
                    string AssetBarcode, 
                    string NoOfBobins, 
                    string CreatedBY, 
                    string Width, 
                    string Length, 
                    string NoofEnds, 
                    string WorkOrderNo, 
                    string FGWeight, 
                    string CustID) {
            this.HHTScanningAsync(Type, TransactionType, MachineBarcode, ItemBarcode, Remarks, PicklistNo, Value, BatchNo, TotalTrolleyWeight, AssetBarcode, NoOfBobins, CreatedBY, Width, Length, NoofEnds, WorkOrderNo, FGWeight, CustID, null);
        }
        
        /// <remarks/>
        public void HHTScanningAsync(
                    string Type, 
                    string TransactionType, 
                    string MachineBarcode, 
                    string ItemBarcode, 
                    string Remarks, 
                    string PicklistNo, 
                    string Value, 
                    string BatchNo, 
                    string TotalTrolleyWeight, 
                    string AssetBarcode, 
                    string NoOfBobins, 
                    string CreatedBY, 
                    string Width, 
                    string Length, 
                    string NoofEnds, 
                    string WorkOrderNo, 
                    string FGWeight, 
                    string CustID, 
                    object userState) {
            if ((this.HHTScanningOperationCompleted == null)) {
                this.HHTScanningOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHHTScanningOperationCompleted);
            }
            this.InvokeAsync("HHTScanning", new object[] {
                        Type,
                        TransactionType,
                        MachineBarcode,
                        ItemBarcode,
                        Remarks,
                        PicklistNo,
                        Value,
                        BatchNo,
                        TotalTrolleyWeight,
                        AssetBarcode,
                        NoOfBobins,
                        CreatedBY,
                        Width,
                        Length,
                        NoofEnds,
                        WorkOrderNo,
                        FGWeight,
                        CustID}, this.HHTScanningOperationCompleted, userState);
        }
        
        private void OnHHTScanningOperationCompleted(object arg) {
            if ((this.HHTScanningCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HHTScanningCompleted(this, new HHTScanningCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IService1/FetchMySqlData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Data.DataSet FetchMySqlData([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Type, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Value) {
            object[] results = this.Invoke("FetchMySqlData", new object[] {
                        Type,
                        Value});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void FetchMySqlDataAsync(string Type, string Value) {
            this.FetchMySqlDataAsync(Type, Value, null);
        }
        
        /// <remarks/>
        public void FetchMySqlDataAsync(string Type, string Value, object userState) {
            if ((this.FetchMySqlDataOperationCompleted == null)) {
                this.FetchMySqlDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFetchMySqlDataOperationCompleted);
            }
            this.InvokeAsync("FetchMySqlData", new object[] {
                        Type,
                        Value}, this.FetchMySqlDataOperationCompleted, userState);
        }
        
        private void OnFetchMySqlDataOperationCompleted(object arg) {
            if ((this.FetchMySqlDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FetchMySqlDataCompleted(this, new FetchMySqlDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void LoginValidateCompletedEventHandler(object sender, LoginValidateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoginValidateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoginValidateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void HHTScanningCompletedEventHandler(object sender, HHTScanningCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HHTScanningCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HHTScanningCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void FetchMySqlDataCompletedEventHandler(object sender, FetchMySqlDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FetchMySqlDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FetchMySqlDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591