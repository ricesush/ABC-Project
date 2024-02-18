using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ABC.Shared.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }


        //SUPPLIER LIST - NEW SUPPLIER
        //Supplier Information
        [Required]
        [DisplayName("Company Name")]
        public string companyName { get; set; }

        [Required]
      
        [DisplayName("Contact Number")]
        public long contactNumber { get; set; }

        [Required]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [Required]
     
        [DisplayName("Status")]
        public string Status { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Line Address")]
        public string line_Address { get; set; }

   
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Province")]
        public string Province { get; set; }

        [Required]
        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }

        [DisplayName("Additional Note")]
        public string remarks { get; set; }
    }
}
