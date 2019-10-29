using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore_Tutorial.Models;
using DotNetCore_Tutorial.ViewModels;
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
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel();
            homeDetailsViewModel.Employee = _employeeRepository.GetEmployee(id);
            return View(homeDetailsViewModel);
        }

    }
}