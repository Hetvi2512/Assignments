using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingAssignment.Models;

namespace TestingAssignment.Repository
{
    public interface IPassengerRepository
    {
        Passenger AddPassenger(Passenger passenger);
        bool Delete(int Id);
        Passenger GetById(int id);
        IList<Passenger> getPassengersList();
        Passenger Update(Passenger passenger);
    }
}