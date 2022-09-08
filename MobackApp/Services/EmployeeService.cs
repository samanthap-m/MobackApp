using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MobackApp.Models;

namespace MobackApp.Services
{
    public class EmployeeService: IEmployeeService
    {
        private MobackDBContext _context;
        MapperConfiguration mc = new MapperConfiguration(cfg => cfg.CreateProjection<Employee, EmployeeModel>()
                                                  .ForMember(dto => dto.DepartmentName, conf =>
                                              conf.MapFrom(ol => ol.Department.DepartmentName)));

        public EmployeeService(MobackDBContext context)
        {
            _context = context;
        }
        public async Task<string> GetEmployeeNamebyId(int EmpID)
        {
            var name = await _context.Employees.Where(c => c.EmployeeId == EmpID).Select(d => d.EmployeeName).FirstOrDefaultAsync();
            return name;
        }
        public async Task<EmployeeJoiningDetails> GetEmployeeJoiningDetailsbyId(int EmpID)
        {
            var empj = await _context.Employees.Where(c => c.EmployeeId == EmpID).Select(e => new EmployeeJoiningDetails
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
                DateOfJoining = e.DateOfJoining,
                DepartmentName = e.Department.DepartmentName
            }).FirstOrDefaultAsync();
            return empj;
        }
        public async Task<EmployeeModel> GetEmployeeDetailsbyId(int EmpID)
        {
           var result = await _context.Employees.ProjectTo<EmployeeModel>(mc).FirstOrDefaultAsync(c => c.EmployeeId == EmpID);
            return (result);
        }
        public async Task<List<EmployeeModel>> GetAllEmployeeDetailsOrderbyDateDesc()
        {
            List<EmployeeModel> emp = await _context.Employees.ProjectTo<EmployeeModel>(mc).OrderByDescending(d => d.DateOfJoining).ToListAsync();
            return emp;

        }

        public async Task<List<Employee>> GetAllEmployeeDetails()
        {
            var result = from e in _context.Employees select e;
            return await Task.FromResult(result.ToList());
            // List<Employee> emp = await _appDbContext.Employees.ToListAsync();
            //return emp;

        }
    }
}
