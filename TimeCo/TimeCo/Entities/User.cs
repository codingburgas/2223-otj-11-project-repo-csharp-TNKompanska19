using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TimeCo.DAL.Entities;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public double MainVacationHours { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Users")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();

    [InverseProperty("User")]
    public virtual ICollection<Vacation> Vacations { get; } = new List<Vacation>();
}
