using System.ComponentModel.DataAnnotations;

namespace WebAppMVCClientLocationEFCore.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
    }
}
