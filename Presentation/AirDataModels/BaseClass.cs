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
    [DataContract]
    [Validator(typeof(TokenRequestValidator))]
    public class TokenRQ
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string CustomerID { get; set; }
        [DataMember]
        public string BranchID { get; set; }

    }
    #region TokenRequest validation
    public class TokenRequestValidator : AbstractValidator<TokenRQ>
    {
        public TokenRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName cannot be null or empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be null or empty");
            //RuleFor(x => x.AgencyID).NotEmpty().WithMessage("AgencyID cannot be null or empty");
            //RuleFor(x => x.BranchID).NotEmpty().WithMessage("BranchID cannot be null or empty");
        }

    }
    #endregion
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TokenRS
    {
        [DataMember]
        public string TokenID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public AgencyInformation RegisteredAgencyInformation { get; set; }
        [DataMember]
        public List<Error> Errors { get; set; } = new List<Error>();
    }

    public class RootTokenRQ
    {
        public TokenRQ TokenRQ;
    }
    public class RootAirLowfareSearchRequest
    {
        public AirLowfareSearchRequest AirLowfareSearchRequest;
    }

    public class RootAirLowfareSearchContinueRequest
    {
        public AirLowfareSearchContinueRequest AirLowfareSearchContinueRequest;
    }

    public class RootAirRevalidateRequest
    {
        public AirRevalidateRequest[] AirRevalidateRequest;
    }
    public class RootCreateAirBookRQ
    {
        public CreateAirBookRQ[] CreateAirBookRQ;
    }
    public class RootConfirmBookRQ
    {
        public CreateAirBookRQ[] CreateAirBookRQ;
    }
    public class RootAirRulesRQ
    {
        public AirRulesRQ AirRulesRQ;
    }
    //public class RootGetBookingDetailsRQ
    //{
    //    public GetBookingDetailsRQ GetBookingDetailsRQ;
    //}
    public class RootCancelAirBookingRQ
    {
        public CancelAirBookingRQ CancelAirBookingRQ;
    }
    public class RootAirTicketIssueRQ
    {
        public AirTicketIssueRQ AirTicketIssueRQ;
    }

    public class RootTokenRS
    {
        public TokenRS TokenRS;
    }
    public class RootAirLowfareSearchResponse
    {
        public AirLowfareSearchResponse AirLowfareSearchResponse;
    }
    public class RootAirRevalidateResponse
    {
        public AirRevalidateResponse[] AirRevalidateResponse;
    }
    public class RootCreateAirBookRS
    {
        public CreateAirBookRS CreateAirBookRS;
    }
    public class RootAirRulesRS
    {
        public AirRulesRS AirRulesRS;
    }
    //public class RootGetBookingDetailsRS
    //{
    //    public GetBookingDetailsRS[] GetBookingDetails;
    //}
    public class RootCancelAirBookingRS
    {
        public CancelAirBookingRS CancelAirBookingRS;
    }
    public class RootAirTicketIssueRS
    {
        public AirTicketIssueRS AirTicketIssueRS;
    }
}
