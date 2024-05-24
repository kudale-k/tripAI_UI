using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataModels
{
    public class CancellationRQ
    {
        [DataMember]
        public string TokenID = string.Empty;
        [DataMember]
        public string SessionID = "";
        public string OrderID { get; set; }

    }

    public class CancellationRS
    {
        public string ErrorMsg { get; set; }
        public string ResultCode { get; set; }
        public bool Status { get; set; }

        public HotelCancel HotelCancel { get; set; }
    }
    public class HotelCancel
    {
        public string Status { get; set; }
        public string CancelStatus { get; set; }
        public string CancellationId { get; set; }
        public string PenaltyApplied { get; set; }
        public string PenaltyCurrency { get; set; }
    }

    public class CancelHotelRS
    {
        public string ErrorMsg { get; set; }
        public string ResultCode { get; set; }
        public bool Status { get; set; }
        public List<CancelHotel> CancelHotel { get; set; }


    }
    public class CancelHotel
    {
        public string Status { get; set; }
        public string Notes { get; set; }
        public string CancellationId { get; set; }
        public string PenaltyApplied { get; set; }
        public string PenaltyCurrency { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string ImportantNotes { get; set; }
        public string CancelType { get; set; }
        public string FixedPrice { get; set; }
        public string PercentPrice { get; set; }
        public string Nights { get; set; }
        public bool Hold { get; set; }
        public string Cancellationdeadline { get; set; }
        public string Price { get; set; }
        public string BaseAmount { get; set; }
        public string CancellationStatus { get; set; }
        public string RatePlanCode { get; set; }
        public string Text { get; set; }
    }
}
