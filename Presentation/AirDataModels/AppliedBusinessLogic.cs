using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirDataModels
{
    [Serializable]
    public class AppliedBusinessLogic
    {
        public decimal ID;
        public decimal BkingID;
        public decimal TMMarkUP;
        public string TMMarkUPType;
        public decimal TMBookingFee;
        public string TMBookingFeeType;
        public decimal Comm;
        public decimal CommVal;
        public string CommType;
        public decimal PLB;
        public decimal PLBVal;
        public MarkUpType SegmentIncentiveType;
        public decimal SegmentIncentiveADT;
        public decimal SegmentIncentiveCHD;
        public decimal SegmentIncentiveINF;
        public MarkUpType DepositIncentiveType;
        public decimal DepositIncentive;
        public decimal IncentiveVal;
        public string CommShareType;
        public decimal CommShare;
        public decimal PLBShare;
        public MarkUpType SegmentIncentiveShareType;
        public decimal SegmentIncentiveShareADT;
        public decimal SegmentIncentiveShareCHD;
        public decimal SegmentIncentiveShareINF;
        public MarkUpType DepositIncentiveShareType;
        public decimal DepositIncentiveShare;
        public decimal TDSOnCommission;
        public decimal TDSOnPLB;
        public decimal TDSOnIncentive;
        public string PaxType;
        public string CommPoolID;
        public string SCPoolID;
        public string MKPPoolID;
        public string PromoPoolID;
        public MarkUpType PromoDiscountType;
        public decimal PromoDiscount;
        public int PaxCount;
        public decimal SupplierVAT;
        public decimal CustomerVAT;
        public string PercentageVAT;
    }
}
