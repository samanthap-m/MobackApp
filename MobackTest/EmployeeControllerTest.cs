using MobackApp.Controllers;
using MobackApp.Models;
using MobackApp.Services;
using Moq;

namespace MobackTest
{
    public class EmployeeControllerTest
    {
        public Mock<IEmployeeService> mockservice = new Mock<IEmployeeService>();
        [Fact]
        public async void GetEmployeeNamebyIdControllerTest_ShouldreturnEmployeeName()
        {
            mockservice.Setup(p => p.GetEmployeeNamebyId(1)).ReturnsAsync("TestN");
            EmployeeController emp = new EmployeeController(mockservice.Object);
            string result = await emp.GetEmployeeNameById(1);
            Assert.Equal("TestN", result);
        }
        [Fact]
        public async void GetEmployeeJoiningDetailsbyIdControllerTest_shouldreturnEmployeeJoiningDetails()
        {
            var employee =
              new EmployeeJoiningDetails()
              {
                  EmployeeId = 1,
                  EmployeeName = "TestN",
                  DateOfJoining = DateTime.Now,
                  DepartmentName = "HR"
              };
            mockservice.Setup(p => p.GetEmployeeJoiningDetailsbyId(1)).ReturnsAsync(employee);
            EmployeeController emp = new EmployeeController(mockservice.Object);
            var result = await emp.GetEmployeeJoiningDetailsById(1);
            Assert.True(employee.Equals(result));
        }
        [Fact]
        public async void GetEmployeeDetailsbyIdControllerTest_shouldreturnAllEmployeeDetails()
        {
            var employee =
              new EmployeeModel()
              {
                  EmployeeId = 1,
                  EmployeeName = "TestN",
                  DateOfJoining = DateTime.Now,
                  DepartmentName= "HR",
                  PhotoFileName="IMG1.png",
                  
              };
            mockservice.Setup(p => p.GetEmployeeDetailsbyId(1)).ReturnsAsync(employee);
            EmployeeController emp = new EmployeeController(mockservice.Object);
            var result = await emp.GetEmployeeDetailsById(1);
            Assert.True(employee.Equals(result));
        }
        [Fact]
        public async void GetAllEmployeeDetailsOrderbyDateDescControllerTest_shouldreturnAllEmployeesOrderbyDescDateOfJoining()
        {
            var employees = new List<EmployeeModel>()
            {
              new EmployeeModel()
              {
                  EmployeeId = 1,
                  EmployeeName = "TestN",
                  DateOfJoining = DateTime.Now,
                  DepartmentName= "HR",
                  PhotoFileName="IMG1.png",

              }, 
              new EmployeeModel()
              {
                  EmployeeId = 2,
                  EmployeeName = "TestN2",
                  DateOfJoining = new DateTime(2020,07,07,07,00,00),
                  DepartmentName= "Management",
                  PhotoFileName="img2.png",

              },
              new EmployeeModel()
              {
                  EmployeeId = 3,
                  EmployeeName = "TestN3",
                  DateOfJoining = new DateTime(2021,07,07,07,00,00),
                  DepartmentName= "IT",
                  PhotoFileName="IMG3.png",

              }

            };
            mockservice.Setup(p => p.GetAllEmployeeDetailsOrderbyDateDesc()).ReturnsAsync(employees);
            EmployeeController emp = new EmployeeController(mockservice.Object);
            List<EmployeeModel> result = await emp.GetAllEmployeeDetailsOrderByDateDesc();
            Assert.True(employees.Equals(result));
        }
        [Fact]
        public async void GetAllEmployeeControllerTest_shouldreturnAllEmployeesDetails()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    EmployeeName = "Name1",
                    DepartmentId=1,
                    DateOfJoining = DateTime.Now
                },
                new Employee()
                {
                    EmployeeId = 2,
                    EmployeeName = "Name2",
                    DepartmentId=2,
                    DateOfJoining = DateTime.Now
                }
            };
            mockservice.Setup(p => p.GetAllEmployeeDetails()).ReturnsAsync(employees);
            EmployeeController emp = new EmployeeController(mockservice.Object);
            List<Employee> result = await emp.GetAllEmployeedetails();
            Assert.True(employees.Equals(result));
        }
    }
}