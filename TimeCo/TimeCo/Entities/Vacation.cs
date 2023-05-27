using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TimeCo.DAL.Entities;

// Entity for vacations
public partial class Vacation
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [Column("isMainVacation")]
    public bool isMainVacation { get; set; }

    [Column("userID")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Vacations")]
    public virtual User User { get; set; } = null!;
}
