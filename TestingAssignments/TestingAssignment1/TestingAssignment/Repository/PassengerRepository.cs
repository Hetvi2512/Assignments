using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingAssignment.Models;

namespace TestingAssignment.Repository
{
    public class PassengerRepository: IPassengerRepository
    {
        readonly Dictionary<int, Passenger> _passenger = new Dictionary<int, Passenger>();
        public PassengerRepository()
        {
            _passenger.Add(1, new Passenger() { ID = 1, FirstName = "Hetvi", LastName = "Shah", PhoneNumber =12345678 });
            _passenger.Add(2, new Passenger() { ID = 2, FirstName = "ABC", LastName = "ABC", PhoneNumber = 12345678 });
            _passenger.Add(3, new Passenger() { ID = 3, FirstName = "DEF", LastName = "XYZ", PhoneNumber = 12345678 });

        }
        public Passenger AddPassenger(Passenger passenger)
        {

            int newId = !getPassengersList().Any() ? 1 : getPassengersList().Max(x => x.ID) + 1;
            passenger.ID = newId;
            _passenger.Add(newId, passenger);
            return passenger;
        }

      
        public IList<Passenger> getPassengersList()
        {
            return _passenger.Select(x => x.Value).ToList();
        }
        public Passenger Update(Passenger passenger)
        {
            Passenger obj = GetById(passenger.ID);
            if (obj == null)
                return null;
            _passenger[obj.ID] = passenger;
            return passenger;
        }

        public bool Delete(int Id)
        {
            var result = _passenger.Remove(Id);
            return result;
        }

        public Passenger GetById(int id)
        {
            return _passenger.FirstOrDefault(x => x.Key == id).Value;
        }

    }
}