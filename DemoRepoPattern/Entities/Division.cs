using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoRepoPattern.Entities
{
    public class Division
    {
        
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 words required")]
        public string Name { get; set; }
        //One to Many
        public ICollection<Student> Students { get; set; }
    }
}
