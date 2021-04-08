using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.BAL.Interface;

namespace WEBAPI.Controllers
{
    
    [RoutePrefix("api/hotelManagement")]
    public class hotelManagementController : ApiController
    {
        private readonly IhotelManagement hotelmanagement;
        public hotelManagementController(IhotelManagement _hotelmanagement)
        {
            hotelmanagement = _hotelmanagement;
        }
        [HttpGet]
        [Route("gethotel")]
        //To Get all Hotels
        public IHttpActionResult getHotel()
        {
            var results = hotelmanagement.GetAllHotel();
            return Ok(results);
        }

        [HttpGet]
        [Route("{id}")]
        //To Get Hotel by ID
        public IHttpActionResult getHotelbyId(int id)
        {
            var results = hotelmanagement.GetHotelbyId(id);
            if(results!=null)
            {
                return Ok(results);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Hotel with id " + id + " is not present");
            }
            
        }

         [HttpGet]
         [Route("city/{city}")]
        //To Get Hotel by city
        public IHttpActionResult getHotelbyCity(string city)
         {
            var results = hotelmanagement.GetHotelbyCity(city);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No hotels are there in city " + city );
            }
         }

        [HttpGet]
        [Route("pincode/{pincode}")]
        //To Get Hotel by Pincode
        public IHttpActionResult getHotelbypinCode(int pinCode)
        {
            var results = hotelmanagement.GetHotelbyPinCode(pinCode);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Hotel with PinCode " + pinCode + " is not present");
            }
        }

        [HttpGet]
        [Route("room")]
        //To Get all the Room by Price Lowest to highest
        public IHttpActionResult GetAllRoom()
        {
            var results = hotelmanagement.GetAllRoom();
                return Ok(results);
       }

        [HttpGet]
        [Route("room/{id}")]
        //To Get Room by ID
        public IHttpActionResult GetRoomById(int id)
        {
            var results = hotelmanagement.GetRoomById(id);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "Room with id " + id + " is not present");
            }

        }

        [HttpGet]
        [Route("roombycity/{city}")]
        //To Get Room by City
        public IHttpActionResult GetRoomByCity(string city)
        {
            var results = hotelmanagement.GetRoomByCity(city);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No hotels are there in city " + city);
            }
        }
        [HttpGet]
        [Route("roombyPincode/{pin}")]
        //To Get Room by Pincode
        public IHttpActionResult GetRoomByPinCode(int pin)
        {
            var results = hotelmanagement.GetRoomByPinCode(pin);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No hotels are there with pinCode " + pin);
            }
        }

        [HttpGet]
        [Route("category/{category}")]
        //To Get Room by Category
        public IHttpActionResult GetRoomByCategory(string category)
        {
            var results = hotelmanagement.GetRoomByCategory(category);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No hotels are there with category " + category);
            }
        }
        [HttpPost]
        //TO Create New Hotel
        public IHttpActionResult postHotel(WEBAPI.Model.hotel newHotel)
        {
            try
            {
               
                if (newHotel == null)
                {
                    return BadRequest();
                }
                else
                {
                    var results = hotelmanagement.Createhotel(newHotel);
                    return Created(new Uri(Request.RequestUri + "/" + newHotel.Hotel_Id), newHotel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         }

        [HttpPost]
        [Route("postRoom")]
        //TO Create New Room
        public IHttpActionResult postRoom(WEBAPI.Model.Room room)
        {

            try
            {
                var results = hotelmanagement.GetHotelbyId(room.Hotels_Id);
                if (results == null)
                {
                    return Content(HttpStatusCode.NotFound, "Hotel with id " + room.Hotels_Id + " is not present");
                }
                else
                {
                    var newRoom = hotelmanagement.CreateRoom(room);
                    return Created(new Uri(Request.RequestUri + "/" + room.Room_Id), room);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("postBooking")]
        //To Book A Room
        public IHttpActionResult CreateBooking(WEBAPI.Model.Booking book)
        {
            try
            {
                var results = hotelmanagement.GetRoomById(book.Room_Id);
                if (results == null)
                {
                    return Content(HttpStatusCode.NotFound, "Room with id " + book.Room_Id + " is not present");
                }
                else
                {
                    var newRoom = hotelmanagement.CreateBooking(book);
                    return Created(new Uri(Request.RequestUri + "/" + book.bookingId), book);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("room/checkRoom/{id}/{date}")]
        //To check availablity of room
        public IHttpActionResult AvailablityOfRoom(int id, DateTime date)
        {
            var results = hotelmanagement.AvailablityOfRoom(id,date);
           
                return Ok(results);
            
        }
        [HttpPut]
        [Route("updateBooking")]
        //To Update booking by Room ID
        public IHttpActionResult UpdateBooking(WEBAPI.Model.Booking book)
        {
            try
            {
                var results = hotelmanagement.GetRoomById(book.Room_Id);
                if (results == null)
                {
                    return Content(HttpStatusCode.NotFound, "Room with id " + book.Room_Id + " is not present");
                }
                else
                {
                    var newRoom = hotelmanagement.UpdateBooking(book);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("updateBookingById")]
        //To Update booking by Booking ID
        public IHttpActionResult UpdateBookingbyId(WEBAPI.Model.Booking book)
        {
            try
            {
                var results = hotelmanagement.GetRoomById(book.bookingId);
                if (results == null)
                {
                    return Content(HttpStatusCode.NotFound, "Room with id " + book.bookingId + " is not present");
                }
                else
                {
                    var newRoom = hotelmanagement.UpdateBookingbyId(book);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("delete/{id}")]
        //To delete a booking- soft delete
       public IHttpActionResult deleteBooking(int id)
        {
            try
            {
                var deleted = hotelmanagement.deleteBooking(id);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
    }
