using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Tutorial.Management.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IList<Employee> GetAllEmployees();
        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
    }
}
