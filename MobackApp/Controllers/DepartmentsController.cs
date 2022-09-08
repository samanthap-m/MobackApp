using Microsoft.AspNetCore.Mvc;
using MobackApp.Models;
using MobackApp.Services;

namespace MobackApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet(nameof(getalldepartments))]
        public IEnumerable<Department> getalldepartments()
        {
            var deptlist=departmentService.GetAllDepartments();
            return deptlist;
        }
        [HttpGet(nameof(getdepartmentbyid))]
        public Department getdepartmentbyid(int id)
        {
            return departmentService.GetDepartmentById(id);
        }
        [HttpPut(nameof(updatedepartment))]
        public Department updatedepartment(Department department)
        {
            return departmentService.UpdateDepartment(department);
        }
        [HttpPost(nameof(adddepartment))]
        public Department adddepartment(Department department)
        {
            return departmentService.AddDepartment(department);
        }

        [HttpDelete(nameof(deletedepartment))]
        public bool deletedepartment(int id)
        {
            return departmentService.DeleteDepartment(id);
        }
    }
}
