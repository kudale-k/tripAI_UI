using HotelDataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Tripmakers.DataContract;

namespace HotelDataModels
{
    public class Validate
    {
        public string errormessage { get; set; }

        public string RequestTimeFlag { get; set; }

        public string SearchRequest(HotelLowfareShoppingRQ req)
        {
            if (req != null)
            {
                if (string.IsNullOrEmpty(req.SessionID))
                {
                    errormessage = "Data Error , SessionID is required";
                }
                if (string.IsNullOrEmpty(req.TokenID))
                {
                    errormessage = "Data Error , TokenID is required";
                }
                if (string.IsNullOrEmpty(req.Destination))
                {
                    errormessage = "Data Error , invalid destination ";
                }
                if (string.IsNullOrEmpty(req.CheckIn) || !req.CheckIn.Contains('-'))
                {
                    errormessage = "Data Error ,invalid  CheckIn  dateformat";
                }
                if (int.Parse(req.CheckIn.Split('-')[1]) > 12 || int.Parse(req.CheckIn.Split('-')[0]) > 31 ||
                    req.CheckIn.Split('-')[2].Length != 4)
                {
                    errormessage = "Data Error ,  invalid CheckIn  dateformat";
                }
                if (string.IsNullOrEmpty(req.CheckOut))
                {
                    errormessage = "Data Error ,invalid CheckOut  dateformat";
                }
                if (int.Parse(req.CheckOut.Split('-')[1]) > 12 || int.Parse(req.CheckOut.Split('-')[0]) > 31 ||
                    req.CheckOut.Split('-')[2].Length != 4)
                {
                    errormessage = "Data Error ,invalid  CheckOut  dateformat";
                }
                if (req.HotelOccupancy == null)
                {
                    errormessage = "Data Error , Rooms detials required";
                }
                foreach (var room in req.HotelOccupancy)
                {
                    if (room.Occupancy.AdultCount == 0)
                    {
                        errormessage = "Data Error , Adult Count required";
                    }
                }
            }
            else
            {
                errormessage = "please check json format";
            }
            return errormessage;
        }

        //public string Reserve(ReserveHotelRQ req)
        //{
        //    if (req != null)
        //    {
        //        if (string.IsNullOrEmpty(req.ApiKey))
        //        {
        //            errormessage = "Data Error , Api key is required";
        //        }
        //        if (string.IsNullOrEmpty(req.Vendor))
        //        {
        //            errormessage = "Data Error , Vendor is required";
        //        }
        //        if (string.IsNullOrEmpty(req.Destination))
        //        {
        //            errormessage = "Data Error , invalid destination is required";
        //        }
        //        if (string.IsNullOrEmpty(req.CheckIn) || !req.CheckIn.Contains('-'))
        //        {
        //            errormessage = "Data Error , CheckIn invalid dateformat";
        //        }
        //        if (int.Parse(req.CheckIn.Split('-')[1]) > 12 || int.Parse(req.CheckIn.Split('-')[0]) > 31 ||
        //            req.CheckIn.Split('-')[2].Length != 4)
        //        {
        //            errormessage = "Data Error , CheckIn invalid dateformat";
        //        }
        //        if (string.IsNullOrEmpty(req.CheckOut))
        //        {
        //            errormessage = "Data Error , CheckOut invalid dateformat";
        //        }
        //        if (int.Parse(req.CheckOut.Split('-')[1]) > 12 || int.Parse(req.CheckOut.Split('-')[0]) > 31 ||
        //            req.CheckOut.Split('-')[2].Length != 4)
        //        {
        //            errormessage = "Data Error , CheckOut invalid dateformat";
        //        }
        //        if (req.RoomsTypes == null)
        //        {
        //            errormessage = "Data Error ,Guest Rooms details required";
        //        }
        //        //if (req.Rooms.Room == null)
        //        //{
        //        //    errormessage = "Data Error ,Guest Rooms details required";
        //        //}
        //        if (req.PaxCounts == null)
        //        {
        //            errormessage = "Data Error , RoomGroup detials required";
        //        }
        //        if (string.IsNullOrEmpty(req.HotelCode))
        //        {
        //            errormessage = "Data Error ,Hotel code is required";
        //        }

        //        foreach (var room in req.PaxCounts)
        //        {
        //            if (room.AD == null)
        //            {
        //                errormessage = "Data Error , Guest detials required";
        //            }
        //            if (room.CH == null)
        //            {
        //                errormessage = "Data Error , Guest detials required";
        //            }
        //            if (room.CH > 0)
        //            {
        //                foreach (var child in room.CHAge)
        //                {
        //                    if (child == null)
        //                    {
        //                        errormessage = "Data Error , Child age is missing";
        //                    }
        //                    if (child == 0)
        //                    {
        //                        errormessage = "Data Error , Child age is missing";
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        errormessage = "please check xml format";
        //    }
        //    return errormessage;
        //}

        //public string Confirm(ConfirmHotelRQ req)
        //{
        //    if (req != null)
        //    {
        //        if (string.IsNullOrEmpty(req.ApiKey))
        //        {
        //            errormessage = "Data Error , Api key is required";
        //        }
        //        //if (string.IsNullOrEmpty(req.BRN))
        //        //{
        //        //    errormessage = "Data Error , Booking refrence is required";
        //        //}
        //        if (string.IsNullOrEmpty(req.Vendor))
        //        {
        //            errormessage = "Data Error , Vendor is required";
        //        }
        //        if (string.IsNullOrEmpty(req.Destination))
        //        {
        //            errormessage = "Data Error , invalid destination is required";
        //        }
        //        if (string.IsNullOrEmpty(req.CheckIn) || !req.CheckIn.Contains('-'))
        //        {
        //            errormessage = "Data Error ,invalid CheckIn  dateformat";
        //        }
        //        if (int.Parse(req.CheckIn.Split('-')[1]) > 12 || int.Parse(req.CheckIn.Split('-')[0]) > 31 ||
        //            req.CheckIn.Split('-')[2].Length != 4)
        //        {
        //            errormessage = "Data Error , invalid CheckIn  dateformat";
        //        }
        //        if (string.IsNullOrEmpty(req.CheckOut))
        //        {
        //            errormessage = "Data Error , invalid CheckOut  dateformat";
        //        }
        //        if (int.Parse(req.CheckOut.Split('-')[1]) > 12 || int.Parse(req.CheckOut.Split('-')[0]) > 31 ||
        //            req.CheckOut.Split('-')[2].Length != 4)
        //        {
        //            errormessage = "Data Error ,invalid  CheckOut  dateformat";
        //        }
        //        //if (req.Rooms == null)
        //        //{
        //        //    errormessage = "Data Error , Rooms detials required";
        //        //}

        //        if (req.PaxCounts == null)
        //        {
        //            errormessage = "Data Error , RoomGroup detials required";
        //        }

        //        if (string.IsNullOrEmpty(req.HotelCode))
        //        {
        //            errormessage = "Data Error ,Hotel code is required";
        //        }
        //        foreach (var room in req.PaxCounts)
        //        {
        //            if (room.Guest == null)
        //            {
        //                errormessage = "Data Error , Guest detials required";
        //            }
        //            foreach (var gues in room.Guest)
        //            {
        //                if (string.IsNullOrEmpty(gues.type))
        //                {
        //                    errormessage = "Data Error , Guest type is missing";
        //                }
        //                if (string.IsNullOrEmpty(gues.title))
        //                {
        //                    errormessage = "Data Error , Title is missing";
        //                }
        //                if (string.IsNullOrEmpty(gues.firstname))
        //                {
        //                    errormessage = "Data Error , First name is missing";
        //                }
        //                if (string.IsNullOrEmpty(gues.lastname))
        //                {
        //                    errormessage = "Data Error , Last name is missing";
        //                }
        //                if (string.IsNullOrEmpty(gues.age))
        //                {
        //                    errormessage = "Data Error , Age is missing";
        //                }
        //            }
        //        }

        //        if (req.GuestInformations == null)
        //        {
        //            errormessage = "Data Error , Invalid Guest information";
        //        }

        //        foreach (var Guests in req.GuestInformations)
        //        {
        //            foreach (var Guest in Guests.Guest)
        //            {
        //                if (Guest.Address == null)
        //                {
        //                    errormessage = "Data Error , Address is required";
        //                }
        //                if (string.IsNullOrEmpty(Guest.Email) || !Guest.Email.Contains("@") || !Guest.Email.Contains("."))
        //                {
        //                    errormessage = "Data Error , Invaild email id";
        //                }
        //                if (string.IsNullOrEmpty(Guest.FirstName))
        //                {
        //                    errormessage = "Data Error , Guest FirstName is missing";
        //                }
        //                if (string.IsNullOrEmpty(Guest.LastName))
        //                {
        //                    errormessage = "Data Error , Guest LastName is missing";
        //                }
        //                //if (string.IsNullOrEmpty(Guest.Address.City ))
        //                //{
        //                //    errormessage = "Data Error , Guest City is missing";
        //                //}
        //                //if (string.IsNullOrEmpty(Guest.Address.ZipCode))
        //                //{
        //                //    errormessage = "Data Error , Guest Zipcode is missing";
        //                //}

        //            }
        //        }

        //    }
        //    else
        //    {
        //        errormessage = "please check json format";
        //    }
        //    return errormessage;
        //}
        public string TariffNote(string City)
        {
            //string Note = string.Empty;
            //var dubaicities = new[] { "dubai, united arab emirates", "bur dubai, united arab emirates", "dubai airport, dubai airport", "dubai creek, united arab emirates", "dubai desert, united arab emirates", "dubai emirate, united arab emirates", "dubai marina, united arab emirates", "dubai-desert, united arab emirates", "dubai-jumeirah, united arab emirates" };        
            //var rasalkhayma = new[] { "ras al khaimah, united arab emirates", "ras al khaimah area, united arab emirates", "ras al khaymah, united arab emirates", "ras al-khaimah, united arab emirates" };
            //if(dubaicities.Contains(City))
            //{
            //    Note="Dubai Tourism Dirham  fee applies from 31.03.14 to be paid by the guest directly at the Hotel/Hotel apartment on per room per night basis. AED 20 – 5 * Hotel and deluxe Hotel apartment / AED 15 – 4 * Hotel, Superior Hotel apartment and Holiday Home deluxe / AED 10 – 3 and 2* Hotel, Standard Hotel apartment and Holiday Home Standard / AED 7 – 1* Hotel and Motel.";
            //}
            //else if(rasalkhayma.Contains(City))
            //{
            //    Note = "Ras-Al-Khaimah Tourism Dirham fee applies from 01.11.15 to be paid by the guest directly at the Hotel/Hotel Apartment on per room per night basis. AED 20 – 5 * Hotel and deluxe Hotel apartment / AED 15 – 4 * Hotel, Superior Hotel apartment and Holiday Home deluxe / AED 10 – 3 and 2* Hotel, Standard Hotel apartment and Holiday Home Standard / AED 7 – 1* Hotel and Motel.";
            //}
            //else
            //{
            //    Note="";
            //}
            //return Note;
            return "";
        }

        public int GetCancellationBuffer()
        {
            if (ConfigurationManager.AppSettings["HoldBooking"].ToString() == "1")
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["CancellationBuffer"].ToString());
            }
            else
            {
                return 0;
            }
        }

        public int GetTimeOut(int i)
        {
            switch (i)
            {
                //Search
                case 1:
                    if (RequestTimeFlag == "1")
                    {
                        return Convert.ToInt32(ConfigurationManager.AppSettings["SearchRequestTimeOut"].ToString());
                    }
                    else
                    {
                        return Convert.ToInt32(ConfigurationManager.AppSettings["OtherRequestTimeOut"].ToString());
                    }
                //Details
                case 2: return Convert.ToInt32(ConfigurationManager.AppSettings["OtherRequestTimeOut"].ToString());
                //Reserve
                case 3: return Convert.ToInt32(ConfigurationManager.AppSettings["OtherRequestTimeOut"].ToString());
                //Cancel Policy
                case 4: return Convert.ToInt32(ConfigurationManager.AppSettings["OtherRequestTimeOut"].ToString());
                //Book/Confirm
                case 5: return Convert.ToInt32(ConfigurationManager.AppSettings["OtherRequestTimeOut"].ToString());
                //Cancel Hotel
                case 6: return Convert.ToInt32(ConfigurationManager.AppSettings["OtherRequestTimeOut"].ToString());
                //SearchBooking
                case 7: return Convert.ToInt32(ConfigurationManager.AppSettings["OtherRequestTimeOut"].ToString());

            }
            return Convert.ToInt32(ConfigurationManager.AppSettings["OtherRequestTimeOut"].ToString());
        }
    }

    //public class HotelDetailRQ
    //{

    //    public string ApiKey { get; set; }

    //    public string Vendor { get; set; }

    //    public string Destination { get; set; }

    //    public string CheckIn { get; set; }

    //    public string CheckOut { get; set; }

    //    public List<Room> Rooms { get; set; }

    //    public List<SearchRoom> SearchRooms { get; set; }


    //    //public List<Room> Room { get; set; }

    //    public string Currency { get; set; }

    //    public string ClientNationality { get; set; }

    //    public string AgencyCode { get; set; }
    //    public string BranchCode { get; set; }

    //    public string HotelCode { get; set; }

    //    public string Nationality { get; set; }

    //    public string Residence { get; set; }

    //    public string RequestTimeFlag { get; set; }
    //    public string SearchId { get; set; }
    //    public string Page { get; set; }
    //    public string CountryCode { get; set; } = "";
    //}












}
