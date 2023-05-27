using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TimeCo.DAL.Entities;

// Entity for department
public partial class Department
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<User> Users { get; } = new List<User>();
}
