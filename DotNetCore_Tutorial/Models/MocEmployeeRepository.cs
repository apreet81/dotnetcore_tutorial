using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Tutorial.Models
{
    public class MocEmployeeRepository : IEmployeeRepository
    {
        private IList<Employee> _employees = new List<Employee>();
        public MocEmployeeRepository()
        {
            _employees.Add(new Employee { Id = 1, Name = "Amanpreet", Designation = "Director" });
            _employees.Add(new Employee { Id = 2, Name = "Rahul", Designation = "Engineer" });
            _employees.Add(new Employee { Id = 3, Name = "Shyam", Designation = "Trainee" });
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IList<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}
