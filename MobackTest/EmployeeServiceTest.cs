using Microsoft.EntityFrameworkCore;
using MobackApp.Models;
using MobackApp.Services;
using Moq;

namespace MobackTest
{
    public class EmployeeServiceTest
    {
        public Mock<MobackDBContext> mockContext = new Mock<MobackDBContext>();
        [Fact]
        public async Task GetAllEmployeesAsyncServiceTest_shouldreturnAllEmployeeDetails()
        {
            var data = new List<Employee>()
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
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<Employee>(data.Provider));
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);

            mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            var service = new EmployeeService(mockContext.Object);
            var employees = await service.GetAllEmployeeDetails();
            Assert.NotNull(employees);
            Assert.Equal(2, employees.Count());
        }
    }
}
