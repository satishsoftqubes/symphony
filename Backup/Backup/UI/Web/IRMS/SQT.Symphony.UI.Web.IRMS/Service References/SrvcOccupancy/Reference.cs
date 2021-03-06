//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQT.Symphony.UI.Web.IRMS.SrvcOccupancy {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SrvcOccupancy.CheckInGuestListSoap")]
    public interface CheckInGuestListSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCheckInGuestListWihtXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode GetCheckInGuestListWihtXML();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDataForOccupancyReport", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetDataForOccupancyReport(string startDate, string endDate);
        
        // CODEGEN: Parameter 'RoomTypeID' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDataForRoomAvailabilityChart", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetDataForRoomAvailabilityChartResponse GetDataForRoomAvailabilityChart(SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetDataForRoomAvailabilityChartRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDataForRoomType", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetDataForRoomType();
        
        // CODEGEN: Parameter 'StartDate' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetRentPayOutPerQuarterData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetRentPayOutPerQuarterDataResponse GetRentPayOutPerQuarterData(SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetRentPayOutPerQuarterDataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetTotalRevenueForQuarterForIR", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetTotalRevenueForQuarterForIR(System.DateTime StartDate, System.DateTime EndDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetNoOfBedsAndNoOfOccupiedBeds", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetNoOfBedsAndNoOfOccupiedBeds();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataForRoomAvailabilityChart", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataForRoomAvailabilityChartRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string StartDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string EndDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.Guid> RoomTypeID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public int Hrs;
        
        public GetDataForRoomAvailabilityChartRequest() {
        }
        
        public GetDataForRoomAvailabilityChartRequest(string StartDate, string EndDate, System.Nullable<System.Guid> RoomTypeID, int Hrs) {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.RoomTypeID = RoomTypeID;
            this.Hrs = Hrs;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataForRoomAvailabilityChartResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataForRoomAvailabilityChartResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Data.DataSet GetDataForRoomAvailabilityChartResult;
        
        public GetDataForRoomAvailabilityChartResponse() {
        }
        
        public GetDataForRoomAvailabilityChartResponse(System.Data.DataSet GetDataForRoomAvailabilityChartResult) {
            this.GetDataForRoomAvailabilityChartResult = GetDataForRoomAvailabilityChartResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetRentPayOutPerQuarterData", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetRentPayOutPerQuarterDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> StartDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> EndDate;
        
        public GetRentPayOutPerQuarterDataRequest() {
        }
        
        public GetRentPayOutPerQuarterDataRequest(System.Nullable<System.DateTime> StartDate, System.Nullable<System.DateTime> EndDate) {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetRentPayOutPerQuarterDataResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetRentPayOutPerQuarterDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Data.DataSet GetRentPayOutPerQuarterDataResult;
        
        public GetRentPayOutPerQuarterDataResponse() {
        }
        
        public GetRentPayOutPerQuarterDataResponse(System.Data.DataSet GetRentPayOutPerQuarterDataResult) {
            this.GetRentPayOutPerQuarterDataResult = GetRentPayOutPerQuarterDataResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CheckInGuestListSoapChannel : SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.CheckInGuestListSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CheckInGuestListSoapClient : System.ServiceModel.ClientBase<SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.CheckInGuestListSoap>, SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.CheckInGuestListSoap {
        
        public CheckInGuestListSoapClient() {
        }
        
        public CheckInGuestListSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CheckInGuestListSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CheckInGuestListSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CheckInGuestListSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Xml.XmlNode GetCheckInGuestListWihtXML() {
            return base.Channel.GetCheckInGuestListWihtXML();
        }
        
        public System.Data.DataSet GetDataForOccupancyReport(string startDate, string endDate) {
            return base.Channel.GetDataForOccupancyReport(startDate, endDate);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetDataForRoomAvailabilityChartResponse SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.CheckInGuestListSoap.GetDataForRoomAvailabilityChart(SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetDataForRoomAvailabilityChartRequest request) {
            return base.Channel.GetDataForRoomAvailabilityChart(request);
        }
        
        public System.Data.DataSet GetDataForRoomAvailabilityChart(string StartDate, string EndDate, System.Nullable<System.Guid> RoomTypeID, int Hrs) {
            SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetDataForRoomAvailabilityChartRequest inValue = new SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetDataForRoomAvailabilityChartRequest();
            inValue.StartDate = StartDate;
            inValue.EndDate = EndDate;
            inValue.RoomTypeID = RoomTypeID;
            inValue.Hrs = Hrs;
            SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetDataForRoomAvailabilityChartResponse retVal = ((SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.CheckInGuestListSoap)(this)).GetDataForRoomAvailabilityChart(inValue);
            return retVal.GetDataForRoomAvailabilityChartResult;
        }
        
        public System.Data.DataSet GetDataForRoomType() {
            return base.Channel.GetDataForRoomType();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetRentPayOutPerQuarterDataResponse SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.CheckInGuestListSoap.GetRentPayOutPerQuarterData(SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetRentPayOutPerQuarterDataRequest request) {
            return base.Channel.GetRentPayOutPerQuarterData(request);
        }
        
        public System.Data.DataSet GetRentPayOutPerQuarterData(System.Nullable<System.DateTime> StartDate, System.Nullable<System.DateTime> EndDate) {
            SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetRentPayOutPerQuarterDataRequest inValue = new SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetRentPayOutPerQuarterDataRequest();
            inValue.StartDate = StartDate;
            inValue.EndDate = EndDate;
            SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.GetRentPayOutPerQuarterDataResponse retVal = ((SQT.Symphony.UI.Web.IRMS.SrvcOccupancy.CheckInGuestListSoap)(this)).GetRentPayOutPerQuarterData(inValue);
            return retVal.GetRentPayOutPerQuarterDataResult;
        }
        
        public System.Data.DataSet GetTotalRevenueForQuarterForIR(System.DateTime StartDate, System.DateTime EndDate) {
            return base.Channel.GetTotalRevenueForQuarterForIR(StartDate, EndDate);
        }
        
        public System.Data.DataSet GetNoOfBedsAndNoOfOccupiedBeds() {
            return base.Channel.GetNoOfBedsAndNoOfOccupiedBeds();
        }
    }
}
