using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.DAL
{
    public class DataSource
    {
        public DataSource(AirportContext airportContext)
        {
            airportContext.Database.EnsureCreated();

            List<Aviator> aviators = new List<Aviator>
            {
                new Aviator { Id = 1, Name = "Alex", Surname = "Harper", Experience = 3},
                new Aviator { Id = 2, Name = "Qwer", Surname = "Tiger", Experience = 2},
                new Aviator { Id = 3, Name = "Chery", Surname = "Bim", Experience = 1}
            };
            airportContext.Aviators.AddRange(aviators);

            List<Crew> crews = new List<Crew>
            {
                new Crew { Id = 1, aviator = new Aviator(), stewardesses = new List<Stewardess>()},
                new Crew { Id = 2, aviator = new Aviator(), stewardesses = new List<Stewardess>()},
                new Crew { Id = 3, aviator = new Aviator(), stewardesses = new List<Stewardess>()}
            };
            airportContext.Crews.AddRange(crews);

            List<Departure> departures = new List<Departure>
            {
                new Departure { Id = 1, FlightNumber = 111, PlaneId = 100, CrewId = 1},
                new Departure { Id = 2, FlightNumber = 222, PlaneId = 200, CrewId = 2},
                new Departure { Id = 3, FlightNumber = 333, PlaneId = 300, CrewId = 3}
            };
            airportContext.Departures.AddRange(departures);

            List<Flight> flights = new List<Flight>
            {
                new Flight { Number = 111, Destination = "nulL", TicketId = 1},
                new Flight { Number = 222, Destination = "Null", TicketId = 2},
                new Flight { Number = 333, Destination = "nUll", TicketId = 3}
            };
            airportContext.Flights.AddRange(flights);

            List<Plane> planes = new List<Plane>
            {
                new Plane { Id = 1, Name = "qwe", TimeSpan = 3, Type = "A"},
                new Plane { Id = 2, Name = "rty", TimeSpan = 4, Type = "B"},
                new Plane { Id = 3, Name = "zxc", TimeSpan = 5, Type = "C"}
            };
            airportContext.Planes.AddRange(planes);

            List<Stewardess> stewardesses = new List<Stewardess>
            {
                new Stewardess { Id = 1, Name = "Anna", Surname = "Kasparova"},
                new Stewardess { Id = 2, Name = "Zany", Surname = "Jimova"},
                new Stewardess { Id = 2, Name = "Sara", Surname = "Binomy"}
            };
            airportContext.Stewardesses.AddRange(stewardesses);

            List<Ticket> tickets = new List<Ticket>
            {
                new Ticket { Id = 1, Price = 1000},
                new Ticket { Id = 1, Price = 2000},
                new Ticket { Id = 1, Price = 3000}
            };
            airportContext.Tickets.AddRange(tickets);

            List<TypePlane> typesPlane = new List<TypePlane>
            {
                new TypePlane { Id = 1, CarryingCapacity = 1000, CountOfSeats = 60},
                new TypePlane { Id = 2, CarryingCapacity = 1200, CountOfSeats = 80},
                new TypePlane { Id = 3, CarryingCapacity = 1500, CountOfSeats = 100}
            };
            airportContext.TypesPlane.AddRange(typesPlane);
        }
    }
}