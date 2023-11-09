using System.Text.RegularExpressions;

namespace PPM.Domain
{
    public class ValidationCheck
    {

        public bool IsValidEmail(string email)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            return Regex.IsMatch(email, pattern);
        }
        public bool IsValidRole(int roleId)
        {
            return RoleRepo.roleList.Exists(r => r.RoleId == roleId);
        }
        public bool IsValidMobileNumber(string mobileNumber)
        {
            string pattern = @"^\d{10}$";

            return Regex.IsMatch(mobileNumber, pattern);
        }
        public bool IsEmployeeIdValid(int employeeId)
        {
            return EmployeeRepo.employeeList.Exists(p => p.EmployeeId == employeeId);
        }

        public bool IsProjectIdValid(int projectId)
        {
            return ProjectRepo.projectList.Exists(p => p.ProjectId == projectId);
        }
        public bool IsRoleIdValid(int roleId)
        {
            return RoleRepo.roleList.Exists(p => p.RoleId == roleId);
        }

        public bool IsValidName(string name)
        {
            if (name == "")
            {
                return false;
            }
            return true;
        }
        public bool EmployeeIsAlreadyPresentInProject(int employeeId)
        {
            var employeeDetails = EmployeeRepo.employeeList.SingleOrDefault(e => e.EmployeeId == employeeId);
            var employeePresent = ProjectRepo.projectList.Exists(p => p.ProjectEmployees!.Contains(employeeDetails!));
            return employeePresent;

        }
        public bool RoleIsAlreadyPresentInProject(int roleId)
        {
            var employeeDetails = EmployeeRepo.employeeList.SingleOrDefault(e => e.EmployeeRoleId == roleId);
            var employeePresent = ProjectRepo.projectList.Exists(p => p.ProjectEmployees!.Contains(employeeDetails!));
            return employeePresent;
        }

        // var projectValid = ProjectRepo.projectList.FirstOrDefault(p => p.ProjectId == projectId);

        // // Check if employee is not already added to the project
        // projectValid!.ProjectEmployees ??= new();
        // var employeeAlreadyAdded = projectValid.ProjectEmployees.Contains(employeeId);

        // return employeeAlreadyAdded;


        // public bool IsValidDate(string date)
        // {
        //     return DateOnly.TryParse(date, out _);
        // }


        // public bool ProjectCotainsThatEmployee(int employeeId)
        // {
        //     bool employeePresentInProject = ProjectRepo.project.ProjectEmployees!.Exists(e => e == employeeId);
        //     return employeePresentInProject;
        // }

        // public Employee AddEmployeeToProject(int employeeId)
        // {
        //     var employeeDetails = EmployeeRepo.employeeList.SingleOrDefault(e => e.EmployeeId == employeeId);
        //     return employeeDetails!;
        // }
    }
}