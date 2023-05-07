using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TimeCo.PL.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;     
        public string Description { get; set; } = null!;
    }
}
