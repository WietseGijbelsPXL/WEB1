using System.ComponentModel.DataAnnotations;

namespace MVCSportStore.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        [StringLength(100)]
        public string ClientName { get; set; } = string.Empty;
    }
}
