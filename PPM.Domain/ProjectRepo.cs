using PPM.Model;

namespace PPM.Domain
{
    public class ProjectRepo : IProjectRepo
    {
        public static Project project = new();
        public static List<Project> projectList = new();

        public void AddProject(Project project)
        {
            projectList.Add(project);
        }

        public List<Project> ListAllProjectsWithoutEmployeeDetails()
        {
            return projectList;
        }

        public void DeleteProject(int projectId)
        {
            var projectValid = projectList.Find(x => x.ProjectId == projectId);
            projectList.Remove(projectValid!);
        }

        // Adds an employee to a project based on their ID
        public void AddEmployeeToExistingProject(int projectId, int employeeId)
        {
            var projectValid = projectList.FirstOrDefault(p => p.ProjectId == projectId);
            var employeeDetails = EmployeeRepo.employeeList.SingleOrDefault(e => e.EmployeeId == employeeId);
            // Add employee to project
            projectValid!.ProjectEmployees?.Add(employeeDetails!);

        }

        // Removes an employee from a project based on their IDs
        public void DeleteEmployeeFromProject(int projectId, int employeeId)
        {
            var projectIdValid = projectList.FirstOrDefault(p => p.ProjectId == projectId);
            var employeeDetails = EmployeeRepo.employeeList.SingleOrDefault(e => e.EmployeeId == employeeId);
            // Remove the employee from the project
            projectIdValid!.ProjectEmployees?.Remove(employeeDetails!);

        }
        // View project details by entering the project ID.
        public Project ViewProjectDetail(int projectId)
        {
            // Find the project with the given projectId
            var projectIdValid = projectList.FirstOrDefault(p => p.ProjectId == projectId);
            return projectIdValid!;
        }
    }
}