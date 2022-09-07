using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobackApp.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }
        public string DepartmentName { get; set; }
    }
}
