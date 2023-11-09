using PPM.Model;

namespace PPM.Domain
{
    public class RoleRepo : IRoleRepo
    {
        public static List<Role> roleList = new();

        public void AddRole(Role role)
        {
            roleList.Add(role);
        }

        public List<Role> ListAllRoles()
        {
            return roleList;
        }

        public Role GetRole(int roleId)
        {
            var roleValid = roleList.Find(x => x.RoleId == roleId);
            return roleValid!;

        }

        public void DeleteRole(int roleId)
        {
            var roleValid = roleList.Find(x => x.RoleId == roleId);
            roleList.Remove(roleValid!);
        }
    }
}