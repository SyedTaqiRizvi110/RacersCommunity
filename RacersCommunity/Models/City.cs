using System.ComponentModel.DataAnnotations;

namespace RacersCommunity.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }
        public int Zip { get; set; }
        public string Country { get; set; }
    }
}
