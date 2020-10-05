using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController:Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();

            return View (model);
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel hdvm = new HomeDetailsViewModel();
             hdvm.Employee = _employeeRepository.GetEmployee(id??1);
            hdvm.PageTitle = "Employee Details";
            return View(hdvm);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult Create(Employee employee)
        {
            var e = _employeeRepository.AddEmployee(employee);
            return RedirectToAction("Details", new { id = e.Id });
        }
    }
}
