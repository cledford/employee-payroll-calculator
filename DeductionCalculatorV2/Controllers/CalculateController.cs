using System;
using System.Web.Mvc;
using DeductionCalculatorV2.Models;
using static DeductionCalculatorV2.Core.PaycheckCalculatorSingleton;
using static DeductionCalculatorV2.Data.EmployeeStorageSingleton;

namespace DeductionCalculatorV2.Controllers
{
    public class CalculateController : Controller
    {
        public ActionResult Index(Guid employeeId)
        {
            var employee = EmployeeStorage.Get(employeeId).Result;
            var payrollData = PaycheckCalculator.CalculatePayrollForEmployee(employee);
            return View(new PayrollDataViewModel(employee, payrollData));
        }
    }
}