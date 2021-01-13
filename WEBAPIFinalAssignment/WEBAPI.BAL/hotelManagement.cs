using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBAPI.BAL.Interface;
using WEBAPI.DAL;
using WEBAPI.DAL.Repository;

namespace WEBAPI.BAL
{
    public class hotelManagement : IhotelManagement
    {
        private readonly IHotelRepo hotelRepo;

        public hotelManagement(IHotelRepo _hotelRepo)
        {
            hotelRepo = _hotelRepo;
        }

        public List<WEBAPI.Model.hotel> GetAllHotel()
        {
            return hotelRepo.GetAllHotel();
        }

        public WEBAPI.Model.hotel GetHotelbyId(int id)
        {
            return hotelRepo.GetHotelbyId(id);
        }

        public List<WEBAPI.Model.hotel> GetHotelbyCity(string city)
        {
            return hotelRepo.GetHotelbyCity(city);
        }
        public List<WEBAPI.Model.hotel> GetHotelbyPinCode(int pinCode)
        {
            return hotelRepo.GetHotelbyPinCode(pinCode);
        }
        public List<WEBAPI.Model.Room> GetAllRoom()
        {
            return hotelRepo.GetAllRoom();
        }
        public string Createhotel(Model.hotel hotel)
        {
            return hotelRepo.Createhotel(hotel);
        }
        public bool AvailablityOfRoom(int id, DateTime date)
        {
            return hotelRepo.AvailablityOfRoom(id, date);
        }
            public Model.Room GetRoomById(int id)
        {
            return hotelRepo.GetRoomById(id);
        }
        public List<WEBAPI.Model.roomByCity> GetRoomByCity(string city)
        {
            return hotelRepo.GetRoomByCity(city);
        }
        public List<WEBAPI.Model.roombyPincode> GetRoomByPinCode(int pin)
        {
            return hotelRepo.GetRoomByPinCode(pin);
        }
            public List<WEBAPI.Model.Room> GetRoomByCategory(string category)
        {
            return hotelRepo.GetRoomByCategory(category);
        }
            public string CreateRoom(Model.Room room)
        {
            return hotelRepo.CreateRoom(room);
        }
        public string CreateBooking(Model.Booking book)
        {
            return hotelRepo.CreateBooking(book);
        }
        public string UpdateBooking(Model.Booking book)
        {
            return hotelRepo.UpdateBooking(book);
        }
        public string UpdateBookingbyId(Model.Booking book)
        {
            return hotelRepo.UpdateBookingbyId(book);
        }
        public string deleteBooking(int id)
        {
            return hotelRepo.deleteBooking( id);
        }


    }
}
