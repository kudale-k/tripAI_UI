using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirDataModels;

namespace HotelDataModels
{
    public class HotelConfirmRQ
    {
        [DataMember]
        public string TokenID = string.Empty;
        [DataMember]
        public string SessionID = "";
        [DataMember]
        public List<AirTraveler> GuestInfo = new List<AirTraveler>();
        [DataMember]
        public string SupplierRemark = string.Empty;
        [DataMember]
        public AgencyInformation AgencyInformation = new AgencyInformation();
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();
    }
    public class HotelConfirmRS
    {
        [DataMember]
        public string SessionID { get; set; } = string.Empty;
        [DataMember]
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier { get; set; } 
        [DataMember]
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
        public Hotel Hotel { get; set; }
    }
}
