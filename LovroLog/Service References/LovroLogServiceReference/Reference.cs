﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LovroLog.LovroLogServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LovroLogServiceReference.ILovroLogService")]
    public interface ILovroLogService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/GetBaseEvents", ReplyAction="http://tempuri.org/ILovroLogService/GetBaseEventsResponse")]
        LovroLog.Core.LovroEvents.LovroBaseEvent[] GetBaseEvents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/GetBaseEvents", ReplyAction="http://tempuri.org/ILovroLogService/GetBaseEventsResponse")]
        System.Threading.Tasks.Task<LovroLog.Core.LovroEvents.LovroBaseEvent[]> GetBaseEventsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/GetDiaperChangedEvents", ReplyAction="http://tempuri.org/ILovroLogService/GetDiaperChangedEventsResponse")]
        LovroLog.Core.LovroEvents.LovroDiaperChangedEvent[] GetDiaperChangedEvents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/GetDiaperChangedEvents", ReplyAction="http://tempuri.org/ILovroLogService/GetDiaperChangedEventsResponse")]
        System.Threading.Tasks.Task<LovroLog.Core.LovroEvents.LovroDiaperChangedEvent[]> GetDiaperChangedEventsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/GetSummary", ReplyAction="http://tempuri.org/ILovroLogService/GetSummaryResponse")]
        LovroLog.Core.Database.DatabaseSummary GetSummary();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/GetSummary", ReplyAction="http://tempuri.org/ILovroLogService/GetSummaryResponse")]
        System.Threading.Tasks.Task<LovroLog.Core.Database.DatabaseSummary> GetSummaryAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/AddBaseEvent", ReplyAction="http://tempuri.org/ILovroLogService/AddBaseEventResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LovroLog.Core.LovroEvents.LovroDiaperChangedEvent))]
        LovroLog.Core.LovroEvents.LovroBaseEvent AddBaseEvent(LovroLog.Core.LovroEvents.LovroBaseEvent newEvent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/AddBaseEvent", ReplyAction="http://tempuri.org/ILovroLogService/AddBaseEventResponse")]
        System.Threading.Tasks.Task<LovroLog.Core.LovroEvents.LovroBaseEvent> AddBaseEventAsync(LovroLog.Core.LovroEvents.LovroBaseEvent newEvent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/EditBaseEvent", ReplyAction="http://tempuri.org/ILovroLogService/EditBaseEventResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LovroLog.Core.LovroEvents.LovroDiaperChangedEvent))]
        LovroLog.Core.LovroEvents.LovroBaseEvent EditBaseEvent(LovroLog.Core.LovroEvents.LovroBaseEvent editedEvent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/EditBaseEvent", ReplyAction="http://tempuri.org/ILovroLogService/EditBaseEventResponse")]
        System.Threading.Tasks.Task<LovroLog.Core.LovroEvents.LovroBaseEvent> EditBaseEventAsync(LovroLog.Core.LovroEvents.LovroBaseEvent editedEvent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/DeleteBaseEvent", ReplyAction="http://tempuri.org/ILovroLogService/DeleteBaseEventResponse")]
        void DeleteBaseEvent(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILovroLogService/DeleteBaseEvent", ReplyAction="http://tempuri.org/ILovroLogService/DeleteBaseEventResponse")]
        System.Threading.Tasks.Task DeleteBaseEventAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILovroLogServiceChannel : LovroLog.LovroLogServiceReference.ILovroLogService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LovroLogServiceClient : System.ServiceModel.ClientBase<LovroLog.LovroLogServiceReference.ILovroLogService>, LovroLog.LovroLogServiceReference.ILovroLogService {
        
        public LovroLogServiceClient() {
        }
        
        public LovroLogServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LovroLogServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LovroLogServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LovroLogServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public LovroLog.Core.LovroEvents.LovroBaseEvent[] GetBaseEvents() {
            return base.Channel.GetBaseEvents();
        }
        
        public System.Threading.Tasks.Task<LovroLog.Core.LovroEvents.LovroBaseEvent[]> GetBaseEventsAsync() {
            return base.Channel.GetBaseEventsAsync();
        }
        
        public LovroLog.Core.LovroEvents.LovroDiaperChangedEvent[] GetDiaperChangedEvents() {
            return base.Channel.GetDiaperChangedEvents();
        }
        
        public System.Threading.Tasks.Task<LovroLog.Core.LovroEvents.LovroDiaperChangedEvent[]> GetDiaperChangedEventsAsync() {
            return base.Channel.GetDiaperChangedEventsAsync();
        }
        
        public LovroLog.Core.Database.DatabaseSummary GetSummary() {
            return base.Channel.GetSummary();
        }
        
        public System.Threading.Tasks.Task<LovroLog.Core.Database.DatabaseSummary> GetSummaryAsync() {
            return base.Channel.GetSummaryAsync();
        }
        
        public LovroLog.Core.LovroEvents.LovroBaseEvent AddBaseEvent(LovroLog.Core.LovroEvents.LovroBaseEvent newEvent) {
            return base.Channel.AddBaseEvent(newEvent);
        }
        
        public System.Threading.Tasks.Task<LovroLog.Core.LovroEvents.LovroBaseEvent> AddBaseEventAsync(LovroLog.Core.LovroEvents.LovroBaseEvent newEvent) {
            return base.Channel.AddBaseEventAsync(newEvent);
        }
        
        public LovroLog.Core.LovroEvents.LovroBaseEvent EditBaseEvent(LovroLog.Core.LovroEvents.LovroBaseEvent editedEvent) {
            return base.Channel.EditBaseEvent(editedEvent);
        }
        
        public System.Threading.Tasks.Task<LovroLog.Core.LovroEvents.LovroBaseEvent> EditBaseEventAsync(LovroLog.Core.LovroEvents.LovroBaseEvent editedEvent) {
            return base.Channel.EditBaseEventAsync(editedEvent);
        }
        
        public void DeleteBaseEvent(int id) {
            base.Channel.DeleteBaseEvent(id);
        }
        
        public System.Threading.Tasks.Task DeleteBaseEventAsync(int id) {
            return base.Channel.DeleteBaseEventAsync(id);
        }
    }
}
