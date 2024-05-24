using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace AirDataModels
{
    #region Flight Cancel Objects
    
    [DataContract]
    public class CancelAirBookingRQ
    {
        [DataMember]
        public string TokenID = string.Empty;
        [DataMember]
        public string TMID = string.Empty;
        [DataMember]
        public List<string> PaxID = new List<string>();
        [DataMember]
        public CancellationType CancellationType;
        [DataMember]
        public CancelRequestType CancelRequestType;
        [DataMember]
        public List<ETicket> Eticket;
        [DataMember]
        public bool ImpactSupplier = false;
        [DataMember]
        public string BookingID = string.Empty;
        [DataMember]
        public string BookingSource = string.Empty;
        [DataMember]
        public string BookingPNR = string.Empty;
        [DataMember]
        public string BookingStatus = string.Empty;
        [DataMember]
        public string BookingPCC = string.Empty;
        [DataMember]
        public string CRNId = string.Empty;
        [DataMember]
        public AgencyInformation AgencyInformation = new AgencyInformation();
        //added for Transaction details filling
        [DataMember]
        public List<MandatoryParameter> mandatoryParameterList = new List<MandatoryParameter>();

    }
    #endregion

    #region Cancellation RS
    [DataContract]
    public class CancelAirBookingRS
    {
        [DataMember]
        public ResponseType Success;
        [DataMember]
        public string ItineraryRef = string.Empty;
        public List<ETicket> Eticket;
        [DataMember]
        public List<Error> Errors = new List<Error>();
    }
    public partial class CreditNote
    {
        public string TokenID = string.Empty;
        public int FcnObjId { get; set; }
        public string FcnId { get; set; }
        public string FcnCrn { get; set; }
        public string FcnOrderId { get; set; }
        public string FcnBookingId { get; set; }
        public string FcnPaxid { get; set; }
        public decimal FcnServiceFee { get; set; }
        public decimal FcnTotalFareReversed { get; set; }
        public decimal FcnTotalRefund { get; set; }
        public decimal FcnTmmarkupReversed { get; set; }
        public decimal FcnCommissionReversed { get; set; }
        public decimal FcnPromoDiscountReversed { get; set; }
        public string FcnAgencyCurrency { get; set; }
        public string FcnSupplierCurrency { get; set; }
        public decimal FcnUtilizedAmount { get; set; }
        public decimal FcnCancellationPenalty { get; set; }
        public decimal FcnProcessingFee { get; set; }
        public decimal FcnCcfee { get; set; }
        public decimal FcnBankFee { get; set; }
        public decimal FcnOthersReversed { get; set; }
        public decimal FcnConvenienceFee { get; set; }
        public decimal FcnUtilizedAmountLCY { get; set; }
        public decimal FcnCancellationPenaltyLCY { get; set; }
        public decimal FcnRoe { get; set; }
        public string FcnCreatedBy { get; set; }
        public DateTime FcnCreatedOn { get; set; }
    }
    #endregion
}
