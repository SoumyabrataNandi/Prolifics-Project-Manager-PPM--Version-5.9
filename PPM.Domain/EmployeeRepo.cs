using PPM.Model;

namespace PPM.Domain
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public static List<Employee> employeeList = new();

        public void AddEmployee(Employee employee)
        {
            employeeList.Add(employee);
        }

        public List<Employee> ListAllEmployees()
        {
            return employeeList;
        }

        public Employee GetEmployee(int employeeId)
        {
            var employeeValid = employeeList.Find(x => x.EmployeeId == employeeId);
            return employeeValid!;
        }

        public void DeleteEmployee(int employeeId)
        {
            var employeeValid = employeeList.Find(x => x.EmployeeId == employeeId);
            employeeList.Remove(employeeValid!);
        }
    }
}