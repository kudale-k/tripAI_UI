using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AirDataModels
{
    #region Flight AirRules Objects
    [DataContract]
    public class AirRulesRQ
    {
        [DataMember]
        public string TokenID = "";
        [DataMember]
        public string SessionID = "";
        [DataMember]
        public string GroupID = "";
        [DataMember]
        public string OutwardID = "";
        [DataMember]
        public string ReturnID = "";
        public string RevalidatedID = "";
        public List<ReservationItem> RulesItinInfos = new List<ReservationItem>();
        public List<PassengerTypeQuantity> PassengerTypeQuantities = new List<PassengerTypeQuantity>();
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();
        public AgencyInformation AgencyInformation = new AgencyInformation();
        [DataMember]
        public List<MandatoryParameter> MandatoryParameterList = new List<MandatoryParameter>();
    }
    [DataContract]
    [Serializable]
    public class AirRulesRS
    {
        [DataMember]
        public bool Success;
        [DataMember]
        public List<Error> Errors = new List<Error>();
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public List<FareRule> FareRules = new List<FareRule>();
        [DataMember]
        public List<BaggageProvision> Baggage = new List<BaggageProvision>();
        [DataMember]
        public SpecialServices SpecialServices = new SpecialServices();
    }


    [DataContract]
    [Serializable]
    public class BaggageProvision
    {
        [DataMember]
        public Assosiations Associations { get; set; }
        [DataMember]
        public string WeightLimit { get; set; }
        [DataMember]
        public Fare BaggagePrice { get; set; }
        [DataMember]
        public Fare BaggageTax { get; set; }
        [DataMember]
        public BaggageCodes BaggageCode { get; set; }
        [DataMember]//This is created as most of the baggagecodes from TBO API is new for agency API
        public string BaggageCodeSupplier { get; set; }
        [DataMember]
        public string BaggageDescription { get; set; }
        [DataMember]
        public string WayType { get; set; }
        [DataMember]
        public string SSRType { get; set; }
        [DataMember]
        public string JourneyType { get; set; }
        [DataMember]
        public string ROE { get; set; } = "1";
        [DataMember]
        public PassengerTypeQuantity PassengerTypeQuantity { get; set; } = new PassengerTypeQuantity();
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string Cabin { get; set; } = null;
        public string SSRCode = null; // For FlyDubai
        public int LFID = 0; // For FlyDubai
    }
    [DataContract]
    [Serializable]
    public class Assosiations
    {
        [DataMember]
        public string OriginLocationCode { get; set; }
        [DataMember]
        public string DestinationLocationCode { get; set; }
    }

    [DataContract]
    [Serializable]
    public class FareRule
    {
        [DataMember]
        public string Airline = "";
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string FareBasis = null;
        [DataMember]
        public string CityPair = "";
        [DataMember]
        public List<RuleDetail> RuleDetails = new List<RuleDetail>();
        [DataMember]
        public List<MiniRuleDetail> MiniRuleDetails = new List<MiniRuleDetail>();
        public bool IsPrivateFareType = false;
        [DataMember]
        public PassengerType PassengerType = new PassengerType();
        public DateTime DepartureDate;
        public DateTime ReturnDate;
        public string Origin = "";
        public string Destination = "";
        public string FareRestriction = "";
    }

    [DataContract]
    [Serializable]
    public class RuleDetail
    {
        [DataMember]
        public string Category = "";
        [DataMember]
        public string Rules = "";
    }

    [DataContract]
    [Serializable]
    public class MiniRuleDetail
    {
        [DataMember]
        public string Category = "";
        [DataMember]
        public string Rules = "";
        [DataMember]
        public string Applicability = "";
        [DataMember]
        public bool Changeable = false;
        [DataMember]
        public bool Refundable = false;
        [DataMember]
        public Fare FareData = new Fare();
        [DataMember]
        public Fare agencyFee = new Fare();
    }

    [DataContract]
    [Serializable]
    public class OtherServices
    {
        [DataMember]
        public string ServiceType { get; set; }
        [DataMember]
        public string ServiceID { get; set; }
        [DataMember]
        public Fare ServicePrice { get; set; }
    }

    }
#endregion


