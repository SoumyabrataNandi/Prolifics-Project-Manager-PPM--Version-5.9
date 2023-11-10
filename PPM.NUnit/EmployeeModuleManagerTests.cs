using NUnit.Framework;
using Moq;
using PPM.Ui.Consoles;

namespace PPM.Ui.Consoles.Tests
{
    [TestFixture]
    public class EmployeeModuleManagerTests
    {
        private EmployeeModuleManager ?employeeModuleManager;

        [SetUp]
        public void Setup()
        {
            employeeModuleManager = new EmployeeModuleManager();
        }

        [Test]
        public void Test_AddEmployee_ValidInput() // Pass
        {
            // Arrange
            string input = "1\n1\nSoumya\nNandi\nsoumya@example.com\n1234567890\n123-Test\n1\n5"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    employeeModuleManager?.EmployeeModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("...Invalid Role Id... Please Enter Valid Role Id..."));
            }
        }

        [Test]
        public void Test_ListAllEmployees_NoData() // Pass
        {
            // Arrange
            string input = "2\n5"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    employeeModuleManager?.EmployeeModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("No Data Found"));
            }
        }

        [Test]
        public void Test_GetEmployee_ValidId() // Pass
        {
            // Arrange
            string input = "3\n1\n5"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    employeeModuleManager?.EmployeeModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Employee Id is Not Present...."));
            }
        }

        [Test]
        public void Test_DeleteEmployee_ValidId() // Pass
        {
            // Arrange
            string input = "4\n1\n5"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    employeeModuleManager?.EmployeeModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Employee Id is Not Present...."));
            }
        }
    }
}
