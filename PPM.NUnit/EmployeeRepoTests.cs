using NUnit.Framework;
using PPM.Domain;
using PPM.Model;
using System;

namespace PPM.Tests
{
    [TestFixture]
    public class EmployeeRepoTests
    {
        [Test]
        public void AddEmployee_ShouldAddEmployeeToList()
        {
            // Arrange
            EmployeeRepo employeeRepo = new EmployeeRepo();
            Employee employee = new Employee { EmployeeId = 1, EmployeeFirstName = "Test", EmployeeLastName = "Employee", EmployeeAddress = "Test" ,EmployeeEmail = "Test@gmail.com", EmployeeMobileNumber = 8250252772, EmployeeRoleId = 1  };

            // Act
            employeeRepo.AddEmployee(employee);

            // Assert
            CollectionAssert.Contains(employeeRepo.ListAllEmployees(), employee);
        }

        [Test]
        public void DeleteEmployee_ExistingEmployee_ShouldRemoveEmployee()
        {
            // Arrange
            EmployeeRepo employeeRepo = new EmployeeRepo();
            Employee employee = new Employee { EmployeeId = 1, EmployeeFirstName = "Test", EmployeeLastName = "Employee", EmployeeAddress = "Test" ,EmployeeEmail = "Test@gmail.com", EmployeeMobileNumber = 8250252772, EmployeeRoleId = 1  };
            employeeRepo.AddEmployee(employee);

            // Act
            employeeRepo.DeleteEmployee(1);

            // Assert
            CollectionAssert.DoesNotContain(employeeRepo.ListAllEmployees(), employee);
        }

        [Test]
        public void DeleteEmployee_NonExistentEmployee_ShouldNotThrowException()
        {
            // Arrange
            EmployeeRepo employeeRepo = new EmployeeRepo();

            // Act and Assert
            Assert.DoesNotThrow(() => employeeRepo.DeleteEmployee(1));
        }

        [Test]
        public void GetEmployee_ExistingEmployee_ShouldReturnEmployee()
        {
            // Arrange
            EmployeeRepo employeeRepo = new EmployeeRepo();
            Employee employee = new Employee { EmployeeId = 1, EmployeeFirstName = "Test", EmployeeLastName = "Employee", EmployeeAddress = "Test" ,EmployeeEmail = "Test@gmail.com", EmployeeMobileNumber = 8250252772, EmployeeRoleId = 1 };
            employeeRepo.AddEmployee(employee);

            // Act
            Employee retrievedEmployee = employeeRepo.GetEmployee(1);

            // Assert
            Assert.AreEqual(employee, retrievedEmployee);
        }
    }
}
