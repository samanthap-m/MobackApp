using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobackApp.Models
{
    public partial class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } 

        [Column(TypeName = "Date")]
        public DateTime DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
