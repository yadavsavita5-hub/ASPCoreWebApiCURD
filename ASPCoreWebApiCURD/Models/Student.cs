using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebApiCURD.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? StudentName { get; set; }

    [StringLength(10)]
    public string? StudentGender { get; set; }

    public int? Age { get; set; }

    public int? Standard { get; set; }

    [StringLength(10)]
    public string? FatherName { get; set; }
}
