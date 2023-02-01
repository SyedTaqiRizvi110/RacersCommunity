using System.ComponentModel.DataAnnotations;

namespace RacersCommunity.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string StateName { get; set; }
        public String StateCode { get; set; }
    }
}
