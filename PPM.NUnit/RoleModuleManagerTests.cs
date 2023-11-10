using NUnit.Framework;
using System;
using Moq;
using PPM.Ui.Consoles;
using PPM.Domain;

namespace PPM.Ui.Consoles.Tests
{
    [TestFixture]
    public class RoleModuleManagerTests
    {
        private RoleModuleManager ?roleModuleManager;

        [SetUp]
        public void Setup()
        {
            roleModuleManager = new RoleModuleManager();
        }

        [Test, Order(1)]
        public void Test_AddRole_ValidInput() // Pass
        {
            // Arrange
            string input = "1\n1\nTestRole\n5"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    roleModuleManager?.RoleModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Role Add Successfuly"));
            }
        }

        [Test, Order(2)]
        public void Test_ListAllRoles_NoData() // Pass
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
                    roleModuleManager?.RoleModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Role Id: 1 Role Name: TestRole"));
            }
        }

        [Test,Order(3)]
        public void Test_GetRole_InvalidId() // Pass
        {
            // Arrange
            string input = "3\n999\n5"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    roleModuleManager?.RoleModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Role Id is Not Present"));
            }
        }

        [Test,Order(4)]
        public void Test_DeleteRole_InvalidId() // Pass
        {
            // Arrange
            string input = "4\n999\n5"; // Simulate user input

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    roleModuleManager?.RoleModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Role Id is Not Present"));
            }
        }
        [Test,Order(5)]
        public void Test_DeleteRole_ValidId() // Pass
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
                    roleModuleManager?.RoleModule();
                }
                var result = sw.ToString().Trim();

                // Assert
                Assert.That(result, Does.Contain("Role Delete Successfuly"));
            }
        }
    }
}
