using System.ComponentModel.DataAnnotations;

namespace CURDwithCoreWebAPI.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public int age { get; set; }

        public int standard { get; set; }
        [Required]
        public string fatherName { get; set; }

    }
}
