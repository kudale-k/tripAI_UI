using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripmakers.DataContract
{
    public class HotelCancallationPolicyRQ
    {
        public string ApiKey { get; set; }
        public string Vendor { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string HotelCode { get; set; }
        public string SequenceNumber { get; set; }
        public string RatePlanCode { get; set; }
        public string AgencyCode { get; set; }
        public string Destination { get; set; }
        public string PolicyCode { get; set; }
    }
}
