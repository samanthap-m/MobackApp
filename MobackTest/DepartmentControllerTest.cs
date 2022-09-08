using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MobackApp.Controllers;
using MobackApp.Models;
using MobackApp.Services;
using Moq;

namespace MobackTest
{
    public class DepartmentControllerTest
    {
        private readonly Mock<IDepartmentService> mockdepservice;
        public DepartmentControllerTest()
        {
            mockdepservice = new Mock<IDepartmentService>();
        }
        private List<Department> GetDepartmentsData()
        {
            List<Department> departmentdata= new List<Department>()
            {
                new Department
                {
                    DepartmentId=1,
                    DepartmentName="HR"
                },
                new Department
                {
                    DepartmentId=2,
                    DepartmentName="Maintanance"
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Finance"
                }                
            };
            return departmentdata;
        }

        [Fact]
        public void GetDepartmentListControllerTest_ShouldReturnAllDepartmentsList()
        {
            var dept = GetDepartmentsData();
            mockdepservice.Setup(x=>x.GetAllDepartments()).Returns(dept);
            var deptcontroller = new DepartmentsController(mockdepservice.Object);

            var result = deptcontroller.getalldepartments();

            Assert.NotNull(result);
            Assert.Equal(dept.Count(),result.Count());
            Assert.Equal(dept.ToString(),result.ToString());
            Assert.True(result.Equals(dept));
        }
        [Fact]
        public void GetDepartmentByIdControllerTest_ShouldReturnDepartmentbyID()
        {
            var dept = GetDepartmentsData();
            mockdepservice.Setup(x => x.GetDepartmentById(1)).Returns(dept[1]);
            var deptcontroller = new DepartmentsController(mockdepservice.Object);

            var result = deptcontroller.getdepartmentbyid(1);

            Assert.NotNull(result);
            Assert.Equal(dept[1].DepartmentName, result.DepartmentName);
            Assert.True(result.DepartmentId == dept[1].DepartmentId);
        }
        [Fact]
        public void AddDepartmentControllerTest_ShouldReturnDepartment()
        {
            var dept = GetDepartmentsData();
            mockdepservice.Setup(x => x.AddDepartment(dept[1])).Returns(dept[1]);
            var deptcontroller = new DepartmentsController(mockdepservice.Object);

            var result = deptcontroller.adddepartment(dept[1]);

            Assert.NotNull(result);
            Assert.Equal(dept[1].DepartmentId, result.DepartmentId);
            Assert.True(result.DepartmentId == dept[1].DepartmentId);
        }
        [Fact]
        public void UpdateDepartmentControllerTest_ShouldReturnUpdatedDepartment()
        {
            List<Department> updateddepartmentdata = new List<Department>()
            {
                new Department
                {
                    DepartmentId=1,
                    DepartmentName="Human Resources"
                }
            };
            var dept = GetDepartmentsData();
            mockdepservice.Setup(x => x.UpdateDepartment(dept[0])).Returns(updateddepartmentdata[0]);
            var deptcontroller = new DepartmentsController(mockdepservice.Object);
            var result = deptcontroller.updatedepartment(dept[0]);
            Assert.NotNull(result);
            Assert.Equal(updateddepartmentdata[0].DepartmentId, result.DepartmentId);
            Assert.True(result.DepartmentName == updateddepartmentdata[0].DepartmentName);
        }
        [Fact]
        public void DeleteDepartmentControllerTest_ShouldReturnTrueIfDepartmentDeleted()
        {
            var dept = GetDepartmentsData();
            mockdepservice.Setup(x => x.DeleteDepartment(1)).Returns(true);
            var deptcontroller = new DepartmentsController(mockdepservice.Object);

            var result = deptcontroller.deletedepartment(1);

            Assert.True(result);
            Assert.DoesNotContain(dept[1], mockdepservice.Object.GetAllDepartments());
        }
    }
}
       