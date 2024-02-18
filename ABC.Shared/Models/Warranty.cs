using Google.Protobuf.WellKnownTypes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ABC.Shared.Models
{
    public class Warranty
	{
        [Key]
        public int Id { get; set; }


        [MaxLength(30)]
        [Required]
        [DisplayName("Warranty Name")]
        public string Type { get; set; }

		public string Duration { get; set; }
		public string Provider { get; set; }
	}
}
