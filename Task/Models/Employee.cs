﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Task.Models;

public partial class Employee
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Mobile { get; set; }

    [Required]

    [StringLength(50)]
    [Unicode(false)]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    public DateOnly? HireDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Salary { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ProfileImg { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public int? DepartmentID { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifaiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("EmployeeCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; }

    [ForeignKey("DepartmentID")]
    [InverseProperty("Employees")]
    public virtual Department Department { get; set; }

    [ForeignKey("ModifaiedBy")]
    [InverseProperty("EmployeeModifaiedByNavigations")]
    public virtual User ModifaiedByNavigation { get; set; }
}