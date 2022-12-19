using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FootBall.API.Models
{
    public class BaseModel
    {
        [Required]
        [Display(Name = "FirstName is Required field!")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName is Required field!")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Age is Required field!")]
        public int Age { get; set; }
    }
}
