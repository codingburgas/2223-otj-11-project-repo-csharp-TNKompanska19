using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeCo.PL.Models
{
    public class User
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), MinLength(8)]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ModifiedAt { get; set; }

        [Required]
        public double MainVacationHours { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }

}
