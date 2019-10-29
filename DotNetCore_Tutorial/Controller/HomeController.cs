using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore_Tutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_Tutorial
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View(_employeeRepository.GetEmployees());
        }

        public IActionResult Details(int id)
        {
            return View(_employeeRepository.GetEmployee(id));
        }

    }
}