using Common.DTO;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using ProjectStructure;

namespace Airport.Tests
{
    [TestFixture]
    public class ApiTests
    {
        private TestServer _testServer;
        private HttpClient _client;
        
        [OneTimeSetUp]
        public void Init()
        {
            _testServer = new TestServer(new WebHostBuilder()
                              .UseEnvironment("Testing")
                              .UseStartup<Startup>());
            _client = _testServer.CreateClient();
        }

        [Test]
        public async Task Read_Plane_Should_Return_Items()
        {
            //Act
            var response = await _client.GetAsync("/api/planes");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var planes = JsonConvert.DeserializeObject<List<PlaneType>>(data);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.True(planes.Any());
        }

        [Test]
        public async Task Create_PlaneType_Should_Return_Entity_With_Id_And_Statuscode_200()
        {
            //Arrange
            var testPlaneTypeDto = new PlaneTypeDto()
            {
                PlaneModel = "Litak",
                SeatsNumber = 20,
                Carrying = 4000
            };
            var serializedPlaneType = JsonConvert.SerializeObject(testPlaneTypeDto);
            var httpContent = new StringContent(serializedPlaneType, Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("api/planeTypes", httpContent);
            var data = await response.Content.ReadAsStringAsync();
            var planeTypeDto = JsonConvert.DeserializeObject<PlaneTypeDto>(data);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(testPlaneTypeDto.GetType(), planeTypeDto.GetType());
            Assert.AreEqual(testPlaneTypeDto.PlaneModel, planeTypeDto.PlaneModel);
            Assert.True(planeTypeDto.Id != 0);
        }

        [Test]
        public async Task Create_Flight_With_Invalid_Data_Should_Return_Statuscode_400()
        {
            //Arrange
            var testFlightDto = new FlightDto()
            {
                FlightNumber = "Litak",
                DepartureAirport = "Home",
                DestinationAirport = "12"
            };
            var serializedFlight = JsonConvert.SerializeObject(testFlightDto);
            var httpContent = new StringContent(serializedFlight, Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("api/flights", httpContent);
         
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Update_Crew_With_Unvalid_Data_Should_Return_Statuscode_400()
        {
            //Arrange
            var testCrewDto = new CrewDto() { Id = 1, PilotId = -1};
            var serializedCrew = JsonConvert.SerializeObject(testCrewDto);
            var httpContent = new StringContent(serializedCrew, Encoding.UTF8, "application/json");
                        
            //Act
            var response = await _client.PutAsync($"api/crews/{testCrewDto.Id}", httpContent);

            //Asssert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Delete_Departure_Then_Shoud_Return_StatusCode_204()
        {
            //Arrange
            var responseGetAll = await _client.GetAsync("/api/departures");
            responseGetAll.EnsureSuccessStatusCode();

            var data = await responseGetAll.Content.ReadAsStringAsync();
            var testDepartureDto = JsonConvert.DeserializeObject<List<DepartureDto>>(data).FirstOrDefault();
            
            //Act
            var response = await _client.DeleteAsync($"api/crews/{testDepartureDto.Id}");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NoContent);
        }
    }
}
