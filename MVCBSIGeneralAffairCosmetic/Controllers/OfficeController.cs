using BSIGeneralAffairBLL.DTO.Brand;
using BSIGeneralAffairBLL.DTO.Office;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBSIGeneralAffairCosmetic.Helpers;
using System.Text.Json;

namespace MVCBSIGeneralAffairCosmetic.Controllers
{
    public class OfficeController : Controller
    {
        private readonly IOfficeBLL _officeBLL;
        public OfficeController(IOfficeBLL officeBLL)
        {
            _officeBLL = officeBLL;
        }


        [HttpGet]// GET: OfficeController
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
            var offices = _officeBLL.GetAll();
            return View(offices);
        }

        // GET: OfficeController/Create
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

        // POST: OfficeController/Create
        [HttpPost]
        public ActionResult Create(OfficeCreateDTO office)
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
                var _office = _officeBLL.GetByName(office.OfficeName);
                if (_office.ToList().Count() > 0)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Office yang anda masukan sudah ada !</div>";
                    return View();
                }
                _officeBLL.Insert(office);
                return RedirectToAction("Index", "Office");
            }
            catch
            {
                return View();
            }
        }

        // GET: OfficeController/Edit/5
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
            var office = _officeBLL.GetByOfficeID(id);
            if (office == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Office tidak ditemukan !</div>";
                return RedirectToAction("Index", "Office");
            }
            var model = new OfficeUpdateDTO
            {
                OfficeID = id,
                OfficeName = office.OfficeName,
                OfficeAddress = office.OfficeAddress
            };
            return View(model);
        }

        // POST: OfficeController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OfficeUpdateDTO office)
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
                _officeBLL.Update(office);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Office berhasil update !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View();
            }
            return RedirectToAction("Index", "Office");
        }

        // GET: OfficeController/Delete/5
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
                var model = _officeBLL.GetByOfficeID(id);
                if (model == null)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Office tidak ditemukan !</div>";
                    return RedirectToAction("Index", "Office");
                }
                _officeBLL.Delete(id);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Office berhasil dihapus !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View();
            }
            return RedirectToAction("Index", "Office");
        }
    }
}
