using System.ComponentModel.DataAnnotations;

namespace DemoRepoPattern.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "Minimum 2 word required")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 word required")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^([0]|\+91[\-\s]?)?[789]\d{9}$", ErrorMessage = "Entered Mobile No is not valid.")]
        public string PhoneNo { get; set; }
        // Foreign Key for the Department        
        public Division Division { get; set; }
    }
}
