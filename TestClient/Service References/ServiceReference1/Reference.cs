﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestClient.ServiceReference1 {
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
        private string JobNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long LastNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Data.DataTable RetrieveSpoilRecordsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TextFileIndexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] TextFilesInDataFolderField;
        
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
        public int TextFileIndex {
            get {
                return this.TextFileIndexField;
            }
            set {
                if ((this.TextFileIndexField.Equals(value) != true)) {
                    this.TextFileIndexField = value;
                    this.RaisePropertyChanged("TextFileIndex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] TextFilesInDataFolder {
            get {
                return this.TextFilesInDataFolderField;
            }
            set {
                if ((object.ReferenceEquals(this.TextFilesInDataFolderField, value) != true)) {
                    this.TextFilesInDataFolderField = value;
                    this.RaisePropertyChanged("TextFilesInDataFolder");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ISpoilsWCFServices")]
    public interface ISpoilsWCFServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/CustomerName", ReplyAction="http://tempuri.org/ISpoilsWCFServices/CustomerNameResponse")]
        TestClient.ServiceReference1.DataContract CustomerName();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISpoilsWCFServices/CustomerName", ReplyAction="http://tempuri.org/ISpoilsWCFServices/CustomerNameResponse")]
        System.Threading.Tasks.Task<TestClient.ServiceReference1.DataContract> CustomerNameAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISpoilsWCFServicesChannel : TestClient.ServiceReference1.ISpoilsWCFServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SpoilsWCFServicesClient : System.ServiceModel.ClientBase<TestClient.ServiceReference1.ISpoilsWCFServices>, TestClient.ServiceReference1.ISpoilsWCFServices {
        
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
        
        public TestClient.ServiceReference1.DataContract CustomerName() {
            return base.Channel.CustomerName();
        }
        
        public System.Threading.Tasks.Task<TestClient.ServiceReference1.DataContract> CustomerNameAsync() {
            return base.Channel.CustomerNameAsync();
        }
    }
}
