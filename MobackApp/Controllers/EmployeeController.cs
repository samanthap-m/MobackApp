using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobackApp.Models;
using MobackApp.Services;

namespace MobackApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet(nameof(GetEmployeeNameById))]
        public async Task<string> GetEmployeeNameById(int EmpID)
        {
            var result = await _employeeService.GetEmployeeNamebyId(EmpID);
            return result;
        }

        [HttpGet(nameof(GetEmployeeJoiningDetailsById))]
        public async Task<EmployeeJoiningDetails> GetEmployeeJoiningDetailsById(int EmpID)
        {
            var result = await _employeeService.GetEmployeeJoiningDetailsbyId(EmpID);
            return result;
        }

        [HttpGet(nameof(GetEmployeeDetailsById))]
        public async Task<EmployeeModel> GetEmployeeDetailsById(int EmpID)
        {
            var result = await _employeeService.GetEmployeeDetailsbyId(EmpID);
            return result;
        }
        
        [HttpGet(nameof(GetAllEmployeeDetailsOrderByDateDesc))]
        public async Task<List<EmployeeModel>> GetAllEmployeeDetailsOrderByDateDesc()
        {
            var result = await _employeeService.GetAllEmployeeDetailsOrderbyDateDesc();
            return result;
        }

        [HttpGet(nameof(GetAllEmployeedetails))]
        public async Task<List<Employee>> GetAllEmployeedetails()
        {
            var result = await _employeeService.GetAllEmployeeDetails();
            return result;
        }

        [HttpGet(nameof(DownloadFile))]
        public async Task<ActionResult> DownloadFile()
        {
            var filePath = $"C:\\Users\\Samantha P\\Desktop\\abc.txt"; 
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, "text/plain", Path.GetFileName(filePath));
        }
    }
}
