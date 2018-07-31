using BusinessLogic.Services;
using Common.DTO;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ProjectStructure.Controllers;
using System;
using System.Net;
using System.Collections.Generic;

namespace Airport.Tests
{
    [TestFixture]
    public class ControllersTests
    {
        [Test]
        public void Read_When_GetAll_Executed_Then_Should_Return_Entities()
        {
            //Arrange                        
            var planeTypes = new List<PlaneTypeDto>()
            {
                new PlaneTypeDto() { PlaneModel = "Civil", SeatsNumber = 200, Carrying = 10000 },
                new PlaneTypeDto() { PlaneModel = "Cargo", SeatsNumber = 10, Carrying = 50000 },
                new PlaneTypeDto() { PlaneModel = "Military", SeatsNumber = 40, Carrying = 3000 },
                new PlaneTypeDto() { PlaneModel = "Falcon", SeatsNumber = 100, Carrying = 9 }
            };
            
            var service = A.Fake<IPlaneTypeService>();
            A.CallTo(() => service.GetAll()).Returns(planeTypes);
            var controller = new PlaneTypeController(service);

            //Act
            var jsonResult = controller.GetAll() as JsonResult;
            
            //Assert
            Assert.NotNull(jsonResult);
            Assert.AreEqual(jsonResult.Value, planeTypes);
            A.CallTo(() => service.GetAll()).MustHaveHappenedOnceExactly();
        }
        
        [Test]
        public void Read_When_Get_Executed_Then_Should_Return_Entity()
        {
            //Arrange
            var testTicketDto = new TicketDto()
            {
                Id = 1,
                Price = 100,
                FlightNumber = "AT7635",
                FlightId = 1
            };

            var ticketService = A.Fake<ITicketService>();
            A.CallTo(() => ticketService.Get(A<int>._)).Returns(testTicketDto);

            var ticketController = new TicketController(ticketService);

            //Act
            var jsonResult = ticketController.GetById(1) as JsonResult;
            var ticket = jsonResult.Value;

            //Assert
            Assert.NotNull(jsonResult);
            Assert.AreEqual(testTicketDto, ticket);
            A.CallTo(() => ticketService.Get(A<int>._)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Create_Should_Create_New_Pilot_And_Return_Statuscode_200()
        {
            //Arrange
            var testPilotDto = new PilotDto()
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last",
                BirthDate = DateTime.Now,
                Experience = 20
            };

            var pilotService = A.Fake<IPilotService>();
            var pilotController = new PilotController(pilotService);

            //Act
            var actionResult = pilotController.Create(testPilotDto) as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, (int)HttpStatusCode.OK);
            A.CallTo(() => pilotService.Create(testPilotDto)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Create_When_Flight_Is_Not_Valid_Then_StatusCode_400()
        {
            //Arrange
            var testFlightDto = new FlightDto()
            {
                Id = 1,
                FlightNumber = "12",
                DepartureAirport = "AAA",
                DepartureTime = new DateTime(2007, 07, 13, 14, 45, 0),
                DestinationAirport = "BBB",
                ArrivalTime = new DateTime(2007, 07, 13, 16, 15, 0)
            };

            var flightService = A.Fake<IFlightService>();
            A.CallTo(() => flightService.Create(testFlightDto));
            var flightController = new FlightController(flightService);
            flightController.ViewData.ModelState.AddModelError("FlightNumber", "Flight Number Format id AA1111");

            //Act
            var actionResult = flightController.Create(testFlightDto) as ObjectResult;

            //Assert
            Assert.NotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, (int)HttpStatusCode.BadRequest);
            A.CallTo(() => flightService.Create(testFlightDto)).MustNotHaveHappened();
        }

        [Test]
        public void Update_Should_Execute_Update_Service_Method_And_Return_Statuscode_200()
        {
            //Arrange
            var testCrewDtoOne = new CrewDto()
            {
                Id = 1,
                PilotId = 1
            };
            var testCrewDtoTwo = new CrewDto()
            {
                Id = 1,
                PilotId = 2
            };
            var crewService = A.Fake<ICrewService>();
            A.CallTo(() => crewService.Update(testCrewDtoOne)).Returns(testCrewDtoTwo);
            var crewController = new CrewController(crewService);

            //Act
            var actionResult = crewController.Update(testCrewDtoOne) as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, (int) HttpStatusCode.OK);
            Assert.AreEqual(actionResult.Value, testCrewDtoTwo);
            A.CallTo(() => crewService.Update(testCrewDtoOne)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_When_Flight_Is_Not_Valid_Then_StatusCode_400()
        {
            //Arrange
            var testFlightDto = new FlightDto()
            {
                Id = 1,
                FlightNumber = "12",
                DepartureAirport = "AAA",
                DepartureTime = new DateTime(2007, 07, 13, 14, 45, 0),
                DestinationAirport = "BBB",
                ArrivalTime = new DateTime(2007, 07, 13, 16, 15, 0)
            };

            var flightService = A.Fake<IFlightService>();
            A.CallTo(() => flightService.Update(testFlightDto));
            var flightController = new FlightController(flightService);
            flightController.ViewData.ModelState.AddModelError("FlightNumber", "Flight Number Format id AA1111");

            //Act
            var actionResult = flightController.Update(testFlightDto) as ObjectResult;

            //Assert
            Assert.NotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, (int)HttpStatusCode.BadRequest);
            A.CallTo(() => flightService.Update(testFlightDto)).MustNotHaveHappened();
        }

        [Test]
        public void Delete_Should_Return_StatusCode_204()
        {
            //Arrange
            var id = 1;

            var departureService = A.Fake<IDepartureService>();
            A.CallTo(() => departureService.Delete(id));

            var departureController = new DepartureController(departureService);

            //Act
            var actionResult = departureController.Delete(id) as StatusCodeResult;

            //Assert
            Assert.NotNull(actionResult);
            Assert.AreEqual(actionResult.StatusCode, (int)HttpStatusCode.NoContent);
            A.CallTo(() => departureService.Delete(id)).MustHaveHappenedOnceExactly();
        }
    }
}
