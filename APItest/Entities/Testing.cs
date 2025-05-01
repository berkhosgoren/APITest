using System.ComponentModel.DataAnnotations;

namespace APItest.Entities
{
    public class Testers
    {
        // Unique ID of the tester (Primary Key)
        public int Id { get; set; }
       
        // First name of the tester
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        // Last name of the tester
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        // Location (e.g., city) of the tester
        [Required]
        [StringLength(100)]
        public string Place { get; set; }
    }
}
