using MobackApp.Models;

namespace MobackApp.Services
{
    public interface IDepartmentService
    {
        public IEnumerable<Department> GetAllDepartments();
        public Department GetDepartmentById(int id);
        public Department AddDepartment(Department department);
        public Department UpdateDepartment(Department department);
        public bool DeleteDepartment(int id);
    }
}
