using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using TestSoftDebut5.Models;
using TestSoftDebut5.Data;

namespace TestSoftDebut5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _db;

        public HomeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<EmployeeModel> employeeList = _db.Employee.ToList() ?? new List<EmployeeModel>();

            return View(employeeList);
        }

        [HttpPost]
        public IActionResult SaveEmp(EmployeeModel request)
        {
            if (String.IsNullOrWhiteSpace(request.EmpNum))
                TempData["alert_msg"] = "alert('คุณยังไม่ได้กรอกรหัสพนักงาน')";
            else if (String.IsNullOrWhiteSpace(request.EmpName))
                TempData["alert_msg"] = "alert('คุณยังไม่ได้กรอกชื่อพนักงาน')";
            else if (String.IsNullOrWhiteSpace(request.Position))
                TempData["alert_msg"] = "alert('คุณยังไม่ได้เลือกตำแหน่ง')";
            else
            {
                request.HireDate = DateTime.Now;
                request.Salary = 0;
                request.DepNo = "";
                request.HeadNo = "";

                _db.Employee.Add(request);
                _db.SaveChanges();

                TempData["alert_msg"] = "alert('เพิ่มพนักงานสำเร็จ')";
            }

            return RedirectToAction("Index");
        }

    }
}
