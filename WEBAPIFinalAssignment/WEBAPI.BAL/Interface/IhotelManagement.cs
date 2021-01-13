using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBAPI.DAL;

namespace WEBAPI.BAL.Interface
{
   public interface IhotelManagement
    {
        //hotels
        List<Model.hotel> GetAllHotel();
        Model.hotel GetHotelbyId(int id);
        List<Model.hotel> GetHotelbyCity(string city);
        List<Model.hotel> GetHotelbyPinCode(int pinCode);
        string Createhotel(Model.hotel hotel);

        //Room
        List<WEBAPI.Model.Room> GetAllRoom();
        List<WEBAPI.Model.roomByCity> GetRoomByCity(string city);
        Model.Room GetRoomById(int id);
        List<WEBAPI.Model.roombyPincode> GetRoomByPinCode(int pin);
        List<WEBAPI.Model.Room> GetRoomByCategory(string category);
        string CreateRoom(Model.Room room);
        bool AvailablityOfRoom(int id, DateTime date);
        

        //Booking

        string CreateBooking(Model.Booking book);
        string UpdateBooking(Model.Booking book);
        string UpdateBookingbyId(Model.Booking book);
        string deleteBooking(int id);

    }
}
