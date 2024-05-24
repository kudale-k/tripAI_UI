using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AirDataModels
{

    #region Enums
    /// <summary>
    /// Represents the mode of creation of PNR.
    /// </summary>
    [DataContract]
    public enum BookingMode
    {
        [EnumMember]
        Default = 0,
        /// <summary>
        /// creation of PNR by SearchAndBook
        /// </summary>
        [EnumMember]
        B2BBooking = 1,
        /// <summary>
        /// creation of PNR from GKBooking.
        /// </summary>
        [EnumMember]
        GKBooking = 2,
        /// <summary>
        /// creation of PNR from RetrievePNR.
        /// </summary>
        [EnumMember]
        ImportedPNR = 3,

        /// <summary>
        /// creation of PNR from webservice.
        /// </summary>
        [EnumMember]
        WebService = 4,

        /// <summary>
        /// created using Offline Booking
        /// </summary>
        [EnumMember]
        Offline = 5,
        /// <summary>
        /// Created using Android application
        /// </summary>
        [EnumMember]
        Android = 6,
        /// <summary>
        /// Created using iOS application
        /// </summary>
        [EnumMember]
        iOs = 7,
        /// <summary>
        /// /// creation of PNR from GKBooking.
        /// </summary>
        [EnumMember]
        B2CBooking = 8
    }
    
    [DataContract]
    public enum CabinType {[EnumMember] Default = 0, [EnumMember] [Description("Economy")] Y = 1, [EnumMember] [Description("Premium Economy")] S = 2, [EnumMember] [Description("Business")] C = 3, [EnumMember] J = 4, [EnumMember] [Description("First")] F = 5, [EnumMember] P = 6 }
    [DataContract]
    public enum PreferLevelType {[EnumMember] Default = 0, [EnumMember] Only = 1, [EnumMember] Unacceptable = 2, [EnumMember] Preferred = 3 }
    [DataContract]
    [Serializable]
    public enum AirTripType {[EnumMember] Default = 0, [EnumMember] OneWay = 1, [EnumMember] Return = 2, [EnumMember] OpenJaw = 4, [EnumMember] DomesticOnward = 6, [EnumMember] DomesticReturn = 7 }
    [DataContract]
    [Serializable]
    public enum Target {[EnumMember] Default = 0, [EnumMember] Development = 1, [EnumMember] Test = 2, [EnumMember] Production = 3 }
    [DataContract]
    public enum MaximumStopsQuantity {[EnumMember] Default = 0, [EnumMember] Direct = 1, [EnumMember] OneStop = 2, [EnumMember] All = 3 }
    [DataContract]
    [Serializable]
    public enum PricingSourceType {[EnumMember] Default = 0, [EnumMember] Public = 1, [EnumMember] Private = 2, [EnumMember] All = 3 }
    [DataContract]
    public enum FareType {[EnumMember] Default = 0, [EnumMember] Public = 1, [EnumMember] Private = 2, [EnumMember] WebFare = 3, [EnumMember] CorporateFare = 4, [EnumMember] AccountFare = 5, [EnumMember] ImportPNRFare = 6 }
    [DataContract]
    [Serializable]
    public enum PassengerType {[EnumMember] Default = 0, [EnumMember] ADT = 1, [EnumMember] CHD = 2, [EnumMember] INF = 3, [EnumMember] SEA = 4, [EnumMember] SRC = 5, [EnumMember] MRE = 6, [EnumMember] LBR = 7, [EnumMember] VAC = 8, [EnumMember] STU = 9 }
    [DataContract]
    [Serializable]
    public enum RequestOptions {[EnumMember] Default = 0, [EnumMember] Fifty = 1, [EnumMember] Hundred = 2, [EnumMember] TwoHundred = 3 }
    [DataContract]
    public enum Gender {[EnumMember] M = 0, [EnumMember] F = 1 }
    [DataContract]
    public enum PassengerTitle {[EnumMember] Default = 0, [EnumMember] MR = 1, [EnumMember] SIR = 2, [EnumMember] LORD = 3, [EnumMember] MRS = 4, [EnumMember] LADY = 5, [EnumMember] MISS = 6, [EnumMember] MSTR = 7, [EnumMember] INF = 8, [EnumMember] MS = 9 }
    [DataContract]
    [Serializable]
    public enum SeatPreference {[EnumMember] Any = 0, [EnumMember] W = 2, [EnumMember] A = 1, [EnumMember] SpecificSeat = 3 }
    [DataContract]
    public enum MealPreference
    {
        [EnumMember] Any = 0, [EnumMember] HFML = 1,
        [EnumMember] LPML = 2, [EnumMember] ORML = 3, [EnumMember] PRML = 4,
        [EnumMember] VJML = 5, [EnumMember] VOML = 6, [EnumMember] AVML = 7, [EnumMember] BBML = 8,
        [EnumMember] BLML = 9, [EnumMember] FPML = 10, [EnumMember] GFML = 11, [EnumMember] LFML = 12, [EnumMember] LSML = 13,
        [EnumMember] NLML = 14, [EnumMember] RVML = 15, [EnumMember] VVML = 16, [EnumMember] VLML = 17, [EnumMember] KSML = 18,
        [EnumMember] CHML = 19, [EnumMember] MOML = 20, [EnumMember] SFML = 21,
        [EnumMember] HNML = 22, [EnumMember] PFML = 23, [EnumMember] JNML = 24,
        [EnumMember] DBML = 25,  [EnumMember] SPMLJ = 26,[EnumMember] FFML = 27, [EnumMember] CAKE = 28, [EnumMember] VGSW = 29,
        [EnumMember] NVML = 30, [EnumMember] VGML = 31, [EnumMember] PCBC = 32, [EnumMember] NVBF = 33, [EnumMember] VGBF = 34, [EnumMember] NVSW = 35
    }
    [DataContract]
    public enum CardScheme {[EnumMember] Default = 0, [EnumMember] Visa = 1, [EnumMember] Master = 2, [EnumMember] Amex = 3 }
    [DataContract]
    public enum CardType {[EnumMember] Default = 0, [EnumMember] Credit = 1, [EnumMember] Debit = 2 }
    [DataContract]
    public enum Month {[EnumMember] Default = 0, [EnumMember] Jan = 1, [EnumMember] Feb = 2, [EnumMember] Mar = 3, [EnumMember] Apr = 4, [EnumMember] May = 5, [EnumMember] Jun = 6, [EnumMember] Jul = 7, [EnumMember] Aug = 8, [EnumMember] Sep = 9, [EnumMember] Oct = 10, [EnumMember] Nov = 11, [EnumMember] Dec = 12 }
    //[DataContract]
    //public enum BookingClassPreference { [EnumMember] Default = 0,[EnumMember] Only = 1,[EnumMember] Any = 2 }

    public enum PNRStatus { NotBooked = 0, Booked = 1, WaitList = 2, Pending = 3, Ticketed = 4, TicketInProcess = 5, Cancelled = 6, Unconfirmed = 7, ConfirmationPending = 8, Archived = 9 }
    public enum EBossStatus { Unconfirmed = 0, Pending = 1, Confirmed = 2 }
    
    public enum ApiType
    {
        Notset = 0, [Description("1S")] Sabre = 1, [Description("1A")] Amadeus = 2, [Description("1G")] Galileo = 3, [Description("TB")] TBO = 4,
        [Description("TF")] TFusion = 5, [Description("PR")] Product = 6,[Description("FZ")] Fly_Dubai = 7 ,  [Description("G9")] G9 = 8,  [Description("HB")] HotelBeds = 11,[Description("BD")] BookingDotCom = 12,
         
    }
    public enum ServiceType
    {
        ALL = 0, DomesticOneway = 1, DomesticReturn = 2, InternationalOneway = 3, InternationalReturn = 4, DomesticAll = 5, InternationalAll = 6, Activity = 7,
        Tour = 8, Transport = 9, Staycation = 10, AllProduct = 11
    }
    [Serializable]
    public enum MarkUpType { Percentage = 0, Flat = 1, TotalFare_Percentage = 2 }
    public enum CommissionServiceType { ALL = 0, SITI = 1, SOTO = 2, DOM = 3 }
    [DataContract]
    public enum BaggageCodes
    {[EnumMember] Notset = 0, [EnumMember] Nobaggage = 1, [EnumMember] ADD_15KG = 2, [EnumMember] ADD_20KG = 3, [EnumMember] ADD_25KG = 4, [EnumMember] ADD_30KG = 5, [EnumMember] ADD_35KG = 6, [EnumMember] ADD_40KG = 7, [EnumMember] ADD_5KG = 8, [EnumMember] ADD_10KG = 9, [EnumMember] ADD_3KG = 10 }
    public enum SSRType { Meal = 1, Seat = 2, Baggage = 3, Documents = 4, Custom = 5 }
    [DataContract]
    public enum ResponseType {[EnumMember] Notset = 0, [EnumMember] Success = 1, [EnumMember] FailureReasonUnknown = 2, [EnumMember] FailedDueToPriceChange = 3, [EnumMember] FailedOnService = 4, [EnumMember] None = 5, [EnumMember] AlreadyVoided = 6, [EnumMember] NoTicket = 7, [EnumMember] AlreadyCancelled = 8, [EnumMember] NonVoidedTicket = 9, [EnumMember] IGNANDRETRY = 10, [EnumMember] VoidSuccess = 11, [EnumMember] CancelSuccess = 12, [EnumMember] FareIncreased = 13, [EnumMember] FareDecreased = 14 }
    public enum Services { PriceWatch = 1, Invoices = 2, Emails = 3, Ticketing = 4, Cancellation = 5 }
    [DataContract]
    public enum IDType {[EnumMember] Passport = 0, [EnumMember] NationalID = 1 }
    [DataContract]
    public enum CancellationType {[EnumMember] VoidPNR = 0, [EnumMember] CancelPNR = 1, [EnumMember] VoidCancelPNR = 2, [EnumMember] Request = 3, [EnumMember] CreditNoteGenaration = 4 }
    [DataContract]
    public enum CancelRequestType {[EnumMember] Request = 0, [EnumMember] Support = 1 }
    [Serializable]
    [DataContract]
    public enum PaymentMethods {[EnumMember] CardPayment = 0, [EnumMember] FromWallet = 1 }
    [DataContract]
    public enum MandatoryParameterEnum
    {
        [EnumMember]
        Passport = 0,
        [EnumMember]
        PassportNumber = 1,
        [EnumMember]
        PassportExpiryDate = 2,
        [EnumMember]
        DateOfBirth = 3,
        [EnumMember]
        NationalID = 4,
        [EnumMember]
        Country = 5,
        [EnumMember]
        EndUserIPAddress = 6,
        [EnumMember]
        EndUserBrowserAgent = 7,
        [EnumMember]
        EndUserDeviceMACAddress = 8,
        [EnumMember]
        UserData = 9,
        [EnumMember]
        RequestOrigin = 10,
        [EnumMember]
        SpeedyBoarding = 11,
        [EnumMember]
        OnlineCheckinWithEUPassportOrId = 12,
        [EnumMember]
        SupplierData = 13,
        [EnumMember]
        Url = 14,
        [EnumMember]
        Nationality = 15,
        [EnumMember]
        Address = 16
    }
    [DataContract]
    public enum MandatoryParameterTypeEnum
    {
        [EnumMember]
        Mandatory = 0,
        [EnumMember]
        EndUserIPAddress = 1,
        [EnumMember]
        EndUserBrowserAgent = 2,
        [EnumMember]
        EndUserDeviceMACAddress = 3,
        [EnumMember]
        UserData = 4,
        [EnumMember]
        RequestOrigin = 5,
        [EnumMember]
        Url = 6,
        [EnumMember]
        Optional = 7
    }

    [DataContract]
    public enum SeatOccupation {[EnumMember] SeatIsOccupied, [EnumMember] SeatNotOccupied, [EnumMember] SeatBlocked }
    #endregion Enums


}
