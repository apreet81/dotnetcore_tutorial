using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Tutorial.Data
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;

        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public IList<Employee> GetAllEmployees()
        {
            return context.Employees.ToList();
        }

        public Employee Update(Employee employeeChanges)
        {
            var existingEmployee = context.Employees.Where(e => e.Id == employeeChanges.Id).FirstOrDefault();
            existingEmployee.Name = employeeChanges.Name;
            existingEmployee.Email = employeeChanges.Email;
            existingEmployee.Department = employeeChanges.Department;
            return employeeChanges;
        }
    }
}
