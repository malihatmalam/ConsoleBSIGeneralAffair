using BSIGeneralAffairBLL;
using BSIGeneralAffairBLL.DTO.Employee;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBSIGeneralAffairCosmetic.Helpers;
using System.Text.Json;

namespace MVCBSIGeneralAffairCosmetic.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBLL _employeeBLL;
        private readonly IDepartementBLL _departmentBLL;
        private readonly IOfficeBLL _officeBLL;
        public EmployeeController(IEmployeeBLL employeeBLL, IDepartementBLL departmentBLL,  IOfficeBLL officeBLL)
        {
            _employeeBLL = employeeBLL;
            _departmentBLL = departmentBLL;
            _officeBLL = officeBLL;
        }

        [HttpGet]// GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager HR", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            if (TempData["message"] != null)
            {
                ViewData["message"] = TempData["message"];
            }
            var employeis = _employeeBLL.GetAll();
            return View(employeis);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]// GET: EmployeeController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager HR", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            var departments = _departmentBLL.GetAll();
            var offices = _officeBLL.GetAll();
            ViewBag.DepartmentOptions = departments;
            ViewBag.OfficeOptions = offices;
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public ActionResult Create(EmployeeCreateDTO employee)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager HR", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var _employee = _employeeBLL.GetByEmployeeID(int.Parse(employee.EmployeeNumber));
                if (_employee.EmployeeID != null)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Karyawan yang anda masukan sudah ada !</div>";
                    var departments = _departmentBLL.GetAll();
                    var offices = _officeBLL.GetAll();
                    ViewBag.DepartmentOptions = departments;
                    ViewBag.OfficeOptions = offices;
                    return View();
                }
                _employeeBLL.Insert(employee);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data karyawan berhasil ditambahkan !</div>";
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                var departments = _departmentBLL.GetAll();
                var offices = _officeBLL.GetAll();
                ViewBag.DepartmentOptions = departments;
                ViewBag.OfficeOptions = offices;
                return View();
            }
        }
    }
}
