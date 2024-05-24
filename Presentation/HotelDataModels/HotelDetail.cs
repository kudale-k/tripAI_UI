using AirDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataModels
{
    public class HotelDetailRQ
    {
        [DataMember]
        public string TokenID = string.Empty;
        [DataMember]
        public string SessionID = "";
        [DataMember]
        public string PSCIID = "";
        [DataMember]
        public string HotelID = "";
        [DataMember]
        public List<string> RateKeys { get; set; }
        [DataMember]
        public AgencyInformation AgencyInformation { get; set; }
        [DataMember]
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier { get; set; }
    }

    public class HotelDetailRS
    {
        [DataMember]
        public string TokenID = string.Empty;
        [DataMember]
        public string SessionID = "";
        [DataMember]
        public string RevalidatedID = "";
        [DataMember]
        public Hotel Hotel { get; set; }
        [DataMember]
        public AgencyInformation AgencyInformation = new AgencyInformation();
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier { get; set; }
        [DataMember]
        public ResponseType ResponseType { get; set; }
        [DataMember]
        public List<PaymentMethods> PaymentMethods { get; set; }
        public List<Error> Errors = new List<Error>();
    }
}
