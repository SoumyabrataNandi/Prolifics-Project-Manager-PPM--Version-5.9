using NUnit.Framework;
using Moq;
using PPM.Ui.Consoles;

namespace PPM.Ui.Consoles.Tests
{
    [TestFixture]
    public class ProjectModuleManagerTests
    {
        private ProjectModuleManager ?projectModuleManager;

        [SetUp]
        public void Setup()
        {
            projectModuleManager = new ProjectModuleManager();
        }

        [Test, Order(1)]
        public void Test_AddProject_ValidInput()
        {
            // Arrange
            string input = "1\n1\nTestProject\n2023-10-17\n2023-10-31\n7"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    projectModuleManager!.ProjectModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Project Add Successfuly"));
            }
        }

        [Test,Order(2)]
        public void Test_AddEmployeeToExistingProject_ValidInput()
        {
            // Arrange
            string input = "3\n1\n1\n1\n7"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    projectModuleManager!.ProjectModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Employee Is not Found"));
            }
        }

        [Test,Order(3)]
        public void Test_ViewProjectDetail_ValidId()
        {
            // Arrange
            string input = "4\n1\n7"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    projectModuleManager!.ProjectModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Project Name: TestProject"));
            }
        }

        [Test, Order(4)]
        public void Test_DeleteEmployeeFromProject_ValidInput()
        {
            // Arrange
            string input = "5\n1\n1\n7"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    projectModuleManager!.ProjectModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Employee Is not Found"));
            }
        }

        // [Test,Order(5)]
        // public void Test_DeleteProject_ValidInput() // Pass
        // {
        //     // Arrange
        //     string input = "6\n1\n7"; // Simulate user input

        //     // Act
        //     using (var sw = new StringWriter())
        //     {
        //         Console.SetOut(sw);
        //         using (var sr = new StringReader(input))
        //         {
        //             Console.SetIn(sr);
        //             projectModuleManager!.ProjectModule();
        //         }
        //         var result = sw.ToString().Trim();

        //         // Assert
        //         Assert.That(result, Does.Contain("Project Delete Successfully"));
        //     }
        // }
    }
}
