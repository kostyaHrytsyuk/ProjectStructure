﻿
namespace Common.DTO
{
    public class TicketDto : BaseDto
    {
        public decimal Price { get; set; }

        public string FlightNumber { get; set; }
    }
}