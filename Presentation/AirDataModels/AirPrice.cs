using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AirDataModels
{
    [DataContract]
    [Serializable]
    public class AirItineraryInfo
    {
        [DataMember]
        public List<ReservationItem> ItineraryDetails = new List<ReservationItem>();
        [DataMember]
        public AirItineraryPricingInfo PricingInfo = new AirItineraryPricingInfo();
        [DataMember]
        public bool IsRefundable = false;
        [DataMember]
        public string ValidatingAirlineCode;
        [DataMember]
        public SpecialServices SpecialServices = new SpecialServices();
        [DataMember]
        public List<FareRule> FareRules = new List<FareRule>();
        [DataMember]
        public List<BaggageProvision> BaggageInfo = new List<BaggageProvision>();

        [JsonIgnore]public List<SupplierParameters> SupplierParameterList = new List<SupplierParameters>();
        [JsonIgnore]public string FarePCC = "";               
        [JsonIgnore]public List<AppliedBusinessLogic> AppliedBusinessLogic = new List<AppliedBusinessLogic>();
        [JsonIgnore]public TicketTimeLimit TicketTimeLimit = new TicketTimeLimit();        
    }

    [Serializable]
    [DataContract]
    public class PromoDiscounts
    {
        [DataMember]
        public string Code = string.Empty;
        [DataMember]
        public decimal Discount = 0;
        [DataMember]
        public int Supplierid = 0;
        [DataMember]
        public PassengerType PassengerType = new PassengerType();

        [JsonIgnore] public decimal ApplicableDiscount = 0;
        [JsonIgnore] public MarkUpType ApplicableDiscountType = 0;
    }

}
