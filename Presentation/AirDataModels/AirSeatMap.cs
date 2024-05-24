using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AirDataModels
{ 
    [DataContract]
    public class AirSeatMapRQ
    {
        [DataMember]
        public string TokenID = string.Empty;
        [DataMember]
        public string SessionID = string.Empty;
        [DataMember]
        public string GroupID = string.Empty;
        [DataMember]
        public string OutwardID = string.Empty;
        [DataMember]
        public string ReturnID = string.Empty;

        public string Username = string.Empty;
        public string Password = string.Empty;
        public AgencyInformation AgencyInformation;
        public string AgencyID = string.Empty;
        public string SearchIdentifier = string.Empty;
        public string CorrelationID = string.Empty;
        //public string RequestType = string.Empty;
        public List<ReservationItem> ItineraryDetails = new List<ReservationItem>();
        public List<PaxDetails> PassengerDetails = new List<PaxDetails>();
        public string Currency = string.Empty;
        public string PCC = string.Empty;
        public ApiType Source;
    }
    [DataContract]
    [Serializable]
    public class AirSeatMapRS
    {
        [DataMember]
        public List<FlightSeatDetails> FlightDetails = new List<FlightSeatDetails>();
       
    }
    [DataContract]
    [Serializable]
    public class FlightSeatDetails
    {
        //[DataMember]
        //public ApplicationResults ApplicationResults = new ApplicationResults();
        [DataMember]
        public Error Error;
        [DataMember]
        public SeatMapInfo SeatMapInfo = new SeatMapInfo();
        [DataMember]
        public Flight Flight = new Flight();
    }
    [DataContract]
    [Serializable]
    public class ApplicationResults
    {
        [DataMember]
        public string Status = string.Empty;
        [DataMember]
        public string Error = string.Empty;
    }
    /// <summary>
    /// SeatMapInfo details
    /// </summary>
    [DataContract]
    [Serializable]
    public class SeatMapInfo
    {
        [DataMember]
        public List<CabinInfo> CabinInfo = new List<CabinInfo>();
    }
    [DataContract]
    [Serializable]
    public class CabinInfo
    {
        [DataMember]
        public List<Row> Row = new List<Row>();
        [DataMember]
        public List<Column> Column = new List<Column>();
        [DataMember]
        public CabinClassList CabinClass = new CabinClassList();
        [DataMember]
        public decimal firstRow = decimal.Zero;
        [DataMember]
        public decimal lastRow = decimal.Zero;
        [DataMember]
        public Wing Wing = new Wing();
        [DataMember]
        public string seatoccupationDefault = string.Empty;
    }
    [DataContract]
    [Serializable]
    public class CabinClassList
    {
        [DataMember]
        public string RBD = string.Empty;
        [DataMember]
        public List<string> MarketingDescription = new List<string>();
    }
    [DataContract]
    [Serializable]
    public class Row
    {
        [DataMember]
        public string RowNumber = string.Empty;
        [DataMember]
        public List<string> Type = new List<string>();
        [DataMember]
        public List<RowFacility> RowFacility = new List<RowFacility>();
        [DataMember]
        public List<Seat> Seat = new List<Seat>();
    }
    [DataContract]
    [Serializable]
    public class RowFacility
    {
        [DataMember]
        public string Location = string.Empty;
        [DataMember]
        public List<Facility> Facilities = new List<Facility>();
    }
    [DataContract]
    [Serializable]
    public class Facility
    {
        [DataMember]
        public string Characteristics = string.Empty;
        [DataMember]
        public string Location = string.Empty;
    }
    [DataContract]
    [Serializable]
    public class Wing
    {
        [DataMember]
        public decimal firstRow = decimal.Zero;
        [DataMember]
        public decimal lastRow = decimal.Zero;
    }
    [DataContract]
    [Serializable]
    public class Seat
    {
        [DataMember]
        public Boolean exitRowInd = false;
        [DataMember]
        public Boolean restrictedReclineInd = false;
        [DataMember]
        public Boolean chargableInd = false;
        [DataMember]
        public Boolean premiumInd = false;
        [DataMember]
        public Boolean inoperativeInd = false;
        [DataMember]
        public Boolean OccupiedInd = false;
        [DataMember]
        public string Number = string.Empty;
        [DataMember]
        public List<string> Facilities = new List<string>();
        //[DataMember]
        //public List<Facilities> Facilities = new List<Facilities>();
        [DataMember]
        public List<string> Limitations = new List<string>();
        [DataMember]
        public List<string> Location = new List<string>();
        [DataMember]
        public List<string> Occupation = new List<string>();
        //[DataMember]
        //public List<Limitations> Limitations = new List<Limitations>();
        //[DataMember]
        //public List<Location> Location = new List<Location>();
        //[DataMember]
        //public List<Occupation> Occupation = new List<Occupation>();
        [DataMember]
        public Price Price = new Price();
    }
    [DataContract]
    [Serializable]
    public class Column
    {
        [DataMember]
        public string ColumnName = string.Empty;
        [DataMember]
        public List<string> Characteristics;
    }
    //[DataContract]
    //[Serializable]
    //public class Facilities
    //{
    //    [DataMember]
    //    public string Details = string.Empty;
    //}
    //[DataContract]
    //[Serializable]
    //public class Limitations
    //{
    //    [DataMember]
    //    public string Details = string.Empty;
    //}
    //[DataContract]
    //[Serializable]
    //public class Location
    //{
    //    [DataMember]
    //    public string Details = string.Empty;
    //}
    //[DataContract]
    //[Serializable]
    //public class Occupation
    //{
    //    [DataMember]
    //    public string Details = string.Empty;
    //}
    [DataContract]
    [Serializable]
    public class Price
    {
        [DataMember]
        public TotalAmount TotalAmount = new TotalAmount();
        [DataMember]
        public List<Taxes> Taxes = new List<Taxes>();

    }
    [DataContract]
    [Serializable]
    public class TotalAmount
    {
        [DataMember]
        public string currencyCode = string.Empty;
        [DataMember]
        public string value = string.Empty;
    }
    [DataContract]
    [Serializable]
    public class Taxes
    {
        [DataMember]
        public string currencyCode = string.Empty;
        [DataMember]
        public string value = string.Empty;
        [DataMember]
        public string TaxType = string.Empty;   
    }
    [DataContract]
    [Serializable]
    public class Flight
    {
        [DataMember]
        public string origin = string.Empty;
        [DataMember]
        public string destination = string.Empty;
        [DataMember]
        public string flightNo = string.Empty;
        [DataMember]
        public string marketingCarrier = string.Empty;
    }

    [DataContract]
    [Serializable]
    public class PaxDetails
    {
        [DataMember]
        public Boolean accompaniedByInfant = false;
        [DataMember]
        public string travellerID = string.Empty;
        [DataMember]
        public string givenName = string.Empty;
        [DataMember]
        public string surName = string.Empty;
    }
}
