using System;
using System.Web.Mvc;
using DeductionCalculatorV2.Models;
using static DeductionCalculatorV2.Data.EmployeeStorageSingleton;

namespace DeductionCalculatorV2.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employee(Guid employeeId)
        {
            var employee = EmployeeStorage.Get(employeeId).Result;
            return View(employee);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(string firstName, string lastName)
        {
            var employee = new Employee(firstName, lastName);
            EmployeeStorage.Upsert(employee);
            return RedirectToAction("Employee",
                new
                {
                    employeeId = employee.EmployeeId
                });
        }

        public ActionResult AddDependent(Guid employeeId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDependent(AddDependentViewModel model)
        {
            var employee = EmployeeStorage.Get(model.EmployeeId).Result;
            var dependents = employee.Dependents;
            dependents.Add(model.Dependent);

            var newEmployee = new Employee(employee.EmployeeId, employee.FirstName, employee.LastName, dependents);

            EmployeeStorage.Upsert(newEmployee);

            return RedirectToAction("Employee", 
                new
                {
                    employeeId = employee.EmployeeId
                });
        }
    }
}