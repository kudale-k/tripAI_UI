using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Attributes;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
namespace AirDataModels
{
    #region Flight Search Request Objects
    [DataContract]
    [Serializable]
    [Validator(typeof(AirLowfareSearchRequestValidator))]
    public class AirLowfareSearchRequest
    {
        [DataMember]
        public string TokenID = "";
        [DataMember]
        public string SessionID = string.Empty;
        [DataMember]
        public List<OriginDestinationInformation> OriginDestinationInformations = new List<OriginDestinationInformation>();
        [DataMember]
        public TravelPreferences TravelPreferences = new TravelPreferences();
        [DataMember]
        public bool IsRefundable = false;
        [DataMember]
        public List<PassengerTypeQuantity> PassengerTypeQuantities = new List<PassengerTypeQuantity>();
        [DataMember]
        public RequestOptions RequestOptions;
        [DataMember]
        public AgencyInformation AgencyInformation = new AgencyInformation();
        [DataMember]
        public List<MandatoryParameter> mandatoryParameterList = new List<MandatoryParameter>();
        public bool IsLive = false;
        public string SearchIdintifierCode = string.Empty;
        public bool IsPostSearchprocessingInitiated = false;

    }
    [DataContract]
    [Serializable]
    public class AirLowfareSearchContinueRequest
    {
        [DataMember]
        public string TokenID = "";
        [DataMember]
        public string SessionID = string.Empty;
    }
        public class AirLowfareSearchRequestValidator : AbstractValidator<AirLowfareSearchRequest>
    {
        public AirLowfareSearchRequestValidator()
        {
            RuleFor(x => x.TokenID).NotEmpty().WithMessage("Token ID cannot be null or empty");

            RuleFor(x => x.OriginDestinationInformations).NotNull().WithMessage("OriginDestinationInformations cannot be null or empty");

            RuleFor(x => x.TravelPreferences).NotNull().WithMessage("Travel Preferences cannot be null or empty");

            RuleFor(x => x.TravelPreferences.AirTripType).NotEmpty().WithMessage("Invalid air trip type");

            RuleFor(x => x.TravelPreferences.CabinPreference).NotEmpty().WithMessage("Invalid cabin preference");

            RuleFor(x => x.OriginDestinationInformations).SetCollectionValidator(new OriginDestinationInformationValidator());
        }
       
    }


    [DataContract]
    [Serializable]
    public class OriginDestinationInformation
    {
        [DataMember]
        public DateTime DepartureDateTime;
        [DataMember]
        public string DepartureWindow = "";
        [DataMember]
        public string ArrivalWindow = "";
        [DataMember]
        public string OriginLocationCode = "";
        [DataMember]
        public string DestinationLocationCode = "";
    }
    [DataContract]
    [Serializable]
    public class TravelPreferences
    {
        [DataMember]
        public MaximumStopsQuantity MaxStopsQuantity;
        [DataMember]
        public List<string> VendorPreferenceCodes = new List<string>();
        [DataMember]
        public List<string> VendorExcludeCodes = new List<string>();
        [DataMember]
        public CabinType CabinPreference;
        [DataMember]
        public AirTripType AirTripType;

    }


    public class OriginDestinationInformationValidator : AbstractValidator<OriginDestinationInformation>
    {
        public OriginDestinationInformationValidator()
        {

           //List<AirDataModels.Airport> airportList = Airport.Load();

            RuleFor(x => x.OriginLocationCode).NotEmpty().WithMessage("Origin location code cannot be null or empty");

            RuleFor(x => x.DestinationLocationCode).NotEmpty().WithMessage("Destination location code cannot be null or empty");

          //  RuleFor(x => airportList.FirstOrDefault(airport => airport.AirportCode == x.OriginLocationCode)).NotNull().WithMessage("Invalid origin location code");

          //  RuleFor(x => airportList.FirstOrDefault(airport => airport.AirportCode == x.DestinationLocationCode)).NotNull().WithMessage("Invalid origin location code");

            RuleFor(x => x.DepartureDateTime).NotEmpty().WithMessage("Departure date time cannot be null or empty");

            RuleFor(x => x.DepartureDateTime).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("Invalid departure date time");
            

        }
    }


    [DataContract]
    [Serializable]
    public class PassengerTypeQuantity
    {
        [DataMember]
        public PassengerType Code;
        [DataMember]
        public int Quantity;
    }
    #endregion Flight Search Request Objects

    #region Flight Search Response Objects
    [DataContract]
    [Serializable]
    public class AirLowfareSearchResponse
    {
        [DataMember]
        public bool Success;
        [DataMember]
        public List<Error> Errors = new List<Error>();
        [DataMember]
        public string SessionID = string.Empty;
        [DataMember]
        public List<PSCIInfo> PSCIInfoList = new List<PSCIInfo>();
        [DataMember]
        public bool IsCompleted = false; // set true once all PCSI infos are loaded.
        [DataMember]
        public DateTime SearchStarted = new DateTime();
        [DataMember]
        public DateTime SearchEnded = new DateTime();

        [JsonIgnore]
        public AgencyInformation AgencyInformation = new AgencyInformation();
        [JsonIgnore]
        public List<PricedItinerary> PricedItineraries = new List<PricedItinerary>();
        [JsonIgnore]
        public string SearchIdintifierCode = string.Empty;
        [JsonIgnore]
        public bool IsLive;
        [DataMember]
        public DateTime? ElapseTime = null;

    }

    [DataContract]
    [Serializable]
    public class InitiateLowfareShoppingResponse
    {
        [DataMember]
        public bool Success;
        [DataMember]
        public List<PSCIInfo> PSCIInfoList = new List<PSCIInfo>();
        [DataMember]
        public List<Error> Errors = new List<Error>();
        [DataMember]
        public string SessionID = string.Empty;

        public string SearchIdintifierCode = string.Empty;
        public bool IsLive;

    }
    [DataContract]
    [Serializable]
    public class PSCIInfo
    {
        [DataMember]
        public string PSCIID = string.Empty;
        [DataMember]
        public List<PricedItinerary> PricedItineraries = new List<PricedItinerary>();
        [DataMember]
        public bool ProcessingStatus = false;
        [DataMember]
        public TimeSpan ResponseTime = new TimeSpan();
    }

        [DataContract]
    [Serializable]
    public class PricedItinerary
    {
        [DataMember]
        public string GroupID { get; set; }
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public List<FlightOptions> OutwardOptions { get; set; } = new List<FlightOptions>();
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public List<FlightOptions> ReturnOptions { get; set; } = new List<FlightOptions>();
        [DataMember]
        public AirItineraryPricingInfo AirItineraryPricingInfo { get; set; } = new AirItineraryPricingInfo();
        [DataMember]
        public string ValidatingAirlineCode { get; set; } = string.Empty;
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public bool IsResidentFare = false;
        [DataMember]
        public bool IsRefundable = false;
        [DataMember]
        public bool IsLCC = false;
        [DataMember]
        public int TripIdentifier = 0;
        [DataMember]
        public string AirlineRemarks = string.Empty;
        [DataMember]
        public string Source = string.Empty;
        [DataMember]
        public string FilterKey { get; set; } = string.Empty;

        [JsonIgnore]
        public string TicketType { get; set; } = string.Empty;
        [JsonIgnore]
        public List<FlightOptions>  OriginDestinationOptions { get; set; } = new List<FlightOptions>();
        [JsonIgnore]
        public decimal Basefare = 0;
        [JsonIgnore]
        public bool isActive = true;
        [JsonIgnore]
        public int Priority = 1;
        [JsonIgnore]
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();

    }
    
    [DataContract]
    [Serializable]
    public class FlightOptions
    {
        [DataMember]
        public List<ReservationItem> FlightSegments { get; set; } = new List<ReservationItem>();
        [DataMember]
        public string FlightID { get; set; } = "";
        [JsonIgnore]
        public string FilterKey { get; set; } = "";
        [JsonIgnore]
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier { get; set; } = new PricingSourceCodeIdentifier();
      
    }
    [DataContract]
    [Serializable]
    public class StopQuantityInfo
    {
        [DataMember]
        public string LocationCode { get; set; } = "";
        [DataMember]
        public DateTime ArrivalDateTime { get; set; }
        [DataMember]
        public DateTime DepartureDateTime { get; set; }
        [DataMember]
        public int Duration { get; set; }
    }
    
    [DataContract]
    [Serializable]
    public class SeatsRemaining
    {
        [DataMember]
        public int Number;
        [DataMember]
        public bool BelowMinimum;
    }
    [DataContract]
    [Serializable]
    public class AirItineraryPricingInfo
    {
        [DataMember]
        public ItinTotalFare ItinTotalFare { get; set; } = new ItinTotalFare();
        [DataMember]
        public List<PTC_FareBreakdown> PTC_FareBreakdowns = new List<PTC_FareBreakdown>();
        [DataMember]
        public FareType FareType;
        [DataMember]
        public List<PromoDiscounts> ApplicablePromoDiscounts = new List<PromoDiscounts>();
    }
    [DataContract]
    [Serializable]
    public class ItinTotalFare
    {
        [DataMember]
        public Fare BaseFare = new Fare();
        [DataMember]
        public Fare TotalTax = new Fare();
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public Fare ServiceTax = new Fare();
        [DataMember]
        public Fare TransactionCharges = new Fare();
        [DataMember]
        public Fare CommissionEarned = new Fare();
        [DataMember]
        public Fare FixedBookingFee=new Fare();
        [DataMember]
        public Fare PromoDiscount=new Fare();
        [DataMember]
        public Fare UserMarkUp = new Fare();
        [DataMember]
        public AdditionalBankCardCharges AdditionalBankCardCharges = new AdditionalBankCardCharges();
        [DataMember]
        public Fare ExtraServiceCharges = new Fare();
        [DataMember]
        public Fare ConvenienceFee = new Fare();
        [DataMember]
        public Fare ImportBookingFee = new Fare();
        [DataMember]
        public Fare TotalFare { get; set; } = new Fare();
        
        [JsonIgnore] public Fare OtherCharge = new Fare();  
        [JsonIgnore] public Fare ReverseHandlingCharge = new Fare();
        [JsonIgnore] public Fare AirlineCommissions = new Fare();
        [JsonIgnore] public decimal AgencyMarkUp = 0;
        [JsonIgnore] public decimal MarkUp = 0;
        [JsonIgnore] public decimal ROE = 0;
        [JsonIgnore] public decimal TotalPayable = 0;
        [JsonIgnore] public Fare TotalPayableToSupplier = new Fare();
        [JsonIgnore] public Fare RevisedMarkUp = new Fare();
    }
    [DataContract]
    [Serializable]
    public class Fare
    {
        [DataMember]
        public string Amount { get; set; } = "0.0";
        [DataMember]
        public string CurrencyCode { get; set; }
        [DataMember]
        public int DecimalPlaces = 2;
    }
    [DataContract]
    [Serializable]
    public class PTC_FareBreakdown
    {
        [DataMember]
        public PassengerTypeQuantity PassengerTypeQuantity = new PassengerTypeQuantity();
        [DataMember]
        public PassengerFare PassengerFare = new PassengerFare();        
        [JsonIgnore] public string CorporateCode;
        [JsonIgnore] public List<string> FareBasisCodes = new List<string>();
        [JsonIgnore] public FareType FareType;
    }
    [DataContract]
    [Serializable]
    public class PassengerFare
    {
        [DataMember]
        public Fare BaseFare = new Fare();
        [DataMember]
        public List<Tax> Taxes = new List<Tax>();
        [DataMember]
        public Fare TotalTax = new Fare();
        [DataMember]
        public Fare TotalFare = new Fare();

        [JsonIgnore] public Fare AdditionalTxnFee = new Fare();
        [JsonIgnore] public Fare FuelSurcharge = new Fare();
        [JsonIgnore] public Fare AgentServiceCharge = new Fare();
        [JsonIgnore] public Fare AgentConvienceCharge = new Fare();
        [JsonIgnore] public Fare AirlineTxnFee = new Fare();
        [JsonIgnore] public Fare TMMarkup = new Fare();
        [JsonIgnore] public Fare AgencyMarkup = new Fare();
        [JsonIgnore] public Fare IATADiscountVal = new Fare();
        [JsonIgnore] public Fare PLBDiscountVal = new Fare();
        [JsonIgnore] public Fare Incentives = new Fare();
        [JsonIgnore] public Fare ServiceTax = new Fare();
        [JsonIgnore] public Fare PromoDiscounts = new Fare();
        [JsonIgnore] public Fare PLBEarned = new Fare();
        [JsonIgnore] public Fare IATAEarned = new Fare();
        [JsonIgnore] public Fare IncentiveEarned = new Fare();
        [JsonIgnore] public Fare TDSONIATA = new Fare();
        [JsonIgnore] public Fare TDSOnIncentive = new Fare();
        [JsonIgnore] public Fare TDSONPLB = new Fare();
    }
    [DataContract]
    [Serializable]
    public class Tax
    {
        [DataMember]
        public string Amount = "0.0";
        [DataMember]
        public string CurrencyCode = "";
        [DataMember]
        public string TaxCode = "";
        [DataMember]
        public PassengerType PaxType;
        [DataMember]
        public int PaxCount;
        [DataMember]
        public int DecimalPlaces;
    }
    #endregion Flight Search Response Objects
}
