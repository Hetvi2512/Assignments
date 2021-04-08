using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBAPI.Model;

namespace WEBAPI.DAL.Repository
{
    public class hotelRepo : IHotelRepo
    {
        enum statusOfBooking
        {
            Optional,
            Definitive,
            Cancelled,
            Deleted
        }
        private readonly hotelManagementEntity hm;
        public hotelRepo()
        {
            hm = new hotelManagementEntity();
        }
        public List<WEBAPI.Model.hotel> GetAllHotel()
        {

            var result = hm.selectHotel().ToList();

            List<WEBAPI.Model.hotel> detail = new List<WEBAPI.Model.hotel>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    WEBAPI.Model.hotel hotels = new WEBAPI.Model.hotel();
                    hotels.Hotel_Id = item.Hotel_Id;
                    hotels.Hotel_name = item.Hotel_name;
                    hotels.Address = item.Address;
                    hotels.City = item.City;
                    hotels.pinCode = item.pinCode;
                    hotels.contactPerson = item.contactPerson;
                    hotels.contactNumber = item.contactNumber;
                    hotels.website = item.website;
                    hotels.faceBook = item.faceBook;
                    hotels.isActive = item.isActive;
                    hotels.twitter = item.twitter;
                    hotels.createdDate = item.createdDate;
                    hotels.createdBy = item.createdBy;
                    hotels.updateDate = item.updateDate;
                    hotels.updatedBy = item.updatedBy;
                    detail.Add(hotels);
                }
            }
            return detail;
        }

        public WEBAPI.Model.hotel GetHotelbyId(int id)
        {
            var hotel = hm.hotels.SingleOrDefault(e => e.Hotel_Id == id);
            WEBAPI.Model.hotel hotels = new WEBAPI.Model.hotel();
            if (hotel != null)
            {

                hotels.Hotel_Id = hotel.Hotel_Id;
                hotels.Hotel_name = hotel.Hotel_name;
                hotels.Address = hotel.Address;
                hotels.City = hotel.City;
                hotels.pinCode = hotel.pinCode;
                hotels.contactPerson = hotel.contactPerson;
                hotels.contactNumber = hotel.contactNumber;
                hotels.website = hotel.website;
                hotels.faceBook = hotel.faceBook;
                hotels.isActive = hotel.isActive;
                hotels.twitter = hotel.twitter;
                hotels.createdDate = hotel.createdDate;
                hotels.createdBy = hotel.createdBy;
                hotels.updateDate = hotel.updateDate;
                hotels.updatedBy = hotel.updatedBy;

                return (hotels);
            }
            else
            {
                return hotels;
            }
        }

       


        public List<WEBAPI.Model.hotel> GetHotelbyCity(string city)
        {
            var hotel = hm.hotels.Where(e => e.City == city).ToList();
            List<WEBAPI.Model.hotel> detail = new List<WEBAPI.Model.hotel>();

            if (hotel != null)
            {
                foreach (var item in hotel)
                {
                    WEBAPI.Model.hotel hotels = new WEBAPI.Model.hotel();
                    hotels.Hotel_Id = item.Hotel_Id;
                    hotels.Hotel_name = item.Hotel_name;
                    hotels.Address = item.Address;
                    hotels.City = item.City;
                    hotels.pinCode = item.pinCode;
                    hotels.contactPerson = item.contactPerson;
                    hotels.contactNumber = item.contactNumber;
                    hotels.website = item.website;
                    hotels.faceBook = item.faceBook;
                    hotels.isActive = item.isActive;
                    hotels.twitter = item.twitter;
                    hotels.createdDate = item.createdDate;
                    hotels.createdBy = item.createdBy;
                    hotels.updateDate = item.updateDate;
                    hotels.updatedBy = item.updatedBy;
                    detail.Add(hotels);
                }
                return detail;
            }

            else
            {
                return detail;
            }
        }
        public List<WEBAPI.Model.hotel> GetHotelbyPinCode(int pinCode)
        {
            var hotel = hm.hotels.Where(e => e.pinCode == pinCode).ToList();
            List<WEBAPI.Model.hotel> detail = new List<WEBAPI.Model.hotel>();

            if (hotel != null)
            {
                foreach (var item in hotel)
                {
                    WEBAPI.Model.hotel hotels = new WEBAPI.Model.hotel();
                    hotels.Hotel_Id = item.Hotel_Id;
                    hotels.Hotel_name = item.Hotel_name;
                    hotels.Address = item.Address;
                    hotels.City = item.City;
                    hotels.pinCode = item.pinCode;
                    hotels.contactPerson = item.contactPerson;
                    hotels.contactNumber = item.contactNumber;
                    hotels.website = item.website;
                    hotels.faceBook = item.faceBook;
                    hotels.isActive = item.isActive;
                    hotels.twitter = item.twitter;
                    hotels.createdDate = item.createdDate;
                    hotels.createdBy = item.createdBy;
                    hotels.updateDate = item.updateDate;
                    hotels.updatedBy = item.updatedBy;
                    detail.Add(hotels);
                }
                return detail;
            }

            else
            {
                return detail;
            }
        }

        public List<WEBAPI.Model.Room> GetAllRoom()
        {
            var room = hm.selectRoom().ToList();
            List<WEBAPI.Model.Room> detail = new List<WEBAPI.Model.Room>();
            if (room != null)
            {
                foreach (var item in room)
                {
                    WEBAPI.Model.Room rooms = new WEBAPI.Model.Room();
                    rooms.Hotels_Id = item.Hotels_Id;
                    rooms.Room_Name = item.Room_Name;
                    rooms.Category = item.Category;
                    rooms.Price = item.Price;
                    rooms.isActive = item.isActive;
                    rooms.createdDate = item.createdDate;
                    rooms.createdBy = item.createdBy;
                    rooms.updatedDate = item.updatedDate;
                    rooms.updatedBy = item.updatedBy;
                    detail.Add(rooms);
                }
            }
            return detail;

        }
        public Model.Room GetRoomById(int id)
        {
            var room = hm.Rooms.SingleOrDefault(e => e.Room_Id == id);
            Model.Room getRoom = new Model.Room();
            if (room != null)
            {
                getRoom.Room_Id = room.Room_Id;
                getRoom.Hotels_Id = room.Hotels_Id;
                getRoom.Room_Name = room.Room_Name;
                getRoom.Category = room.Category;
                getRoom.Price = room.Price;
                getRoom.isActive = room.isActive;
                getRoom.createdDate = room.createdDate;
                getRoom.createdBy = room.createdBy;
                getRoom.updatedDate = room.updatedDate;
                getRoom.updatedBy = room.updatedBy;

                return (getRoom);
            }
            else
            {
                return (getRoom);
            }
        }
        public List<WEBAPI.Model.roomByCity> GetRoomByCity(string city)
          {
            var room = hm.selectRoomByCity(city).ToList();
            List<WEBAPI.Model.roomByCity> detail = new List<WEBAPI.Model.roomByCity>();
            if (room != null)
            {
                foreach (var item in room)
                {
                    WEBAPI.Model.roomByCity rooms = new WEBAPI.Model.roomByCity();
                    
                    rooms.Room_Name = item.Room_Name;
                    rooms.Category = item.Category;
                    rooms.Price = item.Price;
                    rooms.createdBy = item.createdBy;
                    rooms.Hotel_name = item.Hotel_name;
                    rooms.City = item.City;
                    detail.Add(rooms);
                }
            }
            return detail;

        }
        public List<WEBAPI.Model.roombyPincode> GetRoomByPinCode(int pin)
        {
            var room = hm.selectRoomByPincode(pin).ToList();
            List<WEBAPI.Model.roombyPincode> detail = new List<WEBAPI.Model.roombyPincode>();
            if (room != null)
            {
                foreach (var item in room)
                {
                    WEBAPI.Model.roombyPincode rooms = new WEBAPI.Model.roombyPincode();

                    rooms.Room_Name = item.Room_Name;
                    rooms.Category = item.Category;
                    rooms.Price = item.Price;
                    rooms.createdBy = item.createdBy;
                    rooms.Hotel_name = item.Hotel_name;
                    rooms.City = item.City;
                    rooms.pinCode = item.pinCode;
                    detail.Add(rooms);
                }
            }
            return detail;

        }
        public List<WEBAPI.Model.Room> GetRoomByCategory(string category)
        {
            var room = hm.Rooms.Where(e => e.Category == category).ToList();
            List<WEBAPI.Model.Room> detail = new List<WEBAPI.Model.Room>();
            if (room != null)
            {
                foreach (var item in room)
                {
                    WEBAPI.Model.Room rooms = new WEBAPI.Model.Room();
                    rooms.Hotels_Id = item.Hotels_Id;
                    rooms.Room_Name = item.Room_Name;
                    rooms.Category = item.Category;
                    rooms.Price = item.Price;
                    rooms.isActive = item.isActive;
                    rooms.createdDate = item.createdDate;
                    rooms.createdBy = item.createdBy;
                    rooms.updatedDate = item.updatedDate;
                    rooms.updatedBy = item.updatedBy;
                    detail.Add(rooms);
                }
            }
            return detail;

        }


        public string Createhotel(WEBAPI.Model.hotel hotel)
        {
            try
            {
                hotel newhotel = new hotel();
                //Here ins_hotel is Stored Procedure which i have included in DBSCRIPT file
                hm.ins_hotel(hotel.Hotel_name, hotel.Address, hotel.City,hotel.pinCode,hotel.contactNumber,hotel.contactPerson,hotel.website,hotel.faceBook,hotel.twitter,hotel.isActive,hotel.createdBy,hotel.updatedBy);
                return "Hotel Added Successfully";
            }
            catch (Exception ex)
            {
                return "Exception Occured" + ex;
            }


        }


        public string CreateRoom(WEBAPI.Model.Room room)
        {
            try
            {
                //Here ins_room is Stored Procedure which i have included in DBSCRIPT file
                hm.ins_room(room.Hotels_Id, room.Room_Name,room.Category,room.Price,room.isActive,room.createdBy,room.updatedBy);
                return "Room Added Successfully";
            }
            catch (Exception ex)
            {
                return "Exception Occured" + ex;
            }
         }
        public bool AvailablityOfRoom(int id, DateTime date)
        {
            try
            {
                var availablity = hm.bookings.Where(c => c.Room_Id == id && DbFunctions.TruncateTime(c.bookingDate) == date).FirstOrDefault();
               if(availablity == null)
                {

                    /* if(availablity.bookingDate == date)
                     {
                         if(availablity.statusOfBooking == statusOfBooking.Cancelled.ToString() || availablity.statusOfBooking == statusOfBooking.Definitive.ToString())
                         {
                             return true;
                         }
                         return false;
                     }
                     else
                     {
                         return false;
                     }*/
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                
                return false;
            }
        }
        public string CreateBooking(WEBAPI.Model.Booking book)
        {
            try
            {
                var av = AvailablityOfRoom(book.Room_Id, book.bookingDate);
                if(av == true )
                {
                    if (book != null)
                    {
                        booking newBooking = new booking();
                        newBooking.Room_Id = book.Room_Id;
                        newBooking.bookingDate = book.bookingDate;
                        newBooking.statusOfBooking = statusOfBooking.Optional.ToString();

                        hm.bookings.Add(newBooking);
                        hm.SaveChanges();
                        return "Room Booked Successfully";
                    }
                    return "Room Booking unsuccessfull";
                }
                return "Room Booking unsuccessfull";
            }
            catch (Exception ex)
            {
                return "Exception Occured" + ex;
            }

         }
        public string UpdateBooking(WEBAPI.Model.Booking book)
        {
            try
            {
                var bookFromDb = hm.bookings.SingleOrDefault(c=>c.Room_Id == book.Room_Id);

                if(bookFromDb!=null)
                {
                    bookFromDb.statusOfBooking = book.statusOfBooking;
                    bookFromDb.bookingDate = book.bookingDate;

                    hm.SaveChanges();
                    return "Updated Successfully";
                }
                return "NO Room is booked with id" + book.bookingId + "Please Book the first!";
            }
            catch (Exception ex)
            {
                return "Exception Occured" + ex;
            }


        }
        public string UpdateBookingbyId(WEBAPI.Model.Booking book)
        {
            try
            {
                var bookFromDb = hm.bookings.SingleOrDefault(c => c.bookingId == book.bookingId);

                if (bookFromDb != null)
                {
                    if (book.statusOfBooking == statusOfBooking.Definitive.ToString() || book.statusOfBooking == statusOfBooking.Cancelled.ToString())
                    {
                        bookFromDb.statusOfBooking = book.statusOfBooking;
                        bookFromDb.bookingDate = book.bookingDate;

                        hm.SaveChanges();
                        return "Updated Successfully";
                    }
                    return "Booking status can only be Definitive or Cancelled!";
                }
                return "NO Room is booked with id" +book.bookingId+ "Please Book the first!";
            }
            catch (Exception ex)
            {
                return "Exception Occured" + ex;
            }


        }

        public string deleteBooking(int id)
        {
            try
            {
                  var bookFromDb = hm.bookings.SingleOrDefault(c => c.bookingId == id);
                    if (bookFromDb != null)
                    {
                      bookFromDb.statusOfBooking = statusOfBooking.Deleted.ToString();
                        hm.SaveChanges();
                        return "Deleted Successfully";
                    }
                    else
                    {
                        return "Booking No " + bookFromDb.bookingId + " is not present";
                    }
                
              
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}

