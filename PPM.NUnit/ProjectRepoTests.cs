using NUnit.Framework;
using PPM.Domain;
using PPM.Model;


namespace PPM.Tests
{
    [TestFixture]
    public class ProjectRepoTests
    {
        [Test, Order(1)]
        public void AddProject_ShouldAddProjectToList() // Pass
        {
            // Arrange
            ProjectRepo projectRepo = new ProjectRepo();
            Project project = new Project { ProjectId = 1, ProjectName = "TestProject" };

            // Act
            projectRepo.AddProject(project);

            // Assert
            CollectionAssert.Contains(projectRepo.ListAllProjectsWithoutEmployeeDetails(), project);
        }

        [Test,Order(2)]
        public void DeleteProject_ExistingProject_ShouldRemoveProject() // Pass
        {
            // Arrange
            ProjectRepo projectRepo = new ProjectRepo();
            Project project = new Project { ProjectId = 1, ProjectName = "TestProject" };
            projectRepo.AddProject(project);

            // Act
            projectRepo.DeleteProject(1);

            // Assert
            CollectionAssert.DoesNotContain(projectRepo.ListAllProjectsWithoutEmployeeDetails(), project);
        }

        [Test]
        public void DeleteProject_NonExistentProject_ShouldNotThrowException() // Pass
        {
            // Arrange
            ProjectRepo projectRepo = new ProjectRepo();

            // Act 

            // Assert
            Assert.DoesNotThrow(() => projectRepo.DeleteProject(1));
        }

        [Test, Order(3)]
        public void AddEmployeeToExistingProject_ExistingProjectAndEmployee_ShouldAddEmployee() // Pass
        {
            // Arrange
            ProjectRepo projectRepo = new ProjectRepo();
            Project project = new Project { ProjectId = 1, ProjectName = "TestProject" };
            EmployeeRepo.employeeList.Add(new Employee { EmployeeId = 1, EmployeeFirstName = "Test", EmployeeLastName = "Employee", EmployeeAddress = "Test" ,EmployeeEmail = "Test@gmail.com", EmployeeMobileNumber = 8250252772, EmployeeRoleId = 1 });
            projectRepo.AddProject(project);

            // Act
            projectRepo.AddEmployeeToExistingProject(1, 1);

            // Assert
            Assert.IsTrue(project.ProjectEmployees!.Contains(EmployeeRepo.employeeList[0]));
        }

        [Test,Order(4)]
        public void DeleteEmployeeFromProject_ExistingProjectAndEmployee_ShouldRemoveEmployee() // Pass
        {
            // Arrange
            ProjectRepo projectRepo = new ProjectRepo();
            Project project = new Project { ProjectId = 1, ProjectName = "TestProject" };
            EmployeeRepo.employeeList.Add(new Employee { EmployeeId = 1, EmployeeFirstName = "Test", EmployeeLastName = "Employee", EmployeeAddress = "Test" ,EmployeeEmail = "Test@gmail.com", EmployeeMobileNumber = 8250252772, EmployeeRoleId = 1 });
            project.ProjectEmployees!.Add(EmployeeRepo.employeeList[0]);
            projectRepo.AddProject(project);

            // Act
            projectRepo.DeleteEmployeeFromProject(1, 1);

            // Assert
            Assert.IsEmpty(project.ProjectEmployees);
        }

        [Test,Order(5)]
        public void ViewProjectDetail_ExistingProject_ShouldReturnProject() // Pass
        {
            // Arrange
            ProjectRepo projectRepo = new ProjectRepo();
            Project project = new Project { ProjectId = 1, ProjectName = "TestProject" };
            projectRepo.AddProject(project);

            // Act
            Project retrievedProject = projectRepo.ViewProjectDetail(1);

            // Assert
            Assert.AreEqual(project,retrievedProject);
        }
    }
}
