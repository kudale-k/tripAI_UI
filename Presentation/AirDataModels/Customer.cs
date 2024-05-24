using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirDataModels
{

    [DataContract]
    [Serializable]
    public class AgencyInformation
    {
        [DataMember]
        public string CustomerID { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool IsSpecialDomUser { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public bool IsPaymentCheck = true;
        [DataMember]
        public string CurrentUserName { get; set; }
        [DataMember]
        public BranchDetails BranchDetails { get; set; }
    }
    [Serializable]
    [DataContract]
    public partial class BranchDetails
    {
        [DataMember]
        public string BranchID { get; set; }
        [DataMember]
        public string BranchCode { get; set; }
        [DataMember]
        public string BranchName { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public string Zipcode { get; set; }
        [DataMember]
        public string PrimaryEmailID { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string BranchLogo { get; set; }
        [DataMember]
        public BusinessConfig BusinessConfig = new BusinessConfig();
        [DataMember]
        public StaffDetails StaffDetails = new StaffDetails();
    }
    [DataContract]
    [Serializable]

    public partial class StaffDetails
    {
        [DataMember]
        public int StaffID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string WalletID { get; set; }
        [DataMember]
        public string RoleID = "0";
    }
    [DataContract]
    [Serializable]
    public partial class BusinessConfig
    {

        [DataMember]
        public string SupplierPoolID = "0";
        [DataMember]

        public string MarkupPoolID { get; set; }
        [DataMember]

        public string CommissionPoolID { get; set; }
        [DataMember]

        public string PromoCodePoolID { get; set; }
        [DataMember]

        public string SubCustomerConfigID { get; set; }
        [DataMember]

        public bool IsPGEnabled { get; set; }
        [DataMember]

        public bool IsWalletEnabled { get; set; }
        
    }
}
