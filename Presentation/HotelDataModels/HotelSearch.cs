
using AirDataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelDataModels
{
    [DataContract]
    [Serializable]
    public class HotelLowfareShoppingRQ
    {
        [DataMember]
        public string TokenID = "";
        [DataMember]
        public string SessionID = string.Empty;
        [DataMember]
        public AgencyInformation AgencyInformation = new AgencyInformation();
        [DataMember]
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string CheckIn { get; set; }
        [DataMember]
        public string CheckOut { get; set; }
        [DataMember]
        public List<HotelOccupancy> HotelOccupancy { get; set; }
        [DataMember]
        public string SourceMarket { get; set; }
        [DataMember]
        public string SearchIdintifierCode { get; set; }
        [DataMember]
        public bool IsPostSearchprocessingInitiated { get; set; }
        //[DataMember]
        //public List<MandatoryParameter> MandatoryParameterList = new List<MandatoryParameter>();
    }
    [DataContract]
    [Serializable]
    public class InitiateHotelLowfareShoppingResponse
    {
        [DataMember]
        public bool Success;
        [DataMember]
        public HotelLowfareShoppingRS HotelLowfareShoppingRS = new HotelLowfareShoppingRS();
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
        public List<Hotel> Hotel { get; set; }
        [DataMember]
        public bool ProcessingStatus = false;
        [DataMember]
        public TimeSpan ResponseTime = new TimeSpan();
    }


    [DataContract]
    public class HotelLowfareSearchContinueRequest
    {
        [DataMember]
        public string TokenID = "";
        [DataMember]
        public string SessionID = string.Empty;
    }

    [DataContract]
    [Serializable]
    public class HotelLowfareShoppingRS
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
        public string SearchIdintifierCode = string.Empty;
        [JsonIgnore]
        public bool IsLive;
        [DataMember]
        public DateTime? ElapseTime = null;

    }
    [DataContract]
    [Serializable]
    public class PricingSourceCodeIdentifier
    {
        public string DealCode = string.Empty;
        public ApiType Source;
        public string SubSource;
        public string SupplierSessionID = string.Empty;
        public string SupplierLoginID = string.Empty;
        public List<string> SupplierRateKey { get; set; }
        public string OldFare = string.Empty;
        public string ExpectedFare = string.Empty;
        public string SupplierReferenceNo = string.Empty;
        public string OrderID = string.Empty;
    }
    [DataContract]
    [Serializable]
    public class Guest
    {
        [DataMember]

        public PassengerType Type { get; set; }
        [DataMember]

        public string title { get; set; }
        [DataMember]

        public string Age { get; set; }
        [DataMember]

        public string firstname { get; set; }
        [DataMember]

        public string lastname { get; set; }
        [DataMember]
        public string Email { get; set; }
	}
    [DataContract]
    [Serializable]
    public class Hotel
    {
        public string BaseAmt;
        public string FeeAmt;
        public string TaxAmt;
        public string TotalAmt;

        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Chain { get; set; }
        [DataMember]
        public string Rating { get; set; }
        [DataMember]
        public string ReviewScore { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public Position Position { get; set; }
        [DataMember]
        public string DirectPayment { get; set; }
        [DataMember]
        public ContractList ContractList { get; set; }
        [DataMember]
        public string DateFrom { get; set; }
        [DataMember]
        public string DateTo { get; set; }
        [DataMember]
        public Currency Currency { get; set; }
        [DataMember]
        public string PackageRate { get; set; }
        [DataMember]
        public string TravelAgent { get; set; }
        //[DataMember]
        //public List<Hotel.ViewModel.RoomDetailsVM> Rooms { get; set; }
        [DataMember]
        public List<AvailableRoom> AvailableRoom { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string AvailToken { get; set; }
        [DataMember]
        public List<string> HotelPhotos { get; set; }
        
        public string ID { get; set; }
    }
    [DataContract]
    [Serializable]
    public class IncomingOffice
    {
        [DataMember]
        public string Code { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Contract
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public IncomingOffice IncomingOffice { get; set; }
    }

    [DataContract]
    [Serializable]
    public class ContractList
    {
        [DataMember]
        public Contract Contract { get; set; }
    }

    [DataContract]
    [Serializable]
    public class DateFrom
    {
        [DataMember]
        public string Date { get; set; }
    }
    [DataContract]
    [Serializable]
    public class DateTo
    {
        [DataMember]
        public string Date { get; set; }
    }

    [DataContract]
    [Serializable]
    public class Currency
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Text { get; set; }
    }



    [DataContract]
    [Serializable]
    public class Zone
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Text { get; set; }
    }

    [DataContract]
    [Serializable]
    public class ZoneList
    {
        [DataMember]
        public Zone Zone { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Destination
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public ZoneList ZoneList { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Code { get; set; }
    }

    [DataContract]
    [Serializable]
    public class ChildAge
    {
        [DataMember]
        public string AgeFrom { get; set; }
        [DataMember]
        public string AgeTo { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Position
    {
        [DataMember]
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
    [DataContract]
    [Serializable]

    public class Occupancy
    {
        [DataMember]
        public int AdultCount { get; set; }
        [DataMember]
        public int ChildCount { get; set; }
        [DataMember]
        public List<Guest> Guest { get; set; }
    }

    [DataContract]
    [Serializable]
    public class HotelOccupancy
    {
        [DataMember]
        public int RoomOrder { get; set; }
        [DataMember]
        public Occupancy Occupancy { get; set; }
    }
    [DataContract]
    [Serializable]

    public class Board
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Shortname { get; set; }
        [DataMember]
        public string Text { get; set; }
    }


    [DataContract]
    [Serializable]

    public class DateTimeFrom
    {
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Time { get; set; }
    }

    [DataContract]
    [Serializable]
    public class CancellationPolicy
    {
        [DataMember]
        public Fare Price { get; set; }
        [DataMember]
        public DateTimeFrom DateTimeFrom { get; set; }
        public DateTimeFrom DateTimeUpto { get; set; }
    }

    [DataContract]
    [Serializable]
    public class ContactInfo
    {
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public string EmailList { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string FaxList { get; set; }
        [DataMember]
        public string WebList { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Address
    {
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string StreetName { get; set; }
        [DataMember]
        public string StreetTypeId { get; set; }
        [DataMember]
        public string StreetTypeName { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Attractions
    {
        [DataMember]
        public string Code;
        [DataMember]
        public string Description;
        [DataMember]
        public string DistanceUnit;
        [DataMember]
        public string group;
        [DataMember]
        public string Name;
        [DataMember]
        public string Remark;
        [DataMember]
        public string Value;
        [DataMember]
        public decimal Fee;
    }
    [DataContract]
    [Serializable]
    public class HotelRoom
    {
        public Board Board { get; set; }
        [DataMember]
        public string RoomType { get; set; }
        public string RoomName { get; set; }
        [DataMember]
        public CancellationPolicy CancellationPolicy { get; set; }
        [DataMember]
        public string SHRUI { get; set; }
        [DataMember]
        public string AvailCount { get; set; }
        [DataMember]
        public string OnRequest { get; set; }
        [DataMember]
        public ItinTotalFare FareDetails { get; set; }
        [DataMember]
        public DateTimeFrom DateTimeFrom { get; set; }
        [DataMember]
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();
    }

    [DataContract]
    [Serializable]
    public class AvailableRoom
    {
        [DataMember]
        public HotelOccupancy HotelOccupancy { get; set; }
        [DataMember]
        public List<HotelRoom> HotelRoom { get; set; }
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
        public Fare FixedBookingFee = new Fare();
        [DataMember]
        public Fare PromoDiscount = new Fare();
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
        [DataMember]
        public bool IsRefundable = false;

        [JsonIgnore] public decimal AgencyMarkUp = 0;
        [JsonIgnore] public decimal agencyMarkUp = 0;
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
}

