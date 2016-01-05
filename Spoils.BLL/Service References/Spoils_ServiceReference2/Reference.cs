﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spoils.BLL.Spoils_ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataContract", Namespace="http://schemas.datacontract.org/2004/07/Spoils_ServiceWCF")]
    [System.SerializableAttribute()]
    public partial class DataContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long FirstNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IndexOfTextFileField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string JobNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long LastNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Data.DataTable RetrieveSpoilRecordsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] TextFilesListField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool WasScannedField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerName {
            get {
                return this.CustomerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerNameField, value) != true)) {
                    this.CustomerNameField = value;
                    this.RaisePropertyChanged("CustomerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long FirstNumber {
            get {
                return this.FirstNumberField;
            }
            set {
                if ((this.FirstNumberField.Equals(value) != true)) {
                    this.FirstNumberField = value;
                    this.RaisePropertyChanged("FirstNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IndexOfTextFile {
            get {
                return this.IndexOfTextFileField;
            }
            set {
                if ((this.IndexOfTextFileField.Equals(value) != true)) {
                    this.IndexOfTextFileField = value;
                    this.RaisePropertyChanged("IndexOfTextFile");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string JobNumber {
            get {
                return this.JobNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.JobNumberField, value) != true)) {
                    this.JobNumberField = value;
                    this.RaisePropertyChanged("JobNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long LastNumber {
            get {
                return this.LastNumberField;
            }
            set {
                if ((this.LastNumberField.Equals(value) != true)) {
                    this.LastNumberField = value;
                    this.RaisePropertyChanged("LastNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Data.DataTable RetrieveSpoilRecords {
            get {
                return this.RetrieveSpoilRecordsField;
            }
            set {
                if ((object.ReferenceEquals(this.RetrieveSpoilRecordsField, value) != true)) {
                    this.RetrieveSpoilRecordsField = value;
                    this.RaisePropertyChanged("RetrieveSpoilRecords");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] TextFilesList {
            get {
                return this.TextFilesListField;
            }
            set {
                if ((object.ReferenceEquals(this.TextFilesListField, value) != true)) {
                    this.TextFilesListField = value;
                    this.RaisePropertyChanged("TextFilesList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool WasScanned {
            get {
                return this.WasScannedField;
            }
            set {
                if ((this.WasScannedField.Equals(value) != true)) {
                    this.WasScannedField = value;
                    this.RaisePropertyChanged("WasScanned");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Spoils_ServiceReference2.ISpoilsWCFServices")]
    public interface ISpoilsWCFServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/CustomerName", ReplyAction="http://tempuri.org/ISpoilsWCFServices/CustomerNameResponse")]
        Spoils.BLL.Spoils_ServiceReference2.DataContract CustomerName([System.ServiceModel.MessageParameterAttribute(Name="customerName")] Spoils.BLL.Spoils_ServiceReference2.DataContract customerName1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/CustomerName", ReplyAction="http://tempuri.org/ISpoilsWCFServices/CustomerNameResponse")]
        System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> CustomerNameAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract customerName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/JobNumber", ReplyAction="http://tempuri.org/ISpoilsWCFServices/JobNumberResponse")]
        Spoils.BLL.Spoils_ServiceReference2.DataContract JobNumber([System.ServiceModel.MessageParameterAttribute(Name="jobNumber")] Spoils.BLL.Spoils_ServiceReference2.DataContract jobNumber1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/JobNumber", ReplyAction="http://tempuri.org/ISpoilsWCFServices/JobNumberResponse")]
        System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> JobNumberAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract jobNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/FirstNumber", ReplyAction="http://tempuri.org/ISpoilsWCFServices/FirstNumberResponse")]
        Spoils.BLL.Spoils_ServiceReference2.DataContract FirstNumber(Spoils.BLL.Spoils_ServiceReference2.DataContract firstNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/FirstNumber", ReplyAction="http://tempuri.org/ISpoilsWCFServices/FirstNumberResponse")]
        System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> FirstNumberAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract firstNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/LastNumber", ReplyAction="http://tempuri.org/ISpoilsWCFServices/LastNumberResponse")]
        Spoils.BLL.Spoils_ServiceReference2.DataContract LastNumber(Spoils.BLL.Spoils_ServiceReference2.DataContract lastNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/LastNumber", ReplyAction="http://tempuri.org/ISpoilsWCFServices/LastNumberResponse")]
        System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> LastNumberAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract lastNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/TextFileIndexer", ReplyAction="http://tempuri.org/ISpoilsWCFServices/TextFileIndexerResponse")]
        Spoils.BLL.Spoils_ServiceReference2.DataContract TextFileIndexer(Spoils.BLL.Spoils_ServiceReference2.DataContract textFileIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/TextFileIndexer", ReplyAction="http://tempuri.org/ISpoilsWCFServices/TextFileIndexerResponse")]
        System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> TextFileIndexerAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract textFileIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/WasScanned", ReplyAction="http://tempuri.org/ISpoilsWCFServices/WasScannedResponse")]
        Spoils.BLL.Spoils_ServiceReference2.DataContract WasScanned([System.ServiceModel.MessageParameterAttribute(Name="wasScanned")] Spoils.BLL.Spoils_ServiceReference2.DataContract wasScanned1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/WasScanned", ReplyAction="http://tempuri.org/ISpoilsWCFServices/WasScannedResponse")]
        System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> WasScannedAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract wasScanned);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/ListOfTextFiles", ReplyAction="http://tempuri.org/ISpoilsWCFServices/ListOfTextFilesResponse")]
        Spoils.BLL.Spoils_ServiceReference2.DataContract ListOfTextFiles([System.ServiceModel.MessageParameterAttribute(Name="listOfTextFiles")] Spoils.BLL.Spoils_ServiceReference2.DataContract listOfTextFiles1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/ListOfTextFiles", ReplyAction="http://tempuri.org/ISpoilsWCFServices/ListOfTextFilesResponse")]
        System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> ListOfTextFilesAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract listOfTextFiles);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/GetSpoilRecordsDT", ReplyAction="http://tempuri.org/ISpoilsWCFServices/GetSpoilRecordsDTResponse")]
        Spoils.BLL.Spoils_ServiceReference2.DataContract GetSpoilRecordsDT([System.ServiceModel.MessageParameterAttribute(Name="getSpoilRecordsDT")] Spoils.BLL.Spoils_ServiceReference2.DataContract getSpoilRecordsDT1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/GetSpoilRecordsDT", ReplyAction="http://tempuri.org/ISpoilsWCFServices/GetSpoilRecordsDTResponse")]
        System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> GetSpoilRecordsDTAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract getSpoilRecordsDT);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISpoilsWCFServicesChannel : Spoils.BLL.Spoils_ServiceReference2.ISpoilsWCFServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SpoilsWCFServicesClient : System.ServiceModel.ClientBase<Spoils.BLL.Spoils_ServiceReference2.ISpoilsWCFServices>, Spoils.BLL.Spoils_ServiceReference2.ISpoilsWCFServices {
        
        public SpoilsWCFServicesClient() {
        }
        
        public SpoilsWCFServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SpoilsWCFServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SpoilsWCFServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SpoilsWCFServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Spoils.BLL.Spoils_ServiceReference2.DataContract CustomerName(Spoils.BLL.Spoils_ServiceReference2.DataContract customerName1) {
            return base.Channel.CustomerName(customerName1);
        }
        
        public System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> CustomerNameAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract customerName) {
            return base.Channel.CustomerNameAsync(customerName);
        }
        
        public Spoils.BLL.Spoils_ServiceReference2.DataContract JobNumber(Spoils.BLL.Spoils_ServiceReference2.DataContract jobNumber1) {
            return base.Channel.JobNumber(jobNumber1);
        }
        
        public System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> JobNumberAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract jobNumber) {
            return base.Channel.JobNumberAsync(jobNumber);
        }
        
        public Spoils.BLL.Spoils_ServiceReference2.DataContract FirstNumber(Spoils.BLL.Spoils_ServiceReference2.DataContract firstNum) {
            return base.Channel.FirstNumber(firstNum);
        }
        
        public System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> FirstNumberAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract firstNum) {
            return base.Channel.FirstNumberAsync(firstNum);
        }
        
        public Spoils.BLL.Spoils_ServiceReference2.DataContract LastNumber(Spoils.BLL.Spoils_ServiceReference2.DataContract lastNum) {
            return base.Channel.LastNumber(lastNum);
        }
        
        public System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> LastNumberAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract lastNum) {
            return base.Channel.LastNumberAsync(lastNum);
        }
        
        public Spoils.BLL.Spoils_ServiceReference2.DataContract TextFileIndexer(Spoils.BLL.Spoils_ServiceReference2.DataContract textFileIndex) {
            return base.Channel.TextFileIndexer(textFileIndex);
        }
        
        public System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> TextFileIndexerAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract textFileIndex) {
            return base.Channel.TextFileIndexerAsync(textFileIndex);
        }
        
        public Spoils.BLL.Spoils_ServiceReference2.DataContract WasScanned(Spoils.BLL.Spoils_ServiceReference2.DataContract wasScanned1) {
            return base.Channel.WasScanned(wasScanned1);
        }
        
        public System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> WasScannedAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract wasScanned) {
            return base.Channel.WasScannedAsync(wasScanned);
        }
        
        public Spoils.BLL.Spoils_ServiceReference2.DataContract ListOfTextFiles(Spoils.BLL.Spoils_ServiceReference2.DataContract listOfTextFiles1) {
            return base.Channel.ListOfTextFiles(listOfTextFiles1);
        }
        
        public System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> ListOfTextFilesAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract listOfTextFiles) {
            return base.Channel.ListOfTextFilesAsync(listOfTextFiles);
        }
        
        public Spoils.BLL.Spoils_ServiceReference2.DataContract GetSpoilRecordsDT(Spoils.BLL.Spoils_ServiceReference2.DataContract getSpoilRecordsDT1) {
            return base.Channel.GetSpoilRecordsDT(getSpoilRecordsDT1);
        }
        
        public System.Threading.Tasks.Task<Spoils.BLL.Spoils_ServiceReference2.DataContract> GetSpoilRecordsDTAsync(Spoils.BLL.Spoils_ServiceReference2.DataContract getSpoilRecordsDT) {
            return base.Channel.GetSpoilRecordsDTAsync(getSpoilRecordsDT);
        }
    }
}