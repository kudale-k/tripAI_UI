using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AirDataModels
{
    #region Common Classes
    [DataContract]
    [Serializable]
    public class Error
    {
        public Error() { }
        public Error(string Code, string Message)
        {
            this.Code = Code;
            this.Message = Message;
        }
        [DataMember]
        public string Code = "";
        [DataMember]
        public string Message = "";
    }
    [DataContract]
    [Serializable]
    public class SecurityDetails
    {
        public string IpAddress = string.Empty;
        public string MacAddress = string.Empty;
        public string UserData = string.Empty;
        public string BrowserAgent = string.Empty;
        public string Url = string.Empty;
    }
    #endregion Common Classes
}
