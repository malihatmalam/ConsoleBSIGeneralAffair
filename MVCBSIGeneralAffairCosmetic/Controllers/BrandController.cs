using BSIGeneralAffairBLL.DTO.Brand;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBSIGeneralAffairCosmetic.Helpers;
using MVCBSIGeneralAffairCosmetic.ViewModels;
using System.Text.Json;

namespace MVCBSIGeneralAffairCosmetic.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandBLL _brandBLL;
        public BrandController(IBrandBLL brandBLL)
        {
            _brandBLL = brandBLL;
        }


        [HttpGet]// GET: BrandController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            if (TempData["message"] != null)
            {
                ViewData["message"] = TempData["message"];
            }
            var brands = _brandBLL.GetAll();
            return View(brands);
        }

        // GET: BrandController/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        public ActionResult Create(BrandCreateDTO brand)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var _brand = _brandBLL.GetByName(brand.BrandName);
                if (_brand.ToList().Count() > 0)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Brand yang anda masukan sudah ada !</div>";
                    return View();
                }
                _brandBLL.Insert(brand);
                return RedirectToAction("Index","Brand");
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            var brand = _brandBLL.GetByBrandID(id);
            if (brand == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Brand tidak ditemukan !</div>";
                return RedirectToAction("Index", "Brand");
            }
            var model = new BrandUpdateDTO {
                BrandId = id,
                BrandName = brand.BrandName,
            };
            return View(model);
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BrandUpdateDTO brand)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                _brandBLL.Update(brand);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Brand berhasil update !</div>";
            }
            catch(Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View();
            }
            return RedirectToAction("Index", "Brand");
        }

        // GET: BrandController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var model = _brandBLL.GetByBrandID(id);
                if (model == null)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Brand tidak ditemukan !</div>";
                    return RedirectToAction("Index", "Brand");
                }
                _brandBLL.Delete(id);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Brand berhasil dihapus !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View();
            }
            return RedirectToAction("Index", "Brand");
        }
    }
}
