using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobackApp.Models
{
    public class EmployeeJoiningDetails
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } 
        public DateTime DateOfJoining { get; set; }
        public string DepartmentName { get; set; }

    }
}
