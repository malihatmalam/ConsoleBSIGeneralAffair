using BSIGeneralAffairBLL.DTO.Brand;
using BSIGeneralAffairBLL.DTO.Departement;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBSIGeneralAffairCosmetic.Helpers;
using System.Text.Json;

namespace MVCBSIGeneralAffairCosmetic.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartementBLL _departmentBLL;
        public DepartmentController(IDepartementBLL depertmentBLL)
        {
            _departmentBLL = depertmentBLL;
        }


        [HttpGet]// GET: DepartmentController
        public ActionResult Index()
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
            var departments = _departmentBLL.GetAll();
            return View(departments);
        }

        // GET: DepartmentController/Create
        [HttpGet]
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
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        public ActionResult Create(DepartementCreateDTO department)
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
                var _department = _departmentBLL.GetByName(department.DepartementName);
                if (_department.ToList().Count() > 0)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Departemen yang anda masukan sudah ada !</div>";
                    return View();
                }
                _departmentBLL.Insert(department);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Departemen berhasil ditambahkan !</div>";
                return RedirectToAction("Index", "Department");
            }
            catch(Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
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
            var department = _departmentBLL.GetByDepartementID(id);
            if (department == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Departement tidak ditemukan !</div>";
                return RedirectToAction("Index", "User");
            }
            var model = new DepartementUpdateDTO
            {
                DepartementName = department.DepartementName,
                DepartementID = id
            };
            return View(model);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DepartementUpdateDTO department)
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
                _departmentBLL.Update(department);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Departemen berhasil update !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View();
            }
            return RedirectToAction("Index", "Department");
        }

        // GET: DepartmentController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
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
                var model = _departmentBLL.GetByDepartementID(id);
                if (model == null)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Department tidak ditemukan !</div>";
                    return RedirectToAction("Index", "User");
                }
                _departmentBLL.Delete(id);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Department berhasil dihapus !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View();
            }
            return RedirectToAction("Index", "Department");
        }
    }
}
