using MobackApp.Models;

namespace MobackApp.Services
{
    public interface IEmployeeService
    {
        Task<string> GetEmployeeNamebyId(int EmpID);
        Task<EmployeeJoiningDetails> GetEmployeeJoiningDetailsbyId(int EmpID);
        Task<EmployeeModel> GetEmployeeDetailsbyId(int EmpID);
        Task<List<EmployeeModel>> GetAllEmployeeDetailsOrderbyDateDesc();
        Task<List<Employee>> GetAllEmployeeDetails();
    }
}
