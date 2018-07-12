using System;

namespace Common.DTO
{
    public class StewardessDto : BaseDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
