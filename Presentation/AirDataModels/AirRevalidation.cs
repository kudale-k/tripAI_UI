using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Attributes;

namespace AirDataModels
{
    #region Flight Revalidate Objects
    [DataContract]
    [Validator(typeof(AirRevalidateRequestValidator))]
    [Serializable]
    public class AirRevalidateRequest
    {
        [DataMember]
        public string TokenID = string.Empty;
        [DataMember]
        public string SessionID = "";
        [DataMember]
        public string GroupID = "";
        [DataMember]
        public string OutwardID = "";
        [DataMember]
        public string ReturnID = "";
        [DataMember]
        public List<MandatoryParameter> MandatoryParameterList = new List<MandatoryParameter>();

        public List<ReservationItem> ItineraryDetails = new List<ReservationItem>();
        public List<PassengerTypeQuantity> PassengerTypeQuantities = new List<PassengerTypeQuantity>();
        public AirTripType AirTripType = new AirTripType();
        public string RevalidatedID = string.Empty;
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();
        public AgencyInformation AgencyInformation = new AgencyInformation();
        public List<BaggageProvision> BaggageListFromSearchCache = new List<BaggageProvision>();        

    }
    public class AirRevalidateRequestValidator : AbstractValidator<AirRevalidateRequest>
    {
        public AirRevalidateRequestValidator()
        {

            //RuleFor(x => x.TokenID).NotEmpty().WithMessage("Email cannot be null or empty")
            //                                             .EmailAddress().WithMessage("Invalid Email");
            //RuleFor(x => x.TokenID).NotEmpty().WithMessage("TokenID cannot be null or empty");
                                                      

            //RuleFor(x => x.GroupID).NotEmpty().WithMessage("Group ID cannot be null or empty");

            //RuleFor(x => x.OutwardID).NotEmpty().WithMessage("Outward ID cannot be null or empty");

            //RuleFor(x => x.mandatoryParameterList).NotEmpty().WithMessage("mandatory parameter list ID cannot be null or empty");
        }
    }

    [DataContract]
    [Serializable]
    public class AirRevalidateResponse
    {
        [DataMember]
        public bool Success;
        [DataMember]
        public string SessionID = string.Empty;
        [DataMember]
        public string RevalidateID = "";
        [DataMember]
        public List<Error> Errors = new List<Error>();
        [DataMember]
        public List<MandatoryParameter> MandatoryParameterList = new List<MandatoryParameter>();
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public AirItineraryInfo AirItineraryInfo = new AirItineraryInfo();        
        [DataMember]
        public List<PaymentMethods> PaymentMethods = new List<PaymentMethods>();

        public AgencyInformation AgencyInformation = new AgencyInformation();
        public List<SupplierParameters> SupplierParameterList = new List<SupplierParameters>();
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();
        public string BookingPCC = "";
        public string FarePCC = "";
    }
    [Serializable]
    [DataContract]
    public class MealProvision
    {
        [DataMember]
        public Assosiations Assosiations { get; set; } = new Assosiations();
        [DataMember]
        public string MealQuantity { get; set; } = "";
        [DataMember]
        public Fare MealPrice { get; set; } = new Fare();
        [DataMember]
        public string MealCode { get; set; } = "";
        [DataMember]
        public string MealDescription { get; set; } = "";
        [DataMember]
        public string AirlineDescription { get; set; } = "";
        [DataMember]
        public string WayType { get; set; } = "";
        [DataMember]
        public string SSRType { get; set; } = "";
        [DataMember]
        public string JourneyType { get; set; }  = "";
    }
    [Serializable]
    [DataContract]
    public partial class SpecialServices
    {
        [DataMember]
        public List<MealProvision> Meals = new List<MealProvision>();
        [DataMember]
        public List<BaggageProvision> Baggage = new List<BaggageProvision>();
        [DataMember]
        public List<SeatRequest> SeatRequest = new List<SeatRequest>();
        [DataMember]
        public List<OtherServices> OtherServices = new List<OtherServices>();

        public string FFNumber = string.Empty;
        public string FFAirlineCode = string.Empty;
        public string SeatPreference;
    }

    [Serializable]
    [DataContract]
    public class SupplierParameters
    {
        [DataMember]
        public string ParameterType = "";
        [DataMember]
        public string ParameterValue = "";
        [DataMember]
        public bool ParameterFieldType = false;
    }
    [Serializable]
    [DataContract]
    public class MandatoryParameter
    {
        [DataMember]
        public string ParameterType;
        [DataMember]
        public string ParameterValue = "";
        [DataMember]
        public string ParameterFieldType = "";
    }

    [Serializable]
    [DataContract]
    public class AdditionalBankCardCharges
    {
        [DataMember]
        public string PGCharges = "";
        [DataMember]
        public string BankCharges = "";
        [DataMember]
        public Fare BankChargesValue = new Fare();
        [DataMember]
        public Fare PGChargesValue = new Fare();
        [DataMember]
        public string PayID = string.Empty;
    }
    [Serializable]
    public class PricingSourceCodeIdentifier
    {
        public string PCC = string.Empty;
        public string SupplierAccountsBookCode = string.Empty;
        public string DealCode = string.Empty;
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public ApiType Source;
        public string SupplierSessionID = string.Empty;
        public string SupplierSegmentKeyOutward = string.Empty;
        public string SupplierSegmentKeyInward = string.Empty;
        public string SupplierFareKeyOutward = string.Empty;
        public string SupplierFareKeyInward = string.Empty;
        public string SupplierLoginID = string.Empty;
        public string ValidatingCarrier = string.Empty;
        public string BookingPCC = string.Empty;
        public string OldFare = string.Empty;
        public string ExpectedFare = string.Empty;
        [DataMember]
        public AirItineraryInfo airItineraryInfo = new AirItineraryInfo();
        public SpecialServices SpecialServices = new SpecialServices();
        public string GroupID = string.Empty;
        public string SupplierReferenceNo = string.Empty;
        public bool IsMultiTicket=false;
        public bool IsInternalPCC = false;
        public string PccCountry = string.Empty;
        public Fare RevisedRevenueFare = new Fare();
        public int PccPriority;
    }
    #endregion
}
