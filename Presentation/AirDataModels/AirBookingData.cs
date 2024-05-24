using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using FluentValidation;
using Newtonsoft.Json;
using FluentValidation.Attributes;

namespace AirDataModels
{
   
    

    #region Flight Trip Details Objects

    [DataContract]
    [Serializable]
    public class TravelItinerary
    {
        [DataMember]
        public string UniqueID = "";
        [DataMember]
        public ItineraryInfo ItineraryInfo = new ItineraryInfo();
        [DataMember]
        public List<string> BookingNotes = new List<string>();
        [DataMember]
        public List<PostSalesRequests> PostSalesRequestsInfo = new List<PostSalesRequests>();
        [DataMember]
        public List<CreditNote> CreditNotes = new List<CreditNote>();
    }
    [DataContract]
    public class ItineraryInfo
    {
        [DataMember]
        public List<ReservationItem> ReservationItems = new List<ReservationItem>();
        [DataMember]
        public List<AirTraveler> AirTravelerDetails = new List<AirTraveler>();
        [DataMember]
        public AirItineraryPricingInfo PricingInfo = new AirItineraryPricingInfo();
        [DataMember]
        public List<BaggageProvision> BaggageInfo = new List<BaggageProvision>();
        [DataMember]
        public List<FareRule> FareRules = new List<FareRule>();
    }
    [DataContract]
    [Serializable]
    public class ReservationItem
    {
        [DataMember]
        public int ItemRPH { get; set; }
        [DataMember]
        public DateTime DepartureDateTime { get; set; }
        [DataMember]
        public DateTime ArrivalDateTime { get; set; }
        [DataMember]
        public int StopQuantity { get; set; }
        [DataMember]
        public string FlightNumber { get; set; } = "";
        [DataMember]
        public string ResBookDesigCode { get; set; } = "";
        [DataMember]
        public int NumberInParty { get; set; }
        [DataMember]
        public Airport DepartureAirport { get; set; }
        [DataMember]
        public Airport ArrivalAirport { get; set; }
        [DataMember]
        public Airline MarketingAirline { get; set; } 
        [DataMember]
        public Airline OperatingAirline { get; set; }
        [DataMember]
        public string DepartureAirportLocationCode { get; set; } = "";
        [DataMember]
        public string DepartureAirportLocationName { get; set; } = "";
        [DataMember]
        public string ArrivalAirportLocationCode { get; set; } = "";
        [DataMember]
        public string ArrivalAirportLocationName { get; set; } = "";
        [DataMember]
        public string OperatingAirlineCode { get; set; } = "";
        [DataMember]
        public string OperatingAirlineName { get; set; } = "";
        [DataMember]
        public string AirEquipmentType { get; set; } = "";
        [DataMember]
        public string MarketingAirlineCode { get; set; } = "";
        [DataMember]
        public string MarketingAirlineName { get; set; } = "";
        [DataMember]
        public string MarriageGroupInd { get; set; } = "false";
        [DataMember]
        public bool IsReturnSegment { get; set; } = false;
        [DataMember]
        public string JourneyDuration { get; set; } = "";
        [DataMember]
        public string CabinClass { get; set; } = "";
        [DataMember]
        public string Craft { get; set; } = "";
        [DataMember]
        public string AirlinePNR { get; set; } = "";
        [DataMember]
        public string DepartureTerminal { get; set; } = "";
        [DataMember]
        public string ArrivalTerminal { get; set; } = "";
        [DataMember]
        public string AirRevalidatorID { get; set; } = "";
        [DataMember]
        public StopQuantityInfo StopQuantityInfo { get; set; } = new StopQuantityInfo();
        [DataMember]
        public bool Eticket { get; set; }
        [DataMember]
        public SeatsRemaining SeatsRemaining { get; set; } = new SeatsRemaining();
        [DataMember]
        public string Class { get; set; } = "";[DataMember]
        public string DepartureTime { get; set; }
        [DataMember]
        public string ArrivalTime { get; set; }
        [DataMember]
        public string TicketingPCC = "";
        [DataMember]
        public string EmissionsInKg { get; set; }


        [JsonIgnore] public string SupplierClass = string.Empty;
        [JsonIgnore] public BaggageProvision Baggage = new BaggageProvision();
        [JsonIgnore] public string PNR = "";
        [JsonIgnore] public string Status = "";
        [JsonIgnore] public string Source = "";
        [JsonIgnore] public string SupplierAccountBookID = "";

        [JsonIgnore] public string SupplierReferenceNumber = string.Empty;
        [JsonIgnore] public TicketTimeLimit TicketTimeLimit = new TicketTimeLimit();
        [JsonIgnore] public int AdultCount = 0;
        [JsonIgnore] public int ChildCount = 0;
        [JsonIgnore] public int InfantCount = 0;
        [JsonIgnore] public string DepartureAirportCityCode = string.Empty;
        [JsonIgnore] public string DepartureAirportCountryCode = string.Empty;
        [JsonIgnore] public string ArrivalAirportCityCode = string.Empty;
        [JsonIgnore] public string ArrivalAirportCountryCode = string.Empty;
        [JsonIgnore] public int SeqNo = 0;
    }
    [DataContract]
    [Serializable]
    public class PaxName
    {
        [DataMember]
        public string PassengerTitle = "";
        [DataMember]
        public string PassengerFirstName = "";
        [DataMember]
        public string PassengerLastName = "";
    }
    [DataContract]
    [Serializable]
    public class ETicket
    {
        [DataMember]
        public int ItemRPH;
        [DataMember]
        public string ETicketNumber = "";
        [DataMember]
        public string Status = string.Empty;
    }
    [DataContract]
    [Serializable]
    public class PostSalesRequests
    {
        [DataMember]
        public string RequestType { get; set; }
        [DataMember]
        public string RequestPenalty { get; set; }
        [DataMember]
        public string RequestMarkUpFees { get; set; }
        [DataMember]
        public bool RequestStatus { get; set; }
        [DataMember]
        public AirTraveler TravelerInfo = new AirTraveler();
        [DataMember]
        public string RequestedBy { get; set; }
        [DataMember]
        public DateTime RequestDate { get; set; }
        [DataMember]
        public string FPS_LSTUPDTUSERID { get; set; }
        [DataMember]
        public DateTime FPS_LSTUPDTDT { get; set; }
        [DataMember]
        public bool CreditNoteStatus { get; set; }
    }
    #endregion
    [DataContract]
    [Serializable]
    public class AirBookHistoryRQ
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string AgencyID { get; set; }
        [DataMember]
        public string BranchID { get; set; }
    }
    public class AirBookHistoryRS
    {
        public string id { get; set; }
        public string BM_TMID { get; set; }
        public string BM_BKDT { get; set; }
        public string BM_CRUSERID { get; set; }
        public string FBK_DEPARTDT { get; set; }
        public string FBK_PNRFAILSTAT { get; set; }
        public string FBK_VALIDATING_CARRIER { get; set; }
        public string FBK_SELLING_PRICE { get; set; }
        public string FBK_NOOFADULTS { get; set; }
        public string FBK_NOOFCHLDREN { get; set; }
        public string FBK_NOOFINFANTS { get; set; }
        public string FBK_FROMCITY { get; set; }
        public string FBK_TOCITY { get; set; }
        public string FBK_FROMCITYCODE { get; set; }
        public string FBK_TOCITYCODE { get; set; }
        public string FBK_TOTFARE { get; set; }
        public string FBK_SALE_CURR { get; set; }
        public string FBK_LEADPAX { get; set; }
        public string AirlineName { get; set; }
        public string FBK_IsModificationRequested { get; set; }
        public string FBK_PAYMENTSTATUS { get; set; }
        public string FBK_PROMOCODE { get; set; }
        public string FBK_PROMODISCOUNT { get; set; }
        public string FBK_SELLING_PRICE_NET { get; set; }
        public string RideStatus { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Airport
    {
        [DataMember]
        public string AirportCode { get; set; }
        [DataMember]
        public string AirportName { get; set; }
        [DataMember]
        public string CityCode { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string GMTTimeZone = "5.30";
        [DataMember]
        public string NearestAirpot { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Airline
    {
        [DataMember]
        public string AirlineCode { get; set; }
        [DataMember]
        public string AirlineName { get; set; }
    }
}