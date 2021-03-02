using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestingAssignment.Repository;
using Xunit;
using TestingAssignment.Controllers;
using Microsoft.AspNetCore.Mvc;
using TestingAssignment.Models;
using Newtonsoft.Json;

namespace PassengerTest
{
    public class PassengerControllerTest
    {
        private readonly Mock<IPassengerRepository> mockDtaRepository = new Mock<IPassengerRepository>();
        private readonly PassengerController _passengerController;

        public PassengerControllerTest()
        {
            _passengerController = new PassengerController(mockDtaRepository.Object);
        }

        [Fact]
        public void Test_GetPassengerCount()
        {
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.getPassengersList()).Returns(GetPassenger());

            // Act
            var response = _passengerController.Get();

            // Asert
            Assert.Equal(3, response.Count);

        }
        [Fact]
        public void Test_GetPassengerByID()
        {
            //Arrange
            var controller = _passengerController;

            //Act
            var result = controller.Get(2);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_GetPassengerByIDNotFound()
        {
            //Arrange
            var controller = _passengerController;

            //Act
            var result = controller.Get(8);

            //Assert
            Assert.IsType<NotFoundResult>(result);


        }

        [Fact]
        public void Test_AddPassenger()
        {
            //Arrange
            var newPassenger = new Passenger();
            newPassenger.ID = 4;
            newPassenger.FirstName = "ABC";
            newPassenger.LastName = "XYZ";
            newPassenger.PhoneNumber = 45454545;
            // Act
            var response = mockDtaRepository.Setup(x => x.AddPassenger(newPassenger)).Returns(AddPassenger());
            var result = _passengerController.Post(newPassenger);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteIdNotExist()
        {
            //Arrange
            var controller = _passengerController;
            var id = 8;

            //Act
            var result = _passengerController.Delete(id);

            //Assert
            Assert.False(result);


        }
        [Fact]
        public void Test_DeleteUserById()
        {
            var passenger = new TestingAssignment.Models.Passenger();
            passenger.ID = 1;
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.Delete(passenger.ID)).Returns(true);

            // Act
            var response = _passengerController.Delete(passenger.ID);

            //Assert
            Assert.True(response);

        }

        [Fact]
        public void Test_UpdateUser()
        {
            IList<Passenger> passengers = _passengerController.Get();
            var newpassenger = passengers.First<Passenger>();
            newpassenger.ID = 1;
            newpassenger.FirstName = "Hetvi12";
            newpassenger.LastName = "Shah12";
            newpassenger.PhoneNumber = 5551234;

            var updatedPassenger = _passengerController.Put(newpassenger);

            // Act
            var resultObj = mockDtaRepository.Setup(x => x.Update(newpassenger)).Returns(updatedPassenger);
            var response = _passengerController.Put(newpassenger);
            // Assert
            Assert.Equal(newpassenger, response);
        }
        private static IList<TestingAssignment.Models.Passenger> GetPassenger()
        {
            IList<TestingAssignment.Models.Passenger> users = new List<TestingAssignment.Models.Passenger>()
            {
                new TestingAssignment.Models.Passenger() {ID = 1, FirstName = "Hetvi", LastName = "Shah", PhoneNumber =12345678},
                new TestingAssignment.Models.Passenger() {ID = 1, FirstName = "ABC", LastName = "ABC", PhoneNumber =12345678},
                new TestingAssignment.Models.Passenger() {ID = 1, FirstName = "XYZ", LastName = "XYZ", PhoneNumber =12345678 },

            };
            return users;
        }

        private static TestingAssignment.Models.Passenger AddPassenger()
        {
            var newPassenger = new TestingAssignment.Models.Passenger();
            newPassenger.ID = 4;
            newPassenger.FirstName = "ABC";
            newPassenger.LastName = "XYZ";
            newPassenger.PhoneNumber = 45454545;
            return newPassenger;
        }
    }
}
