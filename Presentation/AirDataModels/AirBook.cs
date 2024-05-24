using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using FluentValidation;
using System.Text.RegularExpressions;
using FluentValidation.Attributes;

namespace AirDataModels
{
    #region Flight Book Objects
    [DataContract]
    [Serializable]
    [Validator(typeof(CreateAirBookRQValidator))]
    public class CreateAirBookRQ
    {
        [DataMember]
        public string TokenID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string RevalidatedID { get; set; }
        [DataMember]
        public bool isRehit { get; set; }

        [DataMember]
        public bool isRetry { get; set; }
        [DataMember]
        public TravelerInfo TravelerInfo { get; set; }
        [DataMember]
        public AirTripType AirTripType { get; set; }
        [DataMember]
        public bool HoldMyBooking { get; set; }
        [DataMember]
        public string PromoCode { get; set; }
        [DataMember]
        public string UserMarkup { get; set; }
        [DataMember]
        public string OrderID { get; set; }
        [DataMember]
        public string PaymentTransactionID { get; set; }
        [DataMember]
        public PaymentMethods PaymentMethod { get; set; }
        [DataMember]
        public List<MandatoryParameter> mandatoryParameterList { get; set; }
        [DataMember]
        public PaymentCardInfo PaymentCardInfo { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public BookingMode Mode = BookingMode.B2BBooking;  

        public string SearchIdentifier = string.Empty;
        public List<ReservationItem> ItineraryDetails = new List<ReservationItem>();
        [DataMember]
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();
        [DataMember]
        public AirItineraryInfo AirPricedItinerary = new AirItineraryInfo();
        public int flightBookingID = 0;
        public string Commission = "";
        public string CommissionSlab = "";
        public string AgencyCountry = "";
        public string PNR = "";
        public string ExpectedPrice = "";      
        public DateTime TicketTimeLimit = new DateTime();
        public AgencyInformation AgencyInformation = new AgencyInformation();

        //nikhil retrybooking
        public int FlightBookingType { get; set; }
    }
    public class CreateAirBookRQValidator : AbstractValidator<CreateAirBookRQ>
    {
        public CreateAirBookRQValidator()
        {
            RuleFor(x => x.TokenID).NotEmpty().WithMessage("Token ID cannot be null or empty");

            RuleFor(x => x.RevalidatedID).NotEmpty().WithMessage("Group ID cannot be null or empty");

            //RuleFor(x => x.mandatoryParameterList).Must((obj, mandatoryParameterList) => ValidatePaymentMadatoryParaInfo(obj.mandatoryParameterList)).WithMessage("Invalid Madatory Parameters");

            RuleFor(x => x.TravelerInfo).NotEmpty().WithMessage("Traveler info cannot be null or empty");

            RuleFor(x => x.TravelerInfo.AirTravelers).NotEmpty().WithMessage("Travelers details should be specified");

            RuleForEach(x => x.TravelerInfo.AirTravelers).SetValidator(new AirTravelerValidator());

            RuleFor(m => m.PaymentCardInfo).Must((obj, PaymentCardInfoDetails) => ValidatePaymentCardInfot(obj.PaymentCardInfo)).WithMessage("Invalid payment Details");

        }
        private bool ValidatePaymentMadatoryParaInfo(List<MandatoryParameter> mandatoryParameterDetails)
        {
            bool status = true;
            if (mandatoryParameterDetails != null)
            {
                foreach (MandatoryParameter madatory in mandatoryParameterDetails)
                {

                    if (madatory.ParameterFieldType == Convert.ToString(MandatoryParameterTypeEnum.Mandatory))
                    {
                        //passport no field check
                        if (madatory.ParameterType == Convert.ToString(MandatoryParameterEnum.PassportNumber).Trim())
                        {
                            if (madatory.ParameterValue != "true")
                            {
                                status = false;
                            }
                        }
                        //DOB  field check
                        if (madatory.ParameterType == Convert.ToString(MandatoryParameterEnum.DateOfBirth).Trim())
                        {
                            if (madatory.ParameterValue != "true")
                            {
                                status = false;
                            }
                        }
                        //Country  field check
                        if (madatory.ParameterType == Convert.ToString(MandatoryParameterEnum.Country).Trim())
                        {
                            if (madatory.ParameterValue != "true")
                            {
                                status = false;
                            }

                        }
                        //Nationality  field check
                        if (madatory.ParameterType == Convert.ToString(MandatoryParameterEnum.Nationality).Trim())
                        {
                            if (madatory.ParameterValue != "true")
                            {
                                status = false;
                            }
                        }
                        //PassportExpiryDate  field check
                        if (madatory.ParameterType == Convert.ToString(MandatoryParameterEnum.PassportExpiryDate).Trim())
                        {
                            if (madatory.ParameterValue != "true")
                            {
                                status = false;
                            }
                        }

                    }

                    //else if ((madatory.ParameterType == madatory.ParameterFieldType)&& (!string.IsNullOrEmpty(madatory.ParameterType)))
                    //{
                    //    if (string.IsNullOrEmpty(madatory.ParameterValue))
                    //    {
                    //        status = false;

                    //    }
                    //}
                }
            }
            return status;
        }
        private bool ValidatePaymentCardInfot(PaymentCardInfo PaymentCardInfoDetails)
        {
            bool paymentvalidatestatus = false;
            if (PaymentCardInfoDetails != null && (!string.IsNullOrEmpty(PaymentCardInfoDetails.cardNumber)))
            {
                if ((!string.IsNullOrEmpty(PaymentCardInfoDetails.cardHolderName)) && (!string.IsNullOrEmpty(Convert.ToString(PaymentCardInfoDetails.cardType))) && (!string.IsNullOrEmpty(Convert.ToString(PaymentCardInfoDetails.cvv))) && ((!string.IsNullOrEmpty(Convert.ToString(PaymentCardInfoDetails.cardExpiry)))))
                {
                    if ((Convert.ToString(PaymentCardInfoDetails.cardNumber).Length == 12) && (Convert.ToString(PaymentCardInfoDetails.cvv).Length == 3))
                    {
                        if (Convert.ToDateTime(PaymentCardInfoDetails.cardExpiry) >= DateTime.Now)
                        {
                            paymentvalidatestatus = true;
                        }
                    }

                }
            }
            else
            {
                paymentvalidatestatus = true;
            }


            return paymentvalidatestatus;
        }

    }
    public class WalletInfo
    {
        public Fare CreditBalance = new Fare();
        public Fare AvailableBalance = new Fare();
        public List<SpecialWalletInfo> SpecialWallet { get; set; }
        public Fare TotalBalance = new Fare();

        public int CreditLimitDays = 0;
        public string HoldBalance = "";
        public string FaultMessage { get; set; }
        public bool Status { get; set; }
        public string StatusDescription { get; set; }

    }
    public class SpecialWalletInfo
    {
        public Fare AvailableBalance = new Fare();
        public Fare TotalBalance = new Fare();
        public Fare HoldBalance = new Fare();
        public int CreditLimitDays = 0;
        public string Supplier = string.Empty;
    }
    [DataContract]
    [Serializable]
    public class CreateAirBookRS
    {
        [DataMember]
        public string SessionID { get; set; } = string.Empty;
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public ResponseType ResponseStatus { get; set; }
        [DataMember]
        public List<Error> Errors { get; set; } = new List<Error>();
        [DataMember]
        public string OrderID { get; set; } = "";
        [DataMember]
        public string ChangedPrice { get; set; } = "";
        [DataMember]
        public WalletInfo Wallet = new WalletInfo();
        [DataMember]
        public string ItineraryRef = string.Empty;
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public PNRStatus Status;
        public TicketTimeLimit TicketTimeLimit = new TicketTimeLimit();
        [DataMember]
        public TravelItinerary TravelItinerary = null;
        public AirItineraryInfo AirPriceResponse = null;
        public AirItineraryInfo SupplierFares = null;
        public int flightBookingID = 0;
        public ApiType FareSource;
        [DataMember]
        public string BookingPCC = "";
        public DateTime CreatedOn;
        public string RevalidatedID = string.Empty;
        [DataMember]
        public PricingSourceCodeIdentifier pricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();

    }
    [DataContract]
    [Serializable]
    public class TravelerInfo
    {
        [DataMember]
        public List<AirTraveler> AirTravelers { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
    [DataContract]
    [Validator(typeof(AirTravelerValidator))]
    [Serializable]
    public class AirTraveler
    {
        [DataMember]
        public PassengerType TravelerType { get; set; }
        [DataMember]
        public Gender Gender { get; set; }
        [DataMember]
        public string TravelerID { get; set; }
        [DataMember]
        public TravelerName TravelerName { get; set; }
        [DataMember]
        public DateTime? DateOfBirth { get; set; }
        [DataMember]
        public Passport Passport { get; set; }
        [DataMember]
        public ETicket Eticket = new ETicket();
        [DataMember]
        public SpecialServiceRequest SpecialServiceRequest { get; set; }
        [DataMember]
        public string EticketNo { get; set; }
        public string TicketNo { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public List<Error> Errors { get; set; }
        public string NameNumber { get; set; }
        [DataMember]
        public string PNRRPH { get; set; }
        public PNRStatus Status { get; set; }
    }
    public class AirTravelerValidator : AbstractValidator<AirTraveler>
    {
        public AirTravelerValidator()
        {

            RuleFor(x => x.TravelerType).NotEmpty().WithMessage("Traveler type cannot be null or empty");

            RuleFor(x => x.TravelerName).NotEmpty().WithMessage("Traveler name cannot be null or empty");

            RuleFor(x => x.TravelerName.PassengerFirstName).NotEmpty().WithMessage("Passenger first name cannot be null or empty");

            RuleFor(x => x.TravelerName.PassengerLastName).Must(Isalpha).WithMessage("last name should be alphabet");

            //RuleFor(x => x.Phone).Must(IsNumeric).WithMessage("phone number should be numeric");

            //RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number cannot be null or empty").Length(10, 13).WithMessage("Invalid mobile number");


            RuleFor(m => m.Passport).Must((obj, Passportdetails) => ValidatePassport(obj.Passport)).WithMessage("Invalid Passport Details");


        }

        //only alpha charctor validation
        private bool Isalpha(string PassengerFirstName)
        {
            string pattern = @"^[a-zA-Z ]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(PassengerFirstName);
        }
        //only numeric validation
        private bool IsNumeric(string PassengerFirstName)
        {
            string pattern = "^[0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(PassengerFirstName);
        }



        //passport validation
        private bool ValidatePassport(Passport passportDetails)
        {
            bool passportstatus = false;
            if (passportDetails != null)
            {

                if (!string.IsNullOrEmpty(passportDetails.PassportNumber))//passport field checking only passport no field added cases
                {
                    if ((!string.IsNullOrEmpty(passportDetails.Country)) && (!string.IsNullOrEmpty(passportDetails.Nationality)) && (passportDetails.ExpiryDate != DateTime.MinValue))
                    {

                        passportstatus = true;
                    }
                    else
                    {
                        passportstatus = false;
                    }
                }
                else
                {
                    if ((string.IsNullOrEmpty(passportDetails.Country)) && (string.IsNullOrEmpty(passportDetails.Nationality)) && (passportDetails.ExpiryDate == DateTime.MinValue))
                    {
                        passportstatus = true;
                    }
                    else
                    {
                        passportstatus = false;
                    }
                }
            }
            else
            {
                //passport filed not added
                passportstatus = true;
            }


            return passportstatus;
        }
    }


    [DataContract]
    [Serializable]
    public class TravelerName
    {
        [DataMember]
        public PassengerTitle PassengerTitle { get; set; }
        [DataMember]
        public string PassengerFirstName { get; set; }
        [DataMember]
        public string PassengerLastName { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Passport
    {
        [DataMember]
        public string PassportNumber { get; set; }
        [DataMember]
        public DateTime ExpiryDate { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public IDType IdType { get; set; }
    }
    [DataContract]
    [Serializable]
    public class SpecialServiceRequest
    {
        [DataMember]
        public SeatPreference SeatPreference { get; set; } = new SeatPreference();
        [DataMember]
        public List<SeatRequest> SeatRequest { get; set; } = new List<SeatRequest>();//TB-1370 :: Added for SeatMap Seat Book

        [DataMember]
        public List<MealProvision> MealPreference { get; set; } = new List<MealProvision>();
        [DataMember]
        public List<BaggageProvision> BaggagePreference { get; set; } = new List<BaggageProvision>();
        [DataMember]
        public string FrequentFlyerNumber { get; set; } = "";
        [DataMember]
        public List<Phone> Phones { get; set; } = new List<Phone>();
        [DataMember]
        public List<OtherServices> OtherServices { get; set; } = new List<OtherServices>();

        public string SSRCode = string.Empty;
        public string NameNumber = string.Empty;
        public string SSRType = string.Empty;
        public string SSRText = string.Empty;
        public string SSRPrice = string.Empty;
        public string CityPair = string.Empty;
        public string JourneyType = string.Empty;
        public string AirlineCode = string.Empty;
        public int SegmentId = 0;
        public string PCC = string.Empty;
    }

    [DataContract]
    [Serializable]
    public class SeatRequest
    {
        [DataMember]
        public string NameNumber { get; set; }
        [DataMember]
        public string seatNumber { get; set; }
        [DataMember]
        public Fare SeatPrice { get; set; }
        [DataMember]
        public string segmentNumber { get; set; }
    }

    [DataContract]
    [Serializable]
    public class PaymentCardInfo
    {
        [DataMember]
        public CardScheme cardScheme;
        [DataMember]
        public CardType cardType;
        [DataMember]
        public string cardNumber = string.Empty;
        [DataMember]
        public short cvv;
        [DataMember]
        public CardValidFrom cardValidFrom = new CardValidFrom();
        [DataMember]
        public CardExpiry cardExpiry = new CardExpiry();
        [DataMember]
        public string cardHolderName = string.Empty;
        [DataMember]
        public BillingAddress billingAddress = new BillingAddress();
        [DataMember]
        public string securePassword = string.Empty;
        [DataMember]
        public string computerIP = string.Empty;
    }
    [DataContract]
    [Serializable]
    public class CardValidFrom
    {
        [DataMember]
        public Month month;
        [DataMember]
        public short year;
    }
    [DataContract]
    [Serializable]
    public class CardExpiry
    {
        [DataMember]
        public Month month;
        [DataMember]
        public short year;
    }
    [DataContract]
    [Serializable]
    public class BillingAddress
    {
        [DataMember]
        public string customerTitle = string.Empty;
        [DataMember]
        public string customerFirstName = string.Empty;
        [DataMember]
        public string customerMiddleName = string.Empty;
        [DataMember]
        public string customerLastName = string.Empty;
        [DataMember]
        public string address1 = string.Empty;
        [DataMember]
        public string address2 = string.Empty;
        [DataMember]
        public string address3 = string.Empty;
        [DataMember]
        public string city = string.Empty;
        [DataMember]
        public string state = string.Empty;
        [DataMember]
        public string country = string.Empty;
        [DataMember]
        public string zip = string.Empty;
        [DataMember]
        public string emailId = string.Empty;
    }
    [DataContract]
    [Serializable]
    public class AirTicketIssueRQ
    {
        [DataMember]
        public string TokenID { get; set; } = string.Empty;
        [DataMember]
        public string agencyReferenceNo = string.Empty;
        [DataMember]
        public string OptionNumber = string.Empty;
        [DataMember]
        public PaymentMethods PaymentOption = new PaymentMethods();
        [DataMember]
        public string PaymentTransactionID = string.Empty;
        [DataMember]
        public List<MandatoryParameter> mandatoryParameterList = new List<MandatoryParameter>();

        public string PNR = string.Empty;
        public int FlightBookingID = 0;
        public string TicketingPCC = string.Empty;
        public string FareSource = string.Empty;
        public string ValidatingAirlineCode = string.Empty;
        public string Commission = "0";
        public PNRStatus Status;
        public Fare ExpectedPrice = new Fare();
        public AgencyInformation AgencyInformation = new AgencyInformation();
    }

    [Serializable]
    public class AirTicketIssueRS
    {
        [DataMember]
        public ResponseType Success;
        [DataMember]
        public List<Error> Errors;
        [DataMember]
        public string agencyReferenceNo = string.Empty;
        public CreateAirBookRS AirBookResp = null;
    }
    [DataContract]
    [Serializable]
    public class PriceWatchRQ
    {
        [DataMember]
        public string UserName = string.Empty;
        [DataMember]
        public string Password = string.Empty;
        [DataMember]
        public string AgencyID = string.Empty;
        [DataMember]
        public string BranchID = string.Empty;
        [DataMember]
        public string agencyReferenceNo = string.Empty;
        [DataMember]
        public string PNR = string.Empty;
        [DataMember]
        public Fare TotalFare = new Fare();
        [DataMember]
        public List<ReservationItem> ReservationItems = new List<ReservationItem>();
        [DataMember]
        public List<PassengerTypeQuantity> PaxList = new List<PassengerTypeQuantity>();
        public int FlightBookingID = 0;
        public string TicketingPCC = string.Empty;
        public string BookingPCC = string.Empty;
        [DataMember]
        public string FareSource = string.Empty;
        public string ValidatingAirlineCode = string.Empty;
        public string Commission = "0";
        public int Index;
        public AgencyInformation AgencyInformation = new AgencyInformation();
        [DataMember]
        public string RevalidateID = string.Empty;
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();
    }
    [DataContract]
    [Serializable]
    public class PriceWatchRS
    {
        [DataMember]
        public ResponseType Success;
        [DataMember]
        public string agencyReferenceNo = string.Empty;
        public List<AirRevalidateResponse> AvailableFares = new List<AirRevalidateResponse>();
        public CreateAirBookRS CommittedFares = new CreateAirBookRS();
    }

    [DataContract]
    [Serializable]
    public class AgencyPaymentInfo
    {
        [DataMember]
        public Fare Balance = new Fare();
        [DataMember]
        public Fare CreditBalance = new Fare();
        [DataMember]
        public int CreditLimitDays = 0;
    }

    [DataContract]
    [Serializable]
    public class Phone
    {
        [DataMember]
        public string SegementRPH { get; set; }
        [DataMember]
        public string MobilePhone { get; set; }
    }
    [DataContract]
    [Serializable]
    public class TicketTimeLimit
    {
        [DataMember]
        public string TimeZone = "5.30";
        [DataMember]
        public DateTime? TimeLimit = null;
        public DateTime TimeLimitWithoutBuffer;
    }

    [DataContract]
    [Serializable]
    public class BookingHistory
    {
        [DataMember]
        public string Remarks = string.Empty;
        [DataMember]
        public int FlightBookingID = 0;
        [DataMember]
        public string CreatedUser = string.Empty;
        [DataMember]
        //change
        public DateTime CreatedDate;
    }
    [DataContract]
    [Serializable]
    public class BookingNote
    {
        [DataMember]
        public string Note = string.Empty;
        [DataMember]
        public int FlightBookingID = 0;
        [DataMember]
        public int NoteID = 0;
        [DataMember]
        public string UpdatedUser = string.Empty;
        [DataMember]
        public DateTime UpdatedOn;
        [DataMember]
        public string CreatedtedUser = string.Empty;
        [DataMember]
        public DateTime CreatedOn;
        [DataMember]
        public string NoteType;
    }

    public class RetryBookingRQ
    {
        public string OrderID { get; set; }
        public string TokenID { get; set; }
    }

    #endregion Flight Book Objects
}
