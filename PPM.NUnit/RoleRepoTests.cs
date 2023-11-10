using NUnit.Framework;
using PPM.Domain;
using PPM.Model;

namespace PPM.Tests
{
    [TestFixture]
    public class RoleRepoTests
    {
        [Test]
        public void AddRole_ShouldAddRoleToList() // Pass
        {
            // Arrange
            RoleRepo roleRepo = new RoleRepo();
            Role role = new Role { RoleId = 1, RoleName = "TestRole" };

            // Act
            roleRepo.AddRole(role);

            // Assert
            Assert.Contains(role, roleRepo.ListAllRoles());
        }

        [Test]
        public void GetRole_ExistingRole_ShouldReturnRole() // Pass
        {
            // Arrange
            RoleRepo roleRepo = new RoleRepo();
            Role role = new Role { RoleId = 1, RoleName = "TestRole" };
            roleRepo.AddRole(role);

            // Act
            Role retrievedRole = roleRepo.GetRole(1);

            // Assert
            Assert.AreEqual(role, retrievedRole);
        }


        [Test]
        public void DeleteRole_ExistingRole_ShouldRemoveRole() // Pass
        {
            // Arrange
            RoleRepo roleRepo = new RoleRepo();
            Role role = new Role { RoleId = 1, RoleName = "TestRole" };
            roleRepo.AddRole(role);

            // Act
            roleRepo.DeleteRole(1);

            // Assert
            Assert.IsEmpty(roleRepo.ListAllRoles());
        }

        [Test]
        public void DeleteRole_NonExistentRole_ShouldNotThrowException() // Pass
        {
            // Arrange
            RoleRepo roleRepo = new RoleRepo();

            // Act and Assert
            Assert.DoesNotThrow(() => roleRepo.DeleteRole(1));
        }
    }
}
