using DotNetCore_Tutorial.Management.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Tutorial.Management.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SQLEmployeeRepository> logger;

        public SQLEmployeeRepository(AppDbContext context, ILogger<SQLEmployeeRepository> logger)
        {
            this.context = context;
            this.logger = logger;
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
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

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
            existingEmployee.PhotoPath = employeeChanges.PhotoPath;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
