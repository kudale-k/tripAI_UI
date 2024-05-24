using AirDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataModels
{
    public class HotelReserveRQ
    {
        [DataMember]
        public string TokenID = string.Empty;
        [DataMember]
        public string SessionID = "";
        [DataMember]
        public Hotel HotelID = new Hotel();
        [DataMember]
        public AgencyInformation AgencyInformation = new AgencyInformation();
        public PricingSourceCodeIdentifier PricingSourceCodeIdentifier = new PricingSourceCodeIdentifier();
        public Hotel Hotel { get; set; }

    }
    public class HotelReserveRS
    {
        [DataMember]
        public string SessionID = "";
        [DataMember]
        public Hotel Hotel { get; set; }
        [DataMember]
        public AgencyInformation AgencyInformation = new AgencyInformation();
    }
}
