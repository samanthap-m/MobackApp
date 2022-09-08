using MobackApp.Models;

namespace MobackApp.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly MobackDBContext _dbContext;
        public DepartmentService(MobackDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _dbContext.Departments.ToList();
        }
        public Department GetDepartmentById(int id)
        {
            return _dbContext.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();
        }
        public Department AddDepartment(Department department)
        {
            var result = _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public Department UpdateDepartment(Department department)
        {
            var result = _dbContext.Departments.Update(department);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteDepartment(int id)
        {
            var data=_dbContext.Departments.Where(x=>x.DepartmentId == id).FirstOrDefault();
            var result= _dbContext.Remove(data);
            _dbContext.SaveChanges();
            return result != null? true: false;
        }
    }
}
