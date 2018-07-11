namespace DAL.Models
{
    class PlaneType : Entity
    {
        public string PlaneModel { get; set; }

        public int SeatsNumber { get; set; }

        public int Carrying { get; set; }
    }
}
